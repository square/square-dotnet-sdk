using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The search criteria for the loyalty accounts.
/// </summary>
public record SearchLoyaltyAccountsRequestLoyaltyAccountQuery
{
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
