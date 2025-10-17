using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Customers;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Customers;

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
              "customers": [
                {
                  "id": "JDKYHBWT1D4F8MFH63DBMEN8Y4",
                  "created_at": "2016-03-23T20:21:54.859Z",
                  "updated_at": "2016-03-23T20:21:55.000Z",
                  "given_name": "Amelia",
                  "family_name": "Earhart",
                  "nickname": "nickname",
                  "company_name": "company_name",
                  "email_address": "Amelia.Earhart@example.com",
                  "address": {
                    "address_line_1": "500 Electric Ave",
                    "address_line_2": "Suite 600",
                    "locality": "New York",
                    "administrative_district_level_1": "NY",
                    "postal_code": "10003",
                    "country": "US"
                  },
                  "phone_number": "+1-212-555-4240",
                  "birthday": "birthday",
                  "reference_id": "YOUR_REFERENCE_ID",
                  "note": "a customer",
                  "preferences": {
                    "email_unsubscribed": false
                  },
                  "creation_source": "THIRD_PARTY",
                  "group_ids": [
                    "545AXB44B4XXWMVQ4W8SBT3HHF"
                  ],
                  "segment_ids": [
                    "1KB9JE5EGJXCW.REACHABLE"
                  ],
                  "version": 1
                }
              ],
              "cursor": "cursor",
              "count": 1000000
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/customers")
                    .WithParam("cursor", "cursor")
                    .WithParam("limit", "1")
                    .WithParam("sort_field", "DEFAULT")
                    .WithParam("sort_order", "DESC")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Customers.ListAsync(
            new ListCustomersRequest
            {
                Cursor = "cursor",
                Limit = 1,
                SortField = CustomerSortField.Default,
                SortOrder = SortOrder.Desc,
                Count = true,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
