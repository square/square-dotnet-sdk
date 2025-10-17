using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines the response returned by [ListPaymentRefunds](api-endpoint:Refunds-ListPaymentRefunds).
///
/// Either `errors` or `refunds` is present in a given response (never both).
/// </summary>
[Serializable]
public record ListPaymentRefundsResponse : IJsonOnDeserialized
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
    /// The list of requested refunds.
    /// </summary>
    [JsonPropertyName("refunds")]
    public IEnumerable<PaymentRefund>? Refunds { get; set; }

    /// <summary>
    /// The pagination cursor to be used in a subsequent request. If empty,
    /// this is the final response.
    ///
    /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

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
