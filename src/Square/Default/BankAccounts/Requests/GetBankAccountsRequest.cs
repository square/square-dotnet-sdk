using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record GetBankAccountsRequest
{
    /// <summary>
    /// Square-issued ID of the desired `BankAccount`.
    /// </summary>
    [JsonIgnore]
    public required string BankAccountId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
