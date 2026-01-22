using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents a set of query expressions (filters) to narrow the scope of targeted subscriptions returned by
/// the [SearchSubscriptions](api-endpoint:Subscriptions-SearchSubscriptions) endpoint.
/// </summary>
[Serializable]
public record SearchSubscriptionsFilter : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A filter to select subscriptions based on the subscribing customer IDs.
    /// </summary>
    [JsonPropertyName("customer_ids")]
    public IEnumerable<string>? CustomerIds { get; set; }

    /// <summary>
    /// A filter to select subscriptions based on the location.
    /// </summary>
    [JsonPropertyName("location_ids")]
    public IEnumerable<string>? LocationIds { get; set; }

    /// <summary>
    /// A filter to select subscriptions based on the source application.
    /// </summary>
    [JsonPropertyName("source_names")]
    public IEnumerable<string>? SourceNames { get; set; }

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
