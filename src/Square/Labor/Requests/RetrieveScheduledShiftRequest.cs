using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Labor;

public record RetrieveScheduledShiftRequest
{
    /// <summary>
    /// The ID of the scheduled shift to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
