using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Information about a booking creator.
/// </summary>
public record BookingCreatorDetails
{
    /// <summary>
    /// The seller-accessible type of the creator of the booking.
    /// See [BookingCreatorDetailsCreatorType](#type-bookingcreatordetailscreatortype) for possible values
    /// </summary>
    [JsonPropertyName("creator_type")]
    public BookingCreatorDetailsCreatorType? CreatorType { get; set; }

    /// <summary>
    /// The ID of the team member who created the booking, when the booking creator is of the `TEAM_MEMBER` type.
    /// Access to this field requires seller-level permissions.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("team_member_id")]
    public string? TeamMemberId { get; set; }

    /// <summary>
    /// The ID of the customer who created the booking, when the booking creator is of the `CUSTOMER` type.
    /// Access to this field requires seller-level permissions.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("customer_id")]
    public string? CustomerId { get; set; }

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
