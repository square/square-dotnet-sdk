using NUnit.Framework;
using Square;
using Square.Core;
using Square.Devices.Codes;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Devices.Codes;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "01bb00a6-0c86-4770-94ed-f5fca973cd56",
              "device_code": {
                "name": "Counter 1",
                "product_type": "TERMINAL_API",
                "location_id": "B5E4484SHHNYH"
              }
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
              "device_code": {
                "id": "B3Z6NAMYQSMTM",
                "name": "Counter 1",
                "code": "EBCARJ",
                "device_id": "device_id",
                "product_type": "TERMINAL_API",
                "location_id": "B5E4484SHHNYH",
                "status": "UNPAIRED",
                "pair_by": "2020-02-06T18:49:33.000Z",
                "created_at": "2020-02-06T18:44:33.000Z",
                "status_changed_at": "2020-02-06T18:44:33.000Z",
                "paired_at": "paired_at"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/devices/codes")
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

        var response = await Client.Devices.Codes.CreateAsync(
            new CreateDeviceCodeRequest
            {
                IdempotencyKey = "01bb00a6-0c86-4770-94ed-f5fca973cd56",
                DeviceCode = new DeviceCode
                {
                    Name = "Counter 1",
                    ProductType = "TERMINAL_API",
                    LocationId = "B5E4484SHHNYH",
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreateDeviceCodeResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
