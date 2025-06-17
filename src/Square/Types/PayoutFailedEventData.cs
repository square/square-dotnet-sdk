using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record PayoutFailedEventData
{
    /// <summary>
    /// The name of the affected object's type, `payout`.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// The ID of the failed payout.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// An object containing the failed payout.
    /// </summary>
    [JsonPropertyName("object")]
    public PayoutFailedEventObject? Object { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
