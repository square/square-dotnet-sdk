using NUnit.Framework;
using Square;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Customers.CustomAttributes;

[TestFixture]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "custom_attribute": {
                "key": "favoritemovie",
                "value": "Dune",
                "version": 1,
                "visibility": "VISIBILITY_READ_ONLY",
                "definition": {
                  "key": "key",
                  "schema": {
                    "key": "value"
                  },
                  "name": "name",
                  "description": "description",
                  "visibility": "VISIBILITY_HIDDEN",
                  "version": 1,
                  "updated_at": "updated_at",
                  "created_at": "created_at"
                },
                "updated_at": "2022-04-26T15:50:27.000Z",
                "created_at": "2022-04-26T15:50:27.000Z"
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
                    .WithPath("/v2/customers/customer_id/custom-attributes/key")
                    .WithParam("version", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Customers.CustomAttributes.GetAsync(
            new Square.Customers.CustomAttributes.GetCustomAttributesRequest
            {
                CustomerId = "customer_id",
                Key = "key",
                WithDefinition = true,
                Version = 1,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetCustomerCustomAttributeResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
