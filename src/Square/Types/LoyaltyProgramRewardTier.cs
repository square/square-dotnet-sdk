using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a reward tier in a loyalty program. A reward tier defines how buyers can redeem points for a reward, such as the number of points required and the value and scope of the discount. A loyalty program can offer multiple reward tiers.
/// </summary>
public record LoyaltyProgramRewardTier
{
    /// <summary>
    /// The Square-assigned ID of the reward tier.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The points exchanged for the reward tier.
    /// </summary>
    [JsonPropertyName("points")]
    public required int Points { get; set; }

    /// <summary>
    /// The name of the reward tier.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Provides details about the reward tier definition.
    /// DEPRECATED at version 2020-12-16. Replaced by the `pricing_rule_reference` field.
    /// </summary>
    [JsonPropertyName("definition")]
    public LoyaltyProgramRewardDefinition? Definition { get; set; }

    /// <summary>
    /// The timestamp when the reward tier was created, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// A reference to the specific version of a `PRICING_RULE` catalog object that contains information about the reward tier discount.
    ///
    /// Use `object_id` and `catalog_version` with the [RetrieveCatalogObject](api-endpoint:Catalog-RetrieveCatalogObject) endpoint
    /// to get discount details. Make sure to set `include_related_objects` to true in the request to retrieve all catalog objects
    /// that define the discount. For more information, see [Getting discount details for a reward tier](https://developer.squareup.com/docs/loyalty-api/loyalty-rewards#get-discount-details).
    /// </summary>
    [JsonPropertyName("pricing_rule_reference")]
    public required CatalogObjectReference PricingRuleReference { get; set; }

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
