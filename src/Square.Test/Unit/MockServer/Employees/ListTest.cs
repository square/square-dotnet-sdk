using NUnit.Framework;
using Square;
using Square.Employees;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Employees;

[TestFixture]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "employees": [
                {
                  "id": "id",
                  "first_name": "first_name",
                  "last_name": "last_name",
                  "email": "email",
                  "phone_number": "phone_number",
                  "location_ids": [
                    "location_ids"
                  ],
                  "status": "ACTIVE",
                  "is_owner": true,
                  "created_at": "created_at",
                  "updated_at": "updated_at"
                }
              ],
              "cursor": "cursor",
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
                    .WithPath("/v2/employees")
                    .WithParam("location_id", "location_id")
                    .WithParam("status", "ACTIVE")
                    .WithParam("limit", "1")
                    .WithParam("cursor", "cursor")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Employees.ListAsync(
            new ListEmployeesRequest
            {
                LocationId = "location_id",
                Status = EmployeeStatus.Active,
                Limit = 1,
                Cursor = "cursor",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
