using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record ListTeamMemberBookingProfilesResponse
{
    /// <summary>
    /// The list of team member booking profiles. The results are returned in the ascending order of the time
    /// when the team member booking profiles were last updated. Multiple booking profiles updated at the same time
    /// are further sorted in the ascending order of their IDs.
    /// </summary>
    [JsonPropertyName("team_member_booking_profiles")]
    public IEnumerable<TeamMemberBookingProfile>? TeamMemberBookingProfiles { get; set; }

    /// <summary>
    /// The pagination cursor to be used in the subsequent request to get the next page of the results. Stop retrieving the next page of the results when the cursor is not set.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

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
