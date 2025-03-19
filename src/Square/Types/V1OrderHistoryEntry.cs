using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// V1OrderHistoryEntry
/// </summary>
public record V1OrderHistoryEntry
{
    /// <summary>
    /// The type of action performed on the order.
    /// See [V1OrderHistoryEntryAction](#type-v1orderhistoryentryaction) for possible values
    /// </summary>
    [JsonPropertyName("action")]
    public V1OrderHistoryEntryAction? Action { get; set; }

    /// <summary>
    /// The time when the action was performed, in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

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
