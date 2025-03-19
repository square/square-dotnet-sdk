using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// SEO data for for a seller's Square Online store.
/// </summary>
public record CatalogEcomSeoData
{
    /// <summary>
    /// The SEO title used for the Square Online store.
    /// </summary>
    [JsonPropertyName("page_title")]
    public string? PageTitle { get; set; }

    /// <summary>
    /// The SEO description used for the Square Online store.
    /// </summary>
    [JsonPropertyName("page_description")]
    public string? PageDescription { get; set; }

    /// <summary>
    /// The SEO permalink used for the Square Online store.
    /// </summary>
    [JsonPropertyName("permalink")]
    public string? Permalink { get; set; }

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
