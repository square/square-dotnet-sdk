using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Details about the application that took the payment.
/// </summary>
[Serializable]
public record ApplicationDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The Square product, such as Square Point of Sale (POS),
    /// Square Invoices, or Square Virtual Terminal.
    /// See [ExternalSquareProduct](#type-externalsquareproduct) for possible values
    /// </summary>
    [JsonPropertyName("square_product")]
    public ApplicationDetailsExternalSquareProduct? SquareProduct { get; set; }

    /// <summary>
    /// The Square ID assigned to the application used to take the payment.
    /// Application developers can use this information to identify payments that
    /// their application processed.
    /// For example, if a developer uses a custom application to process payments,
    /// this field contains the application ID from the Developer Dashboard.
    /// If a seller uses a [Square App Marketplace](https://developer.squareup.com/docs/app-marketplace)
    /// application to process payments, the field contains the corresponding application ID.
    /// </summary>
    [JsonPropertyName("application_id")]
    public string? ApplicationId { get; set; }

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
