using NUnit.Framework;
using Square;
using Square.Core;
using Square.Customers.Groups;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Customers.Groups;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "group": {
                "name": "Loyal Customers"
              }
            }
            """;

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
              "group": {
                "id": "2TAT3CMH4Q0A9M87XJZED0WMR3",
                "name": "Loyal Customers",
                "created_at": "2020-04-13T21:54:57.863Z",
                "updated_at": "2020-04-13T21:54:58.000Z"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/customers/groups")
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

        var response = await Client.Customers.Groups.CreateAsync(
            new CreateCustomerGroupRequest
            {
                Group = new CustomerGroup { Name = "Loyal Customers" },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreateCustomerGroupResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
