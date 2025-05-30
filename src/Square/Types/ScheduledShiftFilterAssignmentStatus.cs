using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<ScheduledShiftFilterAssignmentStatus>))]
public readonly record struct ScheduledShiftFilterAssignmentStatus : IStringEnum
{
    public static readonly ScheduledShiftFilterAssignmentStatus Assigned = new(Values.Assigned);

    public static readonly ScheduledShiftFilterAssignmentStatus Unassigned = new(Values.Unassigned);

    public ScheduledShiftFilterAssignmentStatus(string value)
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
    public static ScheduledShiftFilterAssignmentStatus FromCustom(string value)
    {
        return new ScheduledShiftFilterAssignmentStatus(value);
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

    public static bool operator ==(ScheduledShiftFilterAssignmentStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ScheduledShiftFilterAssignmentStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ScheduledShiftFilterAssignmentStatus value) =>
        value.Value;

    public static explicit operator ScheduledShiftFilterAssignmentStatus(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Assigned = "ASSIGNED";

        public const string Unassigned = "UNASSIGNED";
    }
}
