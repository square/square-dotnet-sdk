using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Additional details about Square Account payments.
/// </summary>
public record SquareAccountDetails
{
    /// <summary>
    /// Unique identifier for the payment source used for this payment.
    /// </summary>
    [JsonPropertyName("payment_source_token")]
    public string? PaymentSourceToken { get; set; }

    /// <summary>
    /// Information about errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
