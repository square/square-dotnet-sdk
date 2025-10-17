using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Bookings.CustomAttributes;

[Serializable]
public record BulkDeleteBookingCustomAttributesRequest
{
    /// <summary>
    /// A map containing 1 to 25 individual Delete requests. For each request, provide an
    /// arbitrary ID that is unique for this `BulkDeleteBookingCustomAttributes` request and the
    /// information needed to delete a custom attribute.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, BookingCustomAttributeDeleteRequest> Values { get; set; } =
        new Dictionary<string, BookingCustomAttributeDeleteRequest>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
