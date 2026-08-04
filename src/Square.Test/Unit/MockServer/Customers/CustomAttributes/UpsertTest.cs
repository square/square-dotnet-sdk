using NUnit.Framework;
using Square;
using Square.Core;
using Square.Customers.CustomAttributes;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Customers.CustomAttributes;

[TestFixture]
public class UpsertTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "custom_attribute": {
                "value": "Dune"
              }
            }
            """;

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

        var response = await Client.Customers.CustomAttributes.UpsertAsync(
            new UpsertCustomerCustomAttributeRequest
            {
                CustomerId = "customer_id",
                Key = "key",
                CustomAttribute = new CustomAttribute { Value = "Dune" },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpsertCustomerCustomAttributeResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
