using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The custom attribute filter. Use this filter in a set of [custom attribute filters](entity:CustomerCustomAttributeFilters) to search
/// based on the value or last updated date of a customer-related [custom attribute](entity:CustomAttribute).
/// </summary>
public record CustomerCustomAttributeFilter
{
    /// <summary>
    /// The `key` of the [custom attribute](entity:CustomAttribute) to filter by. The key is the identifier of the custom attribute
    /// (and the corresponding custom attribute definition) and can be retrieved using the [Customer Custom Attributes API](api:CustomerCustomAttributes).
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// A filter that corresponds to the data type of the target custom attribute. For example, provide the `phone` filter to
    /// search based on the value of a `PhoneNumber`-type custom attribute. The data type is specified by the schema field of the custom attribute definition,
    /// which can be retrieved using the [Customer Custom Attributes API](api:CustomerCustomAttributes).
    ///
    /// You must provide this `filter` field, the `updated_at` field, or both.
    /// </summary>
    [JsonPropertyName("filter")]
    public CustomerCustomAttributeFilterValue? Filter { get; set; }

    /// <summary>
    /// The date range for when the custom attribute was last updated. The date range can include `start_at`, `end_at`, or
    /// both. Range boundaries are inclusive. Dates are specified as RFC 3339 timestamps.
    ///
    /// You must provide this `updated_at` field, the `filter` field, or both.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public TimeRange? UpdatedAt { get; set; }

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
