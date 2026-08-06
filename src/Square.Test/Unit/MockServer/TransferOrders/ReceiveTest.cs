using NUnit.Framework;
using Square;
using Square.Core;
using Square.Test.Unit.MockServer;
using Square.TransferOrders;

namespace Square.Test.Unit.MockServer.TransferOrders;

[TestFixture]
public class ReceiveTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "EXAMPLE_IDEMPOTENCY_KEY_101",
              "receipt": {
                "line_items": [
                  {
                    "transfer_order_line_uid": "1",
                    "quantity_received": "3",
                    "quantity_damaged": "1",
                    "quantity_canceled": "1"
                  },
                  {
                    "transfer_order_line_uid": "2",
                    "quantity_received": "2",
                    "quantity_canceled": "1"
                  }
                ]
              },
              "version": 1753118664873
            }
            """;

        const string mockResponse = """
            {
              "transfer_order": {
                "id": "EXAMPLE_TRANSFER_ORDER_ID_123",
                "source_location_id": "EXAMPLE_SOURCE_LOCATION_ID_123",
                "destination_location_id": "EXAMPLE_DEST_LOCATION_ID_456",
                "status": "COMPLETED",
                "created_at": "2025-01-15T10:30:00.000Z",
                "updated_at": "2025-01-15T10:55:00.000Z",
                "expected_at": "2025-11-09T05:00:00.000Z",
                "completed_at": "2025-01-15T10:55:00.000Z",
                "notes": "Example transfer order for inventory redistribution between locations",
                "tracking_number": "TRACK123456789",
                "created_by_team_member_id": "EXAMPLE_TEAM_MEMBER_ID_789",
                "line_items": [
                  {
                    "uid": "1",
                    "item_variation_id": "EXAMPLE_ITEM_VARIATION_ID_001",
                    "quantity_ordered": "5",
                    "quantity_pending": "0",
                    "quantity_received": "3",
                    "quantity_damaged": "1",
                    "quantity_canceled": "1"
                  },
                  {
                    "uid": "2",
                    "item_variation_id": "EXAMPLE_ITEM_VARIATION_ID_002",
                    "quantity_ordered": "3",
                    "quantity_pending": "0",
                    "quantity_received": "2",
                    "quantity_damaged": "0",
                    "quantity_canceled": "1"
                  }
                ],
                "version": 1753118667248
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
                    .WithPath("/v2/transfer-orders/transfer_order_id/receive")
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

        var response = await Client.TransferOrders.ReceiveAsync(
            new ReceiveTransferOrderRequest
            {
                TransferOrderId = "transfer_order_id",
                IdempotencyKey = "EXAMPLE_IDEMPOTENCY_KEY_101",
                Receipt = new TransferOrderGoodsReceipt
                {
                    LineItems = new List<TransferOrderGoodsReceiptLineItem>()
                    {
                        new TransferOrderGoodsReceiptLineItem
                        {
                            TransferOrderLineUid = "1",
                            QuantityReceived = "3",
                            QuantityDamaged = "1",
                            QuantityCanceled = "1",
                        },
                        new TransferOrderGoodsReceiptLineItem
                        {
                            TransferOrderLineUid = "2",
                            QuantityReceived = "2",
                            QuantityCanceled = "1",
                        },
                    },
                },
                Version = 1753118664873,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<ReceiveTransferOrderResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
