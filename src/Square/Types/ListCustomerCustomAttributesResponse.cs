using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a [ListCustomerCustomAttributes](api-endpoint:CustomerCustomAttributes-ListCustomerCustomAttributes) response.
/// Either `custom_attributes`, an empty object, or `errors` is present in the response. If additional
/// results are available, the `cursor` field is also present along with `custom_attributes`.
/// </summary>
public record ListCustomerCustomAttributesResponse
{
    /// <summary>
    /// The retrieved custom attributes. If `with_definitions` was set to `true` in the request,
    /// the custom attribute definition is returned in the `definition` field of each custom attribute.
    ///
    /// If no custom attributes are found, Square returns an empty object (`{}`).
    /// </summary>
    [JsonPropertyName("custom_attributes")]
    public IEnumerable<CustomAttribute>? CustomAttributes { get; set; }

    /// <summary>
    /// The cursor to use in your next call to this endpoint to retrieve the next page of results
    /// for your original request. This field is present only if the request succeeded and additional
    /// results are available. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
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
