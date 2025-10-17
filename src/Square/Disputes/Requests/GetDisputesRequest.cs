using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Disputes;

[Serializable]
public record GetDisputesRequest
{
    /// <summary>
    /// The ID of the dispute you want more details about.
    /// </summary>
    [JsonIgnore]
    public required string DisputeId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
