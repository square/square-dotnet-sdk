using NUnit.Framework;
using Square;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Bookings;

[TestFixture]
public class GetBusinessProfileTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "business_booking_profile": {
                "seller_id": "MLJQYZZRM0D3Y",
                "created_at": "2020-09-10T21:40:38.000Z",
                "booking_enabled": true,
                "customer_timezone_choice": "CUSTOMER_CHOICE",
                "booking_policy": "ACCEPT_ALL",
                "allow_user_cancel": true,
                "business_appointment_settings": {
                  "location_types": [
                    "BUSINESS_LOCATION"
                  ],
                  "alignment_time": "HALF_HOURLY",
                  "min_booking_lead_time_seconds": 0,
                  "max_booking_lead_time_seconds": 31536000,
                  "any_team_member_booking_enabled": true,
                  "multiple_service_booking_enabled": true,
                  "max_appointments_per_day_limit_type": "PER_TEAM_MEMBER",
                  "max_appointments_per_day_limit": 1,
                  "cancellation_window_seconds": 1,
                  "cancellation_fee_money": {
                    "currency": "USD"
                  },
                  "cancellation_policy": "CUSTOM_POLICY",
                  "cancellation_policy_text": "cancellation_policy_text",
                  "skip_booking_flow_staff_selection": false
                },
                "support_seller_level_writes": true
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
                    .WithPath("/v2/bookings/business-booking-profile")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Bookings.GetBusinessProfileAsync();
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetBusinessBookingProfileResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
