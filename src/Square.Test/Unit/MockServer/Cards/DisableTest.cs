using NUnit.Framework;
using Square;
using Square.Cards;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Cards;

[TestFixture]
public class DisableTest : BaseMockServerTest
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
              "card": {
                "id": "ccof:uIbfJXhXETSP197M3GB",
                "card_brand": "VISA",
                "last_4": "1111",
                "exp_month": 11,
                "exp_year": 2022,
                "cardholder_name": "Amelia Earhart",
                "billing_address": {
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
                "fingerprint": "ex-p-cs80EK9Flz7LsCMv-szbptQ_ssAGrhemzSTsPFgt9nzyE6t7okiLIQc-qw_quqKX4Q",
                "customer_id": "VDKXEEKPJN48QDG3BGGFAK05P8",
                "merchant_id": "6SSW7HV8K2ST5",
                "reference_id": "user-id-1",
                "enabled": false,
                "card_type": "CREDIT",
                "prepaid_type": "NOT_PREPAID",
                "bin": "411111",
                "version": 2,
                "card_co_brand": "UNKNOWN",
                "issuer_alert": "ISSUER_ALERT_CARD_CLOSED",
                "issuer_alert_at": "issuer_alert_at",
                "hsa_fsa": false
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/cards/card_id/disable")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Cards.DisableAsync(
            new DisableCardsRequest { CardId = "card_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<DisableCardResponse>(mockResponse)).UsingDefaults()
        );
    }
}
