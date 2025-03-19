using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Invoices;

public record DeleteInvoiceAttachmentRequest
{
    /// <summary>
    /// The ID of the [invoice](entity:Invoice) to delete the attachment from.
    /// </summary>
    [JsonIgnore]
    public required string InvoiceId { get; set; }

    /// <summary>
    /// The ID of the [attachment](entity:InvoiceAttachment) to delete.
    /// </summary>
    [JsonIgnore]
    public required string AttachmentId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
