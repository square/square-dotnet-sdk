using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Customers.Segments;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Customers.Segments;

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
              "segment": {
                "id": "GMNXRZVEXNQDF.CHURN_RISK",
                "name": "Lapsed",
                "created_at": "2020-01-09T19:33:24.469Z",
                "updated_at": "2020-04-13T23:01:13.000Z"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/customers/segments/segment_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Customers.Segments.GetAsync(
            new GetSegmentsRequest { SegmentId = "segment_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetCustomerSegmentResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
