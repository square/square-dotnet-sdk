using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

[Serializable]
public record CreateInvoiceAttachmentRequest
{
    /// <summary>
    /// The ID of the [invoice](entity:Invoice) to attach the file to.
    /// </summary>
    [JsonIgnore]
    public required string InvoiceId { get; set; }

    public CreateInvoiceAttachmentRequestData? Request { get; set; }

    public FileParameter? ImageFile { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
