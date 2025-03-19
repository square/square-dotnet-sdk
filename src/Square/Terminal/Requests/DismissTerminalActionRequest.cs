using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Terminal;

public record DismissTerminalActionRequest
{
    /// <summary>
    /// Unique ID for the `TerminalAction` associated with the action to be dismissed.
    /// </summary>
    [JsonIgnore]
    public required string ActionId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
