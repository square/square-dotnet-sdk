using NUnit.Framework;
using Square.TeamMembers;
using Square.TeamMembers.WageSetting;

namespace Square.Test.Integration;

[TestFixture]
public class TeamsTests
{
    private SquareClient _client;
    private string _memberId;
    private List<string> _bulkMemberIds;

    [SetUp]
    public async Task SetUp()
    {
        _client = Helpers.CreateClient();
        _bulkMemberIds = [];

        // Create team member for testing
        var createRequest = new CreateTeamMemberRequest
        {
            IdempotencyKey = Guid.NewGuid().ToString(),
            TeamMember = new TeamMember { GivenName = "Sherlock", FamilyName = "Holmes" },
        };
        var memberResponse = await _client.TeamMembers.CreateAsync(createRequest);
        var member = memberResponse.TeamMember ?? throw new Exception("Member is null");
        _memberId = member.Id ?? throw new Exception("Member ID is null");

        // Create bulk team members for testing
        var bulkRequest = new BatchCreateTeamMembersRequest
        {
            TeamMembers = new Dictionary<string, CreateTeamMemberRequest>
            {
                {
                    "id1",
                    new CreateTeamMemberRequest
                    {
                        TeamMember = new TeamMember
                        {
                            GivenName = "Donatello",
                            FamilyName = "Splinter",
                        },
                    }
                },
                {
                    "id2",
                    new CreateTeamMemberRequest
                    {
                        TeamMember = new TeamMember
                        {
                            GivenName = "Leonardo",
                            FamilyName = "Splinter",
                        },
                    }
                },
            },
        };
        var bulkResponse = await _client.TeamMembers.BatchCreateAsync(bulkRequest);
        foreach (var result in bulkResponse.TeamMembers ?? [])
        {
            var teamMember = result.Value.TeamMember ?? throw new Exception("Team member is null");
            _bulkMemberIds.Add(teamMember.Id ?? throw new Exception("Team member ID is null"));
        }
    }

    [Test]
    public async Task TestSearchTeamMembers()
    {
        var searchRequest = new SearchTeamMembersRequest { Limit = 1 };
        var response = await _client.TeamMembers.SearchAsync(searchRequest);

        Assert.Multiple(() =>
        {
            Assert.That(response.TeamMembers, Is.Not.Null);
            Assert.That(response.TeamMembers, Is.Not.Empty);
        });
    }

    [Test]
    public async Task TestCreateTeamMember()
    {
        var createRequest = new CreateTeamMemberRequest
        {
            IdempotencyKey = Guid.NewGuid().ToString(),
            TeamMember = new TeamMember { GivenName = "John", FamilyName = "Watson" },
        };
        var response = await _client.TeamMembers.CreateAsync(createRequest);

        Assert.Multiple(() =>
        {
            Assert.That(response.TeamMember, Is.Not.Null);
            Assert.That(response.TeamMember?.GivenName, Is.EqualTo("John"));
            Assert.That(response.TeamMember?.FamilyName, Is.EqualTo("Watson"));
        });
    }

    [Test]
    public async Task TestRetrieveTeamMember()
    {
        var response = await _client.TeamMembers.GetAsync(
            new GetTeamMembersRequest { TeamMemberId = _memberId }
        );

        Assert.Multiple(() =>
        {
            Assert.That(response.TeamMember, Is.Not.Null);
            Assert.That(response.TeamMember?.Id, Is.EqualTo(_memberId));
        });
    }

    [Test]
    public async Task TestUpdateTeamMember()
    {
        var updateRequest = new UpdateTeamMemberRequest
        {
            TeamMember = new TeamMember { GivenName = "Agent", FamilyName = "Smith" },
        };
        await _client.TeamMembers.UpdateAsync(
            new UpdateTeamMembersRequest { TeamMemberId = _memberId, Body = updateRequest }
        );
        var getResponse = await _client.TeamMembers.GetAsync(
            new GetTeamMembersRequest { TeamMemberId = _memberId }
        );

        var teamMember = getResponse.TeamMember ?? throw new Exception("Team member is null");
        Assert.Multiple(() =>
        {
            Assert.That(teamMember.GivenName, Is.EqualTo("Agent"));
            Assert.That(teamMember.FamilyName, Is.EqualTo("Smith"));
        });
    }

    [Test]
    public async Task TestUpdateWageSetting()
    {
        var updateRequest = new UpdateWageSettingRequest
        {
            TeamMemberId = _memberId,
            WageSetting = new WageSetting
            {
                JobAssignments =
                [
                    new JobAssignment
                    {
                        PayType = JobAssignmentPayType.Hourly,
                        HourlyRate = Helpers.NewTestMoney(2500),
                        JobTitle = "Math tutor",
                    },
                ],
            },
        };
        var response = await _client.TeamMembers.WageSetting.UpdateAsync(updateRequest);

        var wageSetting = response.WageSetting ?? throw new Exception("Wage setting is null");
        var jobAssignments =
            wageSetting.JobAssignments?.ToArray()
            ?? throw new Exception("Job assignments are null");
        Assert.Multiple(() =>
        {
            Assert.That(jobAssignments, Is.Not.Empty);
            Assert.That(jobAssignments.First().JobTitle, Is.EqualTo("Math tutor"));
            var hourlyRate =
                jobAssignments.First().HourlyRate ?? throw new Exception("Hourly rate is null");
            Assert.That(hourlyRate.Amount, Is.EqualTo(2500));
        });
    }

    [Test]
    public async Task TestBatchUpdateTeamMembers()
    {
        var updateRequest = new BatchUpdateTeamMembersRequest
        {
            TeamMembers = new Dictionary<string, UpdateTeamMemberRequest>
            {
                {
                    _bulkMemberIds[0],
                    new UpdateTeamMemberRequest
                    {
                        TeamMember = new TeamMember
                        {
                            GivenName = "Raphael",
                            FamilyName = "Splinter",
                        },
                    }
                },
                {
                    _bulkMemberIds[1],
                    new UpdateTeamMemberRequest
                    {
                        TeamMember = new TeamMember
                        {
                            GivenName = "Leonardo",
                            FamilyName = "Splinter",
                        },
                    }
                },
            },
        };
        var response = await _client.TeamMembers.BatchUpdateAsync(updateRequest);

        var teamMembers = response.TeamMembers ?? throw new Exception("Team members are null");
        Assert.That(teamMembers, Has.Count.EqualTo(2));
    }
}
