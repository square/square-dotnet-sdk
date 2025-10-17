using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A discount applicable to items.
/// </summary>
[Serializable]
public record CatalogDiscount : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The discount name. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Indicates whether the discount is a fixed amount or percentage, or entered at the time of sale.
    /// See [CatalogDiscountType](#type-catalogdiscounttype) for possible values
    /// </summary>
    [JsonPropertyName("discount_type")]
    public CatalogDiscountType? DiscountType { get; set; }

    /// <summary>
    /// The percentage of the discount as a string representation of a decimal number, using a `.` as the decimal
    /// separator and without a `%` sign. A value of `7.5` corresponds to `7.5%`. Specify a percentage of `0` if `discount_type`
    /// is `VARIABLE_PERCENTAGE`.
    ///
    /// Do not use this field for amount-based or variable discounts.
    /// </summary>
    [JsonPropertyName("percentage")]
    public string? Percentage { get; set; }

    /// <summary>
    /// The amount of the discount. Specify an amount of `0` if `discount_type` is `VARIABLE_AMOUNT`.
    ///
    /// Do not use this field for percentage-based or variable discounts.
    /// </summary>
    [JsonPropertyName("amount_money")]
    public Money? AmountMoney { get; set; }

    /// <summary>
    /// Indicates whether a mobile staff member needs to enter their PIN to apply the
    /// discount to a payment in the Square Point of Sale app.
    /// </summary>
    [JsonPropertyName("pin_required")]
    public bool? PinRequired { get; set; }

    /// <summary>
    /// The color of the discount display label in the Square Point of Sale app. This must be a valid hex color code.
    /// </summary>
    [JsonPropertyName("label_color")]
    public string? LabelColor { get; set; }

    /// <summary>
    /// Indicates whether this discount should reduce the price used to calculate tax.
    ///
    /// Most discounts should use `MODIFY_TAX_BASIS`. However, in some circumstances taxes must
    /// be calculated based on an item's price, ignoring a particular discount. For example,
    /// in many US jurisdictions, a manufacturer coupon or instant rebate reduces the price a
    /// customer pays but does not reduce the sale price used to calculate how much sales tax is
    /// due. In this case, the discount representing that manufacturer coupon should have
    /// `DO_NOT_MODIFY_TAX_BASIS` for this field.
    ///
    /// If you are unsure whether you need to use this field, consult your tax professional.
    /// See [CatalogDiscountModifyTaxBasis](#type-catalogdiscountmodifytaxbasis) for possible values
    /// </summary>
    [JsonPropertyName("modify_tax_basis")]
    public CatalogDiscountModifyTaxBasis? ModifyTaxBasis { get; set; }

    /// <summary>
    /// For a percentage discount, the maximum absolute value of the discount. For example, if a
    /// 50% discount has a `maximum_amount_money` of $20, a $100 purchase will yield a $20 discount,
    /// not a $50 discount.
    /// </summary>
    [JsonPropertyName("maximum_amount_money")]
    public Money? MaximumAmountMoney { get; set; }

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
