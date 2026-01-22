using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Terminal;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Terminal;

[TestFixture]
public class SearchTest_ : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "query": {
                "filter": {
                  "status": "COMPLETED"
                }
              },
              "limit": 1
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
              "refunds": [
                {
                  "id": "009DP5HD-5O5OvgkcNUhl7JBuINflcjKqUzXZY",
                  "refund_id": "5O5OvgkcNUhl7JBuINflcjKqUzXZY_43Q4iGp7sNeATiWrUruA1EYeMRUXaddXXlDDJ1EQLvb",
                  "payment_id": "5O5OvgkcNUhl7JBuINflcjKqUzXZY",
                  "order_id": "kcuKDKreRaI4gF4TjmEgZjHk8Z7YY",
                  "amount_money": {
                    "amount": 111,
                    "currency": "CAD"
                  },
                  "reason": "Returning item",
                  "device_id": "f72dfb8e-4d65-4e56-aade-ec3fb8d33291",
                  "deadline_duration": "PT5M",
                  "status": "COMPLETED",
                  "cancel_reason": "BUYER_CANCELED",
                  "created_at": "2020-09-29T15:21:46.771Z",
                  "updated_at": "2020-09-29T15:21:48.675Z",
                  "app_id": "sandbox-sq0idb-c2OuYt13YaCAeJq_2cd8OQ",
                  "location_id": "76C9W6K8CNNQ5"
                }
              ],
              "cursor": "cursor"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/terminals/refunds/search")
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

        var response = await Client.Default.Terminal.Refunds.SearchAsync(
            new SearchTerminalRefundsRequest
            {
                Query = new TerminalRefundQuery
                {
                    Filter = new TerminalRefundQueryFilter { Status = "COMPLETED" },
                },
                Limit = 1,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<SearchTerminalRefundsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
