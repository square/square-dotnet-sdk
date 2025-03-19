using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<ArchivedState>))]
public readonly record struct ArchivedState : IStringEnum
{
    public static readonly ArchivedState ArchivedStateNotArchived = new(
        Values.ArchivedStateNotArchived
    );

    public static readonly ArchivedState ArchivedStateArchived = new(Values.ArchivedStateArchived);

    public static readonly ArchivedState ArchivedStateAll = new(Values.ArchivedStateAll);

    public ArchivedState(string value)
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
    public static ArchivedState FromCustom(string value)
    {
        return new ArchivedState(value);
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

    public static bool operator ==(ArchivedState value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ArchivedState value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ArchivedState value) => value.Value;

    public static explicit operator ArchivedState(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string ArchivedStateNotArchived = "ARCHIVED_STATE_NOT_ARCHIVED";

        public const string ArchivedStateArchived = "ARCHIVED_STATE_ARCHIVED";

        public const string ArchivedStateAll = "ARCHIVED_STATE_ALL";
    }
}
