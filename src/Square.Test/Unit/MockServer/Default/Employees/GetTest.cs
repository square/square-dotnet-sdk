using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Employees;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Employees;

[TestFixture]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "employee": {
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
                WireMock.RequestBuilders.Request.Create().WithPath("/v2/employees/id").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Employees.GetAsync(
            new GetEmployeesRequest { Id = "id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetEmployeeResponse>(mockResponse)).UsingDefaults()
        );
    }
}
