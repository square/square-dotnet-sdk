using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A response that includes loyalty accounts that satisfy the search criteria.
/// </summary>
public record SearchLoyaltyAccountsResponse
{
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

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
