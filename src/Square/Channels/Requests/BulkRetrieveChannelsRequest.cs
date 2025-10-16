using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Channels;

public record BulkRetrieveChannelsRequest
{
    [JsonPropertyName("channel_ids")]
    public IEnumerable<string> ChannelIds { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
