using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Checkout;

[Serializable]
public record RetrieveLocationSettingsRequest
{
    /// <summary>
    /// The ID of the location for which to retrieve settings.
    /// </summary>
    [JsonIgnore]
    public required string LocationId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
