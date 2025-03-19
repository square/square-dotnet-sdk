using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record ListEmployeesResponse
{
    [JsonPropertyName("employees")]
    public IEnumerable<Employee>? Employees { get; set; }

    /// <summary>
    /// The token to be used to retrieve the next page of results.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

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
