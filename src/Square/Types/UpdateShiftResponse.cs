using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The response to a request to update a `Shift`. The response contains
/// the updated `Shift` object and might contain a set of `Error` objects if
/// the request resulted in errors.
/// </summary>
public record UpdateShiftResponse
{
    /// <summary>
    /// The updated `Shift`.
    /// </summary>
    [JsonPropertyName("shift")]
    public Shift? Shift { get; set; }

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
