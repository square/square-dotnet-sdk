using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Terminal.Checkouts;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Terminal.Checkouts;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "28a0c3bc-7839-11ea-bc55-0242ac130003",
              "checkout": {
                "amount_money": {
                  "amount": 2610,
                  "currency": "USD"
                },
                "reference_id": "id11572",
                "note": "A brief note",
                "device_options": {
                  "device_id": "dbb5d83a-7838-11ea-bc55-0242ac130003"
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
              "checkout": {
                "id": "08YceKh7B3ZqO",
                "amount_money": {
                  "amount": 2610,
                  "currency": "USD"
                },
                "reference_id": "id11572",
                "note": "A brief note",
                "order_id": "order_id",
                "payment_options": {
                  "autocomplete": true,
                  "delay_duration": "delay_duration",
                  "accept_partial_authorization": true,
                  "delay_action": "CANCEL"
                },
                "device_options": {
                  "device_id": "dbb5d83a-7838-11ea-bc55-0242ac130003",
                  "skip_receipt_screen": false,
                  "collect_signature": true,
                  "tip_settings": {
                    "allow_tipping": false
                  },
                  "show_itemized_cart": true
                },
                "deadline_duration": "PT5M",
                "status": "PENDING",
                "cancel_reason": "BUYER_CANCELED",
                "payment_ids": [
                  "payment_ids"
                ],
                "created_at": "2020-04-06T16:39:32.545Z",
                "updated_at": "2020-04-06T16:39:32.545Z",
                "app_id": "APP_ID",
                "location_id": "LOCATION_ID",
                "payment_type": "CARD_PRESENT",
                "team_member_id": "team_member_id",
                "customer_id": "customer_id",
                "app_fee_money": {
                  "amount": 1000000,
                  "currency": "UNKNOWN_CURRENCY"
                },
                "statement_description_identifier": "statement_description_identifier",
                "tip_money": {
                  "amount": 1000000,
                  "currency": "UNKNOWN_CURRENCY"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/terminals/checkouts")
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

        var response = await Client.Default.Terminal.Checkouts.CreateAsync(
            new CreateTerminalCheckoutRequest
            {
                IdempotencyKey = "28a0c3bc-7839-11ea-bc55-0242ac130003",
                Checkout = new TerminalCheckout
                {
                    AmountMoney = new Money { Amount = 2610, Currency = Currency.Usd },
                    ReferenceId = "id11572",
                    Note = "A brief note",
                    DeviceOptions = new DeviceCheckoutOptions
                    {
                        DeviceId = "dbb5d83a-7838-11ea-bc55-0242ac130003",
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreateTerminalCheckoutResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
