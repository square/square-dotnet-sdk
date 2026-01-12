using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Locations;

[Serializable]
public record GetLocationsRequest
{
    /// <summary>
    /// The ID of the location to retrieve. Specify the string
    /// "main" to return the main location.
    /// </summary>
    [JsonIgnore]
    public required string LocationId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
