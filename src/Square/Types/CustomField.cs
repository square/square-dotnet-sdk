using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Describes a custom form field to add to the checkout page to collect more information from buyers during checkout.
/// For more information,
/// see [Specify checkout options](https://developer.squareup.com/docs/checkout-api/optional-checkout-configurations#specify-checkout-options-1).
/// </summary>
[Serializable]
public record CustomField : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The title of the custom field.
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; set; }

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
