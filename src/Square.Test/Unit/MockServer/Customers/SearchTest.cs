using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Customers;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Customers;

[TestFixture]
public class SearchTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "limit": 2,
              "query": {
                "filter": {
                  "creation_source": {
                    "values": [
                      "THIRD_PARTY"
                    ],
                    "rule": "INCLUDE"
                  },
                  "created_at": {
                    "start_at": "2018-01-01T00:00:00.000Z",
                    "end_at": "2018-02-01T00:00:00.000Z"
                  },
                  "email_address": {
                    "fuzzy": "example.com"
                  },
                  "group_ids": {
                    "all": [
                      "545AXB44B4XXWMVQ4W8SBT3HHF"
                    ]
                  }
                },
                "sort": {
                  "field": "CREATED_AT",
                  "order": "ASC"
                }
              }
            }
            """;

        const string mockResponse = """
            {
              "errors": [
                {
                  "category": "API_ERROR",
                  "code": "INTERNAL_SERVER_ERROR",
                  "detail": "detail",
                  "field": "field"
                }
              ],
              "customers": [
                {
                  "id": "JDKYHBWT1D4F8MFH63DBMEN8Y4",
                  "created_at": "2018-01-23T20:21:54.859Z",
                  "updated_at": "2020-04-20T10:02:43.083Z",
                  "given_name": "James",
                  "family_name": "Bond",
                  "nickname": "nickname",
                  "company_name": "company_name",
                  "email_address": "james.bond@example.com",
                  "address": {
                    "address_line_1": "505 Electric Ave",
                    "address_line_2": "Suite 600",
                    "locality": "New York",
                    "administrative_district_level_1": "NY",
                    "postal_code": "10003",
                    "country": "US"
                  },
                  "phone_number": "+1-212-555-4250",
                  "birthday": "birthday",
                  "reference_id": "YOUR_REFERENCE_ID_2",
                  "note": "note",
                  "preferences": {
                    "email_unsubscribed": false
                  },
                  "creation_source": "DIRECTORY",
                  "group_ids": [
                    "545AXB44B4XXWMVQ4W8SBT3HHF"
                  ],
                  "segment_ids": [
                    "1KB9JE5EGJXCW.REACHABLE"
                  ],
                  "version": 7
                },
                {
                  "id": "A9641GZW2H7Z56YYSD41Q12HDW",
                  "created_at": "2018-01-30T14:10:54.859Z",
                  "updated_at": "2018-03-08T18:25:21.342Z",
                  "given_name": "Amelia",
                  "family_name": "Earhart",
                  "nickname": "nickname",
                  "company_name": "company_name",
                  "email_address": "amelia.earhart@example.com",
                  "address": {
                    "address_line_1": "500 Electric Ave",
                    "address_line_2": "Suite 600",
                    "locality": "New York",
                    "administrative_district_level_1": "NY",
                    "postal_code": "10003",
                    "country": "US"
                  },
                  "phone_number": "+1-212-555-9238",
                  "birthday": "birthday",
                  "reference_id": "YOUR_REFERENCE_ID_1",
                  "note": "a customer",
                  "preferences": {
                    "email_unsubscribed": false
                  },
                  "creation_source": "THIRD_PARTY",
                  "group_ids": [
                    "545AXB44B4XXWMVQ4W8SBT3HHF"
                  ],
                  "segment_ids": [
                    "1KB9JE5EGJXCW.REACHABLE"
                  ],
                  "version": 1
                }
              ],
              "cursor": "9dpS093Uy12AzeE",
              "count": 1000000
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/customers/search")
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

        var response = await Client.Customers.SearchAsync(
            new SearchCustomersRequest
            {
                Limit = 2,
                Query = new CustomerQuery
                {
                    Filter = new CustomerFilter
                    {
                        CreationSource = new CustomerCreationSourceFilter
                        {
                            Values = new List<CustomerCreationSource>()
                            {
                                CustomerCreationSource.ThirdParty,
                            },
                            Rule = CustomerInclusionExclusion.Include,
                        },
                        CreatedAt = new TimeRange
                        {
                            StartAt = "2018-01-01T00:00:00-00:00",
                            EndAt = "2018-02-01T00:00:00-00:00",
                        },
                        EmailAddress = new CustomerTextFilter { Fuzzy = "example.com" },
                        GroupIds = new FilterValue
                        {
                            All = new List<string>() { "545AXB44B4XXWMVQ4W8SBT3HHF" },
                        },
                    },
                    Sort = new CustomerSort
                    {
                        Field = CustomerSortField.CreatedAt,
                        Order = SortOrder.Asc,
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<SearchCustomersResponse>(mockResponse)).UsingDefaults()
        );
    }
}
