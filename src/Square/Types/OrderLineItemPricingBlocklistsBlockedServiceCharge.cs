using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A service charge to block from applying to a line item. The service charge
/// must be identified by either `service_charge_uid` or
/// `service_charge_catalog_object_id`, but not both.
/// </summary>
[Serializable]
public record OrderLineItemPricingBlocklistsBlockedServiceCharge : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A unique ID of the `BlockedServiceCharge` within the order.
    /// </summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>
    /// The `uid` of the service charge that should be blocked. Use this field to
    /// block ad hoc service charges. For catalog service charges, use the
    /// `service_charge_catalog_object_id` field.
    /// </summary>
    [JsonPropertyName("service_charge_uid")]
    public string? ServiceChargeUid { get; set; }

    /// <summary>
    /// The `catalog_object_id` of the service charge that should be blocked.
    /// Use this field to block catalog service charges. For ad hoc service charges,
    /// use the `service_charge_uid` field.
    /// </summary>
    [JsonPropertyName("service_charge_catalog_object_id")]
    public string? ServiceChargeCatalogObjectId { get; set; }

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
