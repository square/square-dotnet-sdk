using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a business that sells with Square.
/// </summary>
public record Merchant
{
    /// <summary>
    /// The Square-issued ID of the merchant.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The name of the merchant's overall business.
    /// </summary>
    [JsonPropertyName("business_name")]
    public string? BusinessName { get; set; }

    /// <summary>
    /// The country code associated with the merchant, in the two-letter format of ISO 3166. For example, `US` or `JP`.
    /// See [Country](#type-country) for possible values
    /// </summary>
    [JsonPropertyName("country")]
    public required Country Country { get; set; }

    /// <summary>
    /// The code indicating the [language preferences](https://developer.squareup.com/docs/build-basics/general-considerations/language-preferences) of the merchant, in [BCP 47 format](https://tools.ietf.org/html/bcp47#appendix-A). For example, `en-US` or `fr-CA`.
    /// </summary>
    [JsonPropertyName("language_code")]
    public string? LanguageCode { get; set; }

    /// <summary>
    /// The currency associated with the merchant, in ISO 4217 format. For example, the currency code for US dollars is `USD`.
    /// See [Currency](#type-currency) for possible values
    /// </summary>
    [JsonPropertyName("currency")]
    public Currency? Currency { get; set; }

    /// <summary>
    /// The merchant's status.
    /// See [MerchantStatus](#type-merchantstatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public MerchantStatus? Status { get; set; }

    /// <summary>
    /// The ID of the [main `Location`](https://developer.squareup.com/docs/locations-api#about-the-main-location) for this merchant.
    /// </summary>
    [JsonPropertyName("main_location_id")]
    public string? MainLocationId { get; set; }

    /// <summary>
    /// The time when the merchant was created, in RFC 3339 format.
    ///    For more information, see [Working with Dates](https://developer.squareup.com/docs/build-basics/working-with-dates).
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

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
