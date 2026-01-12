using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents a snapshot of customer data. This object stores customer data that is displayed on the invoice
/// and that Square uses to deliver the invoice.
///
/// When you provide a customer ID for a draft invoice, Square retrieves the associated customer profile and populates
/// the remaining `InvoiceRecipient` fields. You cannot update these fields after the invoice is published.
/// Square updates the customer ID in response to a merge operation, but does not update other fields.
/// </summary>
[Serializable]
public record InvoiceRecipient : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the customer. This is the customer profile ID that
    /// you provide when creating a draft invoice.
    /// </summary>
    [JsonPropertyName("customer_id")]
    public string? CustomerId { get; set; }

    /// <summary>
    /// The recipient's given (that is, first) name.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("given_name")]
    public string? GivenName { get; set; }

    /// <summary>
    /// The recipient's family (that is, last) name.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("family_name")]
    public string? FamilyName { get; set; }

    /// <summary>
    /// The recipient's email address.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("email_address")]
    public string? EmailAddress { get; set; }

    /// <summary>
    /// The recipient's physical address.
    /// </summary>
    [JsonPropertyName("address")]
    public Address? Address { get; set; }

    /// <summary>
    /// The recipient's phone number.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// The name of the recipient's company.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("company_name")]
    public string? CompanyName { get; set; }

    /// <summary>
    /// The recipient's tax IDs. The country of the seller account determines whether this field
    /// is available for the customer. For more information, see [Invoice recipient tax IDs](https://developer.squareup.com/docs/invoices-api/overview#recipient-tax-ids).
    /// </summary>
    [JsonPropertyName("tax_ids")]
    public InvoiceRecipientTaxIds? TaxIds { get; set; }

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
