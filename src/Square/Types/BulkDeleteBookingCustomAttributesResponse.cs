using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a [BulkDeleteBookingCustomAttributes](api-endpoint:BookingCustomAttributes-BulkDeleteBookingCustomAttributes) response,
/// which contains a map of responses that each corresponds to an individual delete request.
/// </summary>
public record BulkDeleteBookingCustomAttributesResponse
{
    /// <summary>
    /// A map of responses that correspond to individual delete requests. Each response has the
    /// same ID as the corresponding request and contains `booking_id` and  `errors` field.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, BookingCustomAttributeDeleteResponse>? Values { get; set; }

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
