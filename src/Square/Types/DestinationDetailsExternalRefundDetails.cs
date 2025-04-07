using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Stores details about an external refund. Contains only non-confidential information.
/// </summary>
public record DestinationDetailsExternalRefundDetails
{
    /// <summary>
    /// The type of external refund the seller paid to the buyer. It can be one of the
    /// following:
    /// - CHECK - Refunded using a physical check.
    /// - BANK_TRANSFER - Refunded using external bank transfer.
    /// - OTHER\_GIFT\_CARD - Refunded using a non-Square gift card.
    /// - CRYPTO - Refunded using a crypto currency.
    /// - SQUARE_CASH - Refunded using Square Cash App.
    /// - SOCIAL - Refunded using peer-to-peer payment applications.
    /// - EXTERNAL - A third-party application gathered this refund outside of Square.
    /// - EMONEY - Refunded using an E-money provider.
    /// - CARD - A credit or debit card that Square does not support.
    /// - STORED_BALANCE - Use for house accounts, store credit, and so forth.
    /// - FOOD_VOUCHER - Restaurant voucher provided by employers to employees to pay for meals
    /// - OTHER - A type not listed here.
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    /// <summary>
    /// A description of the external refund source. For example,
    /// "Food Delivery Service".
    /// </summary>
    [JsonPropertyName("source")]
    public required string Source { get; set; }

    /// <summary>
    /// An ID to associate the refund to its originating source.
    /// </summary>
    [JsonPropertyName("source_id")]
    public string? SourceId { get; set; }

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
