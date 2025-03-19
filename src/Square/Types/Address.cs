using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a postal address in a country.
/// For more information, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
/// </summary>
public record Address
{
    /// <summary>
    /// The first line of the address.
    ///
    /// Fields that start with `address_line` provide the address's most specific
    /// details, like street number, street name, and building name. They do *not*
    /// provide less specific details like city, state/province, or country (these
    /// details are provided in other fields).
    /// </summary>
    [JsonPropertyName("address_line_1")]
    public string? AddressLine1 { get; set; }

    /// <summary>
    /// The second line of the address, if any.
    /// </summary>
    [JsonPropertyName("address_line_2")]
    public string? AddressLine2 { get; set; }

    /// <summary>
    /// The third line of the address, if any.
    /// </summary>
    [JsonPropertyName("address_line_3")]
    public string? AddressLine3 { get; set; }

    /// <summary>
    /// The city or town of the address. For a full list of field meanings by country, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
    /// </summary>
    [JsonPropertyName("locality")]
    public string? Locality { get; set; }

    /// <summary>
    /// A civil region within the address's `locality`, if any.
    /// </summary>
    [JsonPropertyName("sublocality")]
    public string? Sublocality { get; set; }

    /// <summary>
    /// A civil region within the address's `sublocality`, if any.
    /// </summary>
    [JsonPropertyName("sublocality_2")]
    public string? Sublocality2 { get; set; }

    /// <summary>
    /// A civil region within the address's `sublocality_2`, if any.
    /// </summary>
    [JsonPropertyName("sublocality_3")]
    public string? Sublocality3 { get; set; }

    /// <summary>
    /// A civil entity within the address's country. In the US, this
    /// is the state. For a full list of field meanings by country, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
    /// </summary>
    [JsonPropertyName("administrative_district_level_1")]
    public string? AdministrativeDistrictLevel1 { get; set; }

    /// <summary>
    /// A civil entity within the address's `administrative_district_level_1`.
    /// In the US, this is the county.
    /// </summary>
    [JsonPropertyName("administrative_district_level_2")]
    public string? AdministrativeDistrictLevel2 { get; set; }

    /// <summary>
    /// A civil entity within the address's `administrative_district_level_2`,
    /// if any.
    /// </summary>
    [JsonPropertyName("administrative_district_level_3")]
    public string? AdministrativeDistrictLevel3 { get; set; }

    /// <summary>
    /// The address's postal code. For a full list of field meanings by country, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
    /// </summary>
    [JsonPropertyName("postal_code")]
    public string? PostalCode { get; set; }

    /// <summary>
    /// The address's country, in the two-letter format of ISO 3166. For example, `US` or `FR`.
    /// See [Country](#type-country) for possible values
    /// </summary>
    [JsonPropertyName("country")]
    public Country? Country { get; set; }

    /// <summary>
    /// Optional first name when it's representing recipient.
    /// </summary>
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    /// <summary>
    /// Optional last name when it's representing recipient.
    /// </summary>
    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
