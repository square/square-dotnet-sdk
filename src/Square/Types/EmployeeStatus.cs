using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<EmployeeStatus>))]
public readonly record struct EmployeeStatus : IStringEnum
{
    public static readonly EmployeeStatus Active = new(Values.Active);

    public static readonly EmployeeStatus Inactive = new(Values.Inactive);

    public EmployeeStatus(string value)
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
    public static EmployeeStatus FromCustom(string value)
    {
        return new EmployeeStatus(value);
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

    public static bool operator ==(EmployeeStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EmployeeStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EmployeeStatus value) => value.Value;

    public static explicit operator EmployeeStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Active = "ACTIVE";

        public const string Inactive = "INACTIVE";
    }
}
