using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents the details of a tender with `type` `BANK_ACCOUNT`.
///
/// See [BankAccountPaymentDetails](entity:BankAccountPaymentDetails)
/// for more exposed details of a bank account payment.
/// </summary>
[Serializable]
public record TenderBankAccountDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The bank account payment's current state.
    ///
    /// See [TenderBankAccountPaymentDetailsStatus](entity:TenderBankAccountDetailsStatus) for possible values.
    /// See [TenderBankAccountDetailsStatus](#type-tenderbankaccountdetailsstatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public TenderBankAccountDetailsStatus? Status { get; set; }

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
