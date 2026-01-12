using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

[Serializable]
public record V1Money : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
