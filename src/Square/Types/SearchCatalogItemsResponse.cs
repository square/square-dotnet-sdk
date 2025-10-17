using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines the response body returned from the [SearchCatalogItems](api-endpoint:Catalog-SearchCatalogItems) endpoint.
/// </summary>
[Serializable]
public record SearchCatalogItemsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
