using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default;

[TestFixture]
public class CancelTest_ : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "65cc0586-3e82-4d08-b524-3885cffd52",
              "version": 1753117449752
            }
            """;

        const string mockResponse = """
            {
              "transfer_order": {
                "id": "EXAMPLE_TRANSFER_ORDER_ID_123",
                "source_location_id": "EXAMPLE_SOURCE_LOCATION_ID_123",
                "destination_location_id": "EXAMPLE_DEST_LOCATION_ID_456",
                "status": "CANCELED",
                "created_at": "2025-01-15T10:30:00.000Z",
                "updated_at": "2025-01-15T10:45:00.000Z",
                "expected_at": "2025-11-09T05:00:00.000Z",
                "completed_at": "2025-01-15T10:45:00.000Z",
                "notes": "Example transfer order for inventory redistribution between locations",
                "tracking_number": "TRACK123456789",
                "created_by_team_member_id": "EXAMPLE_TEAM_MEMBER_ID_789",
                "line_items": [
                  {
                    "uid": "1",
                    "item_variation_id": "EXAMPLE_ITEM_VARIATION_ID_001",
                    "quantity_ordered": "5",
                    "quantity_pending": "0",
                    "quantity_received": "0",
                    "quantity_damaged": "0",
                    "quantity_canceled": "5"
                  },
                  {
                    "uid": "2",
                    "item_variation_id": "EXAMPLE_ITEM_VARIATION_ID_002",
                    "quantity_ordered": "3",
                    "quantity_pending": "0",
                    "quantity_received": "0",
                    "quantity_damaged": "0",
                    "quantity_canceled": "3"
                  }
                ],
                "version": 1753117461842
              },
              "errors": [
                {
                  "category": "API_ERROR",
                  "code": "INTERNAL_SERVER_ERROR",
                  "detail": "detail",
                  "field": "field"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/transfer-orders/transfer_order_id/cancel")
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

        var response = await Client.Default.TransferOrders.CancelAsync(
            new CancelTransferOrderRequest
            {
                TransferOrderId = "transfer_order_id",
                IdempotencyKey = "65cc0586-3e82-4d08-b524-3885cffd52",
                Version = 1753117449752,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CancelTransferOrderResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
