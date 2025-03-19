using NUnit.Framework;
using Square.Labor.BreakTypes;
using Square.Labor.Shifts;
using Square.Labor.WorkweekConfigs;

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
        _locationId = await Helpers.GetDefaultLocationIdAsync(_client);

        // Delete existing breaks to avoid exceeding the limit
        var existingBreaks = await _client.Labor.BreakTypes.ListAsync(new ListBreakTypesRequest());
        await foreach (var breakType in existingBreaks)
        {
            await _client.Labor.BreakTypes.DeleteAsync(
                new DeleteBreakTypesRequest { Id = breakType.Id! }
            );
        }

        // Create team member for testing
        var teamResponse = await _client.TeamMembers.CreateAsync(
            new CreateTeamMemberRequest
            {
                IdempotencyKey = Guid.NewGuid().ToString(),
                TeamMember = new TeamMember { GivenName = "Sherlock", FamilyName = "Holmes" },
            }
        );
        _memberId =
            teamResponse.TeamMember?.Id ?? throw new Exception("Failed to create team member.");

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
        // create team member
        var teamMemberResponse = await _client.TeamMembers.CreateAsync(
            new CreateTeamMemberRequest
            {
                IdempotencyKey = Guid.NewGuid().ToString(),
                TeamMember = new TeamMember { GivenName = "Sherlock", FamilyName = "Holmes" },
            }
        );

        // create shift
        var shiftResponse = await _client.Labor.Shifts.CreateAsync(
            new CreateShiftRequest
            {
                IdempotencyKey = Guid.NewGuid().ToString(),
                Shift = new Shift
                {
                    LocationId = _locationId!,
                    StartAt = DateTimeOffset.Now.ToString("o"),
                    TeamMemberId =
                        teamMemberResponse.TeamMember?.Id
                        ?? throw new Exception("Failed to create team member."),
                },
            }
        );

        _shiftId = shiftResponse.Shift?.Id ?? throw new Exception("Failed to create shift.");
        var response = await _client.Labor.Shifts.DeleteAsync(
            new DeleteShiftsRequest { Id = _shiftId! }
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
