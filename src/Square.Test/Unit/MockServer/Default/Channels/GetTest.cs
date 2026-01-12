using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Channels;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Channels;

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
              "channel": {
                "id": "CH_9C03D0B59",
                "merchant_id": "ML64FACEA",
                "name": "Contoso Fulfillment Application",
                "version": 1,
                "reference": {
                  "type": "OAUTH_APPLICATION",
                  "id": "OA_9C03D0444"
                },
                "status": "ACTIVE",
                "created_at": "2022-10-25T16:27:00.000Z",
                "updated_at": "2022-10-25T16:48:00.000Z"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/channels/channel_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Channels.GetAsync(
            new GetChannelsRequest { ChannelId = "channel_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<RetrieveChannelResponse>(mockResponse)).UsingDefaults()
        );
    }
}
