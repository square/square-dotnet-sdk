using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

[Serializable]
public record OrderLineItemAppliedServiceCharge : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
