using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Bookings.CustomAttributes;

public record BulkUpsertBookingCustomAttributesRequest
{
    /// <summary>
    /// A map containing 1 to 25 individual upsert requests. For each request, provide an
    /// arbitrary ID that is unique for this `BulkUpsertBookingCustomAttributes` request and the
    /// information needed to create or update a custom attribute.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, BookingCustomAttributeUpsertRequest> Values { get; set; } =
        new Dictionary<string, BookingCustomAttributeUpsertRequest>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
