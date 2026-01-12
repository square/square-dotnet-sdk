using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Devices.Codes;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Devices.Codes;

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
              "device_code": {
                "id": "B3Z6NAMYQSMTM",
                "name": "Counter 1",
                "code": "EBCARJ",
                "device_id": "907CS13101300122",
                "product_type": "TERMINAL_API",
                "location_id": "B5E4484SHHNYH",
                "status": "PAIRED",
                "pair_by": "2020-02-06T18:49:33.000Z",
                "created_at": "2020-02-06T18:44:33.000Z",
                "status_changed_at": "2020-02-06T18:47:28.000Z",
                "paired_at": "paired_at"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/devices/codes/id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Devices.Codes.GetAsync(
            new GetCodesRequest { Id = "id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetDeviceCodeResponse>(mockResponse)).UsingDefaults()
        );
    }
}
