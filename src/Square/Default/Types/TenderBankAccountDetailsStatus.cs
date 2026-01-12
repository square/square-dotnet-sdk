using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<TenderBankAccountDetailsStatus>))]
[Serializable]
public readonly record struct TenderBankAccountDetailsStatus : IStringEnum
{
    public static readonly TenderBankAccountDetailsStatus Pending = new(Values.Pending);

    public static readonly TenderBankAccountDetailsStatus Completed = new(Values.Completed);

    public static readonly TenderBankAccountDetailsStatus Failed = new(Values.Failed);

    public TenderBankAccountDetailsStatus(string value)
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
    public static TenderBankAccountDetailsStatus FromCustom(string value)
    {
        return new TenderBankAccountDetailsStatus(value);
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

    public static bool operator ==(TenderBankAccountDetailsStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TenderBankAccountDetailsStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TenderBankAccountDetailsStatus value) => value.Value;

    public static explicit operator TenderBankAccountDetailsStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Pending = "PENDING";

        public const string Completed = "COMPLETED";

        public const string Failed = "FAILED";
    }
}
