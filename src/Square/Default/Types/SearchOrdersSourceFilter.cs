using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// A filter based on order `source` information.
/// </summary>
[Serializable]
public record SearchOrdersSourceFilter : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Filters by the [Source](entity:OrderSource) `name`. The filter returns any orders
    /// with a `source.name` that matches any of the listed source names.
    ///
    /// Max: 10 source names.
    /// </summary>
    [JsonPropertyName("source_names")]
    public IEnumerable<string>? SourceNames { get; set; }

    /// <summary>
    /// Filters by the [Source](entity:OrderSource) `applicationId`. The filter returns any orders
    /// with a `source.applicationId` that matches any of the listed source applicationIds.
    ///
    /// Max: 100 source applicationIds.
    /// </summary>
    [JsonPropertyName("source_application_ids")]
    public IEnumerable<string>? SourceApplicationIds { get; set; }

    /// <summary>
    /// Filters by the [Source](entity:OrderSource) `clientOu`. The filter returns any orders
    /// with a `source.clientOu` that matches any of the listed source clientOus.
    ///
    /// Max: 100 source clientOus.
    /// </summary>
    [JsonPropertyName("source_client_ous")]
    public IEnumerable<string>? SourceClientOus { get; set; }

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
