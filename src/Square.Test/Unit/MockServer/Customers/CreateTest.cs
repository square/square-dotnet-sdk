using NUnit.Framework;
using Square;
using Square.Core;
using Square.Customers;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Customers;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "given_name": "Amelia",
              "family_name": "Earhart",
              "email_address": "Amelia.Earhart@example.com",
              "address": {
                "address_line_1": "500 Electric Ave",
                "address_line_2": "Suite 600",
                "locality": "New York",
                "administrative_district_level_1": "NY",
                "postal_code": "10003",
                "country": "US"
              },
              "phone_number": "+1-212-555-4240",
              "reference_id": "YOUR_REFERENCE_ID",
              "note": "a customer"
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
                "updated_at": "2016-03-23T20:21:54.859Z",
                "given_name": "Amelia",
                "family_name": "Earhart",
                "nickname": "nickname",
                "company_name": "company_name",
                "email_address": "Amelia.Earhart@example.com",
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
                "phone_number": "+1-212-555-4240",
                "birthday": "birthday",
                "reference_id": "YOUR_REFERENCE_ID",
                "note": "a customer",
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
                "version": 0,
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
                    .WithPath("/v2/customers")
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

        var response = await Client.Customers.CreateAsync(
            new CreateCustomerRequest
            {
                GivenName = "Amelia",
                FamilyName = "Earhart",
                EmailAddress = "Amelia.Earhart@example.com",
                Address = new Address
                {
                    AddressLine1 = "500 Electric Ave",
                    AddressLine2 = "Suite 600",
                    Locality = "New York",
                    AdministrativeDistrictLevel1 = "NY",
                    PostalCode = "10003",
                    Country = Country.Us,
                },
                PhoneNumber = "+1-212-555-4240",
                ReferenceId = "YOUR_REFERENCE_ID",
                Note = "a customer",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CreateCustomerResponse>(mockResponse)).UsingDefaults()
        );
    }
}
