using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents the parameters in a search for `TeamMember` objects.
/// </summary>
public record SearchTeamMembersQuery
{
    /// <summary>
    /// The options to filter by.
    /// </summary>
    [JsonPropertyName("filter")]
    public SearchTeamMembersFilter? Filter { get; set; }

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
