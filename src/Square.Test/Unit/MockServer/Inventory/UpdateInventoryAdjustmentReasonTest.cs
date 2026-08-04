using NUnit.Framework;
using Square;
using Square.Core;
using Square.Inventory;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Inventory;

[TestFixture]
public class UpdateInventoryAdjustmentReasonTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "reason_id": {
                "type": "CUSTOM",
                "custom_reason_id": "R5BX3PDCZ6EXAMPLE"
              },
              "adjustment_reason": {
                "id": {
                  "type": "CUSTOM",
                  "custom_reason_id": "R5BX3PDCZ6EXAMPLE"
                },
                "name": "Charitable donation"
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
              "adjustment_reason": {
                "id": {
                  "type": "CUSTOM",
                  "custom_reason_id": "R5BX3PDCZ6EXAMPLE"
                },
                "name": "Charitable donation",
                "direction": "DECREASE",
                "created_at": "2026-07-15T18:24:31.000Z",
                "updated_at": "2026-07-15T19:02:07.000Z",
                "is_deleted": false
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/inventory/adjustment-reasons/update")
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

        var response = await Client.Inventory.UpdateInventoryAdjustmentReasonAsync(
            new UpdateInventoryAdjustmentReasonRequest
            {
                ReasonId = new InventoryAdjustmentReasonId
                {
                    Type = InventoryAdjustmentReasonIdType.Custom,
                    CustomReasonId = "R5BX3PDCZ6EXAMPLE",
                },
                AdjustmentReason = new InventoryAdjustmentReason
                {
                    Id = new InventoryAdjustmentReasonId
                    {
                        Type = InventoryAdjustmentReasonIdType.Custom,
                        CustomReasonId = "R5BX3PDCZ6EXAMPLE",
                    },
                    Name = "Charitable donation",
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpdateInventoryAdjustmentReasonResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
