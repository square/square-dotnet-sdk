using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Refunds;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Refunds;

[TestFixture]
public class ListTest : BaseMockServerTest
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
              "refunds": [
                {
                  "id": "bP9mAsEMYPUGjjGNaNO5ZDVyLhSZY_69MmgHubkLqx9wGhnmenRUHOaKitE6llfZuxcWYjGxd",
                  "status": "COMPLETED",
                  "location_id": "L88917AVBK2S5",
                  "unlinked": true,
                  "destination_type": "destination_type",
                  "amount_money": {
                    "amount": 555,
                    "currency": "USD"
                  },
                  "processing_fee": [
                    {
                      "effective_at": "2021-10-13T21:34:35.000Z",
                      "type": "INITIAL",
                      "amount_money": {
                        "amount": -34,
                        "currency": "USD"
                      }
                    }
                  ],
                  "payment_id": "bP9mAsEMYPUGjjGNaNO5ZDVyLhSZY",
                  "order_id": "9ltv0bx5PuvGXUYHYHxYSKEqC3IZY",
                  "reason": "Example Refund",
                  "created_at": "2021-10-13T19:59:05.342Z",
                  "updated_at": "2021-10-13T20:00:03.497Z",
                  "team_member_id": "team_member_id",
                  "terminal_refund_id": "terminal_refund_id"
                }
              ],
              "cursor": "5evquW1YswHoT4EoyUhzMmTsCnsSXBU9U0WJ4FU4623nrMQcocH0RGU6Up1YkwfiMcF59ood58EBTEGgzMTGHQJpocic7ExOL0NtrTXCeWcv0UJIJNk8eXb"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/refunds")
                    .WithParam("begin_time", "begin_time")
                    .WithParam("end_time", "end_time")
                    .WithParam("sort_order", "sort_order")
                    .WithParam("cursor", "cursor")
                    .WithParam("location_id", "location_id")
                    .WithParam("status", "status")
                    .WithParam("source_type", "source_type")
                    .WithParam("limit", "1")
                    .WithParam("updated_at_begin_time", "updated_at_begin_time")
                    .WithParam("updated_at_end_time", "updated_at_end_time")
                    .WithParam("sort_field", "CREATED_AT")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Refunds.ListAsync(
            new ListRefundsRequest
            {
                BeginTime = "begin_time",
                EndTime = "end_time",
                SortOrder = "sort_order",
                Cursor = "cursor",
                LocationId = "location_id",
                Status = "status",
                SourceType = "source_type",
                Limit = 1,
                UpdatedAtBeginTime = "updated_at_begin_time",
                UpdatedAtEndTime = "updated_at_end_time",
                SortField = ListPaymentRefundsRequestSortField.CreatedAt,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
