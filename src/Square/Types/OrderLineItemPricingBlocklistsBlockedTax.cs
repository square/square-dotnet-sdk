using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A tax to block from applying to a line item. The tax must be
/// identified by either `tax_uid` or `tax_catalog_object_id`, but not both.
/// </summary>
public record OrderLineItemPricingBlocklistsBlockedTax
{
    /// <summary>
    /// A unique ID of the `BlockedTax` within the order.
    /// </summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>
    /// The `uid` of the tax that should be blocked. Use this field to block
    /// ad hoc taxes. For catalog, taxes use the `tax_catalog_object_id` field.
    /// </summary>
    [JsonPropertyName("tax_uid")]
    public string? TaxUid { get; set; }

    /// <summary>
    /// The `catalog_object_id` of the tax that should be blocked.
    /// Use this field to block catalog taxes. For ad hoc taxes, use the
    /// `tax_uid` field.
    /// </summary>
    [JsonPropertyName("tax_catalog_object_id")]
    public string? TaxCatalogObjectId { get; set; }

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
