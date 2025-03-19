using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a response from listing order custom attributes.
/// </summary>
public record ListOrderCustomAttributesResponse
{
    /// <summary>
    /// The retrieved custom attributes. If no custom attribute are found, Square returns an empty object (`{}`).
    /// </summary>
    [JsonPropertyName("custom_attributes")]
    public IEnumerable<CustomAttribute>? CustomAttributes { get; set; }

    /// <summary>
    /// The cursor to provide in your next call to this endpoint to retrieve the next page of results for your original request.
    /// This field is present only if the request succeeded and additional results are available.
    /// For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination).
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
