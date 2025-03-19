using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A query filter to search for buyer-accessible appointment segments by.
/// </summary>
public record SegmentFilter
{
    /// <summary>
    /// The ID of the [CatalogItemVariation](entity:CatalogItemVariation) object representing the service booked in this segment.
    /// </summary>
    [JsonPropertyName("service_variation_id")]
    public required string ServiceVariationId { get; set; }

    /// <summary>
    /// A query filter to search for buyer-accessible appointment segments with service-providing team members matching the specified list of team member IDs.  Supported query expressions are
    /// - `ANY`: return the appointment segments with team members whose IDs match any member in this list.
    /// - `NONE`: return the appointment segments with team members whose IDs are not in this list.
    /// - `ALL`: not supported.
    ///
    /// When no expression is specified, any service-providing team member is eligible to fulfill the Booking.
    /// </summary>
    [JsonPropertyName("team_member_id_filter")]
    public FilterValue? TeamMemberIdFilter { get; set; }

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
