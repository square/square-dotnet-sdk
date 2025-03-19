using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Details about a refund's destination.
/// </summary>
public record DestinationDetails
{
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
