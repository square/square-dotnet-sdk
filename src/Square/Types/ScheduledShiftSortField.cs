using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<ScheduledShiftSortField>))]
public readonly record struct ScheduledShiftSortField : IStringEnum
{
    public static readonly ScheduledShiftSortField StartAt = new(Values.StartAt);

    public static readonly ScheduledShiftSortField EndAt = new(Values.EndAt);

    public static readonly ScheduledShiftSortField CreatedAt = new(Values.CreatedAt);

    public static readonly ScheduledShiftSortField UpdatedAt = new(Values.UpdatedAt);

    public ScheduledShiftSortField(string value)
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
    public static ScheduledShiftSortField FromCustom(string value)
    {
        return new ScheduledShiftSortField(value);
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

    public static bool operator ==(ScheduledShiftSortField value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ScheduledShiftSortField value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ScheduledShiftSortField value) => value.Value;

    public static explicit operator ScheduledShiftSortField(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string StartAt = "START_AT";

        public const string EndAt = "END_AT";

        public const string CreatedAt = "CREATED_AT";

        public const string UpdatedAt = "UPDATED_AT";
    }
}
