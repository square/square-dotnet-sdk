using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a [ListBookingCustomAttributeDefinitions](api-endpoint:BookingCustomAttributes-ListBookingCustomAttributeDefinitions) response.
/// Either `custom_attribute_definitions`, an empty object, or `errors` is present in the response.
/// If additional results are available, the `cursor` field is also present along with `custom_attribute_definitions`.
/// </summary>
public record ListBookingCustomAttributeDefinitionsResponse
{
    /// <summary>
    /// The retrieved custom attribute definitions. If no custom attribute definitions are found,
    /// Square returns an empty object (`{}`).
    /// </summary>
    [JsonPropertyName("custom_attribute_definitions")]
    public IEnumerable<CustomAttributeDefinition>? CustomAttributeDefinitions { get; set; }

    /// <summary>
    /// The cursor to provide in your next call to this endpoint to retrieve the next page of
    /// results for your original request. This field is present only if the request succeeded and
    /// additional results are available. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
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
