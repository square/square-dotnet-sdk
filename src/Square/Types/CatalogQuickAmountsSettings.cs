using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A parent Catalog Object model represents a set of Quick Amounts and the settings control the amounts.
/// </summary>
public record CatalogQuickAmountsSettings
{
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
