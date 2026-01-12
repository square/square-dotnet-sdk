using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.TransferOrders;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.TransferOrders;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "65cc0586-3e82-384s-b524-3885cffd52",
              "transfer_order": {
                "source_location_id": "EXAMPLE_SOURCE_LOCATION_ID_123",
                "destination_location_id": "EXAMPLE_DEST_LOCATION_ID_456",
                "expected_at": "2025-11-09T05:00:00.000Z",
                "notes": "Example transfer order for inventory redistribution between locations",
                "tracking_number": "TRACK123456789",
                "created_by_team_member_id": "EXAMPLE_TEAM_MEMBER_ID_789",
                "line_items": [
                  {
                    "item_variation_id": "EXAMPLE_ITEM_VARIATION_ID_001",
                    "quantity_ordered": "5"
                  },
                  {
                    "item_variation_id": "EXAMPLE_ITEM_VARIATION_ID_002",
                    "quantity_ordered": "3"
                  }
                ]
              }
            }
            """;

        const string mockResponse = """
            {
              "transfer_order": {
                "id": "EXAMPLE_TRANSFER_ORDER_ID_123",
                "source_location_id": "EXAMPLE_SOURCE_LOCATION_ID_123",
                "destination_location_id": "EXAMPLE_DEST_LOCATION_ID_456",
                "status": "DRAFT",
                "created_at": "2025-01-15T10:30:00.000Z",
                "updated_at": "2025-01-15T10:30:00.000Z",
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
                "version": 1753109537351
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
                    .WithPath("/v2/transfer-orders")
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

        var response = await Client.Default.TransferOrders.CreateAsync(
            new CreateTransferOrderRequest
            {
                IdempotencyKey = "65cc0586-3e82-384s-b524-3885cffd52",
                TransferOrder = new CreateTransferOrderData
                {
                    SourceLocationId = "EXAMPLE_SOURCE_LOCATION_ID_123",
                    DestinationLocationId = "EXAMPLE_DEST_LOCATION_ID_456",
                    ExpectedAt = "2025-11-09T05:00:00Z",
                    Notes = "Example transfer order for inventory redistribution between locations",
                    TrackingNumber = "TRACK123456789",
                    CreatedByTeamMemberId = "EXAMPLE_TEAM_MEMBER_ID_789",
                    LineItems = new List<CreateTransferOrderLineData>()
                    {
                        new CreateTransferOrderLineData
                        {
                            ItemVariationId = "EXAMPLE_ITEM_VARIATION_ID_001",
                            QuantityOrdered = "5",
                        },
                        new CreateTransferOrderLineData
                        {
                            ItemVariationId = "EXAMPLE_ITEM_VARIATION_ID_002",
                            QuantityOrdered = "3",
                        },
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreateTransferOrderResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
