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
public record CustomerCreationSourceFilter
{
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
