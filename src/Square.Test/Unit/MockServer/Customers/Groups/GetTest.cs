using NUnit.Framework;
using Square;
using Square.Core;
using Square.Customers.Groups;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Customers.Groups;

[TestFixture]
public class GetTest : BaseMockServerTest
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
                    .WithPath("/v2/customers/groups/group_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Customers.Groups.GetAsync(
            new GetGroupsRequest { GroupId = "group_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetCustomerGroupResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
