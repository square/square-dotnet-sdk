using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A response that includes the loyalty rewards satisfying the search criteria.
/// </summary>
public record SearchLoyaltyRewardsResponse
{
    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The loyalty rewards that satisfy the search criteria.
    /// These are returned in descending order by `updated_at`.
    /// </summary>
    [JsonPropertyName("rewards")]
    public IEnumerable<LoyaltyReward>? Rewards { get; set; }

    /// <summary>
    /// The pagination cursor to be used in a subsequent
    /// request. If empty, this is the final response.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

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
