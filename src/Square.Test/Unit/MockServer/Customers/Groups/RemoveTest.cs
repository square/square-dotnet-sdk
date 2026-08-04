using NUnit.Framework;
using Square;
using Square.Core;
using Square.Customers.Groups;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Customers.Groups;

[TestFixture]
public class RemoveTest : BaseMockServerTest
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
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/customers/customer_id/groups/group_id")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Customers.Groups.RemoveAsync(
            new RemoveGroupsRequest { CustomerId = "customer_id", GroupId = "group_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<RemoveGroupFromCustomerResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
