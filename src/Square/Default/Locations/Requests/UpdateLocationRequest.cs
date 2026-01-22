using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record UpdateLocationRequest
{
    /// <summary>
    /// The ID of the location to update.
    /// </summary>
    [JsonIgnore]
    public required string LocationId { get; set; }

    /// <summary>
    /// The `Location` object with only the fields to update.
    /// </summary>
    [JsonPropertyName("location")]
    public Location? Location { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
