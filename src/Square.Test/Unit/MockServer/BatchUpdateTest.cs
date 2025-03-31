using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Vendors;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class BatchUpdateTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "vendors": {
                "FMCYHBWT1TPL8MFH52PBMEN92A": {
                  "vendor": {}
                },
                "INV_V_JDKYHBWT1D4F8MFH63DBMEN8Y4": {
                  "vendor": {}
                }
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
              "responses": {
                "INV_V_FMCYHBWT1TPL8MFH52PBMEN92A": {
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ],
                  "vendor": {
                    "id": "INV_V_FMCYHBWT1TPL8MFH52PBMEN92A",
                    "created_at": "2022-03-16T10:21:54.859Z",
                    "updated_at": "2022-03-16T20:21:54.859Z",
                    "name": "Annie’s Hot Sauce",
                    "address": {
                      "address_line_1": "202 Mill St",
                      "locality": "Moorestown",
                      "administrative_district_level_1": "NJ",
                      "postal_code": "08057",
                      "country": "US"
                    },
                    "contacts": [
                      {
                        "id": "INV_VC_ABYYHBWT1TPL8MFH52PBMENPJ4",
                        "name": "Annie Thomas",
                        "email_address": "annie@annieshotsauce.com",
                        "phone_number": "1-212-555-4250",
                        "ordinal": 0
                      }
                    ],
                    "version": 11,
                    "status": "ACTIVE"
                  }
                },
                "INV_V_JDKYHBWT1D4F8MFH63DBMEN8Y4": {
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ],
                  "vendor": {
                    "id": "INV_V_JDKYHBWT1D4F8MFH63DBMEN8Y4",
                    "created_at": "2022-03-16T10:10:54.859Z",
                    "updated_at": "2022-03-16T20:21:54.859Z",
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
                        "ordinal": 0
                      }
                    ],
                    "account_number": "4025391",
                    "note": "favorite vendor",
                    "version": 31,
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
                    .WithPath("/v2/vendors/bulk-update")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Vendors.BatchUpdateAsync(
            new BatchUpdateVendorsRequest
            {
                Vendors = new Dictionary<string, UpdateVendorRequest>()
                {
                    {
                        "FMCYHBWT1TPL8MFH52PBMEN92A",
                        new UpdateVendorRequest { Vendor = new Vendor() }
                    },
                    {
                        "INV_V_JDKYHBWT1D4F8MFH63DBMEN8Y4",
                        new UpdateVendorRequest { Vendor = new Vendor() }
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<BatchUpdateVendorsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
