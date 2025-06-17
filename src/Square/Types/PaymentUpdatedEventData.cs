using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record PaymentUpdatedEventData
{
    /// <summary>
    /// Name of the affected object’s type, `"payment"`.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// ID of the affected payment.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// An object containing the updated payment.
    /// </summary>
    [JsonPropertyName("object")]
    public PaymentUpdatedEventObject? Object { get; set; }

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
