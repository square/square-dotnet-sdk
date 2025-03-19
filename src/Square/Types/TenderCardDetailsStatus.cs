using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<TenderCardDetailsStatus>))]
public readonly record struct TenderCardDetailsStatus : IStringEnum
{
    public static readonly TenderCardDetailsStatus Authorized = new(Values.Authorized);

    public static readonly TenderCardDetailsStatus Captured = new(Values.Captured);

    public static readonly TenderCardDetailsStatus Voided = new(Values.Voided);

    public static readonly TenderCardDetailsStatus Failed = new(Values.Failed);

    public TenderCardDetailsStatus(string value)
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
    public static TenderCardDetailsStatus FromCustom(string value)
    {
        return new TenderCardDetailsStatus(value);
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

    public static bool operator ==(TenderCardDetailsStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TenderCardDetailsStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TenderCardDetailsStatus value) => value.Value;

    public static explicit operator TenderCardDetailsStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Authorized = "AUTHORIZED";

        public const string Captured = "CAPTURED";

        public const string Voided = "VOIDED";

        public const string Failed = "FAILED";
    }
}
