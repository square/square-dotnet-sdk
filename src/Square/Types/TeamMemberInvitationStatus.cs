using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<TeamMemberInvitationStatus>))]
public readonly record struct TeamMemberInvitationStatus : IStringEnum
{
    public static readonly TeamMemberInvitationStatus Uninvited = new(Values.Uninvited);

    public static readonly TeamMemberInvitationStatus Pending = new(Values.Pending);

    public static readonly TeamMemberInvitationStatus Accepted = new(Values.Accepted);

    public TeamMemberInvitationStatus(string value)
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
    public static TeamMemberInvitationStatus FromCustom(string value)
    {
        return new TeamMemberInvitationStatus(value);
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

    public static bool operator ==(TeamMemberInvitationStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TeamMemberInvitationStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TeamMemberInvitationStatus value) => value.Value;

    public static explicit operator TeamMemberInvitationStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Uninvited = "UNINVITED";

        public const string Pending = "PENDING";

        public const string Accepted = "ACCEPTED";
    }
}
