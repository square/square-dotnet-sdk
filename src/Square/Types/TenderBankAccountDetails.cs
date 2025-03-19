using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents the details of a tender with `type` `BANK_ACCOUNT`.
///
/// See [BankAccountPaymentDetails](entity:BankAccountPaymentDetails)
/// for more exposed details of a bank account payment.
/// </summary>
public record TenderBankAccountDetails
{
    /// <summary>
    /// The bank account payment's current state.
    ///
    /// See [TenderBankAccountPaymentDetailsStatus](entity:TenderBankAccountDetailsStatus) for possible values.
    /// See [TenderBankAccountDetailsStatus](#type-tenderbankaccountdetailsstatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public TenderBankAccountDetailsStatus? Status { get; set; }

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
