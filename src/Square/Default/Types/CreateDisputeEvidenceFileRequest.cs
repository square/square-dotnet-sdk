using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Defines the parameters for a `CreateDisputeEvidenceFile` request.
/// </summary>
[Serializable]
public record CreateDisputeEvidenceFileRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
