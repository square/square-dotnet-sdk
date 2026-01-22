using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Customers;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Customers;

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
                  "customer_id": "N3NCVYY3WS27HF0HKANA3R9FP8",
                  "custom_attribute": {
                    "key": "favoritemovie",
                    "value": "Dune"
                  }
                },
                "id2": {
                  "customer_id": "SY8EMWRNDN3TQDP2H4KS1QWMMM",
                  "custom_attribute": {
                    "key": "ownsmovie",
                    "value": false
                  }
                },
                "id3": {
                  "customer_id": "SY8EMWRNDN3TQDP2H4KS1QWMMM",
                  "custom_attribute": {
                    "key": "favoritemovie",
                    "value": "Star Wars"
                  }
                },
                "id4": {
                  "customer_id": "N3NCVYY3WS27HF0HKANA3R9FP8",
                  "custom_attribute": {
                    "key": "square:a0f1505a-2aa1-490d-91a8-8d31ff181808",
                    "value": "10.5"
                  }
                },
                "id5": {
                  "customer_id": "70548QG1HN43B05G0KCZ4MMC1G",
                  "custom_attribute": {
                    "key": "sq0ids-0evKIskIGaY45fCyNL66aw:backupemail",
                    "value": "fake-email@squareup.com"
                  }
                }
              }
            }
            """;

        const string mockResponse = """
            {
              "values": {
                "id1": {
                  "customer_id": "N3NCVYY3WS27HF0HKANA3R9FP8",
                  "custom_attribute": {
                    "key": "favoritemovie",
                    "value": "Dune",
                    "version": 1,
                    "visibility": "VISIBILITY_READ_WRITE_VALUES",
                    "updated_at": "2021-12-09T00:16:23.000Z",
                    "created_at": "2021-12-08T23:14:47.000Z"
                  },
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "id2": {
                  "customer_id": "SY8EMWRNDN3TQDP2H4KS1QWMMM",
                  "custom_attribute": {
                    "key": "ownsmovie",
                    "value": false,
                    "version": 2,
                    "visibility": "VISIBILITY_READ_WRITE_VALUES",
                    "updated_at": "2021-12-09T00:16:23.000Z",
                    "created_at": "2021-12-09T00:16:20.000Z"
                  },
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "id3": {
                  "customer_id": "SY8EMWRNDN3TQDP2H4KS1QWMMM",
                  "custom_attribute": {
                    "key": "favoritemovie",
                    "value": "Star Wars",
                    "version": 2,
                    "visibility": "VISIBILITY_READ_WRITE_VALUES",
                    "updated_at": "2021-12-09T00:16:23.000Z",
                    "created_at": "2021-12-09T00:16:20.000Z"
                  },
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "id4": {
                  "customer_id": "N3NCVYY3WS27HF0HKANA3R9FP8",
                  "custom_attribute": {
                    "key": "square:a0f1505a-2aa1-490d-91a8-8d31ff181808",
                    "value": "10.5",
                    "version": 1,
                    "visibility": "VISIBILITY_READ_WRITE_VALUES",
                    "updated_at": "2021-12-09T00:16:23.000Z",
                    "created_at": "2021-12-08T23:14:47.000Z"
                  },
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ]
                },
                "id5": {
                  "customer_id": "70548QG1HN43B05G0KCZ4MMC1G",
                  "custom_attribute": {
                    "key": "sq0ids-0evKIskIGaY45fCyNL66aw:backupemail",
                    "value": "fake-email@squareup.com",
                    "version": 2,
                    "visibility": "VISIBILITY_READ_WRITE_VALUES",
                    "updated_at": "2021-12-09T00:16:23.000Z",
                    "created_at": "2021-12-09T00:16:20.000Z"
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
                    .WithPath("/v2/customers/custom-attributes/bulk-upsert")
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

        var response = await Client.Default.Customers.CustomAttributeDefinitions.BatchUpsertAsync(
            new BatchUpsertCustomerCustomAttributesRequest
            {
                Values = new Dictionary<
                    string,
                    BatchUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest
                >()
                {
                    {
                        "id1",
                        new BatchUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest
                        {
                            CustomerId = "N3NCVYY3WS27HF0HKANA3R9FP8",
                            CustomAttribute = new CustomAttribute
                            {
                                Key = "favoritemovie",
                                Value = "Dune",
                            },
                        }
                    },
                    {
                        "id2",
                        new BatchUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest
                        {
                            CustomerId = "SY8EMWRNDN3TQDP2H4KS1QWMMM",
                            CustomAttribute = new CustomAttribute
                            {
                                Key = "ownsmovie",
                                Value = false,
                            },
                        }
                    },
                    {
                        "id3",
                        new BatchUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest
                        {
                            CustomerId = "SY8EMWRNDN3TQDP2H4KS1QWMMM",
                            CustomAttribute = new CustomAttribute
                            {
                                Key = "favoritemovie",
                                Value = "Star Wars",
                            },
                        }
                    },
                    {
                        "id4",
                        new BatchUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest
                        {
                            CustomerId = "N3NCVYY3WS27HF0HKANA3R9FP8",
                            CustomAttribute = new CustomAttribute
                            {
                                Key = "square:a0f1505a-2aa1-490d-91a8-8d31ff181808",
                                Value = "10.5",
                            },
                        }
                    },
                    {
                        "id5",
                        new BatchUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest
                        {
                            CustomerId = "70548QG1HN43B05G0KCZ4MMC1G",
                            CustomAttribute = new CustomAttribute
                            {
                                Key = "sq0ids-0evKIskIGaY45fCyNL66aw:backupemail",
                                Value = "fake-email@squareup.com",
                            },
                        }
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<BatchUpsertCustomerCustomAttributesResponse>(mockResponse)
                )
                .UsingDefaults()
        );
    }
}
