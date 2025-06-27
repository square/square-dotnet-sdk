using NUnit.Framework;
using Square.Labor.BreakTypes;
using Square.Labor.Shifts;
using Square.Labor.WorkweekConfigs;
using Square.TeamMembers;

// ReSharper disable NullableWarningSuppressionIsUsed

namespace Square.Test.Integration;

[TestFixture]
public class LaborTests
{
    private readonly SquareClient _client = Helpers.CreateClient();
    private string? _locationId;
    private string? _memberId;
    private string? _breakId;
    private string? _shiftId;

    [SetUp]
    public async Task SetUp()
    {
        // Get first available location
        _locationId = await Helpers.GetDefaultLocationIdAsync(_client);

        // Get first available team member at this location
        var teamResponse = await _client.TeamMembers.SearchAsync(
            new SearchTeamMembersRequest
            {
                Limit = 1,
                Query = new SearchTeamMembersQuery
                {
                    Filter = new SearchTeamMembersFilter
                    {
                        LocationIds = new[] { _locationId! },
                        Status = TeamMemberStatus.Active
                    }
                }
            }
        );
        _memberId = teamResponse.TeamMembers?.FirstOrDefault()?.Id 
            ?? throw new Exception($"No team members available at location {_locationId}");

        // Delete existing breaks to avoid exceeding the limit
        var existingBreaks = await _client.Labor.BreakTypes.ListAsync(new ListBreakTypesRequest());
        await foreach (var breakType in existingBreaks)
        {
            await _client.Labor.BreakTypes.DeleteAsync(
                new DeleteBreakTypesRequest { Id = breakType.Id! }
            );
        }

        // Create break type for testing
        var breakResponse = await _client.Labor.BreakTypes.CreateAsync(
            new CreateBreakTypeRequest
            {
                IdempotencyKey = Guid.NewGuid().ToString(),
                BreakType = new BreakType
                {
                    LocationId = _locationId!,
                    BreakName = "Lunch_" + Guid.NewGuid(),
                    ExpectedDuration = "PT0H30M0S",
                    IsPaid = true,
                },
            }
        );
        _breakId =
            breakResponse.BreakType?.Id ?? throw new Exception("Failed to create break type.");

        // Create shift for testing
        var shiftResponse = await _client.Labor.Shifts.CreateAsync(
            new CreateShiftRequest
            {
                IdempotencyKey = Guid.NewGuid().ToString(),
                Shift = new Shift
                {
                    LocationId = _locationId!,
                    StartAt = DateTimeOffset.Now.ToString("o"),
                    TeamMemberId = _memberId,
                },
            }
        );
        _shiftId = shiftResponse.Shift?.Id ?? throw new Exception("Failed to create shift.");
    }

    [TearDown]
    public async Task TearDown()
    {
        // Clean up resources
        try
        {
            await _client.Labor.Shifts.DeleteAsync(new DeleteShiftsRequest { Id = _shiftId! });
        }
        catch (Exception)
        {
            // Test may have already deleted the shift
        }

        try
        {
            await _client.Labor.BreakTypes.DeleteAsync(
                new DeleteBreakTypesRequest { Id = _breakId! }
            );
        }
        catch (Exception)
        {
            // Test may have already deleted the break
        }
    }

    [Test]
    public async Task TestListBreakTypes()
    {
        var response = await _client.Labor.BreakTypes.ListAsync(new ListBreakTypesRequest());
        var breakTypes = new List<BreakType>();
        await foreach (var breakType in response)
        {
            breakTypes.Add(breakType);
            if (breakTypes.Count >= 10)
                break;
        }
        Assert.That(breakTypes, Is.Not.Empty);
    }

    [Test]
    public async Task TestGetBreakType()
    {
        var response = await _client.Labor.BreakTypes.GetAsync(
            new GetBreakTypesRequest { Id = _breakId! }
        );
        Assert.Multiple(() =>
        {
            Assert.That(response.BreakType, Is.Not.Null);
            Assert.That(response.BreakType?.Id, Is.EqualTo(_breakId));
        });
    }

    [Test]
    public async Task TestUpdateBreakType()
    {
        var updateRequest = new UpdateBreakTypeRequest
        {
            Id = _breakId!,
            BreakType = new BreakType
            {
                LocationId = _locationId!,
                BreakName = "Lunch_" + Guid.NewGuid(),
                ExpectedDuration = "PT1H0M0S",
                IsPaid = true,
            },
        };
        var response = await _client.Labor.BreakTypes.UpdateAsync(updateRequest);
        Assert.Multiple(() =>
        {
            Assert.That(response.BreakType, Is.Not.Null);
            Assert.That(response.BreakType?.Id, Is.EqualTo(_breakId));
            Assert.That(response.BreakType?.ExpectedDuration, Is.EqualTo("PT1H"));
        });
    }

    [Test]
    public async Task TestSearchShifts()
    {
        var searchRequest = new SearchShiftsRequest { Limit = 1 };
        var response = await _client.Labor.Shifts.SearchAsync(searchRequest);
        Assert.That(response.Shifts, Is.Not.Empty);
    }

    [Test]
    public async Task TestGetShift()
    {
        var response = await _client.Labor.Shifts.GetAsync(new GetShiftsRequest { Id = _shiftId! });
        Assert.Multiple(() =>
        {
            Assert.That(response.Shift, Is.Not.Null);
            Assert.That(response.Shift?.Id, Is.EqualTo(_shiftId));
        });
    }

    [Test]
    public async Task TestUpdateShift()
    {
        var updateRequest = new UpdateShiftRequest
        {
            Id = _shiftId!,
            Shift = new Shift
            {
                LocationId = _locationId!,
                StartAt = DateTimeOffset.Now.AddMinutes(-1).ToString("o"),
                TeamMemberId = _memberId,
                Wage = new ShiftWage
                {
                    Title = "Manager",
                    HourlyRate = new Money { Amount = 2500, Currency = Currency.Usd },
                },
            },
        };
        var response = await _client.Labor.Shifts.UpdateAsync(updateRequest);
        Assert.Multiple(() =>
        {
            Assert.That(response.Shift, Is.Not.Null);
            Assert.That(response.Shift?.Wage?.Title, Is.EqualTo("Manager"));
            Assert.That(response.Shift?.Wage?.HourlyRate?.Amount, Is.EqualTo(2500));
            Assert.That(response.Shift?.Wage?.HourlyRate?.Currency, Is.EqualTo("USD"));
        });
    }

    [Test]
    public async Task TestDeleteShift()
    {
        // First search for existing shifts for this team member
        var existingShifts = await _client.Labor.Shifts.SearchAsync(
            new SearchShiftsRequest
            {
                Query = new ShiftQuery
                {
                    Filter = new ShiftFilter
                    {
                        TeamMemberIds = new[] { _memberId! }
                    }
                },
                Limit = 100
            }
        );

        // Delete any existing shifts
        if (existingShifts.Shifts != null)
        {
            foreach (var shift in existingShifts.Shifts)
            {
                if (!string.IsNullOrEmpty(shift.Id))
                {
                    await _client.Labor.Shifts.DeleteAsync(new DeleteShiftsRequest { Id = shift.Id });
                }
            }
        }

        // Start the shift 10 seconds from now and end it 20 seconds from now
        var startTime = DateTimeOffset.Now.AddSeconds(10);
        var endTime = startTime.AddSeconds(10);

        // Create shift
        var shiftResponse = await _client.Labor.Shifts.CreateAsync(
            new CreateShiftRequest
            {
                IdempotencyKey = Guid.NewGuid().ToString(),
                Shift = new Shift
                {
                    LocationId = _locationId!,
                    StartAt = startTime.ToString("o"),
                    EndAt = endTime.ToString("o"),
                    TeamMemberId = _memberId,
                },
            }
        );

        var shiftId = shiftResponse.Shift?.Id ?? throw new Exception("Failed to create shift.");

        // Add a small delay to ensure the shift is fully created
        await Task.Delay(1000);

        var response = await _client.Labor.Shifts.DeleteAsync(
            new DeleteShiftsRequest { Id = shiftId }
        );
        Assert.That(response, Is.Not.Null);
    }

    [Test]
    public async Task TestDeleteBreakType()
    {
        // create break type
        var breakResponse = await _client.Labor.BreakTypes.CreateAsync(
            new CreateBreakTypeRequest
            {
                IdempotencyKey = Guid.NewGuid().ToString(),
                BreakType = new BreakType
                {
                    LocationId = _locationId!,
                    BreakName = "Lunch_" + Guid.NewGuid(),
                    ExpectedDuration = "PT0H30M0S",
                    IsPaid = true,
                },
            }
        );

        _breakId =
            breakResponse.BreakType?.Id ?? throw new Exception("Failed to create break type.");
        var response = await _client.Labor.BreakTypes.DeleteAsync(
            new DeleteBreakTypesRequest { Id = _breakId! }
        );
        Assert.That(response, Is.Not.Null);
    }

    [Test]
    public async Task TestListWorkweekConfigs()
    {
        var response = await _client.Labor.WorkweekConfigs.ListAsync(
            new ListWorkweekConfigsRequest()
        );
        var workweekConfigs = new List<WorkweekConfig>();
        await foreach (var config in response)
        {
            workweekConfigs.Add(config);
            if (workweekConfigs.Count >= 10)
                break;
        }
        Assert.That(workweekConfigs, Is.Not.Empty);
    }
}