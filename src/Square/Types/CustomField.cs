using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Describes a custom form field to add to the checkout page to collect more information from buyers during checkout.
/// For more information,
/// see [Specify checkout options](https://developer.squareup.com/docs/checkout-api/optional-checkout-configurations#specify-checkout-options-1).
/// </summary>
public record CustomField
{
    /// <summary>
    /// The title of the custom field.
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; set; }

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
