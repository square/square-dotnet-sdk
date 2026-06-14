using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<CacheMode>))]
[Serializable]
public readonly record struct CacheMode : IStringEnum
{
    public static readonly CacheMode StaleIfSlow = new(Values.StaleIfSlow);

    public static readonly CacheMode StaleWhileRevalidate = new(Values.StaleWhileRevalidate);

    public static readonly CacheMode MustRevalidate = new(Values.MustRevalidate);

    public static readonly CacheMode NoCache = new(Values.NoCache);

    public CacheMode(string value)
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
    public static CacheMode FromCustom(string value)
    {
        return new CacheMode(value);
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

    public static bool operator ==(CacheMode value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(CacheMode value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(CacheMode value) => value.Value;

    public static explicit operator CacheMode(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string StaleIfSlow = "stale-if-slow";

        public const string StaleWhileRevalidate = "stale-while-revalidate";

        public const string MustRevalidate = "must-revalidate";

        public const string NoCache = "no-cache";
    }
}
