using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<RiskEvaluationRiskLevel>))]
[Serializable]
public readonly record struct RiskEvaluationRiskLevel : IStringEnum
{
    public static readonly RiskEvaluationRiskLevel Pending = new(Values.Pending);

    public static readonly RiskEvaluationRiskLevel Normal = new(Values.Normal);

    public static readonly RiskEvaluationRiskLevel Moderate = new(Values.Moderate);

    public static readonly RiskEvaluationRiskLevel High = new(Values.High);

    public RiskEvaluationRiskLevel(string value)
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
    public static RiskEvaluationRiskLevel FromCustom(string value)
    {
        return new RiskEvaluationRiskLevel(value);
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

    public static bool operator ==(RiskEvaluationRiskLevel value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RiskEvaluationRiskLevel value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RiskEvaluationRiskLevel value) => value.Value;

    public static explicit operator RiskEvaluationRiskLevel(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Pending = "PENDING";

        public const string Normal = "NORMAL";

        public const string Moderate = "MODERATE";

        public const string High = "HIGH";
    }
}
