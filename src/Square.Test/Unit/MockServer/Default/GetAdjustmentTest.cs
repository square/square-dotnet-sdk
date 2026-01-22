using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default;

[TestFixture]
public class GetAdjustmentTest : BaseMockServerTest
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
              "adjustment": {
                "id": "UDMOEO78BG6GYWA2XDRYX3KB",
                "reference_id": "4a366069-4096-47a2-99a5-0084ac879509",
                "from_state": "IN_STOCK",
                "to_state": "SOLD",
                "location_id": "C6W5YS5QM06F5",
                "catalog_object_id": "W62UWFY35CWMYGVWK6TWJDNI",
                "catalog_object_type": "ITEM_VARIATION",
                "quantity": "7",
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
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/inventory/adjustments/adjustment_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Inventory.GetAdjustmentAsync(
            new GetAdjustmentInventoryRequest { AdjustmentId = "adjustment_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetInventoryAdjustmentResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
