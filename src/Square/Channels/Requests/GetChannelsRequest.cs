using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Channels;

[Serializable]
public record GetChannelsRequest
{
    /// <summary>
    /// A channel id
    /// </summary>
    [JsonIgnore]
    public required string ChannelId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
