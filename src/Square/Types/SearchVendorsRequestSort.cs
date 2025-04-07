using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines a sorter used to sort results from [SearchVendors](api-endpoint:Vendors-SearchVendors).
/// </summary>
public record SearchVendorsRequestSort
{
    /// <summary>
    /// Specifies the sort key to sort the returned vendors.
    /// See [Field](#type-field) for possible values
    /// </summary>
    [JsonPropertyName("field")]
    public SearchVendorsRequestSortField? Field { get; set; }

    /// <summary>
    /// Specifies the sort order for the returned vendors.
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
