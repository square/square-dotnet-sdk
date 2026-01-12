using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Terminal.Actions;

[Serializable]
public record CreateTerminalActionRequest
{
    /// <summary>
    /// A unique string that identifies this `CreateAction` request. Keys can be any valid string
    /// but must be unique for every `CreateAction` request.
    ///
    /// See [Idempotency keys](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency) for more
    /// information.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// The Action to create.
    /// </summary>
    [JsonPropertyName("action")]
    public required TerminalAction Action { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
