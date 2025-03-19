using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Locations;

public record CreateLocationRequest
{
    /// <summary>
    /// The initial values of the location being created. The `name` field is required and must be unique within a seller account.
    /// All other fields are optional, but any information you care about for the location should be included.
    /// The remaining fields are automatically added based on the data from the [main location](https://developer.squareup.com/docs/locations-api#about-the-main-location).
    /// </summary>
    [JsonPropertyName("location")]
    public Location? Location { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
