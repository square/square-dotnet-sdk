using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Devices;

public record GetDevicesRequest
{
    /// <summary>
    /// The unique ID for the desired `Device`.
    /// </summary>
    [JsonIgnore]
    public required string DeviceId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
