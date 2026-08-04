using NUnit.Framework;
using Square;
using Square.Core;
using Square.Test.Unit.MockServer;
using Square.TransferOrders;

namespace Square.Test.Unit.MockServer.TransferOrders;

[TestFixture]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "transfer_order": {
                "id": "EXAMPLE_TRANSFER_ORDER_ID_123",
                "source_location_id": "EXAMPLE_SOURCE_LOCATION_ID_123",
                "destination_location_id": "EXAMPLE_DEST_LOCATION_ID_456",
                "status": "STARTED",
                "created_at": "2025-01-15T10:30:00.000Z",
                "updated_at": "2025-01-15T10:35:00.000Z",
                "expected_at": "2025-11-09T05:00:00.000Z",
                "completed_at": "completed_at",
                "notes": "Example transfer order for inventory redistribution between locations",
                "tracking_number": "TRACK123456789",
                "created_by_team_member_id": "EXAMPLE_TEAM_MEMBER_ID_789",
                "line_items": [
                  {
                    "uid": "1",
                    "item_variation_id": "EXAMPLE_ITEM_VARIATION_ID_001",
                    "quantity_ordered": "5",
                    "quantity_pending": "5",
                    "quantity_received": "0",
                    "quantity_damaged": "0",
                    "quantity_canceled": "0"
                  },
                  {
                    "uid": "2",
                    "item_variation_id": "EXAMPLE_ITEM_VARIATION_ID_002",
                    "quantity_ordered": "3",
                    "quantity_pending": "3",
                    "quantity_received": "0",
                    "quantity_damaged": "0",
                    "quantity_canceled": "0"
                  }
                ],
                "version": 1753117449752
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
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.TransferOrders.GetAsync(
            new GetTransferOrdersRequest { TransferOrderId = "transfer_order_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<RetrieveTransferOrderResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
