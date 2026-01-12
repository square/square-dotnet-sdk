using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Customers.Groups;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Customers.Groups;

[TestFixture]
public class DeleteTest : BaseMockServerTest
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
                    .WithPath("/v2/customers/groups/group_id")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Customers.Groups.DeleteAsync(
            new DeleteGroupsRequest { GroupId = "group_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<DeleteCustomerGroupResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
