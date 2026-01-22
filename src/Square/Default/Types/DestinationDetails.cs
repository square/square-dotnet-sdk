using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Details about a refund's destination.
/// </summary>
[Serializable]
public record DestinationDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Details about a card refund. Only populated if the destination_type is `CARD`.
    /// </summary>
    [JsonPropertyName("card_details")]
    public DestinationDetailsCardRefundDetails? CardDetails { get; set; }

    /// <summary>
    /// Details about a cash refund. Only populated if the destination_type is `CASH`.
    /// </summary>
    [JsonPropertyName("cash_details")]
    public DestinationDetailsCashRefundDetails? CashDetails { get; set; }

    /// <summary>
    /// Details about an external refund. Only populated if the destination_type is `EXTERNAL`.
    /// </summary>
    [JsonPropertyName("external_details")]
    public DestinationDetailsExternalRefundDetails? ExternalDetails { get; set; }

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
