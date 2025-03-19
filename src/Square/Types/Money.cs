using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an amount of money. `Money` fields can be signed or unsigned.
/// Fields that do not explicitly define whether they are signed or unsigned are
/// considered unsigned and can only hold positive amounts. For signed fields, the
/// sign of the value indicates the purpose of the money transfer. See
/// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
/// for more information.
/// </summary>
public record Money
{
    /// <summary>
    /// The amount of money, in the smallest denomination of the currency
    /// indicated by `currency`. For example, when `currency` is `USD`, `amount` is
    /// in cents. Monetary amounts can be positive or negative. See the specific
    /// field description to determine the meaning of the sign in a particular case.
    /// </summary>
    [JsonPropertyName("amount")]
    public long? Amount { get; set; }

    /// <summary>
    /// The type of currency, in __ISO 4217 format__. For example, the currency
    /// code for US dollars is `USD`.
    ///
    /// See [Currency](entity:Currency) for possible values.
    /// See [Currency](#type-currency) for possible values
    /// </summary>
    [JsonPropertyName("currency")]
    public Currency? Currency { get; set; }

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
