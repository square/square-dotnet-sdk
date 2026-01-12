using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// The timeline for card payments.
/// </summary>
[Serializable]
public record CardPaymentTimeline : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The timestamp when the payment was authorized, in RFC 3339 format.
    /// </summary>
    [JsonPropertyName("authorized_at")]
    public string? AuthorizedAt { get; set; }

    /// <summary>
    /// The timestamp when the payment was captured, in RFC 3339 format.
    /// </summary>
    [JsonPropertyName("captured_at")]
    public string? CapturedAt { get; set; }

    /// <summary>
    /// The timestamp when the payment was voided, in RFC 3339 format.
    /// </summary>
    [JsonPropertyName("voided_at")]
    public string? VoidedAt { get; set; }

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
