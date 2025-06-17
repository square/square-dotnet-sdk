using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record InvoicePaymentMadeEventData
{
    /// <summary>
    /// Name of the affected object’s type, `"invoice"`.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// ID of the affected invoice.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// An object containing the invoice that was paid.
    /// </summary>
    [JsonPropertyName("object")]
    public InvoicePaymentMadeEventObject? Object { get; set; }

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
