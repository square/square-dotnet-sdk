using NUnit.Framework;
using Square;
using Square.Core;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class ListInventoryAdjustmentReasonsTest : BaseMockServerTest
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
              "adjustment_reasons": [
                {
                  "id": {
                    "type": "RECEIVED"
                  },
                  "name": "name",
                  "direction": "INCREASE",
                  "created_at": "created_at",
                  "updated_at": "updated_at",
                  "is_deleted": true
                },
                {
                  "id": {
                    "type": "DAMAGED"
                  },
                  "name": "name",
                  "direction": "DECREASE",
                  "created_at": "created_at",
                  "updated_at": "updated_at",
                  "is_deleted": true
                },
                {
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
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/inventory/adjustment-reasons")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Inventory.ListInventoryAdjustmentReasonsAsync(
            new ListInventoryAdjustmentReasonsRequest
            {
                IncludeDeleted = true,
                IncludeSystemCodes = true,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<ListInventoryAdjustmentReasonsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
