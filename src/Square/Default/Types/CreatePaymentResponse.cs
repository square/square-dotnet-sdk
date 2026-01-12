using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Defines the response returned by [CreatePayment](api-endpoint:Payments-CreatePayment).
///
/// If there are errors processing the request, the `payment` field might not be
/// present, or it might be present with a status of `FAILED`.
/// </summary>
[Serializable]
public record CreatePaymentResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Information about errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The newly created payment.
    /// </summary>
    [JsonPropertyName("payment")]
    public Payment? Payment { get; set; }

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
