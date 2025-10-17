using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Describes query filters to apply.
/// </summary>
[Serializable]
public record InvoiceFilter : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Limits the search to the specified locations. A location is required.
    /// In the current implementation, only one location can be specified.
    /// </summary>
    [JsonPropertyName("location_ids")]
    public IEnumerable<string> LocationIds { get; set; } = new List<string>();

    /// <summary>
    /// Limits the search to the specified customers, within the specified locations.
    /// Specifying a customer is optional. In the current implementation,
    /// a maximum of one customer can be specified.
    /// </summary>
    [JsonPropertyName("customer_ids")]
    public IEnumerable<string>? CustomerIds { get; set; }

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
