using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Describes receipt action fields.
/// </summary>
[Serializable]
public record ReceiptOptions : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
