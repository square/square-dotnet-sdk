using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Labor.Shifts;

[Serializable]
public record CreateShiftRequest
{
    /// <summary>
    /// A unique string value to ensure the idempotency of the operation.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// The `Shift` to be created.
    /// </summary>
    [JsonPropertyName("shift")]
    public required Shift Shift { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
