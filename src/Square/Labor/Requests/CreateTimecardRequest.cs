using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Labor;

[Serializable]
public record CreateTimecardRequest
{
    /// <summary>
    /// A unique string value to ensure the idempotency of the operation.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// The `Timecard` to be created.
    /// </summary>
    [JsonPropertyName("timecard")]
    public required Timecard Timecard { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
