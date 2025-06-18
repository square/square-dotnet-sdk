using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record VendorUpdatedEventObject
{
    /// <summary>
    /// The operation on the vendor that caused the event to be published. The value is `UPDATED`.
    /// See [Operation](#type-operation) for possible values
    /// </summary>
    [JsonPropertyName("operation")]
    public string? Operation { get; set; }

    /// <summary>
    /// The updated vendor as the result of the specified operation.
    /// </summary>
    [JsonPropertyName("vendor")]
    public Vendor? Vendor { get; set; }

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
