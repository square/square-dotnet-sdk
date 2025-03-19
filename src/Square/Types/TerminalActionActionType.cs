using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<TerminalActionActionType>))]
public readonly record struct TerminalActionActionType : IStringEnum
{
    public static readonly TerminalActionActionType QrCode = new(Values.QrCode);

    public static readonly TerminalActionActionType Ping = new(Values.Ping);

    public static readonly TerminalActionActionType SaveCard = new(Values.SaveCard);

    public static readonly TerminalActionActionType Signature = new(Values.Signature);

    public static readonly TerminalActionActionType Confirmation = new(Values.Confirmation);

    public static readonly TerminalActionActionType Receipt = new(Values.Receipt);

    public static readonly TerminalActionActionType DataCollection = new(Values.DataCollection);

    public static readonly TerminalActionActionType Select = new(Values.Select);

    public TerminalActionActionType(string value)
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
    public static TerminalActionActionType FromCustom(string value)
    {
        return new TerminalActionActionType(value);
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

    public static bool operator ==(TerminalActionActionType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TerminalActionActionType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TerminalActionActionType value) => value.Value;

    public static explicit operator TerminalActionActionType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string QrCode = "QR_CODE";

        public const string Ping = "PING";

        public const string SaveCard = "SAVE_CARD";

        public const string Signature = "SIGNATURE";

        public const string Confirmation = "CONFIRMATION";

        public const string Receipt = "RECEIPT";

        public const string DataCollection = "DATA_COLLECTION";

        public const string Select = "SELECT";
    }
}
