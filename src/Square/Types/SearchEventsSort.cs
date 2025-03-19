using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Criteria to sort events by.
/// </summary>
public record SearchEventsSort
{
    /// <summary>
    /// Sort events by event types.
    /// See [SearchEventsSortField](#type-searcheventssortfield) for possible values
    /// </summary>
    [JsonPropertyName("field")]
    public string? Field { get; set; }

    /// <summary>
    /// The order to use for sorting the events.
    /// See [SortOrder](#type-sortorder) for possible values
    /// </summary>
    [JsonPropertyName("order")]
    public SortOrder? Order { get; set; }

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
