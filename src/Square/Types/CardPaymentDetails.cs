using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Reflects the current status of a card payment. Contains only non-confidential information.
/// </summary>
public record CardPaymentDetails
{
    /// <summary>
    /// The card payment's current state. The state can be AUTHORIZED, CAPTURED, VOIDED, or
    /// FAILED.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// The credit card's non-confidential details.
    /// </summary>
    [JsonPropertyName("card")]
    public Card? Card { get; set; }

    /// <summary>
    /// The method used to enter the card's details for the payment. The method can be
    /// `KEYED`, `SWIPED`, `EMV`, `ON_FILE`, or `CONTACTLESS`.
    /// </summary>
    [JsonPropertyName("entry_method")]
    public string? EntryMethod { get; set; }

    /// <summary>
    /// The status code returned from the Card Verification Value (CVV) check. The code can be
    /// `CVV_ACCEPTED`, `CVV_REJECTED`, or `CVV_NOT_CHECKED`.
    /// </summary>
    [JsonPropertyName("cvv_status")]
    public string? CvvStatus { get; set; }

    /// <summary>
    /// The status code returned from the Address Verification System (AVS) check. The code can be
    /// `AVS_ACCEPTED`, `AVS_REJECTED`, or `AVS_NOT_CHECKED`.
    /// </summary>
    [JsonPropertyName("avs_status")]
    public string? AvsStatus { get; set; }

    /// <summary>
    /// The status code returned by the card issuer that describes the payment's
    /// authorization status.
    /// </summary>
    [JsonPropertyName("auth_result_code")]
    public string? AuthResultCode { get; set; }

    /// <summary>
    /// For EMV payments, the application ID identifies the EMV application used for the payment.
    /// </summary>
    [JsonPropertyName("application_identifier")]
    public string? ApplicationIdentifier { get; set; }

    /// <summary>
    /// For EMV payments, the human-readable name of the EMV application used for the payment.
    /// </summary>
    [JsonPropertyName("application_name")]
    public string? ApplicationName { get; set; }

    /// <summary>
    /// For EMV payments, the cryptogram generated for the payment.
    /// </summary>
    [JsonPropertyName("application_cryptogram")]
    public string? ApplicationCryptogram { get; set; }

    /// <summary>
    /// For EMV payments, the method used to verify the cardholder's identity. The method can be
    /// `PIN`, `SIGNATURE`, `PIN_AND_SIGNATURE`, `ON_DEVICE`, or `NONE`.
    /// </summary>
    [JsonPropertyName("verification_method")]
    public string? VerificationMethod { get; set; }

    /// <summary>
    /// For EMV payments, the results of the cardholder verification. The result can be
    /// `SUCCESS`, `FAILURE`, or `UNKNOWN`.
    /// </summary>
    [JsonPropertyName("verification_results")]
    public string? VerificationResults { get; set; }

    /// <summary>
    /// The statement description sent to the card networks.
    ///
    /// Note: The actual statement description varies and is likely to be truncated and appended with
    /// additional information on a per issuer basis.
    /// </summary>
    [JsonPropertyName("statement_description")]
    public string? StatementDescription { get; set; }

    /// <summary>
    /// __Deprecated__: Use `Payment.device_details` instead.
    ///
    /// Details about the device that took the payment.
    /// </summary>
    [JsonPropertyName("device_details")]
    public DeviceDetails? DeviceDetails { get; set; }

    /// <summary>
    /// The timeline for card payments.
    /// </summary>
    [JsonPropertyName("card_payment_timeline")]
    public CardPaymentTimeline? CardPaymentTimeline { get; set; }

    /// <summary>
    /// Whether the card must be physically present for the payment to
    /// be refunded.  If set to `true`, the card must be present.
    /// </summary>
    [JsonPropertyName("refund_requires_card_presence")]
    public bool? RefundRequiresCardPresence { get; set; }

    /// <summary>
    /// Information about errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

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
