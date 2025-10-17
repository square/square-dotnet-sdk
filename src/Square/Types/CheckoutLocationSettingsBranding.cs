using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[Serializable]
public record CheckoutLocationSettingsBranding : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
