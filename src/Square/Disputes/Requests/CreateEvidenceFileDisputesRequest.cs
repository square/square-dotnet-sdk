using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Disputes;

public record CreateEvidenceFileDisputesRequest
{
    /// <summary>
    /// The ID of the dispute for which you want to upload evidence.
    /// </summary>
    [JsonIgnore]
    public required string DisputeId { get; set; }

    public CreateDisputeEvidenceFileRequest? Request { get; set; }

    public FileParameter? ImageFile { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
