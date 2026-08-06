using NUnit.Framework;
using Square;
using Square.Core;
using Square.Test.Unit.MockServer;
using Square.Vendors;

namespace Square.Test.Unit.MockServer.Vendors;

[TestFixture]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "idempotency_key": "8fc6a5b0-9fe8-4b46-b46b-2ef95793abbe",
              "vendor": {
                "id": "INV_V_JDKYHBWT1D4F8MFH63DBMEN8Y4",
                "name": "Jack's Chicken Shack",
                "version": 1,
                "status": "ACTIVE"
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
              "vendor": {
                "id": "INV_V_JDKYHBWT1D4F8MFH63DBMEN8Y4",
                "created_at": "2022-03-16T10:21:54.859Z",
                "updated_at": "2022-03-16T20:21:54.859Z",
                "name": "Jack's Chicken Shack",
                "address": {
                  "address_line_1": "505 Electric Ave",
                  "address_line_2": "Suite 600",
                  "address_line_3": "address_line_3",
                  "locality": "New York",
                  "sublocality": "sublocality",
                  "sublocality_2": "sublocality_2",
                  "sublocality_3": "sublocality_3",
                  "administrative_district_level_1": "NY",
                  "administrative_district_level_2": "administrative_district_level_2",
                  "administrative_district_level_3": "administrative_district_level_3",
                  "postal_code": "10003",
                  "country": "US",
                  "first_name": "first_name",
                  "last_name": "last_name"
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
                "note": "note",
                "version": 2,
                "status": "ACTIVE"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/vendors/vendor_id")
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

        var response = await Client.Vendors.UpdateAsync(
            new UpdateVendorsRequest
            {
                VendorId = "vendor_id",
                Body = new UpdateVendorRequest
                {
                    IdempotencyKey = "8fc6a5b0-9fe8-4b46-b46b-2ef95793abbe",
                    Vendor = new Vendor
                    {
                        Id = "INV_V_JDKYHBWT1D4F8MFH63DBMEN8Y4",
                        Name = "Jack's Chicken Shack",
                        Version = 1,
                        Status = VendorStatus.Active,
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpdateVendorResponse>(mockResponse)).UsingDefaults()
        );
    }
}
