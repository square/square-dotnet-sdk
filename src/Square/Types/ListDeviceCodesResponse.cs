using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record ListDeviceCodesResponse
{
    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The queried DeviceCode.
    /// </summary>
    [JsonPropertyName("device_codes")]
    public IEnumerable<DeviceCode>? DeviceCodes { get; set; }

    /// <summary>
    /// A pagination cursor to retrieve the next set of results for your
    /// original query to the endpoint. This value is present only if the request
    /// succeeded and additional results are available.
    ///
    /// See [Paginating results](https://developer.squareup.com/docs/working-with-apis/pagination) for more information.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
