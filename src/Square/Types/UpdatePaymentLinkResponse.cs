using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record UpdatePaymentLinkResponse
{
    /// <summary>
    /// Any errors that occurred when updating the payment link.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The updated payment link.
    /// </summary>
    [JsonPropertyName("payment_link")]
    public PaymentLink? PaymentLink { get; set; }

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
