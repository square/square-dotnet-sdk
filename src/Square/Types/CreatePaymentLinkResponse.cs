using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record CreatePaymentLinkResponse
{
    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The created payment link.
    /// </summary>
    [JsonPropertyName("payment_link")]
    public PaymentLink? PaymentLink { get; set; }

    /// <summary>
    /// The list of related objects.
    /// </summary>
    [JsonPropertyName("related_resources")]
    public PaymentLinkRelatedResources? RelatedResources { get; set; }

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
