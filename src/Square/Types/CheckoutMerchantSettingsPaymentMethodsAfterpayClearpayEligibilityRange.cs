using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A range of purchase price that qualifies.
/// </summary>
public record CheckoutMerchantSettingsPaymentMethodsAfterpayClearpayEligibilityRange
{
    [JsonPropertyName("min")]
    public required Money Min { get; set; }

    [JsonPropertyName("max")]
    public required Money Max { get; set; }

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
