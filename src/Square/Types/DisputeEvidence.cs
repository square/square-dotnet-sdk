using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record DisputeEvidence
{
    /// <summary>
    /// The Square-generated ID of the evidence.
    /// </summary>
    [JsonPropertyName("evidence_id")]
    public string? EvidenceId { get; set; }

    /// <summary>
    /// The Square-generated ID of the evidence.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The ID of the dispute the evidence is associated with.
    /// </summary>
    [JsonPropertyName("dispute_id")]
    public string? DisputeId { get; set; }

    /// <summary>
    /// Image, PDF, TXT
    /// </summary>
    [JsonPropertyName("evidence_file")]
    public DisputeEvidenceFile? EvidenceFile { get; set; }

    /// <summary>
    /// Raw text
    /// </summary>
    [JsonPropertyName("evidence_text")]
    public string? EvidenceText { get; set; }

    /// <summary>
    /// The time when the evidence was uploaded, in RFC 3339 format.
    /// </summary>
    [JsonPropertyName("uploaded_at")]
    public string? UploadedAt { get; set; }

    /// <summary>
    /// The type of the evidence.
    /// See [DisputeEvidenceType](#type-disputeevidencetype) for possible values
    /// </summary>
    [JsonPropertyName("evidence_type")]
    public DisputeEvidenceType? EvidenceType { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
