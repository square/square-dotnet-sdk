using NUnit.Framework;
using Square;
using Square.Core;
using Square.Locations.CustomAttributes;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Locations.CustomAttributes;

[TestFixture]
public class BatchUpsertTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "values": {
                "id1": {
                  "location_id": "L0TBCBTB7P8RQ",
                  "custom_attribute": {
                    "key": "bestseller",
                    "value": "hot cocoa"
                  }
                },
                "id2": {
                  "location_id": "L9XMD04V3STJX",
                  "custom_attribute": {
                    "key": "bestseller",
                    "value": "berry smoothie"
                  }
                },
                "id3": {
                  "location_id": "L0TBCBTB7P8RQ",
                  "custom_attribute": {
                    "key": "phone-number",
                    "value": "+12223334444"
                  }
                }
              }
            }
            """;

        const string mockResponse = """
            {
              "values": {
                "id1": {
                  "location_id": "L0TBCBTB7P8RQ",
                  "custom_attribute": {
                    "key": "bestseller",
                    "value": "hot cocoa",
                    "version": 2,
                    "visibility": "VISIBILITY_READ_WRITE_VALUES",
                    "updated_at": "2023-01-09T19:21:04.551Z",
                    "created_at": "2023-01-09T19:02:58.647Z"
                  },
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "id2": {
                  "location_id": "L9XMD04V3STJX",
                  "custom_attribute": {
                    "key": "bestseller",
                    "value": "berry smoothie",
                    "version": 1,
                    "visibility": "VISIBILITY_READ_WRITE_VALUES",
                    "updated_at": "2023-01-09T19:21:04.551Z",
                    "created_at": "2023-01-09T19:02:58.647Z"
                  },
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "id3": {
                  "location_id": "L0TBCBTB7P8RQ",
                  "custom_attribute": {
                    "key": "phone-number",
                    "value": "+12239903892",
                    "version": 2,
                    "visibility": "VISIBILITY_READ_WRITE_VALUES",
                    "updated_at": "2023-01-09T19:21:04.563Z",
                    "created_at": "2023-01-09T19:04:57.985Z"
                  },
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
                    .WithPath("/v2/locations/custom-attributes/bulk-upsert")
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

        var response = await Client.Locations.CustomAttributes.BatchUpsertAsync(
            new BulkUpsertLocationCustomAttributesRequest
            {
                Values = new Dictionary<
                    string,
                    BulkUpsertLocationCustomAttributesRequestLocationCustomAttributeUpsertRequest
                >()
                {
                    {
                        "id1",
                        new BulkUpsertLocationCustomAttributesRequestLocationCustomAttributeUpsertRequest
                        {
                            LocationId = "L0TBCBTB7P8RQ",
                            CustomAttribute = new CustomAttribute
                            {
                                Key = "bestseller",
                                Value = "hot cocoa",
                            },
                        }
                    },
                    {
                        "id2",
                        new BulkUpsertLocationCustomAttributesRequestLocationCustomAttributeUpsertRequest
                        {
                            LocationId = "L9XMD04V3STJX",
                            CustomAttribute = new CustomAttribute
                            {
                                Key = "bestseller",
                                Value = "berry smoothie",
                            },
                        }
                    },
                    {
                        "id3",
                        new BulkUpsertLocationCustomAttributesRequestLocationCustomAttributeUpsertRequest
                        {
                            LocationId = "L0TBCBTB7P8RQ",
                            CustomAttribute = new CustomAttribute
                            {
                                Key = "phone-number",
                                Value = "+12223334444",
                            },
                        }
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<BulkUpsertLocationCustomAttributesResponse>(mockResponse)
                )
                .UsingDefaults()
        );
    }
}
