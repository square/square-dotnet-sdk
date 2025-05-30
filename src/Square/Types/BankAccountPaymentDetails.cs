using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Additional details about BANK_ACCOUNT type payments.
/// </summary>
public record BankAccountPaymentDetails
{
    /// <summary>
    /// The name of the bank associated with the bank account.
    /// </summary>
    [JsonPropertyName("bank_name")]
    public string? BankName { get; set; }

    /// <summary>
    /// The type of the bank transfer. The type can be `ACH` or `UNKNOWN`.
    /// </summary>
    [JsonPropertyName("transfer_type")]
    public string? TransferType { get; set; }

    /// <summary>
    /// The ownership type of the bank account performing the transfer.
    /// The type can be `INDIVIDUAL`, `COMPANY`, or `ACCOUNT_TYPE_UNKNOWN`.
    /// </summary>
    [JsonPropertyName("account_ownership_type")]
    public string? AccountOwnershipType { get; set; }

    /// <summary>
    /// Uniquely identifies the bank account for this seller and can be used
    /// to determine if payments are from the same bank account.
    /// </summary>
    [JsonPropertyName("fingerprint")]
    public string? Fingerprint { get; set; }

    /// <summary>
    /// The two-letter ISO code representing the country the bank account is located in.
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }

    /// <summary>
    /// The statement description as sent to the bank.
    /// </summary>
    [JsonPropertyName("statement_description")]
    public string? StatementDescription { get; set; }

    /// <summary>
    /// ACH-specific information about the transfer. The information is only populated
    /// if the `transfer_type` is `ACH`.
    /// </summary>
    [JsonPropertyName("ach_details")]
    public AchDetails? AchDetails { get; set; }

    /// <summary>
    /// Information about errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
