using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Customers.CustomAttributes;

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
                    .WithPath("/v2/customers/customer_id/custom-attributes/key")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Customers.CustomAttributes.DeleteAsync(
            new Square.Default.Customers.CustomAttributes.DeleteCustomAttributesRequest
            {
                CustomerId = "customer_id",
                Key = "key",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<DeleteCustomerCustomAttributeResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
