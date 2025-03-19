using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines the response body returned from the [SearchCatalogItems](api-endpoint:Catalog-SearchCatalogItems) endpoint.
/// </summary>
public record SearchCatalogItemsResponse
{
    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// Returned items matching the specified query expressions.
    /// </summary>
    [JsonPropertyName("items")]
    public IEnumerable<CatalogObject>? Items { get; set; }

    /// <summary>
    /// Pagination token used in the next request to return more of the search result.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// Ids of returned item variations matching the specified query expression.
    /// </summary>
    [JsonPropertyName("matched_variation_ids")]
    public IEnumerable<string>? MatchedVariationIds { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
