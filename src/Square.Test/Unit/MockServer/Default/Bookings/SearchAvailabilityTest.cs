using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Bookings;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Bookings;

[TestFixture]
public class SearchAvailabilityTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "query": {
                "filter": {
                  "start_at_range": {}
                }
              }
            }
            """;

        const string mockResponse = """
            {
              "availabilities": [
                {
                  "start_at": "2020-11-26T13:00:00.000Z",
                  "location_id": "LEQHH0YY8B42M",
                  "appointment_segments": [
                    {
                      "duration_minutes": 60,
                      "service_variation_id": "RU3PBTZTK7DXZDQFCJHOK2MC",
                      "team_member_id": "TMXUrsBWWcHTt79t",
                      "service_variation_version": 1599775456731
                    }
                  ]
                },
                {
                  "start_at": "2020-11-26T13:30:00.000Z",
                  "location_id": "LEQHH0YY8B42M",
                  "appointment_segments": [
                    {
                      "duration_minutes": 60,
                      "service_variation_id": "RU3PBTZTK7DXZDQFCJHOK2MC",
                      "team_member_id": "TMXUrsBWWcHTt79t",
                      "service_variation_version": 1599775456731
                    }
                  ]
                },
                {
                  "start_at": "2020-11-26T14:00:00.000Z",
                  "location_id": "LEQHH0YY8B42M",
                  "appointment_segments": [
                    {
                      "duration_minutes": 60,
                      "service_variation_id": "RU3PBTZTK7DXZDQFCJHOK2MC",
                      "team_member_id": "TMaJcbiRqPIGZuS9",
                      "service_variation_version": 1599775456731
                    }
                  ]
                },
                {
                  "start_at": "2020-11-26T14:30:00.000Z",
                  "location_id": "LEQHH0YY8B42M",
                  "appointment_segments": [
                    {
                      "duration_minutes": 60,
                      "service_variation_id": "RU3PBTZTK7DXZDQFCJHOK2MC",
                      "team_member_id": "TMaJcbiRqPIGZuS9",
                      "service_variation_version": 1599775456731
                    }
                  ]
                },
                {
                  "start_at": "2020-11-26T15:00:00.000Z",
                  "location_id": "LEQHH0YY8B42M",
                  "appointment_segments": [
                    {
                      "duration_minutes": 60,
                      "service_variation_id": "RU3PBTZTK7DXZDQFCJHOK2MC",
                      "team_member_id": "TMaJcbiRqPIGZuS9",
                      "service_variation_version": 1599775456731
                    }
                  ]
                },
                {
                  "start_at": "2020-11-26T15:30:00.000Z",
                  "location_id": "LEQHH0YY8B42M",
                  "appointment_segments": [
                    {
                      "duration_minutes": 60,
                      "service_variation_id": "RU3PBTZTK7DXZDQFCJHOK2MC",
                      "team_member_id": "TMaJcbiRqPIGZuS9",
                      "service_variation_version": 1599775456731
                    }
                  ]
                },
                {
                  "start_at": "2020-11-26T16:00:00.000Z",
                  "location_id": "LEQHH0YY8B42M",
                  "appointment_segments": [
                    {
                      "duration_minutes": 60,
                      "service_variation_id": "RU3PBTZTK7DXZDQFCJHOK2MC",
                      "team_member_id": "TMaJcbiRqPIGZuS9",
                      "service_variation_version": 1599775456731
                    }
                  ]
                },
                {
                  "start_at": "2020-11-27T09:00:00.000Z",
                  "location_id": "LEQHH0YY8B42M",
                  "appointment_segments": [
                    {
                      "duration_minutes": 60,
                      "service_variation_id": "RU3PBTZTK7DXZDQFCJHOK2MC",
                      "team_member_id": "TMXUrsBWWcHTt79t",
                      "service_variation_version": 1599775456731
                    }
                  ]
                },
                {
                  "start_at": "2020-11-27T09:30:00.000Z",
                  "location_id": "LEQHH0YY8B42M",
                  "appointment_segments": [
                    {
                      "duration_minutes": 60,
                      "service_variation_id": "RU3PBTZTK7DXZDQFCJHOK2MC",
                      "team_member_id": "TMaJcbiRqPIGZuS9",
                      "service_variation_version": 1599775456731
                    }
                  ]
                },
                {
                  "start_at": "2020-11-27T10:00:00.000Z",
                  "location_id": "LEQHH0YY8B42M",
                  "appointment_segments": [
                    {
                      "duration_minutes": 60,
                      "service_variation_id": "RU3PBTZTK7DXZDQFCJHOK2MC",
                      "team_member_id": "TMXUrsBWWcHTt79t",
                      "service_variation_version": 1599775456731
                    }
                  ]
                },
                {
                  "start_at": "2020-11-27T10:30:00.000Z",
                  "location_id": "LEQHH0YY8B42M",
                  "appointment_segments": [
                    {
                      "duration_minutes": 60,
                      "service_variation_id": "RU3PBTZTK7DXZDQFCJHOK2MC",
                      "team_member_id": "TMXUrsBWWcHTt79t",
                      "service_variation_version": 1599775456731
                    }
                  ]
                },
                {
                  "start_at": "2020-11-27T11:00:00.000Z",
                  "location_id": "LEQHH0YY8B42M",
                  "appointment_segments": [
                    {
                      "duration_minutes": 60,
                      "service_variation_id": "RU3PBTZTK7DXZDQFCJHOK2MC",
                      "team_member_id": "TMXUrsBWWcHTt79t",
                      "service_variation_version": 1599775456731
                    }
                  ]
                },
                {
                  "start_at": "2020-11-27T11:30:00.000Z",
                  "location_id": "LEQHH0YY8B42M",
                  "appointment_segments": [
                    {
                      "duration_minutes": 60,
                      "service_variation_id": "RU3PBTZTK7DXZDQFCJHOK2MC",
                      "team_member_id": "TMaJcbiRqPIGZuS9",
                      "service_variation_version": 1599775456731
                    }
                  ]
                },
                {
                  "start_at": "2020-11-27T12:00:00.000Z",
                  "location_id": "LEQHH0YY8B42M",
                  "appointment_segments": [
                    {
                      "duration_minutes": 60,
                      "service_variation_id": "RU3PBTZTK7DXZDQFCJHOK2MC",
                      "team_member_id": "TMaJcbiRqPIGZuS9",
                      "service_variation_version": 1599775456731
                    }
                  ]
                },
                {
                  "start_at": "2020-11-27T12:30:00.000Z",
                  "location_id": "LEQHH0YY8B42M",
                  "appointment_segments": [
                    {
                      "duration_minutes": 60,
                      "service_variation_id": "RU3PBTZTK7DXZDQFCJHOK2MC",
                      "team_member_id": "TMaJcbiRqPIGZuS9",
                      "service_variation_version": 1599775456731
                    }
                  ]
                },
                {
                  "start_at": "2020-11-27T13:00:00.000Z",
                  "location_id": "LEQHH0YY8B42M",
                  "appointment_segments": [
                    {
                      "duration_minutes": 60,
                      "service_variation_id": "RU3PBTZTK7DXZDQFCJHOK2MC",
                      "team_member_id": "TMXUrsBWWcHTt79t",
                      "service_variation_version": 1599775456731
                    }
                  ]
                },
                {
                  "start_at": "2020-11-27T13:30:00.000Z",
                  "location_id": "LEQHH0YY8B42M",
                  "appointment_segments": [
                    {
                      "duration_minutes": 60,
                      "service_variation_id": "RU3PBTZTK7DXZDQFCJHOK2MC",
                      "team_member_id": "TMXUrsBWWcHTt79t",
                      "service_variation_version": 1599775456731
                    }
                  ]
                },
                {
                  "start_at": "2020-11-27T14:00:00.000Z",
                  "location_id": "LEQHH0YY8B42M",
                  "appointment_segments": [
                    {
                      "duration_minutes": 60,
                      "service_variation_id": "RU3PBTZTK7DXZDQFCJHOK2MC",
                      "team_member_id": "TMaJcbiRqPIGZuS9",
                      "service_variation_version": 1599775456731
                    }
                  ]
                }
              ],
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
                    .WithPath("/v2/bookings/availability/search")
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

        var response = await Client.Default.Bookings.SearchAvailabilityAsync(
            new SearchAvailabilityRequest
            {
                Query = new SearchAvailabilityQuery
                {
                    Filter = new SearchAvailabilityFilter { StartAtRange = new TimeRange() },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<SearchAvailabilityResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
