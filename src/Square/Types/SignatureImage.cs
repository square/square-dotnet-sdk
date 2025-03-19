using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record SignatureImage
{
    /// <summary>
    /// The mime/type of the image data.
    /// Use `image/png;base64` for png.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("image_type")]
    public string? ImageType { get; set; }

    /// <summary>
    /// The base64 representation of the image.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("data")]
    public string? Data { get; set; }

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
