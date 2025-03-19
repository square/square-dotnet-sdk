using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Labor.Shifts;

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

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
