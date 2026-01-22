using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

[Serializable]
public record CreateEvidenceFileDisputesRequest
{
    /// <summary>
    /// The ID of the dispute for which you want to upload evidence.
    /// </summary>
    [JsonIgnore]
    public required string DisputeId { get; set; }

    public CreateDisputeEvidenceFileRequest? Request { get; set; }

    public FileParameter? ImageFile { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
