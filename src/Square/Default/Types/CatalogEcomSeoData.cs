using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// SEO data for for a seller's Square Online store.
/// </summary>
[Serializable]
public record CatalogEcomSeoData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
