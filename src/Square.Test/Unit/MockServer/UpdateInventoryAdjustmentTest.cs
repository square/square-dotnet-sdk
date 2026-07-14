using NUnit.Framework;
using Square;
using Square.Core;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class UpdateInventoryAdjustmentTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "8fc6a5b0-9fe8-4b46-b46b-2ef95793abbe",
              "adjustment": {}
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
              "adjustment": {
                "id": "UDMOEO78BG6GYWA2XDRYX3KB",
                "reference_id": "4a366069-4096-47a2-99a5-0084ac879509",
                "from_state": "IN_STOCK",
                "to_state": "SOLD",
                "from_location_id": "from_location_id",
                "to_location_id": "to_location_id",
                "catalog_object_id": "W62UWFY35CWMYGVWK6TWJDNI",
                "catalog_object_type": "ITEM_VARIATION",
                "quantity": "7.5",
                "total_price_money": {
                  "amount": 4550,
                  "currency": "USD"
                },
                "occurred_at": "2016-11-16T25:44:22.837Z",
                "created_at": "2016-11-17T13:02:15.142Z",
                "source": {
                  "product": "SQUARE_POS",
                  "application_id": "416ff29c-86c4-4feb-b58c-9705f21f3ea0",
                  "name": "Square Point of Sale 4.37"
                },
                "employee_id": "employee_id",
                "team_member_id": "LRK57NSQ5X7PUD05",
                "transaction_id": "transaction_id",
                "refund_id": "refund_id",
                "purchase_order_id": "purchase_order_id",
                "goods_receipt_id": "goods_receipt_id",
                "adjustment_group": {
                  "id": "id",
                  "root_adjustment_id": "root_adjustment_id",
                  "from_state": "CUSTOM",
                  "to_state": "CUSTOM"
                },
                "cost_money": {
                  "amount": 1000000,
                  "currency": "UNKNOWN_CURRENCY"
                },
                "vendor_id": "vendor_id",
                "physical_count_id": "physical_count_id",
                "reason_id": {
                  "type": "RECEIVED",
                  "custom_reason_id": "custom_reason_id"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/inventory/adjustments/update")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Inventory.UpdateInventoryAdjustmentAsync(
            new UpdateInventoryAdjustmentRequest
            {
                IdempotencyKey = "8fc6a5b0-9fe8-4b46-b46b-2ef95793abbe",
                Adjustment = new InventoryAdjustment(),
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpdateInventoryAdjustmentResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
