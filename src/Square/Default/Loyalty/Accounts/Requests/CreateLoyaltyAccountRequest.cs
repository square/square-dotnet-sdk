using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Loyalty.Accounts;

[Serializable]
public record CreateLoyaltyAccountRequest
{
    /// <summary>
    /// The loyalty account to create.
    /// </summary>
    [JsonPropertyName("loyalty_account")]
    public required LoyaltyAccount LoyaltyAccount { get; set; }

    /// <summary>
    /// A unique string that identifies this `CreateLoyaltyAccount` request.
    /// Keys can be any valid string, but must be unique for every request.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
