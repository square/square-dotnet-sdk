using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Test.Unit.MockServer;
using Square.TransferOrders;

namespace Square.Test.Unit.MockServer.TransferOrders;

[TestFixture]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "f47ac10b-58cc-4372-a567-0e02b2c3d479",
              "transfer_order": {
                "source_location_id": "EXAMPLE_SOURCE_LOCATION_ID_789",
                "destination_location_id": "EXAMPLE_DEST_LOCATION_ID_101",
                "expected_at": "2025-11-10T08:00:00.000Z",
                "notes": "Updated: Priority transfer due to low stock at destination",
                "tracking_number": "TRACK987654321",
                "line_items": [
                  {
                    "uid": "1",
                    "quantity_ordered": "7"
                  },
                  {
                    "item_variation_id": "EXAMPLE_NEW_ITEM_VARIATION_ID_003",
                    "quantity_ordered": "2"
                  },
                  {
                    "uid": "2",
                    "remove": true
                  }
                ]
              },
              "version": 1753109537351
            }
            """;

        const string mockResponse = """
            {
              "transfer_order": {
                "id": "EXAMPLE_TRANSFER_ORDER_ID_123",
                "source_location_id": "EXAMPLE_SOURCE_LOCATION_ID_789",
                "destination_location_id": "EXAMPLE_DEST_LOCATION_ID_101",
                "status": "DRAFT",
                "created_at": "2025-01-15T10:30:00.000Z",
                "updated_at": "2025-01-15T11:15:00.000Z",
                "expected_at": "2025-11-10T08:00:00.000Z",
                "completed_at": "completed_at",
                "notes": "Updated: Priority transfer due to low stock at destination",
                "tracking_number": "TRACK987654321",
                "created_by_team_member_id": "EXAMPLE_TEAM_MEMBER_ID_789",
                "line_items": [
                  {
                    "uid": "1",
                    "item_variation_id": "EXAMPLE_ITEM_VARIATION_ID_001",
                    "quantity_ordered": "7",
                    "quantity_pending": "7",
                    "quantity_received": "0",
                    "quantity_damaged": "0",
                    "quantity_canceled": "0"
                  },
                  {
                    "uid": "3",
                    "item_variation_id": "EXAMPLE_NEW_ITEM_VARIATION_ID_003",
                    "quantity_ordered": "2",
                    "quantity_pending": "2",
                    "quantity_received": "0",
                    "quantity_damaged": "0",
                    "quantity_canceled": "0"
                  }
                ],
                "version": 1753122900456
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
                    .WithPath("/v2/transfer-orders/transfer_order_id")
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

        var response = await Client.TransferOrders.UpdateAsync(
            new UpdateTransferOrderRequest
            {
                TransferOrderId = "transfer_order_id",
                IdempotencyKey = "f47ac10b-58cc-4372-a567-0e02b2c3d479",
                TransferOrder = new UpdateTransferOrderData
                {
                    SourceLocationId = "EXAMPLE_SOURCE_LOCATION_ID_789",
                    DestinationLocationId = "EXAMPLE_DEST_LOCATION_ID_101",
                    ExpectedAt = "2025-11-10T08:00:00Z",
                    Notes = "Updated: Priority transfer due to low stock at destination",
                    TrackingNumber = "TRACK987654321",
                    LineItems = new List<UpdateTransferOrderLineData>()
                    {
                        new UpdateTransferOrderLineData { Uid = "1", QuantityOrdered = "7" },
                        new UpdateTransferOrderLineData
                        {
                            ItemVariationId = "EXAMPLE_NEW_ITEM_VARIATION_ID_003",
                            QuantityOrdered = "2",
                        },
                        new UpdateTransferOrderLineData { Uid = "2", Remove = true },
                    },
                },
                Version = 1753109537351,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpdateTransferOrderResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
