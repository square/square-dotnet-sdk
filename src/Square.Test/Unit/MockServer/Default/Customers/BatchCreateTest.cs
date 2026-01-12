using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Customers;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Customers;

[TestFixture]
public class BatchCreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "customers": {
                "8bb76c4f-e35d-4c5b-90de-1194cd9179f0": {
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
                },
                "d1689f23-b25d-4932-b2f0-aed00f5e2029": {
                  "given_name": "Marie",
                  "family_name": "Curie",
                  "email_address": "Marie.Curie@example.com",
                  "address": {
                    "address_line_1": "500 Electric Ave",
                    "address_line_2": "Suite 601",
                    "locality": "New York",
                    "administrative_district_level_1": "NY",
                    "postal_code": "10003",
                    "country": "US"
                  },
                  "phone_number": "+1-212-444-4240",
                  "reference_id": "YOUR_REFERENCE_ID",
                  "note": "another customer"
                }
              }
            }
            """;

        const string mockResponse = """
            {
              "responses": {
                "8bb76c4f-e35d-4c5b-90de-1194cd9179f4": {
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ],
                  "customer": {
                    "id": "8DDA5NZVBZFGAX0V3HPF81HHE0",
                    "created_at": "2024-03-23T20:21:54.859Z",
                    "updated_at": "2024-03-23T20:21:54.859Z",
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
                    "note": "a customer",
                    "preferences": {
                      "email_unsubscribed": false
                    },
                    "creation_source": "THIRD_PARTY",
                    "version": 0
                  }
                },
                "d1689f23-b25d-4932-b2f0-aed00f5e2029": {
                  "errors": [
                    {
                      "category": "API_ERROR",
                      "code": "INTERNAL_SERVER_ERROR"
                    }
                  ],
                  "customer": {
                    "id": "N18CPRVXR5214XPBBA6BZQWF3C",
                    "created_at": "2024-03-23T20:21:54.859Z",
                    "updated_at": "2024-03-23T20:21:54.859Z",
                    "given_name": "Marie",
                    "family_name": "Curie",
                    "email_address": "Marie.Curie@example.com",
                    "address": {
                      "address_line_1": "500 Electric Ave",
                      "address_line_2": "Suite 601",
                      "locality": "New York",
                      "administrative_district_level_1": "NY",
                      "postal_code": "10003",
                      "country": "US"
                    },
                    "phone_number": "+1-212-444-4240",
                    "reference_id": "YOUR_REFERENCE_ID",
                    "note": "another customer",
                    "preferences": {
                      "email_unsubscribed": false
                    },
                    "creation_source": "THIRD_PARTY",
                    "version": 0
                  }
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
                    .WithPath("/v2/customers/bulk-create")
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

        var response = await Client.Default.Customers.BatchCreateAsync(
            new BulkCreateCustomersRequest
            {
                Customers = new Dictionary<string, BulkCreateCustomerData>()
                {
                    {
                        "8bb76c4f-e35d-4c5b-90de-1194cd9179f0",
                        new BulkCreateCustomerData
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
                    },
                    {
                        "d1689f23-b25d-4932-b2f0-aed00f5e2029",
                        new BulkCreateCustomerData
                        {
                            GivenName = "Marie",
                            FamilyName = "Curie",
                            EmailAddress = "Marie.Curie@example.com",
                            Address = new Address
                            {
                                AddressLine1 = "500 Electric Ave",
                                AddressLine2 = "Suite 601",
                                Locality = "New York",
                                AdministrativeDistrictLevel1 = "NY",
                                PostalCode = "10003",
                                Country = Country.Us,
                            },
                            PhoneNumber = "+1-212-444-4240",
                            ReferenceId = "YOUR_REFERENCE_ID",
                            Note = "another customer",
                        }
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<BulkCreateCustomersResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
