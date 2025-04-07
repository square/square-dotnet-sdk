using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents one of a business' [locations](https://developer.squareup.com/docs/locations-api).
/// </summary>
public record Location
{
    /// <summary>
    /// A short generated string of letters and numbers that uniquely identifies this location instance.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The name of the location.
    /// This information appears in the Seller Dashboard as the nickname.
    /// A location name must be unique within a seller account.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The physical address of the location.
    /// </summary>
    [JsonPropertyName("address")]
    public Address? Address { get; set; }

    /// <summary>
    /// The [IANA time zone](https://www.iana.org/time-zones) identifier for
    /// the time zone of the location. For example, `America/Los_Angeles`.
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <summary>
    /// The Square features that are enabled for the location.
    /// See [LocationCapability](entity:LocationCapability) for possible values.
    /// See [LocationCapability](#type-locationcapability) for possible values
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("capabilities")]
    public IEnumerable<LocationCapability>? Capabilities { get; set; }

    /// <summary>
    /// The status of the location.
    /// See [LocationStatus](#type-locationstatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public LocationStatus? Status { get; set; }

    /// <summary>
    /// The time when the location was created, in RFC 3339 format.
    /// For more information, see [Working with Dates](https://developer.squareup.com/docs/build-basics/working-with-dates).
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The ID of the merchant that owns the location.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("merchant_id")]
    public string? MerchantId { get; set; }

    /// <summary>
    /// The country of the location, in the two-letter format of ISO 3166. For example, `US` or `JP`.
    ///
    /// See [Country](entity:Country) for possible values.
    /// See [Country](#type-country) for possible values
    /// </summary>
    [JsonPropertyName("country")]
    public Country? Country { get; set; }

    /// <summary>
    /// The language associated with the location, in
    /// [BCP 47 format](https://tools.ietf.org/html/bcp47#appendix-A).
    /// For more information, see [Language Preferences](https://developer.squareup.com/docs/build-basics/general-considerations/language-preferences).
    /// </summary>
    [JsonPropertyName("language_code")]
    public string? LanguageCode { get; set; }

    /// <summary>
    /// The currency used for all transactions at this location,
    /// in ISO 4217 format. For example, the currency code for US dollars is `USD`.
    /// See [Currency](entity:Currency) for possible values.
    /// See [Currency](#type-currency) for possible values
    /// </summary>
    [JsonPropertyName("currency")]
    public Currency? Currency { get; set; }

    /// <summary>
    /// The phone number of the location. For example, `+1 855-700-6000`.
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// The name of the location's overall business. This name is present on receipts and other customer-facing branding, and can be changed no more than three times in a twelve-month period.
    /// </summary>
    [JsonPropertyName("business_name")]
    public string? BusinessName { get; set; }

    /// <summary>
    /// The type of the location.
    /// See [LocationType](#type-locationtype) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public LocationType? Type { get; set; }

    /// <summary>
    /// The website URL of the location.  For example, `https://squareup.com`.
    /// </summary>
    [JsonPropertyName("website_url")]
    public string? WebsiteUrl { get; set; }

    /// <summary>
    /// The hours of operation for the location.
    /// </summary>
    [JsonPropertyName("business_hours")]
    public BusinessHours? BusinessHours { get; set; }

    /// <summary>
    /// The email address of the location. This can be unique to the location and is not always the email address for the business owner or administrator.
    /// </summary>
    [JsonPropertyName("business_email")]
    public string? BusinessEmail { get; set; }

    /// <summary>
    /// The description of the location. For example, `Main Street location`.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The Twitter username of the location without the '@' symbol. For example, `Square`.
    /// </summary>
    [JsonPropertyName("twitter_username")]
    public string? TwitterUsername { get; set; }

    /// <summary>
    /// The Instagram username of the location without the '@' symbol. For example, `square`.
    /// </summary>
    [JsonPropertyName("instagram_username")]
    public string? InstagramUsername { get; set; }

    /// <summary>
    /// The Facebook profile URL of the location. The URL should begin with 'facebook.com/'. For example, `https://www.facebook.com/square`.
    /// </summary>
    [JsonPropertyName("facebook_url")]
    public string? FacebookUrl { get; set; }

    /// <summary>
    /// The physical coordinates (latitude and longitude) of the location.
    /// </summary>
    [JsonPropertyName("coordinates")]
    public Coordinates? Coordinates { get; set; }

    /// <summary>
    /// The URL of the logo image for the location. When configured in the Seller
    /// Dashboard (Receipts section), the logo appears on transactions (such as receipts and invoices) that Square generates on behalf of the seller.
    /// This image should have a roughly square (1:1) aspect ratio and should be at least 200x200 pixels.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("logo_url")]
    public string? LogoUrl { get; set; }

    /// <summary>
    /// The URL of the Point of Sale background image for the location.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("pos_background_url")]
    public string? PosBackgroundUrl { get; set; }

    /// <summary>
    /// A four-digit number that describes the kind of goods or services sold at the location.
    /// The [merchant category code (MCC)](https://developer.squareup.com/docs/locations-api#initialize-a-merchant-category-code) of the location as standardized by ISO 18245.
    /// For example, `5045`, for a location that sells computer goods and software.
    /// </summary>
    [JsonPropertyName("mcc")]
    public string? Mcc { get; set; }

    /// <summary>
    /// The URL of a full-format logo image for the location. When configured in the Seller
    /// Dashboard (Receipts section), the logo appears on transactions (such as receipts and invoices) that Square generates on behalf of the seller.
    /// This image can be wider than it is tall and should be at least 1280x648 pixels.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("full_format_logo_url")]
    public string? FullFormatLogoUrl { get; set; }

    /// <summary>
    /// The tax IDs for this location.
    /// </summary>
    [JsonPropertyName("tax_ids")]
    public TaxIds? TaxIds { get; set; }

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
