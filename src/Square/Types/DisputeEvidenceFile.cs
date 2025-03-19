using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A file to be uploaded as dispute evidence.
/// </summary>
public record DisputeEvidenceFile
{
    /// <summary>
    /// The file name including the file extension. For example: "receipt.tiff".
    /// </summary>
    [JsonPropertyName("filename")]
    public string? Filename { get; set; }

    /// <summary>
    /// Dispute evidence files must be application/pdf, image/heic, image/heif, image/jpeg, image/png, or image/tiff formats.
    /// </summary>
    [JsonPropertyName("filetype")]
    public string? Filetype { get; set; }

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
