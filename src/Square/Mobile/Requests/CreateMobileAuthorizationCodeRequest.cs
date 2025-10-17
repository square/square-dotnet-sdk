using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Mobile;

[Serializable]
public record CreateMobileAuthorizationCodeRequest
{
    /// <summary>
    /// The Square location ID that the authorization code should be tied to.
    /// </summary>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
