using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Labor;

[Serializable]
public record CreateBreakTypeRequest
{
    /// <summary>
    /// A unique string value to ensure the idempotency of the operation.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// The `BreakType` to be created.
    /// </summary>
    [JsonPropertyName("break_type")]
    public required BreakType BreakType { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
