using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Customers.CustomAttributes;

[Serializable]
public record ListCustomAttributesRequest
{
    /// <summary>
    /// The ID of the target [customer profile](entity:Customer).
    /// </summary>
    [JsonIgnore]
    public required string CustomerId { get; set; }

    /// <summary>
    /// The maximum number of results to return in a single paged response. This limit is advisory.
    /// The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100.
    /// The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// The cursor returned in the paged response from the previous call to this endpoint.
    /// Provide this cursor to retrieve the next page of results for your original request. For more
    /// information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <summary>
    /// Indicates whether to return the [custom attribute definition](entity:CustomAttributeDefinition) in the `definition` field of each
    /// custom attribute. Set this parameter to `true` to get the name and description of each custom
    /// attribute, information about the data type, or other definition details. The default value is `false`.
    /// </summary>
    [JsonIgnore]
    public bool? WithDefinitions { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
