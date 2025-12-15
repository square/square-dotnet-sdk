using NUnit.Framework;
using Square;
using Square.Channels;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Channels;

[TestFixture]
public class ListTest : BaseMockServerTest
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
              "channels": [
                {
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
              ],
              "cursor": "cursor"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/channels")
                    .WithParam("reference_type", "UNKNOWN_TYPE")
                    .WithParam("reference_id", "reference_id")
                    .WithParam("status", "ACTIVE")
                    .WithParam("cursor", "cursor")
                    .WithParam("limit", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Channels.ListAsync(
            new ListChannelsRequest
            {
                ReferenceType = ReferenceType.UnknownType,
                ReferenceId = "reference_id",
                Status = ChannelStatus.Active,
                Cursor = "cursor",
                Limit = 1,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
