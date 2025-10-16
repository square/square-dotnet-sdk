using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record TransferOrderUpdatedEventObject
{
    /// <summary>
    /// The updated transfer_order.
    /// </summary>
    [JsonPropertyName("transfer_order")]
    public TransferOrder? TransferOrder { get; set; }

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
