using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Disputes.Evidence;

public record GetEvidenceRequest
{
    /// <summary>
    /// The ID of the dispute from which you want to retrieve evidence metadata.
    /// </summary>
    [JsonIgnore]
    public required string DisputeId { get; set; }

    /// <summary>
    /// The ID of the evidence to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string EvidenceId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
