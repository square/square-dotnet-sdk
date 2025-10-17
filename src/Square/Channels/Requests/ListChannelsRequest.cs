using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Channels;

[Serializable]
public record ListChannelsRequest
{
    /// <summary>
    /// Type of reference associated to channel
    /// </summary>
    [JsonIgnore]
    public ReferenceType? ReferenceType { get; set; }

    /// <summary>
    /// id of reference associated to channel
    /// </summary>
    [JsonIgnore]
    public string? ReferenceId { get; set; }

    /// <summary>
    /// Status of channel
    /// </summary>
    [JsonIgnore]
    public ChannelStatus? Status { get; set; }

    /// <summary>
    /// Cursor to fetch the next result
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <summary>
    /// Maximum number of results to return.
    /// When not provided the returned results will be cap at 100 channels.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
