using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a line item update in a transfer order
/// </summary>
public record UpdateTransferOrderLineData
{
    /// <summary>
    /// Line item id being updated. Required for updating/removing existing line items, but should not be set for new line items.
    /// </summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>
    /// Catalog item variation being transferred
    ///
    /// Required for new line items, but otherwise is not updatable.
    /// </summary>
    [JsonPropertyName("item_variation_id")]
    public string? ItemVariationId { get; set; }

    /// <summary>
    /// Total quantity ordered
    /// </summary>
    [JsonPropertyName("quantity_ordered")]
    public string? QuantityOrdered { get; set; }

    /// <summary>
    /// Flag to remove the line item during update. Must include `uid` in removal request
    /// </summary>
    [JsonPropertyName("remove")]
    public bool? Remove { get; set; }

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
