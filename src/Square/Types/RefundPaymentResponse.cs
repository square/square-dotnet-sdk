using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines the response returned by
/// [RefundPayment](api-endpoint:Refunds-RefundPayment).
///
/// If there are errors processing the request, the `refund` field might not be
/// present, or it might be present with a status of `FAILED`.
/// </summary>
public record RefundPaymentResponse
{
    /// <summary>
    /// Information about errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The successfully created `PaymentRefund`.
    /// </summary>
    [JsonPropertyName("refund")]
    public PaymentRefund? Refund { get; set; }

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
