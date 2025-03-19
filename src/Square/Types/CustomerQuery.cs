using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents filtering and sorting criteria for a [SearchCustomers](api-endpoint:Customers-SearchCustomers) request.
/// </summary>
public record CustomerQuery
{
    /// <summary>
    /// The filtering criteria for the search query. A query can contain multiple filters in any combination.
    /// Multiple filters are combined as `AND` statements.
    ///
    /// __Note:__ Combining multiple filters as `OR` statements is not supported. Instead, send multiple single-filter
    /// searches and join the result sets.
    /// </summary>
    [JsonPropertyName("filter")]
    public CustomerFilter? Filter { get; set; }

    /// <summary>
    /// Sorting criteria for query results. The default behavior is to sort
    /// customers alphabetically by `given_name` and `family_name`.
    /// </summary>
    [JsonPropertyName("sort")]
    public CustomerSort? Sort { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
