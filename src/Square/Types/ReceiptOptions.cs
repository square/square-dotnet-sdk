using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Describes receipt action fields.
/// </summary>
public record ReceiptOptions
{
    /// <summary>
    /// The reference to the Square payment ID for the receipt.
    /// </summary>
    [JsonPropertyName("payment_id")]
    public required string PaymentId { get; set; }

    /// <summary>
    /// Instructs the device to print the receipt without displaying the receipt selection screen.
    /// Requires `printer_enabled` set to true.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("print_only")]
    public bool? PrintOnly { get; set; }

    /// <summary>
    /// Identify the receipt as a reprint rather than an original receipt.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("is_duplicate")]
    public bool? IsDuplicate { get; set; }

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
