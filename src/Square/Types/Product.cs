using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<Product>))]
[Serializable]
public readonly record struct Product : IStringEnum
{
    public static readonly Product SquarePos = new(Values.SquarePos);

    public static readonly Product ExternalApi = new(Values.ExternalApi);

    public static readonly Product Billing = new(Values.Billing);

    public static readonly Product Appointments = new(Values.Appointments);

    public static readonly Product Invoices = new(Values.Invoices);

    public static readonly Product OnlineStore = new(Values.OnlineStore);

    public static readonly Product Payroll = new(Values.Payroll);

    public static readonly Product Dashboard = new(Values.Dashboard);

    public static readonly Product ItemLibraryImport = new(Values.ItemLibraryImport);

    public static readonly Product Other = new(Values.Other);

    public Product(string value)
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
    public static Product FromCustom(string value)
    {
        return new Product(value);
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

    public static bool operator ==(Product value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(Product value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(Product value) => value.Value;

    public static explicit operator Product(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string SquarePos = "SQUARE_POS";

        public const string ExternalApi = "EXTERNAL_API";

        public const string Billing = "BILLING";

        public const string Appointments = "APPOINTMENTS";

        public const string Invoices = "INVOICES";

        public const string OnlineStore = "ONLINE_STORE";

        public const string Payroll = "PAYROLL";

        public const string Dashboard = "DASHBOARD";

        public const string ItemLibraryImport = "ITEM_LIBRARY_IMPORT";

        public const string Other = "OTHER";
    }
}
