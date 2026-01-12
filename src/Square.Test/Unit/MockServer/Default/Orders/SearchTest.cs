using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Orders;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Orders;

[TestFixture]
public class SearchTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "location_ids": [
                "057P5VYJ4A5X1",
                "18YC4JDH91E1H"
              ],
              "query": {
                "filter": {
                  "state_filter": {
                    "states": [
                      "COMPLETED"
                    ]
                  },
                  "date_time_filter": {
                    "closed_at": {
                      "start_at": "2018-03-03T20:00:00.000Z",
                      "end_at": "2019-03-04T21:54:45.000Z"
                    }
                  }
                },
                "sort": {
                  "sort_field": "CLOSED_AT",
                  "sort_order": "DESC"
                }
              },
              "limit": 3,
              "return_entries": true
            }
            """;

        const string mockResponse = """
            {
              "order_entries": [
                {
                  "order_id": "CAISEM82RcpmcFBM0TfOyiHV3es",
                  "version": 1,
                  "location_id": "057P5VYJ4A5X1"
                },
                {
                  "order_id": "CAISENgvlJ6jLWAzERDzjyHVybY",
                  "version": 1,
                  "location_id": "18YC4JDH91E1H"
                },
                {
                  "order_id": "CAISEM52YcpmcWAzERDOyiWS3ty",
                  "version": 1,
                  "location_id": "057P5VYJ4A5X1"
                }
              ],
              "orders": [
                {
                  "id": "id",
                  "location_id": "location_id",
                  "reference_id": "reference_id",
                  "customer_id": "customer_id",
                  "line_items": [
                    {
                      "quantity": "quantity"
                    }
                  ],
                  "taxes": [
                    {}
                  ],
                  "discounts": [
                    {}
                  ],
                  "service_charges": [
                    {}
                  ],
                  "fulfillments": [
                    {}
                  ],
                  "returns": [
                    {}
                  ],
                  "tenders": [
                    {
                      "type": "CARD"
                    }
                  ],
                  "refunds": [
                    {
                      "id": "id",
                      "location_id": "location_id",
                      "reason": "reason",
                      "amount_money": {},
                      "status": "PENDING"
                    }
                  ],
                  "created_at": "created_at",
                  "updated_at": "updated_at",
                  "closed_at": "closed_at",
                  "state": "OPEN",
                  "version": 1,
                  "ticket_name": "ticket_name",
                  "rewards": [
                    {
                      "id": "id",
                      "reward_tier_id": "reward_tier_id"
                    }
                  ]
                }
              ],
              "cursor": "123",
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
                    .WithPath("/v2/orders/search")
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

        var response = await Client.Default.Orders.SearchAsync(
            new SearchOrdersRequest
            {
                LocationIds = new List<string>() { "057P5VYJ4A5X1", "18YC4JDH91E1H" },
                Query = new SearchOrdersQuery
                {
                    Filter = new SearchOrdersFilter
                    {
                        StateFilter = new SearchOrdersStateFilter
                        {
                            States = new List<OrderState>() { OrderState.Completed },
                        },
                        DateTimeFilter = new SearchOrdersDateTimeFilter
                        {
                            ClosedAt = new TimeRange
                            {
                                StartAt = "2018-03-03T20:00:00+00:00",
                                EndAt = "2019-03-04T21:54:45+00:00",
                            },
                        },
                    },
                    Sort = new SearchOrdersSort
                    {
                        SortField = SearchOrdersSortField.ClosedAt,
                        SortOrder = SortOrder.Desc,
                    },
                },
                Limit = 3,
                ReturnEntries = true,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<SearchOrdersResponse>(mockResponse)).UsingDefaults()
        );
    }
}
