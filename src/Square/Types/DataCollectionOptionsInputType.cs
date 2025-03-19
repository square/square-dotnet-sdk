using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<DataCollectionOptionsInputType>))]
public readonly record struct DataCollectionOptionsInputType : IStringEnum
{
    public static readonly DataCollectionOptionsInputType Email = new(Values.Email);

    public static readonly DataCollectionOptionsInputType PhoneNumber = new(Values.PhoneNumber);

    public DataCollectionOptionsInputType(string value)
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
    public static DataCollectionOptionsInputType FromCustom(string value)
    {
        return new DataCollectionOptionsInputType(value);
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

    public static bool operator ==(DataCollectionOptionsInputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DataCollectionOptionsInputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DataCollectionOptionsInputType value) => value.Value;

    public static explicit operator DataCollectionOptionsInputType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Email = "EMAIL";

        public const string PhoneNumber = "PHONE_NUMBER";
    }
}
