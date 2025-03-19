using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record CheckoutMerchantSettings
{
    /// <summary>
    /// The set of payment methods accepted for the merchant's account.
    /// </summary>
    [JsonPropertyName("payment_methods")]
    public CheckoutMerchantSettingsPaymentMethods? PaymentMethods { get; set; }

    /// <summary>
    /// The timestamp when the settings were last updated, in RFC 3339 format.
    /// Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
    /// UTC: 2020-01-26T02:25:34Z
    /// Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

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
