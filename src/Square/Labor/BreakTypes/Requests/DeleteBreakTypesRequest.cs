using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Labor.BreakTypes;

public record DeleteBreakTypesRequest
{
    /// <summary>
    /// The UUID for the `BreakType` being deleted.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
