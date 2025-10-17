using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Customers;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Customers;

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
                    .WithPath("/v2/customers/customer_id")
                    .WithParam("version", "1000000")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Customers.DeleteAsync(
            new DeleteCustomersRequest { CustomerId = "customer_id", Version = 1000000 }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<DeleteCustomerResponse>(mockResponse)).UsingDefaults()
        );
    }
}
