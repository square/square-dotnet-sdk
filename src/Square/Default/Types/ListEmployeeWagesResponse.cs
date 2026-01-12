using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// The response to a request for a set of `EmployeeWage` objects. The response contains
/// a set of `EmployeeWage` objects.
/// </summary>
[Serializable]
public record ListEmployeeWagesResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
