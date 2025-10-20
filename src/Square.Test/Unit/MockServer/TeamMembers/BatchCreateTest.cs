using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.TeamMembers;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.TeamMembers;

[TestFixture]
public class BatchCreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "team_members": {
                "idempotency-key-1": {
                  "team_member": {
                    "reference_id": "reference_id_1",
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
                },
                "idempotency-key-2": {
                  "team_member": {
                    "reference_id": "reference_id_2",
                    "given_name": "Jane",
                    "family_name": "Smith",
                    "email_address": "jane_smith@gmail.com",
                    "phone_number": "+14159223334",
                    "assigned_locations": {
                      "assignment_type": "ALL_CURRENT_AND_FUTURE_LOCATIONS"
                    }
                  }
                }
              }
            }
            """;

        const string mockResponse = """
            {
              "team_members": {
                "idempotency-key-1": {
                  "team_member": {
                    "id": "ywhG1qfIOoqsHfVRubFV",
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
                },
                "idempotency-key-2": {
                  "team_member": {
                    "id": "IF_Ncrg7fHhCqxVI9T6R",
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
                    .WithPath("/v2/team-members/bulk-create")
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

        var response = await Client.TeamMembers.BatchCreateAsync(
            new BatchCreateTeamMembersRequest
            {
                TeamMembers = new Dictionary<string, CreateTeamMemberRequest>()
                {
                    {
                        "idempotency-key-1",
                        new CreateTeamMemberRequest
                        {
                            TeamMember = new TeamMember
                            {
                                ReferenceId = "reference_id_1",
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
                    {
                        "idempotency-key-2",
                        new CreateTeamMemberRequest
                        {
                            TeamMember = new TeamMember
                            {
                                ReferenceId = "reference_id_2",
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
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<BatchCreateTeamMembersResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
