using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// A parent Catalog Object model represents a set of Quick Amounts and the settings control the amounts.
/// </summary>
[Serializable]
public record CatalogQuickAmountsSettings : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Represents the option seller currently uses on Quick Amounts.
    /// See [CatalogQuickAmountsSettingsOption](#type-catalogquickamountssettingsoption) for possible values
    /// </summary>
    [JsonPropertyName("option")]
    public required CatalogQuickAmountsSettingsOption Option { get; set; }

    /// <summary>
    /// Represents location's eligibility for auto amounts
    /// The boolean should be consistent with whether there are AUTO amounts in the `amounts`.
    /// </summary>
    [JsonPropertyName("eligible_for_auto_amounts")]
    public bool? EligibleForAutoAmounts { get; set; }

    /// <summary>
    /// Represents a set of Quick Amounts at this location.
    /// </summary>
    [JsonPropertyName("amounts")]
    public IEnumerable<CatalogQuickAmount>? Amounts { get; set; }

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
