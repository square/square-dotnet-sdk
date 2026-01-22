using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Disputes;

[Serializable]
public record DeleteEvidenceRequest
{
    /// <summary>
    /// The ID of the dispute from which you want to remove evidence.
    /// </summary>
    [JsonIgnore]
    public required string DisputeId { get; set; }

    /// <summary>
    /// The ID of the evidence you want to remove.
    /// </summary>
    [JsonIgnore]
    public required string EvidenceId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
