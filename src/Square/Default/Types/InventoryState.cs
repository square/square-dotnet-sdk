using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<InventoryState>))]
[Serializable]
public readonly record struct InventoryState : IStringEnum
{
    public static readonly InventoryState Custom = new(Values.Custom);

    public static readonly InventoryState InStock = new(Values.InStock);

    public static readonly InventoryState Sold = new(Values.Sold);

    public static readonly InventoryState ReturnedByCustomer = new(Values.ReturnedByCustomer);

    public static readonly InventoryState ReservedForSale = new(Values.ReservedForSale);

    public static readonly InventoryState SoldOnline = new(Values.SoldOnline);

    public static readonly InventoryState OrderedFromVendor = new(Values.OrderedFromVendor);

    public static readonly InventoryState ReceivedFromVendor = new(Values.ReceivedFromVendor);

    public static readonly InventoryState InTransitTo = new(Values.InTransitTo);

    public static readonly InventoryState None = new(Values.None);

    public static readonly InventoryState Waste = new(Values.Waste);

    public static readonly InventoryState UnlinkedReturn = new(Values.UnlinkedReturn);

    public static readonly InventoryState Composed = new(Values.Composed);

    public static readonly InventoryState Decomposed = new(Values.Decomposed);

    public static readonly InventoryState SupportedByNewerVersion = new(
        Values.SupportedByNewerVersion
    );

    public static readonly InventoryState InTransit = new(Values.InTransit);

    public InventoryState(string value)
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
    public static InventoryState FromCustom(string value)
    {
        return new InventoryState(value);
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

    public static bool operator ==(InventoryState value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InventoryState value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InventoryState value) => value.Value;

    public static explicit operator InventoryState(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Custom = "CUSTOM";

        public const string InStock = "IN_STOCK";

        public const string Sold = "SOLD";

        public const string ReturnedByCustomer = "RETURNED_BY_CUSTOMER";

        public const string ReservedForSale = "RESERVED_FOR_SALE";

        public const string SoldOnline = "SOLD_ONLINE";

        public const string OrderedFromVendor = "ORDERED_FROM_VENDOR";

        public const string ReceivedFromVendor = "RECEIVED_FROM_VENDOR";

        public const string InTransitTo = "IN_TRANSIT_TO";

        public const string None = "NONE";

        public const string Waste = "WASTE";

        public const string UnlinkedReturn = "UNLINKED_RETURN";

        public const string Composed = "COMPOSED";

        public const string Decomposed = "DECOMPOSED";

        public const string SupportedByNewerVersion = "SUPPORTED_BY_NEWER_VERSION";

        public const string InTransit = "IN_TRANSIT";
    }
}
