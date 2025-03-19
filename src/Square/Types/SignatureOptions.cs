using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record SignatureOptions
{
    /// <summary>
    /// The title text to display in the signature capture flow on the Terminal.
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    /// <summary>
    /// The body text to display in the signature capture flow on the Terminal.
    /// </summary>
    [JsonPropertyName("body")]
    public required string Body { get; set; }

    /// <summary>
    /// An image representation of the collected signature.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("signature")]
    public IEnumerable<SignatureImage>? Signature { get; set; }

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
