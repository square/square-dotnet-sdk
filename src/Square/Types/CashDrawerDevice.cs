using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record CashDrawerDevice
{
    /// <summary>
    /// The device Square-issued ID
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The device merchant-specified name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

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
