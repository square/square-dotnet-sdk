using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The response to a request for a set of `EmployeeWage` objects. The response contains
/// a set of `EmployeeWage` objects.
/// </summary>
public record ListEmployeeWagesResponse
{
    /// <summary>
    /// A page of `EmployeeWage` results.
    /// </summary>
    [JsonPropertyName("employee_wages")]
    public IEnumerable<EmployeeWage>? EmployeeWages { get; set; }

    /// <summary>
    /// The value supplied in the subsequent request to fetch the next page
    /// of `EmployeeWage` results.
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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
