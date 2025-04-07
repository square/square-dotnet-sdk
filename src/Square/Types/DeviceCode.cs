using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record DeviceCode
{
    /// <summary>
    /// The unique id for this device code.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// An optional user-defined name for the device code.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The unique code that can be used to login.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    /// <summary>
    /// The unique id of the device that used this code. Populated when the device is paired up.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("device_id")]
    public string? DeviceId { get; set; }

    /// <summary>
    /// The targeting product type of the device code.
    /// </summary>
    [JsonPropertyName("product_type")]
    public string ProductType { get; set; } = "TERMINAL_API";

    /// <summary>
    /// The location assigned to this code.
    /// </summary>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <summary>
    /// The pairing status of the device code.
    /// See [DeviceCodeStatus](#type-devicecodestatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public DeviceCodeStatus? Status { get; set; }

    /// <summary>
    /// When this DeviceCode will expire and no longer login. Timestamp in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("pair_by")]
    public string? PairBy { get; set; }

    /// <summary>
    /// When this DeviceCode was created. Timestamp in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// When this DeviceCode's status was last changed. Timestamp in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("status_changed_at")]
    public string? StatusChangedAt { get; set; }

    /// <summary>
    /// When this DeviceCode was paired. Timestamp in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("paired_at")]
    public string? PairedAt { get; set; }

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
