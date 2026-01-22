using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents a Square customer profile in the Customer Directory of a Square seller.
/// </summary>
[Serializable]
public record Customer : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A unique Square-assigned ID for the customer profile.
    ///
    /// If you need this ID for an API request, use the ID returned when you created the customer profile or call the [SearchCustomers](api-endpoint:Customers-SearchCustomers)
    /// or [ListCustomers](api-endpoint:Customers-ListCustomers) endpoint.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The timestamp when the customer profile was created, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The timestamp when the customer profile was last updated, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

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
    /// A nickname for the customer profile.
    /// </summary>
    [JsonPropertyName("nickname")]
    public string? Nickname { get; set; }

    /// <summary>
    /// A business name associated with the customer profile.
    /// </summary>
    [JsonPropertyName("company_name")]
    public string? CompanyName { get; set; }

    /// <summary>
    /// The email address associated with the customer profile.
    /// </summary>
    [JsonPropertyName("email_address")]
    public string? EmailAddress { get; set; }

    /// <summary>
    /// The physical address associated with the customer profile.
    /// </summary>
    [JsonPropertyName("address")]
    public Address? Address { get; set; }

    /// <summary>
    /// The phone number associated with the customer profile.
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// The birthday associated with the customer profile, in `YYYY-MM-DD` format. For example, `1998-09-21`
    /// represents September 21, 1998, and `0000-09-21` represents September 21 (without a birth year).
    /// </summary>
    [JsonPropertyName("birthday")]
    public string? Birthday { get; set; }

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
    /// Represents general customer preferences.
    /// </summary>
    [JsonPropertyName("preferences")]
    public CustomerPreferences? Preferences { get; set; }

    /// <summary>
    /// The method used to create the customer profile.
    /// See [CustomerCreationSource](#type-customercreationsource) for possible values
    /// </summary>
    [JsonPropertyName("creation_source")]
    public CustomerCreationSource? CreationSource { get; set; }

    /// <summary>
    /// The IDs of [customer groups](entity:CustomerGroup) the customer belongs to.
    /// </summary>
    [JsonPropertyName("group_ids")]
    public IEnumerable<string>? GroupIds { get; set; }

    /// <summary>
    /// The IDs of [customer segments](entity:CustomerSegment) the customer belongs to.
    /// </summary>
    [JsonPropertyName("segment_ids")]
    public IEnumerable<string>? SegmentIds { get; set; }

    /// <summary>
    /// The Square-assigned version number of the customer profile. The version number is incremented each time an update is committed to the customer profile, except for changes to customer segment membership.
    /// </summary>
    [JsonPropertyName("version")]
    public long? Version { get; set; }

    /// <summary>
    /// The tax ID associated with the customer profile. This field is present only for customers of sellers in EU countries or the United Kingdom.
    /// For more information, see [Customer tax IDs](https://developer.squareup.com/docs/customers-api/what-it-does#customer-tax-ids).
    /// </summary>
    [JsonPropertyName("tax_ids")]
    public CustomerTaxIds? TaxIds { get; set; }

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
