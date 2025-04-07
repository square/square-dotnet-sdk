using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The query filter to return the items containing the specified tax IDs.
/// </summary>
public record CatalogQueryItemsForTax
{
    /// <summary>
    /// A set of `CatalogTax` IDs to be used to find associated `CatalogItem`s.
    /// </summary>
    [JsonPropertyName("tax_ids")]
    public IEnumerable<string> TaxIds { get; set; } = new List<string>();

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
