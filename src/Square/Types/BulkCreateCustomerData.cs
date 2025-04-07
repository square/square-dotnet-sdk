using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines the customer data provided in individual create requests for a
/// [BulkCreateCustomers](api-endpoint:Customers-BulkCreateCustomers) operation.
/// </summary>
public record BulkCreateCustomerData
{
    /// <summary>
    /// The given name (that is, the first name) associated with the customer profile.
    /// </summary>
    [JsonPropertyName("given_name")]
    public string? GivenName { get; set; }

    /// <summary>
    /// The family name (that is, the last name) associated with the customer profile.
    /// </summary>
    [JsonPropertyName("family_name")]
    public string? FamilyName { get; set; }

    /// <summary>
    /// A business name associated with the customer profile.
    /// </summary>
    [JsonPropertyName("company_name")]
    public string? CompanyName { get; set; }

    /// <summary>
    /// A nickname for the customer profile.
    /// </summary>
    [JsonPropertyName("nickname")]
    public string? Nickname { get; set; }

    /// <summary>
    /// The email address associated with the customer profile.
    /// </summary>
    [JsonPropertyName("email_address")]
    public string? EmailAddress { get; set; }

    /// <summary>
    /// The physical address associated with the customer profile. For maximum length constraints,
    /// see [Customer addresses](https://developer.squareup.com/docs/customers-api/use-the-api/keep-records#address).
    /// The `first_name` and `last_name` fields are ignored if they are present in the request.
    /// </summary>
    [JsonPropertyName("address")]
    public Address? Address { get; set; }

    /// <summary>
    /// The phone number associated with the customer profile. The phone number must be valid
    /// and can contain 9–16 digits, with an optional `+` prefix and country code. For more information,
    /// see [Customer phone numbers](https://developer.squareup.com/docs/customers-api/use-the-api/keep-records#phone-number).
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// An optional second ID used to associate the customer profile with an
    /// entity in another system.
    /// </summary>
    [JsonPropertyName("reference_id")]
    public string? ReferenceId { get; set; }

    /// <summary>
    /// A custom note associated with the customer profile.
    /// </summary>
    [JsonPropertyName("note")]
    public string? Note { get; set; }

    /// <summary>
    /// The birthday associated with the customer profile, in `YYYY-MM-DD` or `MM-DD` format.
    /// For example, specify `1998-09-21` for September 21, 1998, or `09-21` for September 21.
    /// Birthdays are returned in `YYYY-MM-DD` format, where `YYYY` is the specified birth year or
    /// `0000` if a birth year is not specified.
    /// </summary>
    [JsonPropertyName("birthday")]
    public string? Birthday { get; set; }

    /// <summary>
    /// The tax ID associated with the customer profile. This field is available only for
    /// customers of sellers in EU countries or the United Kingdom. For more information, see
    /// [Customer tax IDs](https://developer.squareup.com/docs/customers-api/what-it-does#customer-tax-ids).
    /// </summary>
    [JsonPropertyName("tax_ids")]
    public CustomerTaxIds? TaxIds { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
