using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<InventoryAdjustmentReasonIdType>))]
[Serializable]
public readonly record struct InventoryAdjustmentReasonIdType : IStringEnum
{
    public static readonly InventoryAdjustmentReasonIdType Received = new(Values.Received);

    public static readonly InventoryAdjustmentReasonIdType Damaged = new(Values.Damaged);

    public static readonly InventoryAdjustmentReasonIdType Theft = new(Values.Theft);

    public static readonly InventoryAdjustmentReasonIdType Lost = new(Values.Lost);

    public static readonly InventoryAdjustmentReasonIdType Returned = new(Values.Returned);

    public static readonly InventoryAdjustmentReasonIdType SpoilageWaste = new(
        Values.SpoilageWaste
    );

    public static readonly InventoryAdjustmentReasonIdType SamplesPromotional = new(
        Values.SamplesPromotional
    );

    public static readonly InventoryAdjustmentReasonIdType InternalUse = new(Values.InternalUse);

    public static readonly InventoryAdjustmentReasonIdType VendorReturn = new(Values.VendorReturn);

    public static readonly InventoryAdjustmentReasonIdType ProductionWaste = new(
        Values.ProductionWaste
    );

    public static readonly InventoryAdjustmentReasonIdType Sale = new(Values.Sale);

    public static readonly InventoryAdjustmentReasonIdType Recount = new(Values.Recount);

    public static readonly InventoryAdjustmentReasonIdType Transfer = new(Values.Transfer);

    public static readonly InventoryAdjustmentReasonIdType InTransit = new(Values.InTransit);

    public static readonly InventoryAdjustmentReasonIdType CanceledSale = new(Values.CanceledSale);

    public static readonly InventoryAdjustmentReasonIdType Custom = new(Values.Custom);

    public InventoryAdjustmentReasonIdType(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static InventoryAdjustmentReasonIdType FromCustom(string value)
    {
        return new InventoryAdjustmentReasonIdType(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(InventoryAdjustmentReasonIdType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InventoryAdjustmentReasonIdType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InventoryAdjustmentReasonIdType value) => value.Value;

    public static explicit operator InventoryAdjustmentReasonIdType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Received = "RECEIVED";

        public const string Damaged = "DAMAGED";

        public const string Theft = "THEFT";

        public const string Lost = "LOST";

        public const string Returned = "RETURNED";

        public const string SpoilageWaste = "SPOILAGE_WASTE";

        public const string SamplesPromotional = "SAMPLES_PROMOTIONAL";

        public const string InternalUse = "INTERNAL_USE";

        public const string VendorReturn = "VENDOR_RETURN";

        public const string ProductionWaste = "PRODUCTION_WASTE";

        public const string Sale = "SALE";

        public const string Recount = "RECOUNT";

        public const string Transfer = "TRANSFER";

        public const string InTransit = "IN_TRANSIT";

        public const string CanceledSale = "CANCELED_SALE";

        public const string Custom = "CUSTOM";
    }
}
