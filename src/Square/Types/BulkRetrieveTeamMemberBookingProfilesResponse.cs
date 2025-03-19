using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Response payload for the [BulkRetrieveTeamMemberBookingProfiles](api-endpoint:Bookings-BulkRetrieveTeamMemberBookingProfiles) endpoint.
/// </summary>
public record BulkRetrieveTeamMemberBookingProfilesResponse
{
    /// <summary>
    /// The returned team members' booking profiles, as a map with `team_member_id` as the key and [TeamMemberBookingProfile](entity:TeamMemberBookingProfile) the value.
    /// </summary>
    [JsonPropertyName("team_member_booking_profiles")]
    public Dictionary<
        string,
        GetTeamMemberBookingProfileResponse
    >? TeamMemberBookingProfiles { get; set; }

    /// <summary>
    /// Errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
