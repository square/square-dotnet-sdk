using NUnit.Framework;
using Square;
using Square.Core;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class CreateInventoryAdjustmentReasonTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "27b2f2b1-1c2a-4b9e-8f3a-0d9c3a1e5b47",
              "adjustment_reason": {
                "id": {
                  "type": "CUSTOM"
                },
                "name": "Donated to charity",
                "direction": "DECREASE"
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
                    .WithPath("/v2/inventory/adjustment-reasons/create")
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

        var response = await Client.Inventory.CreateInventoryAdjustmentReasonAsync(
            new CreateInventoryAdjustmentReasonRequest
            {
                IdempotencyKey = "27b2f2b1-1c2a-4b9e-8f3a-0d9c3a1e5b47",
                AdjustmentReason = new InventoryAdjustmentReason
                {
                    Id = new InventoryAdjustmentReasonId
                    {
                        Type = InventoryAdjustmentReasonIdType.Custom,
                    },
                    Name = "Donated to charity",
                    Direction = InventoryAdjustmentReasonDirection.Decrease,
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreateInventoryAdjustmentReasonResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
