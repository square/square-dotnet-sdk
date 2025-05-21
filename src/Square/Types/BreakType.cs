using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A template for a type of [break](entity:Break) that can be added to a
/// [timecard](entity:Timecard), including the expected duration and paid status.
/// </summary>
public record BreakType
{
    /// <summary>
    /// The UUID for this object.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The ID of the business location this type of break applies to.
    /// </summary>
    [JsonPropertyName("location_id")]
    public required string LocationId { get; set; }

    /// <summary>
    /// A human-readable name for this type of break. The name is displayed to
    /// team members in Square products.
    /// </summary>
    [JsonPropertyName("break_name")]
    public required string BreakName { get; set; }

    /// <summary>
    /// Format: RFC-3339 P[n]Y[n]M[n]DT[n]H[n]M[n]S. The expected length of
    /// this break. Precision less than minutes is truncated.
    ///
    /// Example for break expected duration of 15 minutes: PT15M
    /// </summary>
    [JsonPropertyName("expected_duration")]
    public required string ExpectedDuration { get; set; }

    /// <summary>
    /// Whether this break counts towards time worked for compensation
    /// purposes.
    /// </summary>
    [JsonPropertyName("is_paid")]
    public required bool IsPaid { get; set; }

    /// <summary>
    /// Used for resolving concurrency issues. The request fails if the version
    /// provided does not match the server version at the time of the request. If a value is not
    /// provided, Square's servers execute a "blind" write; potentially
    /// overwriting another writer's data.
    /// </summary>
    [JsonPropertyName("version")]
    public int? Version { get; set; }

    /// <summary>
    /// A read-only timestamp in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// A read-only timestamp in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
