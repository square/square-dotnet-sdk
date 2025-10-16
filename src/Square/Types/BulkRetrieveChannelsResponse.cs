using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines the fields that are included in the request body for the
/// [BulkRetrieveChannels](api-endpoint:Channels-BulkRetrieveChannels) endpoint.
/// </summary>
public record BulkRetrieveChannelsResponse
{
    /// <summary>
    /// Information about errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// A map of channel IDs to channel responses which tell whether
    /// retrieval for a specific channel is success or not.
    /// Channel response of a success retrieval would contain channel info
    /// whereas channel response of a failed retrieval would have error info.
    /// </summary>
    [JsonPropertyName("responses")]
    public Dictionary<string, RetrieveChannelResponse>? Responses { get; set; }

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
