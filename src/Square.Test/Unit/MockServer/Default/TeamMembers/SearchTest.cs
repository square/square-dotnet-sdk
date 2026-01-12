using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.TeamMembers;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.TeamMembers;

[TestFixture]
public class SearchTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "query": {
                "filter": {
                  "location_ids": [
                    "0G5P3VGACMMQZ"
                  ],
                  "status": "ACTIVE"
                }
              },
              "limit": 10
            }
            """;

        const string mockResponse = """
            {
              "team_members": [
                {
                  "id": "-3oZQKPKVk6gUXU_V5Qa",
                  "reference_id": "12345678",
                  "is_owner": false,
                  "status": "ACTIVE",
                  "given_name": "Johnny",
                  "family_name": "Cash",
                  "email_address": "johnny_cash@squareup.com",
                  "phone_number": "phone_number",
                  "created_at": "2019-07-10T17:26:48.000Z",
                  "updated_at": "2020-04-28T21:49:28.000Z",
                  "assigned_locations": {
                    "assignment_type": "ALL_CURRENT_AND_FUTURE_LOCATIONS"
                  },
                  "wage_setting": {
                    "team_member_id": "-3oZQKPKVk6gUXU_V5Qa",
                    "job_assignments": [
                      {
                        "job_title": "Manager",
                        "pay_type": "SALARY",
                        "hourly_rate": {
                          "amount": 1443,
                          "currency": "USD"
                        },
                        "annual_rate": {
                          "amount": 3000000,
                          "currency": "USD"
                        },
                        "weekly_hours": 40,
                        "job_id": "FjS8x95cqHiMenw4f1NAUH4P"
                      },
                      {
                        "job_title": "Cashier",
                        "pay_type": "HOURLY",
                        "hourly_rate": {
                          "amount": 2000,
                          "currency": "USD"
                        },
                        "job_id": "VDNpRv8da51NU8qZFC5zDWpF"
                      }
                    ],
                    "is_overtime_exempt": true,
                    "version": 1,
                    "created_at": "2021-06-11T22:55:45.000Z",
                    "updated_at": "2021-06-11T22:55:45.000Z"
                  }
                },
                {
                  "id": "1AVJj0DjkzbmbJw5r4KK",
                  "reference_id": "abcded",
                  "is_owner": false,
                  "status": "ACTIVE",
                  "given_name": "Lombard",
                  "family_name": "Smith",
                  "email_address": "email_address",
                  "phone_number": "+14155552671",
                  "created_at": "2020-03-24T18:14:01.000Z",
                  "updated_at": "2020-06-09T17:38:05.000Z",
                  "assigned_locations": {
                    "assignment_type": "ALL_CURRENT_AND_FUTURE_LOCATIONS"
                  },
                  "wage_setting": {
                    "team_member_id": "1AVJj0DjkzbmbJw5r4KK",
                    "job_assignments": [
                      {
                        "job_title": "Cashier",
                        "pay_type": "HOURLY",
                        "hourly_rate": {
                          "amount": 2400,
                          "currency": "USD"
                        },
                        "job_id": "VDNpRv8da51NU8qZFC5zDWpF"
                      }
                    ],
                    "is_overtime_exempt": true,
                    "version": 2,
                    "created_at": "2020-03-24T18:14:01.000Z",
                    "updated_at": "2020-06-09T17:38:05.000Z"
                  }
                },
                {
                  "id": "2JCmiJol_KKFs9z2Evim",
                  "reference_id": "reference_id",
                  "is_owner": false,
                  "status": "ACTIVE",
                  "given_name": "Monica",
                  "family_name": "Sway",
                  "email_address": "email_address",
                  "phone_number": "phone_number",
                  "created_at": "2020-03-24T01:09:25.000Z",
                  "updated_at": "2020-03-24T01:11:25.000Z",
                  "assigned_locations": {
                    "assignment_type": "ALL_CURRENT_AND_FUTURE_LOCATIONS"
                  },
                  "wage_setting": {
                    "team_member_id": "2JCmiJol_KKFs9z2Evim",
                    "job_assignments": [
                      {
                        "job_title": "Cashier",
                        "pay_type": "HOURLY",
                        "hourly_rate": {
                          "amount": 2400,
                          "currency": "USD"
                        },
                        "job_id": "VDNpRv8da51NU8qZFC5zDWpF"
                      }
                    ],
                    "is_overtime_exempt": true,
                    "version": 1,
                    "created_at": "2020-03-24T01:09:25.000Z",
                    "updated_at": "2020-03-24T01:09:25.000Z"
                  }
                },
                {
                  "id": "4uXcJQSLtbk3F0UQHFNQ",
                  "reference_id": "reference_id",
                  "is_owner": false,
                  "status": "ACTIVE",
                  "given_name": "Elton",
                  "family_name": "Ipsum",
                  "email_address": "email_address",
                  "phone_number": "phone_number",
                  "created_at": "2020-03-24T01:09:23.000Z",
                  "updated_at": "2020-03-24T01:15:23.000Z",
                  "assigned_locations": {
                    "assignment_type": "ALL_CURRENT_AND_FUTURE_LOCATIONS"
                  }
                },
                {
                  "id": "5CoUpyrw1YwGWcRd-eDL",
                  "reference_id": "reference_id",
                  "is_owner": false,
                  "status": "ACTIVE",
                  "given_name": "Steven",
                  "family_name": "Lo",
                  "email_address": "email_address",
                  "phone_number": "phone_number",
                  "created_at": "2020-03-24T01:09:23.000Z",
                  "updated_at": "2020-03-24T01:19:23.000Z",
                  "assigned_locations": {
                    "assignment_type": "ALL_CURRENT_AND_FUTURE_LOCATIONS"
                  }
                },
                {
                  "id": "5MRPTTp8MMBLVSmzrGha",
                  "reference_id": "reference_id",
                  "is_owner": false,
                  "status": "ACTIVE",
                  "given_name": "Patrick",
                  "family_name": "Steward",
                  "email_address": "email_address",
                  "phone_number": "+14155552671",
                  "created_at": "2020-03-24T18:14:03.000Z",
                  "updated_at": "2020-03-24T18:18:03.000Z",
                  "assigned_locations": {
                    "assignment_type": "ALL_CURRENT_AND_FUTURE_LOCATIONS"
                  },
                  "wage_setting": {
                    "team_member_id": "5MRPTTp8MMBLVSmzrGha",
                    "job_assignments": [
                      {
                        "job_title": "Cashier",
                        "pay_type": "HOURLY",
                        "hourly_rate": {
                          "amount": 2000,
                          "currency": "USD"
                        },
                        "job_id": "VDNpRv8da51NU8qZFC5zDWpF"
                      }
                    ],
                    "is_overtime_exempt": true,
                    "version": 1,
                    "created_at": "2020-03-24T18:14:03.000Z",
                    "updated_at": "2020-03-24T18:14:03.000Z"
                  }
                },
                {
                  "id": "7F5ZxsfRnkexhu1PTbfh",
                  "reference_id": "reference_id",
                  "is_owner": false,
                  "status": "ACTIVE",
                  "given_name": "Ivy",
                  "family_name": "Manny",
                  "email_address": "email_address",
                  "phone_number": "phone_number",
                  "created_at": "2020-03-24T01:09:25.000Z",
                  "updated_at": "2020-03-24T01:09:25.000Z",
                  "assigned_locations": {
                    "assignment_type": "ALL_CURRENT_AND_FUTURE_LOCATIONS"
                  }
                },
                {
                  "id": "808X9HR72yKvVaigQXf4",
                  "reference_id": "reference_id",
                  "is_owner": false,
                  "status": "ACTIVE",
                  "given_name": "John",
                  "family_name": "Smith",
                  "email_address": "john_smith@example.com",
                  "phone_number": "+14155552671",
                  "created_at": "2020-03-24T18:14:02.000Z",
                  "updated_at": "2020-03-24T18:14:02.000Z",
                  "assigned_locations": {
                    "assignment_type": "ALL_CURRENT_AND_FUTURE_LOCATIONS"
                  }
                },
                {
                  "id": "9MVDVoY4hazkWKGo_OuZ",
                  "reference_id": "reference_id",
                  "is_owner": false,
                  "status": "ACTIVE",
                  "given_name": "Robert",
                  "family_name": "Wen",
                  "email_address": "r_wen@example.com",
                  "phone_number": "+14155552671",
                  "created_at": "2020-03-24T18:14:00.000Z",
                  "updated_at": "2020-03-24T18:14:00.000Z",
                  "assigned_locations": {
                    "assignment_type": "ALL_CURRENT_AND_FUTURE_LOCATIONS"
                  }
                },
                {
                  "id": "9UglUjOXQ13-hMFypCft",
                  "reference_id": "reference_id",
                  "is_owner": false,
                  "status": "ACTIVE",
                  "given_name": "Ashley",
                  "family_name": "Simpson",
                  "email_address": "asimpson@example.com",
                  "phone_number": "+14155552671",
                  "created_at": "2020-03-24T18:14:00.000Z",
                  "updated_at": "2020-03-24T18:18:00.000Z",
                  "assigned_locations": {
                    "assignment_type": "ALL_CURRENT_AND_FUTURE_LOCATIONS"
                  },
                  "wage_setting": {
                    "team_member_id": "9UglUjOXQ13-hMFypCft",
                    "job_assignments": [
                      {
                        "job_title": "Cashier",
                        "pay_type": "HOURLY",
                        "hourly_rate": {
                          "amount": 2000,
                          "currency": "USD"
                        },
                        "job_id": "VDNpRv8da51NU8qZFC5zDWpF"
                      }
                    ],
                    "is_overtime_exempt": true,
                    "version": 1,
                    "created_at": "2020-03-24T18:14:00.000Z",
                    "updated_at": "2020-03-24T18:14:03.000Z"
                  }
                }
              ],
              "cursor": "N:9UglUjOXQ13-hMFypCft",
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
                    .WithPath("/v2/team-members/search")
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

        var response = await Client.Default.TeamMembers.SearchAsync(
            new SearchTeamMembersRequest
            {
                Query = new SearchTeamMembersQuery
                {
                    Filter = new SearchTeamMembersFilter
                    {
                        LocationIds = new List<string>() { "0G5P3VGACMMQZ" },
                        Status = TeamMemberStatus.Active,
                    },
                },
                Limit = 10,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<SearchTeamMembersResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
