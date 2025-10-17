using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// V1OrderHistoryEntry
/// </summary>
[Serializable]
public record V1OrderHistoryEntry : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
