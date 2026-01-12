using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Defines the fields that are included in the request body for the
/// [BulkRetrieveChannels](api-endpoint:Channels-BulkRetrieveChannels) endpoint.
/// </summary>
[Serializable]
public record BulkRetrieveChannelsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
