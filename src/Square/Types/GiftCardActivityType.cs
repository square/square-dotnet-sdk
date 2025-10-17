using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<GiftCardActivityType>))]
[Serializable]
public readonly record struct GiftCardActivityType : IStringEnum
{
    public static readonly GiftCardActivityType Activate = new(Values.Activate);

    public static readonly GiftCardActivityType Load = new(Values.Load);

    public static readonly GiftCardActivityType Redeem = new(Values.Redeem);

    public static readonly GiftCardActivityType ClearBalance = new(Values.ClearBalance);

    public static readonly GiftCardActivityType Deactivate = new(Values.Deactivate);

    public static readonly GiftCardActivityType AdjustIncrement = new(Values.AdjustIncrement);

    public static readonly GiftCardActivityType AdjustDecrement = new(Values.AdjustDecrement);

    public static readonly GiftCardActivityType Refund = new(Values.Refund);

    public static readonly GiftCardActivityType UnlinkedActivityRefund = new(
        Values.UnlinkedActivityRefund
    );

    public static readonly GiftCardActivityType Import = new(Values.Import);

    public static readonly GiftCardActivityType Block = new(Values.Block);

    public static readonly GiftCardActivityType Unblock = new(Values.Unblock);

    public static readonly GiftCardActivityType ImportReversal = new(Values.ImportReversal);

    public static readonly GiftCardActivityType TransferBalanceFrom = new(
        Values.TransferBalanceFrom
    );

    public static readonly GiftCardActivityType TransferBalanceTo = new(Values.TransferBalanceTo);

    public GiftCardActivityType(string value)
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
    public static GiftCardActivityType FromCustom(string value)
    {
        return new GiftCardActivityType(value);
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

    public static bool operator ==(GiftCardActivityType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GiftCardActivityType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GiftCardActivityType value) => value.Value;

    public static explicit operator GiftCardActivityType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Activate = "ACTIVATE";

        public const string Load = "LOAD";

        public const string Redeem = "REDEEM";

        public const string ClearBalance = "CLEAR_BALANCE";

        public const string Deactivate = "DEACTIVATE";

        public const string AdjustIncrement = "ADJUST_INCREMENT";

        public const string AdjustDecrement = "ADJUST_DECREMENT";

        public const string Refund = "REFUND";

        public const string UnlinkedActivityRefund = "UNLINKED_ACTIVITY_REFUND";

        public const string Import = "IMPORT";

        public const string Block = "BLOCK";

        public const string Unblock = "UNBLOCK";

        public const string ImportReversal = "IMPORT_REVERSAL";

        public const string TransferBalanceFrom = "TRANSFER_BALANCE_FROM";

        public const string TransferBalanceTo = "TRANSFER_BALANCE_TO";
    }
}
