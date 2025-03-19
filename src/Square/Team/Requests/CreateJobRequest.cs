using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Team;

public record CreateJobRequest
{
    /// <summary>
    /// The job to create. The `title` field is required and `is_tip_eligible` defaults to true.
    /// </summary>
    [JsonPropertyName("job")]
    public required Job Job { get; set; }

    /// <summary>
    /// A unique identifier for the `CreateJob` request. Keys can be any valid string,
    /// but must be unique for each request. For more information, see
    /// [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
