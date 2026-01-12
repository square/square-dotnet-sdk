using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Locations.Transactions;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Locations.Transactions;

[TestFixture]
public class GetTest : BaseMockServerTest
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
              "transaction": {
                "id": "KnL67ZIwXCPtzOrqj0HrkxMF",
                "location_id": "18YC4JDH91E1H",
                "created_at": "2016-03-10T22:57:56.000Z",
                "tenders": [
                  {
                    "id": "MtZRYYdDrYNQbOvV7nbuBvMF",
                    "location_id": "18YC4JDH91E1H",
                    "transaction_id": "KnL67ZIwXCPtzOrqj0HrkxMF",
                    "created_at": "2016-03-10T22:57:56.000Z",
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
                    "id": "id",
                    "location_id": "location_id",
                    "reason": "reason",
                    "amount_money": {},
                    "status": "PENDING"
                  }
                ],
                "reference_id": "some optional reference id",
                "product": "EXTERNAL_API",
                "client_id": "client_id",
                "shipping_address": {
                  "address_line_1": "address_line_1",
                  "address_line_2": "address_line_2",
                  "address_line_3": "address_line_3",
                  "locality": "locality",
                  "sublocality": "sublocality",
                  "sublocality_2": "sublocality_2",
                  "sublocality_3": "sublocality_3",
                  "administrative_district_level_1": "administrative_district_level_1",
                  "administrative_district_level_2": "administrative_district_level_2",
                  "administrative_district_level_3": "administrative_district_level_3",
                  "postal_code": "postal_code",
                  "country": "ZZ",
                  "first_name": "first_name",
                  "last_name": "last_name"
                },
                "order_id": "order_id"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/locations/location_id/transactions/transaction_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Locations.Transactions.GetAsync(
            new GetTransactionsRequest
            {
                LocationId = "location_id",
                TransactionId = "transaction_id",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetTransactionResponse>(mockResponse)).UsingDefaults()
        );
    }
}
