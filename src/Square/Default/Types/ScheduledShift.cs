using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents a specific time slot in a work schedule. This object is used to manage the
/// lifecycle of a scheduled shift from the draft to published state. A scheduled shift contains
/// the latest draft shift details and current published shift details.
/// </summary>
[Serializable]
public record ScheduledShift : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// **Read only** The Square-issued ID of the scheduled shift.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The latest draft shift details for the scheduled shift. Draft shift details are used to
    /// stage and manage shifts before publishing. This field is always present.
    /// </summary>
    [JsonPropertyName("draft_shift_details")]
    public ScheduledShiftDetails? DraftShiftDetails { get; set; }

    /// <summary>
    /// The current published (public) shift details for the scheduled shift. This field is
    /// present only if the shift was published.
    /// </summary>
    [JsonPropertyName("published_shift_details")]
    public ScheduledShiftDetails? PublishedShiftDetails { get; set; }

    /// <summary>
    /// **Read only** The current version of the scheduled shift, which is incremented with each update.
    /// This field is used for [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency)
    /// control to ensure that requests don't overwrite data from another request.
    /// </summary>
    [JsonPropertyName("version")]
    public int? Version { get; set; }

    /// <summary>
    /// The timestamp of when the scheduled shift was created, in RFC 3339 format presented as UTC.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The timestamp of when the scheduled shift was last updated, in RFC 3339 format presented as UTC.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

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
