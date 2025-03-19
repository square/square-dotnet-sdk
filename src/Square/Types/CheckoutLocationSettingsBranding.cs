using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record CheckoutLocationSettingsBranding
{
    /// <summary>
    /// Show the location logo on the checkout page.
    /// See [HeaderType](#type-headertype) for possible values
    /// </summary>
    [JsonPropertyName("header_type")]
    public CheckoutLocationSettingsBrandingHeaderType? HeaderType { get; set; }

    /// <summary>
    /// The HTML-supported hex color for the button on the checkout page (for example, "#FFFFFF").
    /// </summary>
    [JsonPropertyName("button_color")]
    public string? ButtonColor { get; set; }

    /// <summary>
    /// The shape of the button on the checkout page.
    /// See [ButtonShape](#type-buttonshape) for possible values
    /// </summary>
    [JsonPropertyName("button_shape")]
    public CheckoutLocationSettingsBrandingButtonShape? ButtonShape { get; set; }

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
