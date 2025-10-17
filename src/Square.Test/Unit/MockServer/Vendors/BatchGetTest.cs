using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Test.Unit.MockServer;
using Square.Vendors;

namespace Square.Test.Unit.MockServer.Vendors;

[TestFixture]
public class BatchGetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "vendor_ids": [
                "INV_V_JDKYHBWT1D4F8MFH63DBMEN8Y4"
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
                "INV_V_JDKYHBWT1D4F8MFH63DBMEN8Y4": {
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ],
                  "vendor": {
                    "id": "INV_V_JDKYHBWT1D4F8MFH63DBMEN8Y4",
                    "created_at": "2022-03-16T10:21:54.859Z",
                    "updated_at": "2022-03-16T10:21:54.859Z",
                    "name": "Joe's Fresh Seafood",
                    "address": {
                      "address_line_1": "505 Electric Ave",
                      "address_line_2": "Suite 600",
                      "locality": "New York",
                      "administrative_district_level_1": "NY",
                      "postal_code": "10003",
                      "country": "US"
                    },
                    "contacts": [
                      {
                        "id": "INV_VC_FMCYHBWT1TPL8MFH52PBMEN92A",
                        "name": "Joe Burrow",
                        "email_address": "joe@joesfreshseafood.com",
                        "phone_number": "1-212-555-4250",
                        "ordinal": 1
                      }
                    ],
                    "account_number": "4025391",
                    "note": "a vendor",
                    "version": 1,
                    "status": "ACTIVE"
                  }
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/vendors/bulk-retrieve")
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

        var response = await Client.Vendors.BatchGetAsync(
            new BatchGetVendorsRequest
            {
                VendorIds = new List<string>() { "INV_V_JDKYHBWT1D4F8MFH63DBMEN8Y4" },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<BatchGetVendorsResponse>(mockResponse)).UsingDefaults()
        );
    }
}
