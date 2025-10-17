using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a service charge applied to an order.
/// </summary>
[Serializable]
public record OrderServiceCharge : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A unique ID that identifies the service charge only within this order.
    /// </summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>
    /// The name of the service charge.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The catalog object ID referencing the service charge [CatalogObject](entity:CatalogObject).
    /// </summary>
    [JsonPropertyName("catalog_object_id")]
    public string? CatalogObjectId { get; set; }

    /// <summary>
    /// The version of the catalog object that this service charge references.
    /// </summary>
    [JsonPropertyName("catalog_version")]
    public long? CatalogVersion { get; set; }

    /// <summary>
    /// The service charge percentage as a string representation of a
    /// decimal number. For example, `"7.25"` indicates a service charge of 7.25%.
    ///
    /// Exactly 1 of `percentage` or `amount_money` should be set.
    /// </summary>
    [JsonPropertyName("percentage")]
    public string? Percentage { get; set; }

    /// <summary>
    /// The amount of a non-percentage-based service charge.
    ///
    /// Exactly one of `percentage` or `amount_money` should be set.
    /// </summary>
    [JsonPropertyName("amount_money")]
    public Money? AmountMoney { get; set; }

    /// <summary>
    /// The amount of money applied to the order by the service charge,
    /// including any inclusive tax amounts, as calculated by Square.
    ///
    /// - For fixed-amount service charges, `applied_money` is equal to `amount_money`.
    /// - For percentage-based service charges, `applied_money` is the money
    /// calculated using the percentage.
    /// </summary>
    [JsonPropertyName("applied_money")]
    public Money? AppliedMoney { get; set; }

    /// <summary>
    /// The total amount of money to collect for the service charge.
    ///
    /// __Note__: If an inclusive tax is applied to the service charge,
    /// `total_money` does not equal `applied_money` plus `total_tax_money`
    /// because the inclusive tax amount is already included in both
    /// `applied_money` and `total_tax_money`.
    /// </summary>
    [JsonPropertyName("total_money")]
    public Money? TotalMoney { get; set; }

    /// <summary>
    /// The total amount of tax money to collect for the service charge.
    /// </summary>
    [JsonPropertyName("total_tax_money")]
    public Money? TotalTaxMoney { get; set; }

    /// <summary>
    /// The calculation phase at which to apply the service charge.
    /// See [OrderServiceChargeCalculationPhase](#type-orderservicechargecalculationphase) for possible values
    /// </summary>
    [JsonPropertyName("calculation_phase")]
    public OrderServiceChargeCalculationPhase? CalculationPhase { get; set; }

    /// <summary>
    /// Indicates whether the service charge can be taxed. If set to `true`,
    /// order-level taxes automatically apply to the service charge. Note that
    /// service charges calculated in the `TOTAL_PHASE` cannot be marked as taxable.
    /// </summary>
    [JsonPropertyName("taxable")]
    public bool? Taxable { get; set; }

    /// <summary>
    /// The list of references to the taxes applied to this service charge. Each
    /// `OrderLineItemAppliedTax` has a `tax_uid` that references the `uid` of a top-level
    /// `OrderLineItemTax` that is being applied to this service charge. On reads, the amount applied
    /// is populated.
    ///
    /// An `OrderLineItemAppliedTax` is automatically created on every taxable service charge
    /// for all `ORDER` scoped taxes that are added to the order. `OrderLineItemAppliedTax` records
    /// for `LINE_ITEM` scoped taxes must be added in requests for the tax to apply to any taxable
    /// service charge. Taxable service charges have the `taxable` field set to `true` and calculated
    /// in the `SUBTOTAL_PHASE`.
    ///
    /// To change the amount of a tax, modify the referenced top-level tax.
    /// </summary>
    [JsonPropertyName("applied_taxes")]
    public IEnumerable<OrderLineItemAppliedTax>? AppliedTaxes { get; set; }

    /// <summary>
    /// Application-defined data attached to this service charge. Metadata fields are intended
    /// to store descriptive references or associations with an entity in another system or store brief
    /// information about the object. Square does not process this field; it only stores and returns it
    /// in relevant API calls. Do not use metadata to store any sensitive information (such as personally
    /// identifiable information or card details).
    ///
    /// Keys written by applications must be 60 characters or less and must be in the character set
    /// `[a-zA-Z0-9_-]`. Entries can also include metadata generated by Square. These keys are prefixed
    /// with a namespace, separated from the key with a ':' character.
    ///
    /// Values have a maximum length of 255 characters.
    ///
    /// An application can have up to 10 entries per metadata field.
    ///
    /// Entries written by applications are private and can only be read or modified by the same
    /// application.
    ///
    /// For more information, see [Metadata](https://developer.squareup.com/docs/build-basics/metadata).
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, string?>? Metadata { get; set; }

    /// <summary>
    /// The type of the service charge.
    /// See [OrderServiceChargeType](#type-orderservicechargetype) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public OrderServiceChargeType? Type { get; set; }

    /// <summary>
    /// The treatment type of the service charge.
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
