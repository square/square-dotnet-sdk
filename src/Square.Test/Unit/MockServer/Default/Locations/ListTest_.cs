using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Locations;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Locations;

[TestFixture]
public class ListTest_ : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
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
              "transactions": [
                {
                  "id": "KnL67ZIwXCPtzOrqj0HrkxMF",
                  "location_id": "18YC4JDH91E1H",
                  "created_at": "2016-01-20T22:57:56.000Z",
                  "tenders": [
                    {
                      "id": "MtZRYYdDrYNQbOvV7nbuBvMF",
                      "location_id": "18YC4JDH91E1H",
                      "transaction_id": "KnL67ZIwXCPtzOrqj0HrkxMF",
                      "created_at": "2016-01-20T22:57:56.000Z",
                      "note": "some optional note",
                      "amount_money": {
                        "amount": 5000,
                        "currency": "USD"
                      },
                      "processing_fee_money": {
                        "amount": 138,
                        "currency": "USD"
                      },
                      "type": "CARD",
                      "card_details": {
                        "status": "CAPTURED",
                        "card": {
                          "card_brand": "VISA",
                          "last_4": "1111"
                        },
                        "entry_method": "KEYED"
                      },
                      "additional_recipients": [
                        {
                          "location_id": "057P5VYJ4A5X1",
                          "description": "Application fees",
                          "amount_money": {
                            "amount": 20,
                            "currency": "USD"
                          }
                        }
                      ]
                    }
                  ],
                  "refunds": [
                    {
                      "id": "7a5RcVI0CxbOcJ2wMOkE",
                      "location_id": "18YC4JDH91E1H",
                      "transaction_id": "KnL67ZIwXCPtzOrqj0HrkxMF",
                      "tender_id": "MtZRYYdDrYNQbOvV7nbuBvMF",
                      "created_at": "2016-01-20T22:59:20.000Z",
                      "reason": "some reason why",
                      "amount_money": {
                        "amount": 5000,
                        "currency": "USD"
                      },
                      "status": "APPROVED",
                      "processing_fee_money": {
                        "amount": 138,
                        "currency": "USD"
                      },
                      "additional_recipients": [
                        {
                          "location_id": "057P5VYJ4A5X1",
                          "description": "Application fees",
                          "amount_money": {
                            "amount": 100,
                            "currency": "USD"
                          }
                        }
                      ]
                    }
                  ],
                  "reference_id": "some optional reference id",
                  "product": "EXTERNAL_API",
                  "client_id": "client_id",
                  "order_id": "order_id"
                }
              ],
              "cursor": "cursor"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/locations/location_id/transactions")
                    .WithParam("begin_time", "begin_time")
                    .WithParam("end_time", "end_time")
                    .WithParam("sort_order", "DESC")
                    .WithParam("cursor", "cursor")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Locations.Transactions.ListAsync(
            new ListTransactionsRequest
            {
                LocationId = "location_id",
                BeginTime = "begin_time",
                EndTime = "end_time",
                SortOrder = SortOrder.Desc,
                Cursor = "cursor",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<ListTransactionsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
