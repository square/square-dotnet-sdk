using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// An additional seller-defined and customer-facing field to include on the invoice. For more information,
/// see [Custom fields](https://developer.squareup.com/docs/invoices-api/overview#custom-fields).
///
/// Adding custom fields to an invoice requires an
/// [Invoices Plus subscription](https://developer.squareup.com/docs/invoices-api/overview#invoices-plus-subscription).
/// </summary>
[Serializable]
public record InvoiceCustomField : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The label or title of the custom field. This field is required for a custom field.
    /// </summary>
    [JsonPropertyName("label")]
    public string? Label { get; set; }

    /// <summary>
    /// The text of the custom field. If omitted, only the label is rendered.
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value { get; set; }

    /// <summary>
    /// The location of the custom field on the invoice. This field is required for a custom field.
    /// See [InvoiceCustomFieldPlacement](#type-invoicecustomfieldplacement) for possible values
    /// </summary>
    [JsonPropertyName("placement")]
    public InvoiceCustomFieldPlacement? Placement { get; set; }

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
