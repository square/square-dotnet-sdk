using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Disputes;

[Serializable]
public record SubmitEvidenceDisputesRequest
{
    /// <summary>
    /// The ID of the dispute for which you want to submit evidence.
    /// </summary>
    [JsonIgnore]
    public required string DisputeId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
