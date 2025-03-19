using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an output from a call to [SearchVendors](api-endpoint:Vendors-SearchVendors).
/// </summary>
public record SearchVendorsResponse
{
    /// <summary>
    /// Errors encountered when the request fails.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The [Vendor](entity:Vendor) objects matching the specified search filter.
    /// </summary>
    [JsonPropertyName("vendors")]
    public IEnumerable<Vendor>? Vendors { get; set; }

    /// <summary>
    /// The pagination cursor to be used in a subsequent request. If unset,
    /// this is the final response.
    ///
    /// See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

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
