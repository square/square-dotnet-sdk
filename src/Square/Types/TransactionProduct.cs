using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<TransactionProduct>))]
public readonly record struct TransactionProduct : IStringEnum
{
    public static readonly TransactionProduct Register = new(Values.Register);

    public static readonly TransactionProduct ExternalApi = new(Values.ExternalApi);

    public static readonly TransactionProduct Billing = new(Values.Billing);

    public static readonly TransactionProduct Appointments = new(Values.Appointments);

    public static readonly TransactionProduct Invoices = new(Values.Invoices);

    public static readonly TransactionProduct OnlineStore = new(Values.OnlineStore);

    public static readonly TransactionProduct Payroll = new(Values.Payroll);

    public static readonly TransactionProduct Other = new(Values.Other);

    public TransactionProduct(string value)
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
    public static TransactionProduct FromCustom(string value)
    {
        return new TransactionProduct(value);
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

    public static bool operator ==(TransactionProduct value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TransactionProduct value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TransactionProduct value) => value.Value;

    public static explicit operator TransactionProduct(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Register = "REGISTER";

        public const string ExternalApi = "EXTERNAL_API";

        public const string Billing = "BILLING";

        public const string Appointments = "APPOINTMENTS";

        public const string Invoices = "INVOICES";

        public const string OnlineStore = "ONLINE_STORE";

        public const string Payroll = "PAYROLL";

        public const string Other = "OTHER";
    }
}
