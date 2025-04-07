using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents the sorting criteria in a [search query](entity:CustomerQuery) that defines how to sort
/// customer profiles returned in [SearchCustomers](api-endpoint:Customers-SearchCustomers) results.
/// </summary>
public record CustomerSort
{
    /// <summary>
    /// Indicates the fields to use as the sort key, which is either the default set of fields or `created_at`.
    ///
    /// The default value is `DEFAULT`.
    /// See [CustomerSortField](#type-customersortfield) for possible values
    /// </summary>
    [JsonPropertyName("field")]
    public CustomerSortField? Field { get; set; }

    /// <summary>
    /// Indicates the order in which results should be sorted based on the
    /// sort field value. Strings use standard alphabetic comparison
    /// to determine order. Strings representing numbers are sorted as strings.
    ///
    /// The default value is `ASC`.
    /// See [SortOrder](#type-sortorder) for possible values
    /// </summary>
    [JsonPropertyName("order")]
    public SortOrder? Order { get; set; }

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
