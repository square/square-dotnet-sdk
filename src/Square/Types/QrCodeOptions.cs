using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Fields to describe the action that displays QR-Codes.
/// </summary>
public record QrCodeOptions
{
    /// <summary>
    /// The title text to display in the QR code flow on the Terminal.
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    /// <summary>
    /// The body text to display in the QR code flow on the Terminal.
    /// </summary>
    [JsonPropertyName("body")]
    public required string Body { get; set; }

    /// <summary>
    /// The text representation of the data to show in the QR code
    /// as UTF8-encoded data.
    /// </summary>
    [JsonPropertyName("barcode_contents")]
    public required string BarcodeContents { get; set; }

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
