using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Merchants;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Merchants;

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
              "merchant": {
                "id": "DM7VKY8Q63GNP",
                "business_name": "Apple A Day",
                "country": "US",
                "language_code": "en-US",
                "currency": "USD",
                "status": "ACTIVE",
                "main_location_id": "9A65CGC72ZQG1",
                "created_at": "2021-12-10T19:25:52.484Z"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/merchants/merchant_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Merchants.GetAsync(
            new GetMerchantsRequest { MerchantId = "merchant_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetMerchantResponse>(mockResponse)).UsingDefaults()
        );
    }
}
