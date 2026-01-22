using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// The response object returned by the [ListMerchant](api-endpoint:Merchants-ListMerchants) endpoint.
/// </summary>
[Serializable]
public record ListMerchantsResponse : IJsonOnDeserialized
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
    /// The requested `Merchant` entities.
    /// </summary>
    [JsonPropertyName("merchant")]
    public IEnumerable<Merchant>? Merchant { get; set; }

    /// <summary>
    /// If the  response is truncated, the cursor to use in next  request to fetch next set of objects.
    /// </summary>
    [JsonPropertyName("cursor")]
    public int? Cursor { get; set; }

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
