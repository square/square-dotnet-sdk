using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<BankAccountStatus>))]
[Serializable]
public readonly record struct BankAccountStatus : IStringEnum
{
    public static readonly BankAccountStatus VerificationInProgress = new(
        Values.VerificationInProgress
    );

    public static readonly BankAccountStatus Verified = new(Values.Verified);

    public static readonly BankAccountStatus Disabled = new(Values.Disabled);

    public BankAccountStatus(string value)
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
    public static BankAccountStatus FromCustom(string value)
    {
        return new BankAccountStatus(value);
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

    public static bool operator ==(BankAccountStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BankAccountStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BankAccountStatus value) => value.Value;

    public static explicit operator BankAccountStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string VerificationInProgress = "VERIFICATION_IN_PROGRESS";

        public const string Verified = "VERIFIED";

        public const string Disabled = "DISABLED";
    }
}
