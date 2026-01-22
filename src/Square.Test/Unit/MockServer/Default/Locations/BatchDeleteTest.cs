using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Locations;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Locations;

[TestFixture]
public class BatchDeleteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "values": {
                "id1": {
                  "key": "bestseller"
                },
                "id2": {
                  "key": "bestseller"
                },
                "id3": {
                  "key": "phone-number"
                }
              }
            }
            """;

        const string mockResponse = """
            {
              "values": {
                "id1": {
                  "location_id": "L0TBCBTB7P8RQ",
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "id2": {
                  "location_id": "L9XMD04V3STJX",
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "id3": {
                  "location_id": "L0TBCBTB7P8RQ",
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                }
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
                    .WithPath("/v2/locations/custom-attributes/bulk-delete")
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

        var response = await Client.Default.Locations.CustomAttributes.BatchDeleteAsync(
            new BulkDeleteLocationCustomAttributesRequest
            {
                Values = new Dictionary<
                    string,
                    BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest
                >()
                {
                    {
                        "id1",
                        new BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest
                        {
                            Key = "bestseller",
                        }
                    },
                    {
                        "id2",
                        new BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest
                        {
                            Key = "bestseller",
                        }
                    },
                    {
                        "id3",
                        new BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest
                        {
                            Key = "phone-number",
                        }
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<BulkDeleteLocationCustomAttributesResponse>(mockResponse)
                )
                .UsingDefaults()
        );
    }
}
