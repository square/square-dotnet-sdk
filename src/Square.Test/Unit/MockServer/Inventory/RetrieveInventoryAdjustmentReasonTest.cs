using NUnit.Framework;
using Square;
using Square.Core;
using Square.Inventory;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Inventory;

[TestFixture]
public class RetrieveInventoryAdjustmentReasonTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "reason_id": {
                "type": "CUSTOM",
                "custom_reason_id": "R5BX3PDCZ6EXAMPLE"
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
                "name": "Donated to charity",
                "direction": "DECREASE",
                "created_at": "2026-07-15T18:24:31.000Z",
                "updated_at": "2026-07-15T18:24:31.000Z",
                "is_deleted": false
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/inventory/adjustment-reasons/retrieve")
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

        var response = await Client.Inventory.RetrieveInventoryAdjustmentReasonAsync(
            new RetrieveInventoryAdjustmentReasonRequest
            {
                ReasonId = new InventoryAdjustmentReasonId
                {
                    Type = InventoryAdjustmentReasonIdType.Custom,
                    CustomReasonId = "R5BX3PDCZ6EXAMPLE",
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<RetrieveInventoryAdjustmentReasonResponse>(mockResponse)
                )
                .UsingDefaults()
        );
    }
}
