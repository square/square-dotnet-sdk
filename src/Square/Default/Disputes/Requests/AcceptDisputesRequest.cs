using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Disputes;

[Serializable]
public record AcceptDisputesRequest
{
    /// <summary>
    /// The ID of the dispute you want to accept.
    /// </summary>
    [JsonIgnore]
    public required string DisputeId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
