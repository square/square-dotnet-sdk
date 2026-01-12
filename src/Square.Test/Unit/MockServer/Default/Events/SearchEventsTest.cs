using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Events;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Events;

[TestFixture]
public class SearchEventsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {}
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
              "events": [
                {
                  "merchant_id": "0HPGX5JYE6EE1",
                  "location_id": "VJDQQP3CG14EY",
                  "type": "dispute.state.updated",
                  "event_id": "73ecd468-0aba-424f-b862-583d44efe7c8",
                  "created_at": "2022-04-26T10:08:40.454Z",
                  "data": {
                    "type": "dispute",
                    "id": "ORSEVtZAJxb37RA1EiGw",
                    "object": {
                      "dispute": {
                        "amount_money": {
                          "amount": 8801,
                          "currency": "USD"
                        },
                        "brand_dispute_id": "r9rKGSBBQbywBNnWWIiGFg",
                        "card_brand": "VISA",
                        "created_at": "2020-02-19T21:24:53.258Z",
                        "disputed_payment": {
                          "payment_id": "fbmsaEOpoARDKxiSGH1fqPuqoqFZY"
                        },
                        "due_at": "2020-03-04T00:00:00.000Z",
                        "id": "ORSEVtZAJxb37RA1EiGw",
                        "location_id": "VJDQQP3CG14EY",
                        "reason": "AMOUNT_DIFFERS",
                        "reported_at": "2020-02-19T00:00:00.000Z",
                        "state": "WON",
                        "updated_at": "2020-02-19T21:34:41.851Z",
                        "version": 6
                      }
                    }
                  }
                }
              ],
              "metadata": [
                {
                  "event_id": "73ecd468-0aba-424f-b862-583d44efe7c8",
                  "api_version": "2022-12-13"
                }
              ],
              "cursor": "6b571fc9773647f="
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/events")
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

        var response = await Client.Default.Events.SearchEventsAsync(new SearchEventsRequest());
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<SearchEventsResponse>(mockResponse)).UsingDefaults()
        );
    }
}
