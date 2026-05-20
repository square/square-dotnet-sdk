using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<FelicaDetailsFelicaBrand>))]
[Serializable]
public readonly record struct FelicaDetailsFelicaBrand : IStringEnum
{
    public static readonly FelicaDetailsFelicaBrand Unknown = new(Values.Unknown);

    public static readonly FelicaDetailsFelicaBrand FelicaId = new(Values.FelicaId);

    public static readonly FelicaDetailsFelicaBrand FelicaTransportation = new(
        Values.FelicaTransportation
    );

    public static readonly FelicaDetailsFelicaBrand FelicaQp = new(Values.FelicaQp);

    public FelicaDetailsFelicaBrand(string value)
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
    public static FelicaDetailsFelicaBrand FromCustom(string value)
    {
        return new FelicaDetailsFelicaBrand(value);
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

    public static bool operator ==(FelicaDetailsFelicaBrand value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FelicaDetailsFelicaBrand value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FelicaDetailsFelicaBrand value) => value.Value;

    public static explicit operator FelicaDetailsFelicaBrand(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Unknown = "UNKNOWN";

        public const string FelicaId = "FELICA_ID";

        public const string FelicaTransportation = "FELICA_TRANSPORTATION";

        public const string FelicaQp = "FELICA_QP";
    }
}
