using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record OrderLineItemAppliedServiceCharge
{
    /// <summary>
    /// A unique ID that identifies the applied service charge only within this order.
    /// </summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>
    /// The `uid` of the service charge that the applied service charge represents. It must
    /// reference a service charge present in the `order.service_charges` field.
    ///
    /// This field is immutable. To change which service charges apply to a line item,
    /// delete and add a new `OrderLineItemAppliedServiceCharge`.
    /// </summary>
    [JsonPropertyName("service_charge_uid")]
    public required string ServiceChargeUid { get; set; }

    /// <summary>
    /// The amount of money applied by the service charge to the line item.
    /// </summary>
    [JsonPropertyName("applied_money")]
    public Money? AppliedMoney { get; set; }

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
