using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<TeamMemberStatus>))]
[Serializable]
public readonly record struct TeamMemberStatus : IStringEnum
{
    public static readonly TeamMemberStatus Active = new(Values.Active);

    public static readonly TeamMemberStatus Inactive = new(Values.Inactive);

    public TeamMemberStatus(string value)
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
    public static TeamMemberStatus FromCustom(string value)
    {
        return new TeamMemberStatus(value);
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

    public static bool operator ==(TeamMemberStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TeamMemberStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TeamMemberStatus value) => value.Value;

    public static explicit operator TeamMemberStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Active = "ACTIVE";

        public const string Inactive = "INACTIVE";
    }
}
