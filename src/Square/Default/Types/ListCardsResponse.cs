using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Defines the fields that are included in the response body of
/// a request to the [ListCards](api-endpoint:Cards-ListCards) endpoint.
///
/// Note: if there are errors processing the request, the card field will not be
/// present.
/// </summary>
[Serializable]
public record ListCardsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Information on errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The requested list of `Card`s.
    /// </summary>
    [JsonPropertyName("cards")]
    public IEnumerable<Card>? Cards { get; set; }

    /// <summary>
    /// The pagination cursor to be used in a subsequent request. If empty,
    /// this is the final response.
    ///
    /// See [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination) for more information.
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
