using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents the details of a tender with `type` `BUY_NOW_PAY_LATER`.
/// </summary>
public record TenderBuyNowPayLaterDetails
{
    /// <summary>
    /// The Buy Now Pay Later brand.
    /// See [Brand](#type-brand) for possible values
    /// </summary>
    [JsonPropertyName("buy_now_pay_later_brand")]
    public TenderBuyNowPayLaterDetailsBrand? BuyNowPayLaterBrand { get; set; }

    /// <summary>
    /// The buy now pay later payment's current state (such as `AUTHORIZED` or
    /// `CAPTURED`). See [TenderBuyNowPayLaterDetailsStatus](entity:TenderBuyNowPayLaterDetailsStatus)
    /// for possible values.
    /// See [Status](#type-status) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public TenderBuyNowPayLaterDetailsStatus? Status { get; set; }

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
