using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record V1Money
{
    /// <summary>
    /// Amount in the lowest denominated value of this Currency. E.g. in USD
    /// these are cents, in JPY they are Yen (which do not have a 'cent' concept).
    /// </summary>
    [JsonPropertyName("amount")]
    public int? Amount { get; set; }

    /// <summary>
    /// See [Currency](#type-currency) for possible values
    /// </summary>
    [JsonPropertyName("currency_code")]
    public Currency? CurrencyCode { get; set; }

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
