using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Devices.Codes;

public record CreateDeviceCodeRequest
{
    /// <summary>
    /// A unique string that identifies this CreateDeviceCode request. Keys can
    /// be any valid string but must be unique for every CreateDeviceCode request.
    ///
    /// See [Idempotency keys](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency) for more information.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// The device code to create.
    /// </summary>
    [JsonPropertyName("device_code")]
    public required DeviceCode DeviceCode { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
