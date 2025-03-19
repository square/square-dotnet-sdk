using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Devices.Codes;

public record GetCodesRequest
{
    /// <summary>
    /// The unique identifier for the device code.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
