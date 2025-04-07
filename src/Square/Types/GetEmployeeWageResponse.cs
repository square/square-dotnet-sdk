using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A response to a request to get an `EmployeeWage`. The response contains
/// the requested `EmployeeWage` objects and might contain a set of `Error` objects if
/// the request resulted in errors.
/// </summary>
public record GetEmployeeWageResponse
{
    /// <summary>
    /// The requested `EmployeeWage` object.
    /// </summary>
    [JsonPropertyName("employee_wage")]
    public EmployeeWage? EmployeeWage { get; set; }

    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

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
