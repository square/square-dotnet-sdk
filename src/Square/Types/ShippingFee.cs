using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record ShippingFee
{
    /// <summary>
    /// The name for the shipping fee.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The amount and currency for the shipping fee.
    /// </summary>
    [JsonPropertyName("charge")]
    public required Money Charge { get; set; }

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
