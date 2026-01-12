using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Loyalty.Programs;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Loyalty.Programs;

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
              "program": {
                "id": "d619f755-2d17-41f3-990d-c04ecedd64dd",
                "status": "ACTIVE",
                "reward_tiers": [
                  {
                    "id": "e1b39225-9da5-43d1-a5db-782cdd8ad94f",
                    "points": 10,
                    "name": "10% off entire sale",
                    "created_at": "2020-04-20T16:55:11.000Z",
                    "pricing_rule_reference": {
                      "object_id": "74C4JSHESNLTB2A7ITO5HO6F",
                      "catalog_version": 1000000
                    }
                  }
                ],
                "expiration_policy": {
                  "expiration_duration": "expiration_duration"
                },
                "terminology": {
                  "one": "Point",
                  "other": "Points"
                },
                "location_ids": [
                  "P034NEENMD09F"
                ],
                "created_at": "2020-04-20T16:55:11.000Z",
                "updated_at": "2020-05-01T02:00:02.000Z",
                "accrual_rules": [
                  {
                    "accrual_type": "SPEND",
                    "points": 1,
                    "spend_data": {
                      "amount_money": {
                        "amount": 100,
                        "currency": "USD"
                      },
                      "excluded_category_ids": [
                        "7ZERJKO5PVYXCVUHV2JCZ2UG",
                        "FQKAOJE5C4FIMF5A2URMLW6V"
                      ],
                      "excluded_item_variation_ids": [
                        "CBZXBUVVTYUBZGQO44RHMR6B",
                        "EDILT24Z2NISEXDKGY6HP7XV"
                      ],
                      "tax_mode": "BEFORE_TAX"
                    }
                  }
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/loyalty/programs/program_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Loyalty.Programs.GetAsync(
            new GetProgramsRequest { ProgramId = "program_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetLoyaltyProgramResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
