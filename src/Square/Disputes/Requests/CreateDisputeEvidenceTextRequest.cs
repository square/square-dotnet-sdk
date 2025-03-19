using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Disputes;

public record CreateDisputeEvidenceTextRequest
{
    /// <summary>
    /// The ID of the dispute for which you want to upload evidence.
    /// </summary>
    [JsonIgnore]
    public required string DisputeId { get; set; }

    /// <summary>
    /// A unique key identifying the request. For more information, see [Idempotency](https://developer.squareup.com/docs/working-with-apis/idempotency).
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// The type of evidence you are uploading.
    /// See [DisputeEvidenceType](#type-disputeevidencetype) for possible values
    /// </summary>
    [JsonPropertyName("evidence_type")]
    public DisputeEvidenceType? EvidenceType { get; set; }

    /// <summary>
    /// The evidence string.
    /// </summary>
    [JsonPropertyName("evidence_text")]
    public required string EvidenceText { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
