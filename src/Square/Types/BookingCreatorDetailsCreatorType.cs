using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<BookingCreatorDetailsCreatorType>))]
[Serializable]
public readonly record struct BookingCreatorDetailsCreatorType : IStringEnum
{
    public static readonly BookingCreatorDetailsCreatorType TeamMember = new(Values.TeamMember);

    public static readonly BookingCreatorDetailsCreatorType Customer = new(Values.Customer);

    public BookingCreatorDetailsCreatorType(string value)
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
    public static BookingCreatorDetailsCreatorType FromCustom(string value)
    {
        return new BookingCreatorDetailsCreatorType(value);
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

    public static bool operator ==(BookingCreatorDetailsCreatorType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BookingCreatorDetailsCreatorType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BookingCreatorDetailsCreatorType value) => value.Value;

    public static explicit operator BookingCreatorDetailsCreatorType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string TeamMember = "TEAM_MEMBER";

        public const string Customer = "CUSTOMER";
    }
}
