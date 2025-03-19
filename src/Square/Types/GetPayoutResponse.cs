using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record GetPayoutResponse
{
    /// <summary>
    /// The requested payout.
    /// </summary>
    [JsonPropertyName("payout")]
    public Payout? Payout { get; set; }

    /// <summary>
    /// Information about errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

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
