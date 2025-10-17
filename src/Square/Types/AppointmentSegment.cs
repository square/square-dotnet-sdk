using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines an appointment segment of a booking.
/// </summary>
[Serializable]
public record AppointmentSegment : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The time span in minutes of an appointment segment.
    /// </summary>
    [JsonPropertyName("duration_minutes")]
    public int? DurationMinutes { get; set; }

    /// <summary>
    /// The ID of the [CatalogItemVariation](entity:CatalogItemVariation) object representing the service booked in this segment.
    /// </summary>
    [JsonPropertyName("service_variation_id")]
    public string? ServiceVariationId { get; set; }

    /// <summary>
    /// The ID of the [TeamMember](entity:TeamMember) object representing the team member booked in this segment.
    /// </summary>
    [JsonPropertyName("team_member_id")]
    public required string TeamMemberId { get; set; }

    /// <summary>
    /// The current version of the item variation representing the service booked in this segment.
    /// </summary>
    [JsonPropertyName("service_variation_version")]
    public long? ServiceVariationVersion { get; set; }

    /// <summary>
    /// Time between the end of this segment and the beginning of the subsequent segment.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("intermission_minutes")]
    public int? IntermissionMinutes { get; set; }

    /// <summary>
    /// Whether the customer accepts any team member, instead of a specific one, to serve this segment.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("any_team_member")]
    public bool? AnyTeamMember { get; set; }

    /// <summary>
    /// The IDs of the seller-accessible resources used for this appointment segment.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("resource_ids")]
    public IEnumerable<string>? ResourceIds { get; set; }

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
