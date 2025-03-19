using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record CheckoutLocationSettingsCoupons
{
    /// <summary>
    /// Indicates whether coupons are enabled for this location.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

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
