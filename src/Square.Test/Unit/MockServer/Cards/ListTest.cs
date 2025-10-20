using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Cards;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Cards;

[TestFixture]
public class ListTest : BaseMockServerTest
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
              "cards": [
                {
                  "id": "ccof:uIbfJXhXETSP197M3GB",
                  "card_brand": "VISA",
                  "last_4": "1111",
                  "exp_month": 11,
                  "exp_year": 2022,
                  "cardholder_name": "Amelia Earhart",
                  "billing_address": {
                    "address_line_1": "500 Electric Ave",
                    "address_line_2": "Suite 600",
                    "locality": "New York",
                    "administrative_district_level_1": "NY",
                    "postal_code": "10003",
                    "country": "US"
                  },
                  "fingerprint": "ex-p-cs80EK9Flz7LsCMv-szbptQ_ssAGrhemzSTsPFgt9nzyE6t7okiLIQc-qw_quqKX4Q",
                  "customer_id": "VDKXEEKPJN48QDG3BGGFAK05P8",
                  "merchant_id": "6SSW7HV8K2ST5",
                  "reference_id": "user-id-1",
                  "enabled": true,
                  "card_type": "CREDIT",
                  "prepaid_type": "NOT_PREPAID",
                  "bin": "411111",
                  "version": 1,
                  "card_co_brand": "UNKNOWN",
                  "issuer_alert": "ISSUER_ALERT_CARD_CLOSED",
                  "issuer_alert_at": "issuer_alert_at",
                  "hsa_fsa": false
                }
              ],
              "cursor": "cursor"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/cards")
                    .WithParam("cursor", "cursor")
                    .WithParam("customer_id", "customer_id")
                    .WithParam("reference_id", "reference_id")
                    .WithParam("sort_order", "DESC")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Cards.ListAsync(
            new ListCardsRequest
            {
                Cursor = "cursor",
                CustomerId = "customer_id",
                IncludeDisabled = true,
                ReferenceId = "reference_id",
                SortOrder = SortOrder.Desc,
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
