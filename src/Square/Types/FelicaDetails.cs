using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Details for Felica payments.
/// </summary>
[Serializable]
public record FelicaDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The terminal id for a Felica payment.
    /// </summary>
    [JsonPropertyName("terminal_id")]
    public string? TerminalId { get; set; }

    /// <summary>
    /// The masked card number for a Felica payment.
    /// </summary>
    [JsonPropertyName("felica_masked_card_number")]
    public string? FelicaMaskedCardNumber { get; set; }

    /// <summary>
    /// The Felica sub-brand of the payment.
    /// See [FelicaBrand](#type-felicabrand) for possible values
    /// </summary>
    [JsonPropertyName("felica_brand")]
    public FelicaDetailsFelicaBrand? FelicaBrand { get; set; }

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
