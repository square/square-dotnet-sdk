using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a Quick Amount in the Catalog.
/// </summary>
[Serializable]
public record CatalogQuickAmount : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Represents the type of the Quick Amount.
    /// See [CatalogQuickAmountType](#type-catalogquickamounttype) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public required CatalogQuickAmountType Type { get; set; }

    /// <summary>
    /// Represents the actual amount of the Quick Amount with Money type.
    /// </summary>
    [JsonPropertyName("amount")]
    public required Money Amount { get; set; }

    /// <summary>
    /// Describes the ranking of the Quick Amount provided by machine learning model, in the range [0, 100].
    /// MANUAL type amount will always have score = 100.
    /// </summary>
    [JsonPropertyName("score")]
    public long? Score { get; set; }

    /// <summary>
    /// The order in which this Quick Amount should be displayed.
    /// </summary>
    [JsonPropertyName("ordinal")]
    public long? Ordinal { get; set; }

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
