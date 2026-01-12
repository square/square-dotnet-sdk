using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Merchants.CustomAttributes;

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
                    .WithPath("/v2/merchants/merchant_id/custom-attributes/key")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Merchants.CustomAttributes.DeleteAsync(
            new Square.Default.Merchants.CustomAttributes.DeleteCustomAttributesRequest
            {
                MerchantId = "merchant_id",
                Key = "key",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<DeleteMerchantCustomAttributeResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
