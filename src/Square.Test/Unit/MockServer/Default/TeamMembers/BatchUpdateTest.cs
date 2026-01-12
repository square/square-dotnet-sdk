using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.TeamMembers;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.TeamMembers;

[TestFixture]
public class BatchUpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "team_members": {
                "AFMwA08kR-MIF-3Vs0OE": {
                  "team_member": {
                    "reference_id": "reference_id_2",
                    "is_owner": false,
                    "status": "ACTIVE",
                    "given_name": "Jane",
                    "family_name": "Smith",
                    "email_address": "jane_smith@gmail.com",
                    "phone_number": "+14159223334",
                    "assigned_locations": {
                      "assignment_type": "ALL_CURRENT_AND_FUTURE_LOCATIONS"
                    }
                  }
                },
                "fpgteZNMaf0qOK-a4t6P": {
                  "team_member": {
                    "reference_id": "reference_id_1",
                    "is_owner": false,
                    "status": "ACTIVE",
                    "given_name": "Joe",
                    "family_name": "Doe",
                    "email_address": "joe_doe@gmail.com",
                    "phone_number": "+14159283333",
                    "assigned_locations": {
                      "assignment_type": "EXPLICIT_LOCATIONS",
                      "location_ids": [
                        "YSGH2WBKG94QZ",
                        "GA2Y9HSJ8KRYT"
                      ]
                    }
                  }
                }
              }
            }
            """;

        const string mockResponse = """
            {
              "team_members": {
                "AFMwA08kR-MIF-3Vs0OE": {
                  "team_member": {
                    "id": "AFMwA08kR-MIF-3Vs0OE",
                    "reference_id": "reference_id_2",
                    "is_owner": false,
                    "status": "ACTIVE",
                    "given_name": "Jane",
                    "family_name": "Smith",
                    "email_address": "jane_smith@example.com",
                    "phone_number": "+14159223334",
                    "created_at": "2020-03-24T18:14:00.000Z",
                    "updated_at": "2020-03-24T18:18:00.000Z",
                    "assigned_locations": {
                      "assignment_type": "ALL_CURRENT_AND_FUTURE_LOCATIONS"
                    }
                  },
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "fpgteZNMaf0qOK-a4t6P": {
                  "team_member": {
                    "id": "fpgteZNMaf0qOK-a4t6P",
                    "reference_id": "reference_id_1",
                    "is_owner": false,
                    "status": "ACTIVE",
                    "given_name": "Joe",
                    "family_name": "Doe",
                    "email_address": "joe_doe@example.com",
                    "phone_number": "+14159283333",
                    "created_at": "2020-03-24T18:14:00.000Z",
                    "updated_at": "2020-03-24T18:18:00.000Z",
                    "assigned_locations": {
                      "assignment_type": "EXPLICIT_LOCATIONS",
                      "location_ids": [
                        "GA2Y9HSJ8KRYT",
                        "YSGH2WBKG94QZ"
                      ]
                    }
                  },
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                }
              },
              "errors": [
                {
                  "category": "API_ERROR",
                  "code": "INTERNAL_SERVER_ERROR",
                  "detail": "detail",
                  "field": "field"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/team-members/bulk-update")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.TeamMembers.BatchUpdateAsync(
            new BatchUpdateTeamMembersRequest
            {
                TeamMembers = new Dictionary<string, UpdateTeamMemberRequest>()
                {
                    {
                        "AFMwA08kR-MIF-3Vs0OE",
                        new UpdateTeamMemberRequest
                        {
                            TeamMember = new TeamMember
                            {
                                ReferenceId = "reference_id_2",
                                IsOwner = false,
                                Status = TeamMemberStatus.Active,
                                GivenName = "Jane",
                                FamilyName = "Smith",
                                EmailAddress = "jane_smith@gmail.com",
                                PhoneNumber = "+14159223334",
                                AssignedLocations = new TeamMemberAssignedLocations
                                {
                                    AssignmentType =
                                        TeamMemberAssignedLocationsAssignmentType.AllCurrentAndFutureLocations,
                                },
                            },
                        }
                    },
                    {
                        "fpgteZNMaf0qOK-a4t6P",
                        new UpdateTeamMemberRequest
                        {
                            TeamMember = new TeamMember
                            {
                                ReferenceId = "reference_id_1",
                                IsOwner = false,
                                Status = TeamMemberStatus.Active,
                                GivenName = "Joe",
                                FamilyName = "Doe",
                                EmailAddress = "joe_doe@gmail.com",
                                PhoneNumber = "+14159283333",
                                AssignedLocations = new TeamMemberAssignedLocations
                                {
                                    AssignmentType =
                                        TeamMemberAssignedLocationsAssignmentType.ExplicitLocations,
                                    LocationIds = new List<string>()
                                    {
                                        "YSGH2WBKG94QZ",
                                        "GA2Y9HSJ8KRYT",
                                    },
                                },
                            },
                        }
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<BatchUpdateTeamMembersResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
