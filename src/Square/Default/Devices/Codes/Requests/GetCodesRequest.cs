using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Devices.Codes;

[Serializable]
public record GetCodesRequest
{
    /// <summary>
    /// The unique identifier for the device code.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
