using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// ACH-specific details about `BANK_ACCOUNT` type payments with the `transfer_type` of `ACH`.
/// </summary>
[Serializable]
public record AchDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
