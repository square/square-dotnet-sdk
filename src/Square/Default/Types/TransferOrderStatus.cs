using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<TransferOrderStatus>))]
[Serializable]
public readonly record struct TransferOrderStatus : IStringEnum
{
    public static readonly TransferOrderStatus Draft = new(Values.Draft);

    public static readonly TransferOrderStatus Started = new(Values.Started);

    public static readonly TransferOrderStatus PartiallyReceived = new(Values.PartiallyReceived);

    public static readonly TransferOrderStatus Completed = new(Values.Completed);

    public static readonly TransferOrderStatus Canceled = new(Values.Canceled);

    public TransferOrderStatus(string value)
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
    public static TransferOrderStatus FromCustom(string value)
    {
        return new TransferOrderStatus(value);
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

    public static bool operator ==(TransferOrderStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TransferOrderStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TransferOrderStatus value) => value.Value;

    public static explicit operator TransferOrderStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Draft = "DRAFT";

        public const string Started = "STARTED";

        public const string PartiallyReceived = "PARTIALLY_RECEIVED";

        public const string Completed = "COMPLETED";

        public const string Canceled = "CANCELED";
    }
}
