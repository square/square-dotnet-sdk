using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// The response to a request for a set of `TeamMemberWage` objects. The response contains
/// a set of `TeamMemberWage` objects.
/// </summary>
[Serializable]
public record ListTeamMemberWagesResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A page of `TeamMemberWage` results.
    /// </summary>
    [JsonPropertyName("team_member_wages")]
    public IEnumerable<TeamMemberWage>? TeamMemberWages { get; set; }

    /// <summary>
    /// The value supplied in the subsequent request to fetch the next page
    /// of `TeamMemberWage` results.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

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
