using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents fraud risk information for the associated payment.
///
/// When you take a payment through Square's Payments API (using the `CreatePayment`
/// endpoint), Square evaluates it and assigns a risk level to the payment. Sellers
/// can use this information to determine the course of action (for example,
/// provide the goods/services or refund the payment).
/// </summary>
public record RiskEvaluation
{
    /// <summary>
    /// The timestamp when payment risk was evaluated, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The risk level associated with the payment
    /// See [RiskEvaluationRiskLevel](#type-riskevaluationrisklevel) for possible values
    /// </summary>
    [JsonPropertyName("risk_level")]
    public RiskEvaluationRiskLevel? RiskLevel { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
