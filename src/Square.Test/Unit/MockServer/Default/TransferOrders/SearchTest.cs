using NUnit.Framework;
using Square.Default;
using Square.Default.TransferOrders;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.TransferOrders;

[TestFixture]
public class SearchTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "query": {
                "filter": {
                  "source_location_ids": [
                    "EXAMPLE_SOURCE_LOCATION_ID_123"
                  ],
                  "destination_location_ids": [
                    "EXAMPLE_DEST_LOCATION_ID_456"
                  ],
                  "statuses": [
                    "STARTED",
                    "PARTIALLY_RECEIVED"
                  ]
                },
                "sort": {
                  "field": "UPDATED_AT",
                  "order": "DESC"
                }
              },
              "cursor": "eyJsYXN0X3VwZGF0ZWRfYXQiOjE3NTMxMTg2NjQ4NzN9",
              "limit": 10
            }
            """;

        const string mockResponse = """
            {
              "transfer_orders": [
                {
                  "id": "EXAMPLE_TRANSFER_ORDER_ID_123",
                  "source_location_id": "EXAMPLE_SOURCE_LOCATION_ID_123",
                  "destination_location_id": "EXAMPLE_DEST_LOCATION_ID_456",
                  "status": "STARTED",
                  "created_at": "2025-01-15T10:30:00.000Z",
                  "updated_at": "2025-01-15T10:32:00.000Z",
                  "expected_at": "2025-11-09T05:00:00.000Z",
                  "completed_at": "completed_at",
                  "notes": "Inventory rebalance between stores",
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
                    }
                  ],
                  "version": 1753118664873
                },
                {
                  "id": "EXAMPLE_TRANSFER_ORDER_ID_456",
                  "source_location_id": "EXAMPLE_SOURCE_LOCATION_ID_123",
                  "destination_location_id": "EXAMPLE_DEST_LOCATION_ID_456",
                  "status": "PARTIALLY_RECEIVED",
                  "created_at": "2025-01-14T14:20:00.000Z",
                  "updated_at": "2025-01-15T09:45:00.000Z",
                  "expected_at": "2025-11-08T12:00:00.000Z",
                  "completed_at": "completed_at",
                  "notes": "Seasonal stock transfer",
                  "tracking_number": "tracking_number",
                  "created_by_team_member_id": "created_by_team_member_id",
                  "line_items": [
                    {
                      "uid": "1",
                      "item_variation_id": "EXAMPLE_ITEM_VARIATION_ID_002",
                      "quantity_ordered": "10",
                      "quantity_pending": "3",
                      "quantity_received": "7",
                      "quantity_damaged": "0",
                      "quantity_canceled": "0"
                    }
                  ],
                  "version": 1753115540123
                }
              ],
              "cursor": "eyJsYXN0X3VwZGF0ZWRfYXQiOjE3NTMxMTU1NDBfMTIzfQ==",
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
                    .WithPath("/v2/transfer-orders/search")
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

        var items = await Client.Default.TransferOrders.SearchAsync(
            new SearchTransferOrdersRequest
            {
                Query = new TransferOrderQuery
                {
                    Filter = new TransferOrderFilter
                    {
                        SourceLocationIds = new List<string>() { "EXAMPLE_SOURCE_LOCATION_ID_123" },
                        DestinationLocationIds = new List<string>()
                        {
                            "EXAMPLE_DEST_LOCATION_ID_456",
                        },
                        Statuses = new List<TransferOrderStatus>()
                        {
                            TransferOrderStatus.Started,
                            TransferOrderStatus.PartiallyReceived,
                        },
                    },
                    Sort = new TransferOrderSort
                    {
                        Field = TransferOrderSortField.UpdatedAt,
                        Order = SortOrder.Desc,
                    },
                },
                Cursor = "eyJsYXN0X3VwZGF0ZWRfYXQiOjE3NTMxMTg2NjQ4NzN9",
                Limit = 10,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
