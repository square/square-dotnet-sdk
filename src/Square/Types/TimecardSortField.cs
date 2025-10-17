using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<TimecardSortField>))]
[Serializable]
public readonly record struct TimecardSortField : IStringEnum
{
    public static readonly TimecardSortField StartAt = new(Values.StartAt);

    public static readonly TimecardSortField EndAt = new(Values.EndAt);

    public static readonly TimecardSortField CreatedAt = new(Values.CreatedAt);

    public static readonly TimecardSortField UpdatedAt = new(Values.UpdatedAt);

    public TimecardSortField(string value)
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
    public static TimecardSortField FromCustom(string value)
    {
        return new TimecardSortField(value);
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

    public static bool operator ==(TimecardSortField value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TimecardSortField value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TimecardSortField value) => value.Value;

    public static explicit operator TimecardSortField(string value) => new(value);

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
