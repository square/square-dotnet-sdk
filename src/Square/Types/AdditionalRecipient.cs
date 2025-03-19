using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an additional recipient (other than the merchant) receiving a portion of this tender.
/// </summary>
public record AdditionalRecipient
{
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
