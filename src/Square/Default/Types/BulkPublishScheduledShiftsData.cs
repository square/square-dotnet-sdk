using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents options for an individual publish request in a
/// [BulkPublishScheduledShifts](api-endpoint:Labor-BulkPublishScheduledShifts)
/// operation, provided as the value in a key-value pair.
/// </summary>
[Serializable]
public record BulkPublishScheduledShiftsData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The current version of the scheduled shift, used to enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency)
    /// control. If the provided version doesn't match the server version, the request fails.
    /// If omitted, Square executes a blind write, potentially overwriting data from another publish request.
    /// </summary>
    [JsonPropertyName("version")]
    public int? Version { get; set; }

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
