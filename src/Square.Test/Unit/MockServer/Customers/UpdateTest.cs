using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Customers;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Customers;

[TestFixture]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "email_address": "New.Amelia.Earhart@example.com",
              "note": "updated customer note",
              "version": 2
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
              "customer": {
                "id": "JDKYHBWT1D4F8MFH63DBMEN8Y4",
                "created_at": "2016-03-23T20:21:54.859Z",
                "updated_at": "2016-05-15T20:21:55.000Z",
                "given_name": "Amelia",
                "family_name": "Earhart",
                "nickname": "nickname",
                "company_name": "company_name",
                "email_address": "New.Amelia.Earhart@example.com",
                "address": {
                  "address_line_1": "500 Electric Ave",
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
                "phone_number": "phone_number",
                "birthday": "birthday",
                "reference_id": "YOUR_REFERENCE_ID",
                "note": "updated customer note",
                "preferences": {
                  "email_unsubscribed": false
                },
                "creation_source": "THIRD_PARTY",
                "group_ids": [
                  "group_ids"
                ],
                "segment_ids": [
                  "segment_ids"
                ],
                "version": 3,
                "tax_ids": {
                  "eu_vat": "eu_vat"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/customers/customer_id")
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

        var response = await Client.Customers.UpdateAsync(
            new UpdateCustomerRequest
            {
                CustomerId = "customer_id",
                EmailAddress = "New.Amelia.Earhart@example.com",
                Note = "updated customer note",
                Version = 2,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UpdateCustomerResponse>(mockResponse)).UsingDefaults()
        );
    }
}
