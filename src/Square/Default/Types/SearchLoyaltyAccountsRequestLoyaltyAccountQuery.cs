using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// The search criteria for the loyalty accounts.
/// </summary>
[Serializable]
public record SearchLoyaltyAccountsRequestLoyaltyAccountQuery : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The set of mappings to use in the loyalty account search.
    ///
    /// This cannot be combined with `customer_ids`.
    ///
    /// Max: 30 mappings
    /// </summary>
    [JsonPropertyName("mappings")]
    public IEnumerable<LoyaltyAccountMapping>? Mappings { get; set; }

    /// <summary>
    /// The set of customer IDs to use in the loyalty account search.
    ///
    /// This cannot be combined with `mappings`.
    ///
    /// Max: 30 customer IDs
    /// </summary>
    [JsonPropertyName("customer_ids")]
    public IEnumerable<string>? CustomerIds { get; set; }

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
