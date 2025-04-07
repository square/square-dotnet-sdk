using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a file attached to an [invoice](entity:Invoice).
/// </summary>
public record InvoiceAttachment
{
    /// <summary>
    /// The Square-assigned ID of the attachment.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The file name of the attachment, which is displayed on the invoice.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("filename")]
    public string? Filename { get; set; }

    /// <summary>
    /// The description of the attachment, which is displayed on the invoice.
    /// This field maps to the seller-defined **Message** field.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The file size of the attachment in bytes.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("filesize")]
    public int? Filesize { get; set; }

    /// <summary>
    /// The MD5 hash that was generated from the file contents.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("hash")]
    public string? Hash { get; set; }

    /// <summary>
    /// The mime type of the attachment.
    /// The following mime types are supported:
    /// image/gif, image/jpeg, image/png, image/tiff, image/bmp, application/pdf.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("mime_type")]
    public string? MimeType { get; set; }

    /// <summary>
    /// The timestamp when the attachment was uploaded, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("uploaded_at")]
    public string? UploadedAt { get; set; }

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
