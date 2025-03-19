using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Information about the fulfillment recipient.
/// </summary>
public record FulfillmentRecipient
{
    /// <summary>
    /// The ID of the customer associated with the fulfillment.
    ///
    /// If `customer_id` is provided, the fulfillment recipient's `display_name`,
    /// `email_address`, and `phone_number` are automatically populated from the
    /// targeted customer profile. If these fields are set in the request, the request
    /// values override the information from the customer profile. If the
    /// targeted customer profile does not contain the necessary information and
    /// these fields are left unset, the request results in an error.
    /// </summary>
    [JsonPropertyName("customer_id")]
    public string? CustomerId { get; set; }

    /// <summary>
    /// The display name of the fulfillment recipient. This field is required.
    ///
    /// If provided, the display name overrides the corresponding customer profile value
    /// indicated by `customer_id`.
    /// </summary>
    [JsonPropertyName("display_name")]
    public string? DisplayName { get; set; }

    /// <summary>
    /// The email address of the fulfillment recipient.
    ///
    /// If provided, the email address overrides the corresponding customer profile value
    /// indicated by `customer_id`.
    /// </summary>
    [JsonPropertyName("email_address")]
    public string? EmailAddress { get; set; }

    /// <summary>
    /// The phone number of the fulfillment recipient. This field is required.
    ///
    /// If provided, the phone number overrides the corresponding customer profile value
    /// indicated by `customer_id`.
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// The address of the fulfillment recipient. This field is required.
    ///
    /// If provided, the address overrides the corresponding customer profile value
    /// indicated by `customer_id`.
    /// </summary>
    [JsonPropertyName("address")]
    public Address? Address { get; set; }

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
