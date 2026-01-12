using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Payments;

[Serializable]
public record CompletePaymentRequest
{
    /// <summary>
    /// The unique ID identifying the payment to be completed.
    /// </summary>
    [JsonIgnore]
    public required string PaymentId { get; set; }

    /// <summary>
    /// Used for optimistic concurrency. This opaque token identifies the current `Payment`
    /// version that the caller expects. If the server has a different version of the Payment,
    /// the update fails and a response with a VERSION_MISMATCH error is returned.
    /// </summary>
    [JsonPropertyName("version_token")]
    public string? VersionToken { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
