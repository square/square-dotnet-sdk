using NUnit.Framework;
using Square.Default.Labor.EmployeeWages;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Labor.EmployeeWages;

[TestFixture]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "employee_wages": [
                {
                  "id": "pXS3qCv7BERPnEGedM4S8mhm",
                  "employee_id": "33fJchumvVdJwxV0H6L9",
                  "title": "Manager",
                  "hourly_rate": {
                    "amount": 3250,
                    "currency": "USD"
                  }
                },
                {
                  "id": "rZduCkzYDUVL3ovh1sQgbue6",
                  "employee_id": "33fJchumvVdJwxV0H6L9",
                  "title": "Cook",
                  "hourly_rate": {
                    "amount": 2600,
                    "currency": "USD"
                  }
                },
                {
                  "id": "FxLbs5KpPUHa8wyt5ctjubDX",
                  "employee_id": "33fJchumvVdJwxV0H6L9",
                  "title": "Barista",
                  "hourly_rate": {
                    "amount": 1600,
                    "currency": "USD"
                  }
                },
                {
                  "id": "vD1wCgijMDR3cX5TPnu7VXto",
                  "employee_id": "33fJchumvVdJwxV0H6L9",
                  "title": "Cashier",
                  "hourly_rate": {
                    "amount": 1700,
                    "currency": "USD"
                  }
                }
              ],
              "cursor": "2fofTniCgT0yIPAq26kmk0YyFQJZfbWkh73OOnlTHmTAx13NgED",
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
                    .WithPath("/v2/labor/employee-wages")
                    .WithParam("employee_id", "employee_id")
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

        var items = await Client.Default.Labor.EmployeeWages.ListAsync(
            new ListEmployeeWagesRequest
            {
                EmployeeId = "employee_id",
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
