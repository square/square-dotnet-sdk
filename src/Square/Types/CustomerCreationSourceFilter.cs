using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The creation source filter.
///
/// If one or more creation sources are set, customer profiles are included in,
/// or excluded from, the result if they match at least one of the filter criteria.
/// </summary>
[Serializable]
public record CustomerCreationSourceFilter : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The list of creation sources used as filtering criteria.
    /// See [CustomerCreationSource](#type-customercreationsource) for possible values
    /// </summary>
    [JsonPropertyName("values")]
    public IEnumerable<CustomerCreationSource>? Values { get; set; }

    /// <summary>
    /// Indicates whether a customer profile matching the filter criteria
    /// should be included in the result or excluded from the result.
    ///
    /// Default: `INCLUDE`.
    /// See [CustomerInclusionExclusion](#type-customerinclusionexclusion) for possible values
    /// </summary>
    [JsonPropertyName("rule")]
    public CustomerInclusionExclusion? Rule { get; set; }

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
