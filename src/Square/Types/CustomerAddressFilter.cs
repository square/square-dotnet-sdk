using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The customer address filter. This filter is used in a [CustomerCustomAttributeFilterValue](entity:CustomerCustomAttributeFilterValue) filter when
/// searching by an `Address`-type custom attribute.
/// </summary>
[Serializable]
public record CustomerAddressFilter : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The postal code to search for. Only an `exact` match is supported.
    /// </summary>
    [JsonPropertyName("postal_code")]
    public CustomerTextFilter? PostalCode { get; set; }

    /// <summary>
    /// The country code to search for.
    /// See [Country](#type-country) for possible values
    /// </summary>
    [JsonPropertyName("country")]
    public Country? Country { get; set; }

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
