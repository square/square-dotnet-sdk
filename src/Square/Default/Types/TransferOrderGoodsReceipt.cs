using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// The goods receipt details for a transfer order. This object represents a single receipt
/// of goods against a transfer order, tracking:
///
/// - Which [CatalogItemVariation](entity:CatalogItemVariation)s were received
/// - Quantities received in good condition
/// - Quantities damaged during transit/handling
/// - Quantities canceled during receipt
///
/// Multiple goods receipts can be created for a single transfer order to handle:
/// - Partial deliveries
/// - Multiple shipments
/// - Split receipts across different dates
/// - Cancellations of specific quantities
///
/// Each receipt automatically:
/// - Updates the transfer order status
/// - Adjusts received quantities
/// - Updates inventory levels at both source and destination [Location](entity:Location)s
/// </summary>
[Serializable]
public record TransferOrderGoodsReceipt : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Line items being received. Each line item specifies:
    /// - The item being received
    /// - Quantity received in good condition
    /// - Quantity received damaged
    /// - Quantity canceled
    ///
    /// Constraints:
    /// - Must include at least one line item
    /// - Maximum of 1000 line items per receipt
    /// - Each line item must reference a valid item from the transfer order
    /// - Total of received, damaged, and canceled quantities cannot exceed ordered quantity
    /// </summary>
    [JsonPropertyName("line_items")]
    public IEnumerable<TransferOrderGoodsReceiptLineItem>? LineItems { get; set; }

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
