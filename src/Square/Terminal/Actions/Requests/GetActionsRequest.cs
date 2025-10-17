using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Terminal.Actions;

[Serializable]
public record GetActionsRequest
{
    /// <summary>
    /// Unique ID for the desired `TerminalAction`.
    /// </summary>
    [JsonIgnore]
    public required string ActionId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
