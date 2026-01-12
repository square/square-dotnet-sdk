using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<TenderBuyNowPayLaterDetailsStatus>))]
[Serializable]
public readonly record struct TenderBuyNowPayLaterDetailsStatus : IStringEnum
{
    public static readonly TenderBuyNowPayLaterDetailsStatus Authorized = new(Values.Authorized);

    public static readonly TenderBuyNowPayLaterDetailsStatus Captured = new(Values.Captured);

    public static readonly TenderBuyNowPayLaterDetailsStatus Voided = new(Values.Voided);

    public static readonly TenderBuyNowPayLaterDetailsStatus Failed = new(Values.Failed);

    public TenderBuyNowPayLaterDetailsStatus(string value)
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
    public static TenderBuyNowPayLaterDetailsStatus FromCustom(string value)
    {
        return new TenderBuyNowPayLaterDetailsStatus(value);
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

    public static bool operator ==(TenderBuyNowPayLaterDetailsStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TenderBuyNowPayLaterDetailsStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TenderBuyNowPayLaterDetailsStatus value) => value.Value;

    public static explicit operator TenderBuyNowPayLaterDetailsStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Authorized = "AUTHORIZED";

        public const string Captured = "CAPTURED";

        public const string Voided = "VOIDED";

        public const string Failed = "FAILED";
    }
}
