using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents an additional recipient (other than the merchant) receiving a portion of this tender.
/// </summary>
[Serializable]
public record AdditionalRecipient : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The location ID for a recipient (other than the merchant) receiving a portion of this tender.
    /// </summary>
    [JsonPropertyName("location_id")]
    public required string LocationId { get; set; }

    /// <summary>
    /// The description of the additional recipient.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The amount of money distributed to the recipient.
    /// </summary>
    [JsonPropertyName("amount_money")]
    public required Money AmountMoney { get; set; }

    /// <summary>
    /// The unique ID for the RETIRED `AdditionalRecipientReceivable` object. This field should be empty for any `AdditionalRecipient` objects created after the retirement.
    /// </summary>
    [JsonPropertyName("receivable_id")]
    public string? ReceivableId { get; set; }

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
