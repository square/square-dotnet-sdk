using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The customer address filter. This filter is used in a [CustomerCustomAttributeFilterValue](entity:CustomerCustomAttributeFilterValue) filter when
/// searching by an `Address`-type custom attribute.
/// </summary>
public record CustomerAddressFilter
{
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

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
