using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Terminal.Refunds;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Terminal.Refunds;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "402a640b-b26f-401f-b406-46f839590c04",
              "refund": {
                "payment_id": "5O5OvgkcNUhl7JBuINflcjKqUzXZY",
                "amount_money": {
                  "amount": 111,
                  "currency": "CAD"
                },
                "reason": "Returning items",
                "device_id": "f72dfb8e-4d65-4e56-aade-ec3fb8d33291"
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
              "refund": {
                "id": "009DP5HD-5O5OvgkcNUhl7JBuINflcjKqUzXZY",
                "refund_id": "refund_id",
                "payment_id": "5O5OvgkcNUhl7JBuINflcjKqUzXZY",
                "order_id": "kcuKDKreRaI4gF4TjmEgZjHk8Z7YY",
                "amount_money": {
                  "amount": 111,
                  "currency": "CAD"
                },
                "reason": "Returning items",
                "device_id": "f72dfb8e-4d65-4e56-aade-ec3fb8d33291",
                "deadline_duration": "PT5M",
                "status": "PENDING",
                "cancel_reason": "BUYER_CANCELED",
                "created_at": "2020-09-29T15:21:46.771Z",
                "updated_at": "2020-09-29T15:21:46.771Z",
                "app_id": "sandbox-sq0idb-c2OuYt13YaCAeJq_2cd8OQ",
                "location_id": "76C9W6K8CNNQ5"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/terminals/refunds")
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

        var response = await Client.Default.Terminal.Refunds.CreateAsync(
            new CreateTerminalRefundRequest
            {
                IdempotencyKey = "402a640b-b26f-401f-b406-46f839590c04",
                Refund = new TerminalRefund
                {
                    PaymentId = "5O5OvgkcNUhl7JBuINflcjKqUzXZY",
                    AmountMoney = new Money { Amount = 111, Currency = Currency.Cad },
                    Reason = "Returning items",
                    DeviceId = "f72dfb8e-4d65-4e56-aade-ec3fb8d33291",
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreateTerminalRefundResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
