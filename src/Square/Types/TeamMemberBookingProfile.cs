using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The booking profile of a seller's team member, including the team member's ID, display name, description and whether the team member can be booked as a service provider.
/// </summary>
public record TeamMemberBookingProfile
{
    /// <summary>
    /// The ID of the [TeamMember](entity:TeamMember) object for the team member associated with the booking profile.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("team_member_id")]
    public string? TeamMemberId { get; set; }

    /// <summary>
    /// The description of the team member.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The display name of the team member.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("display_name")]
    public string? DisplayName { get; set; }

    /// <summary>
    /// Indicates whether the team member can be booked through the Bookings API or the seller's online booking channel or site (`true`) or not (`false`).
    /// </summary>
    [JsonPropertyName("is_bookable")]
    public bool? IsBookable { get; set; }

    /// <summary>
    /// The URL of the team member's image for the bookings profile.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("profile_image_url")]
    public string? ProfileImageUrl { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
