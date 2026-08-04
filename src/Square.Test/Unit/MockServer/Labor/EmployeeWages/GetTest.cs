using NUnit.Framework;
using Square;
using Square.Core;
using Square.Labor.EmployeeWages;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Labor.EmployeeWages;

[TestFixture]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "employee_wage": {
                "id": "pXS3qCv7BERPnEGedM4S8mhm",
                "employee_id": "33fJchumvVdJwxV0H6L9",
                "title": "Manager",
                "hourly_rate": {
                  "amount": 2000,
                  "currency": "USD"
                }
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
                    .WithPath("/v2/labor/employee-wages/id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Labor.EmployeeWages.GetAsync(
            new GetEmployeeWagesRequest { Id = "id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetEmployeeWageResponse>(mockResponse)).UsingDefaults()
        );
    }
}
