using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents the service charge applied to the original order.
/// </summary>
[Serializable]
public record OrderReturnServiceCharge : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A unique ID that identifies the return service charge only within this order.
    /// </summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>
    /// The service charge `uid` from the order containing the original
    /// service charge. `source_service_charge_uid` is `null` for
    /// unlinked returns.
    /// </summary>
    [JsonPropertyName("source_service_charge_uid")]
    public string? SourceServiceChargeUid { get; set; }

    /// <summary>
    /// The name of the service charge.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The catalog object ID of the associated [OrderServiceCharge](entity:OrderServiceCharge).
    /// </summary>
    [JsonPropertyName("catalog_object_id")]
    public string? CatalogObjectId { get; set; }

    /// <summary>
    /// The version of the catalog object that this service charge references.
    /// </summary>
    [JsonPropertyName("catalog_version")]
    public long? CatalogVersion { get; set; }

    /// <summary>
    /// The percentage of the service charge, as a string representation of
    /// a decimal number. For example, a value of `"7.25"` corresponds to a
    /// percentage of 7.25%.
    ///
    /// Either `percentage` or `amount_money` should be set, but not both.
    /// </summary>
    [JsonPropertyName("percentage")]
    public string? Percentage { get; set; }

    /// <summary>
    /// The amount of a non-percentage-based service charge.
    ///
    /// Either `percentage` or `amount_money` should be set, but not both.
    /// </summary>
    [JsonPropertyName("amount_money")]
    public Money? AmountMoney { get; set; }

    /// <summary>
    /// The amount of money applied to the order by the service charge, including
    /// any inclusive tax amounts, as calculated by Square.
    ///
    /// - For fixed-amount service charges, `applied_money` is equal to `amount_money`.
    /// - For percentage-based service charges, `applied_money` is the money calculated using the percentage.
    /// </summary>
    [JsonPropertyName("applied_money")]
    public Money? AppliedMoney { get; set; }

    /// <summary>
    /// The total amount of money to collect for the service charge.
    ///
    /// __NOTE__: If an inclusive tax is applied to the service charge, `total_money`
    /// does not equal `applied_money` plus `total_tax_money` because the inclusive
    /// tax amount is already included in both `applied_money` and `total_tax_money`.
    /// </summary>
    [JsonPropertyName("total_money")]
    public Money? TotalMoney { get; set; }

    /// <summary>
    /// The total amount of tax money to collect for the service charge.
    /// </summary>
    [JsonPropertyName("total_tax_money")]
    public Money? TotalTaxMoney { get; set; }

    /// <summary>
    /// The calculation phase after which to apply the service charge.
    /// See [OrderServiceChargeCalculationPhase](#type-orderservicechargecalculationphase) for possible values
    /// </summary>
    [JsonPropertyName("calculation_phase")]
    public OrderServiceChargeCalculationPhase? CalculationPhase { get; set; }

    /// <summary>
    /// Indicates whether the surcharge can be taxed. Service charges
    /// calculated in the `TOTAL_PHASE` cannot be marked as taxable.
    /// </summary>
    [JsonPropertyName("taxable")]
    public bool? Taxable { get; set; }

    /// <summary>
    /// The list of references to `OrderReturnTax` entities applied to the
    /// `OrderReturnServiceCharge`. Each `OrderLineItemAppliedTax` has a `tax_uid`
    /// that references the `uid` of a top-level `OrderReturnTax` that is being
    /// applied to the `OrderReturnServiceCharge`. On reads, the applied amount is
    /// populated.
    /// </summary>
    [JsonPropertyName("applied_taxes")]
    public IEnumerable<OrderLineItemAppliedTax>? AppliedTaxes { get; set; }

    /// <summary>
    /// Indicates whether the service charge will be treated as a value-holding line item or apportioned toward a line item.
    /// See [OrderServiceChargeTreatmentType](#type-orderservicechargetreatmenttype) for possible values
    /// </summary>
    [JsonPropertyName("treatment_type")]
    public OrderServiceChargeTreatmentType? TreatmentType { get; set; }

    /// <summary>
    /// Indicates the level at which the apportioned service charge applies. For `ORDER`
    /// scoped service charges, Square generates references in `applied_service_charges` on
    /// all order line items that do not have them. For `LINE_ITEM` scoped service charges,
    /// the service charge only applies to line items with a service charge reference in their
    /// `applied_service_charges` field.
    ///
    /// This field is immutable. To change the scope of an apportioned service charge, you must delete
    /// the apportioned service charge and re-add it as a new apportioned service charge.
    /// See [OrderServiceChargeScope](#type-orderservicechargescope) for possible values
    /// </summary>
    [JsonPropertyName("scope")]
    public OrderServiceChargeScope? Scope { get; set; }

    /// <summary>
    /// The type of the service charge.
    /// See [OrderServiceChargeType](#type-orderservicechargetype) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public OrderServiceChargeType? Type { get; set; }

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
