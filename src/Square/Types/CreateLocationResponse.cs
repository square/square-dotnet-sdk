using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The response object returned by the [CreateLocation](api-endpoint:Locations-CreateLocation) endpoint.
/// </summary>
public record CreateLocationResponse
{
    /// <summary>
    /// Information about [errors](https://developer.squareup.com/docs/build-basics/handling-errors) encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The newly created `Location` object.
    /// </summary>
    [JsonPropertyName("location")]
    public Location? Location { get; set; }

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
