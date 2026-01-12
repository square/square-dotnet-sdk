using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// A response that includes loyalty accounts that satisfy the search criteria.
/// </summary>
[Serializable]
public record SearchLoyaltyAccountsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The loyalty accounts that met the search criteria,
    /// in order of creation date.
    /// </summary>
    [JsonPropertyName("loyalty_accounts")]
    public IEnumerable<LoyaltyAccount>? LoyaltyAccounts { get; set; }

    /// <summary>
    /// The pagination cursor to use in a subsequent
    /// request. If empty, this is the final response.
    /// For more information,
    /// see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
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
