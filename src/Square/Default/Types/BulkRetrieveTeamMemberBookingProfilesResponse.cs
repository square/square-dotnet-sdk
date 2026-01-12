using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Response payload for the [BulkRetrieveTeamMemberBookingProfiles](api-endpoint:Bookings-BulkRetrieveTeamMemberBookingProfiles) endpoint.
/// </summary>
[Serializable]
public record BulkRetrieveTeamMemberBookingProfilesResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
