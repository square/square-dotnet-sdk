using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<ScheduledShiftFilterScheduledShiftStatus>))]
public readonly record struct ScheduledShiftFilterScheduledShiftStatus : IStringEnum
{
    public static readonly ScheduledShiftFilterScheduledShiftStatus Draft = new(Values.Draft);

    public static readonly ScheduledShiftFilterScheduledShiftStatus Published = new(
        Values.Published
    );

    public ScheduledShiftFilterScheduledShiftStatus(string value)
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
    public static ScheduledShiftFilterScheduledShiftStatus FromCustom(string value)
    {
        return new ScheduledShiftFilterScheduledShiftStatus(value);
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

    public static bool operator ==(
        ScheduledShiftFilterScheduledShiftStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ScheduledShiftFilterScheduledShiftStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ScheduledShiftFilterScheduledShiftStatus value) =>
        value.Value;

    public static explicit operator ScheduledShiftFilterScheduledShiftStatus(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Draft = "DRAFT";

        public const string Published = "PUBLISHED";
    }
}
