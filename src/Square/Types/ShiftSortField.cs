using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<ShiftSortField>))]
[Serializable]
public readonly record struct ShiftSortField : IStringEnum
{
    public static readonly ShiftSortField StartAt = new(Values.StartAt);

    public static readonly ShiftSortField EndAt = new(Values.EndAt);

    public static readonly ShiftSortField CreatedAt = new(Values.CreatedAt);

    public static readonly ShiftSortField UpdatedAt = new(Values.UpdatedAt);

    public ShiftSortField(string value)
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
    public static ShiftSortField FromCustom(string value)
    {
        return new ShiftSortField(value);
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

    public static bool operator ==(ShiftSortField value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ShiftSortField value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ShiftSortField value) => value.Value;

    public static explicit operator ShiftSortField(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string StartAt = "START_AT";

        public const string EndAt = "END_AT";

        public const string CreatedAt = "CREATED_AT";

        public const string UpdatedAt = "UPDATED_AT";
    }
}
