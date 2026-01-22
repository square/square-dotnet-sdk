using System.Text.Json.Serialization;
using Square.Core;

namespace Square.BankAccounts;

[Serializable]
public record DisableBankAccountRequest
{
    /// <summary>
    /// The ID of the bank account to disable.
    /// </summary>
    [JsonIgnore]
    public required string BankAccountId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
