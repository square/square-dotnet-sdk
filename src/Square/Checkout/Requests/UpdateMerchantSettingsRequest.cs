using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Checkout;

public record UpdateMerchantSettingsRequest
{
    /// <summary>
    /// Describe your updates using the `merchant_settings` object. Make sure it contains only the fields that have changed.
    /// </summary>
    [JsonPropertyName("merchant_settings")]
    public required CheckoutMerchantSettings MerchantSettings { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
