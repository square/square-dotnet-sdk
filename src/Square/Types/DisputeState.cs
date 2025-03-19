using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<DisputeState>))]
public readonly record struct DisputeState : IStringEnum
{
    public static readonly DisputeState InquiryEvidenceRequired = new(
        Values.InquiryEvidenceRequired
    );

    public static readonly DisputeState InquiryProcessing = new(Values.InquiryProcessing);

    public static readonly DisputeState InquiryClosed = new(Values.InquiryClosed);

    public static readonly DisputeState EvidenceRequired = new(Values.EvidenceRequired);

    public static readonly DisputeState Processing = new(Values.Processing);

    public static readonly DisputeState Won = new(Values.Won);

    public static readonly DisputeState Lost = new(Values.Lost);

    public static readonly DisputeState Accepted = new(Values.Accepted);

    public DisputeState(string value)
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
    public static DisputeState FromCustom(string value)
    {
        return new DisputeState(value);
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

    public static bool operator ==(DisputeState value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DisputeState value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DisputeState value) => value.Value;

    public static explicit operator DisputeState(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string InquiryEvidenceRequired = "INQUIRY_EVIDENCE_REQUIRED";

        public const string InquiryProcessing = "INQUIRY_PROCESSING";

        public const string InquiryClosed = "INQUIRY_CLOSED";

        public const string EvidenceRequired = "EVIDENCE_REQUIRED";

        public const string Processing = "PROCESSING";

        public const string Won = "WON";

        public const string Lost = "LOST";

        public const string Accepted = "ACCEPTED";
    }
}
