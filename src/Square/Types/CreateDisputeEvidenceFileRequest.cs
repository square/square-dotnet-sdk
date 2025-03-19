using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines the parameters for a `CreateDisputeEvidenceFile` request.
/// </summary>
public record CreateDisputeEvidenceFileRequest
{
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
    /// The MIME type of the uploaded file.
    /// The type can be image/heic, image/heif, image/jpeg, application/pdf, image/png, or image/tiff.
    /// </summary>
    [JsonPropertyName("content_type")]
    public string? ContentType { get; set; }

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
