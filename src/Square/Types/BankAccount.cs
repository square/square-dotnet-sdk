using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a bank account. For more information about
/// linking a bank account to a Square account, see
/// [Bank Accounts API](https://developer.squareup.com/docs/bank-accounts-api).
/// </summary>
[Serializable]
public record BankAccount : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The unique, Square-issued identifier for the bank account.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The last few digits of the account number.
    /// </summary>
    [JsonPropertyName("account_number_suffix")]
    public required string AccountNumberSuffix { get; set; }

    /// <summary>
    /// The ISO 3166 Alpha-2 country code where the bank account is based.
    /// See [Country](#type-country) for possible values
    /// </summary>
    [JsonPropertyName("country")]
    public required Country Country { get; set; }

    /// <summary>
    /// The 3-character ISO 4217 currency code indicating the operating
    /// currency of the bank account. For example, the currency code for US dollars
    /// is `USD`.
    /// See [Currency](#type-currency) for possible values
    /// </summary>
    [JsonPropertyName("currency")]
    public required Currency Currency { get; set; }

    /// <summary>
    /// The financial purpose of the associated bank account.
    /// See [BankAccountType](#type-bankaccounttype) for possible values
    /// </summary>
    [JsonPropertyName("account_type")]
    public required BankAccountType AccountType { get; set; }

    /// <summary>
    /// Name of the account holder. This name must match the name
    /// on the targeted bank account record.
    /// </summary>
    [JsonPropertyName("holder_name")]
    public required string HolderName { get; set; }

    /// <summary>
    /// Primary identifier for the bank. For more information, see
    /// [Bank Accounts API](https://developer.squareup.com/docs/bank-accounts-api).
    /// </summary>
    [JsonPropertyName("primary_bank_identification_number")]
    public required string PrimaryBankIdentificationNumber { get; set; }

    /// <summary>
    /// Secondary identifier for the bank. For more information, see
    /// [Bank Accounts API](https://developer.squareup.com/docs/bank-accounts-api).
    /// </summary>
    [JsonPropertyName("secondary_bank_identification_number")]
    public string? SecondaryBankIdentificationNumber { get; set; }

    /// <summary>
    /// Reference identifier that will be displayed to UK bank account owners
    /// when collecting direct debit authorization. Only required for UK bank accounts.
    /// </summary>
    [JsonPropertyName("debit_mandate_reference_id")]
    public string? DebitMandateReferenceId { get; set; }

    /// <summary>
    /// Client-provided identifier for linking the banking account to an entity
    /// in a third-party system (for example, a bank account number or a user identifier).
    /// </summary>
    [JsonPropertyName("reference_id")]
    public string? ReferenceId { get; set; }

    /// <summary>
    /// The location to which the bank account belongs.
    /// </summary>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <summary>
    /// Read-only. The current verification status of this BankAccount object.
    /// See [BankAccountStatus](#type-bankaccountstatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public required BankAccountStatus Status { get; set; }

    /// <summary>
    /// Indicates whether it is possible for Square to send money to this bank account.
    /// </summary>
    [JsonPropertyName("creditable")]
    public required bool Creditable { get; set; }

    /// <summary>
    /// Indicates whether it is possible for Square to take money from this
    /// bank account.
    /// </summary>
    [JsonPropertyName("debitable")]
    public required bool Debitable { get; set; }

    /// <summary>
    /// A Square-assigned, unique identifier for the bank account based on the
    /// account information. The account fingerprint can be used to compare account
    /// entries and determine if the they represent the same real-world bank account.
    /// </summary>
    [JsonPropertyName("fingerprint")]
    public string? Fingerprint { get; set; }

    /// <summary>
    /// The current version of the `BankAccount`.
    /// </summary>
    [JsonPropertyName("version")]
    public int? Version { get; set; }

    /// <summary>
    /// Read only. Name of actual financial institution.
    /// For example "Bank of America".
    /// </summary>
    [JsonPropertyName("bank_name")]
    public string? BankName { get; set; }

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
