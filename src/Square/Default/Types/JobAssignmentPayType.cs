using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<JobAssignmentPayType>))]
[Serializable]
public readonly record struct JobAssignmentPayType : IStringEnum
{
    public static readonly JobAssignmentPayType None = new(Values.None);

    public static readonly JobAssignmentPayType Hourly = new(Values.Hourly);

    public static readonly JobAssignmentPayType Salary = new(Values.Salary);

    public JobAssignmentPayType(string value)
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
    public static JobAssignmentPayType FromCustom(string value)
    {
        return new JobAssignmentPayType(value);
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

    public static bool operator ==(JobAssignmentPayType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(JobAssignmentPayType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(JobAssignmentPayType value) => value.Value;

    public static explicit operator JobAssignmentPayType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string None = "NONE";

        public const string Hourly = "HOURLY";

        public const string Salary = "SALARY";
    }
}
