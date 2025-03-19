using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A discount to block from applying to a line item. The discount must be
/// identified by either `discount_uid` or `discount_catalog_object_id`, but not both.
/// </summary>
public record OrderLineItemPricingBlocklistsBlockedDiscount
{
    /// <summary>
    /// A unique ID of the `BlockedDiscount` within the order.
    /// </summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>
    /// The `uid` of the discount that should be blocked. Use this field to block
    /// ad hoc discounts. For catalog discounts, use the `discount_catalog_object_id` field.
    /// </summary>
    [JsonPropertyName("discount_uid")]
    public string? DiscountUid { get; set; }

    /// <summary>
    /// The `catalog_object_id` of the discount that should be blocked.
    /// Use this field to block catalog discounts. For ad hoc discounts, use the
    /// `discount_uid` field.
    /// </summary>
    [JsonPropertyName("discount_catalog_object_id")]
    public string? DiscountCatalogObjectId { get; set; }

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
