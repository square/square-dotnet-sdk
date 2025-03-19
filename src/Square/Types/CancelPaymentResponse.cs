using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines the response returned by [CancelPayment](api-endpoint:Payments-CancelPayment).
/// </summary>
public record CancelPaymentResponse
{
    /// <summary>
    /// Information about errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The successfully canceled `Payment` object.
    /// </summary>
    [JsonPropertyName("payment")]
    public Payment? Payment { get; set; }

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
