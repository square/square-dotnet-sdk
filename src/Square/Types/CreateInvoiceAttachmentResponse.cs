using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a [CreateInvoiceAttachment](api-endpoint:Invoices-CreateInvoiceAttachment) response.
/// </summary>
public record CreateInvoiceAttachmentResponse
{
    /// <summary>
    /// Metadata about the attachment that was added to the invoice.
    /// </summary>
    [JsonPropertyName("attachment")]
    public InvoiceAttachment? Attachment { get; set; }

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
