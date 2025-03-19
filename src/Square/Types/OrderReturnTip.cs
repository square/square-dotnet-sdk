using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A tip being returned.
/// </summary>
public record OrderReturnTip
{
    /// <summary>
    /// A unique ID that identifies the tip only within this order.
    /// </summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>
    /// The amount of tip being returned
    /// --
    /// </summary>
    [JsonPropertyName("applied_money")]
    public Money? AppliedMoney { get; set; }

    /// <summary>
    /// The tender `uid` from the order that contains the original application of this tip.
    /// </summary>
    [JsonPropertyName("source_tender_uid")]
    public string? SourceTenderUid { get; set; }

    /// <summary>
    /// The tender `id` from the order that contains the original application of this tip.
    /// </summary>
    [JsonPropertyName("source_tender_id")]
    public string? SourceTenderId { get; set; }

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
