using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Channels;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Channels;

[TestFixture]
public class BulkRetrieveTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "channel_ids": [
                "CH_9C03D0B59",
                "CH_6X139B5MN",
                "NOT_EXISTING"
              ]
            }
            """;

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
              "responses": {
                "CH_6X139B5MN": {
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ],
                  "channel": {
                    "id": "CH_6X139B5MN",
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
                },
                "CH_9C03D0B59": {
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ],
                  "channel": {
                    "id": "CH_9C03D0B59",
                    "merchant_id": "ML64FACEA",
                    "name": "State Street Store",
                    "version": 1,
                    "reference": {
                      "type": "LOCATION",
                      "id": "OA_9C03D0B59"
                    },
                    "status": "ACTIVE",
                    "created_at": "2022-10-25T16:27:00.000Z",
                    "updated_at": "2022-10-25T16:48:00.000Z"
                  }
                },
                "NOT_EXISTING": {
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "NOT_FOUND"
                    }
                  ]
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/channels/bulk-retrieve")
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

        var response = await Client.Default.Channels.BulkRetrieveAsync(
            new BulkRetrieveChannelsRequest
            {
                ChannelIds = new List<string>() { "CH_9C03D0B59", "CH_6X139B5MN", "NOT_EXISTING" },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<BulkRetrieveChannelsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
