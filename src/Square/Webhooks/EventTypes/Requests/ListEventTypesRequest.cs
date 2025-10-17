using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Webhooks.EventTypes;

[Serializable]
public record ListEventTypesRequest
{
    /// <summary>
    /// The API version for which to list event types. Setting this field overrides the default version used by the application.
    /// </summary>
    [JsonIgnore]
    public string? ApiVersion { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
