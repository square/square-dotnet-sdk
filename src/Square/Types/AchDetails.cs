using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// ACH-specific details about `BANK_ACCOUNT` type payments with the `transfer_type` of `ACH`.
/// </summary>
public record AchDetails
{
    /// <summary>
    /// The routing number for the bank account.
    /// </summary>
    [JsonPropertyName("routing_number")]
    public string? RoutingNumber { get; set; }

    /// <summary>
    /// The last few digits of the bank account number.
    /// </summary>
    [JsonPropertyName("account_number_suffix")]
    public string? AccountNumberSuffix { get; set; }

    /// <summary>
    /// The type of the bank account performing the transfer. The account type can be `CHECKING`,
    /// `SAVINGS`, or `UNKNOWN`.
    /// </summary>
    [JsonPropertyName("account_type")]
    public string? AccountType { get; set; }

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
