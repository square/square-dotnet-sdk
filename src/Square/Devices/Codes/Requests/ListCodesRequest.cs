using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Devices.Codes;

public record ListCodesRequest
{
    /// <summary>
    /// A pagination cursor returned by a previous call to this endpoint.
    /// Provide this to retrieve the next set of results for your original query.
    ///
    /// See [Paginating results](https://developer.squareup.com/docs/working-with-apis/pagination) for more information.
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <summary>
    /// If specified, only returns DeviceCodes of the specified location.
    /// Returns DeviceCodes of all locations if empty.
    /// </summary>
    [JsonIgnore]
    public string? LocationId { get; set; }

    /// <summary>
    /// If specified, only returns DeviceCodes targeting the specified product type.
    /// Returns DeviceCodes of all product types if empty.
    /// </summary>
    [JsonIgnore]
    public string? ProductType { get; set; }

    /// <summary>
    /// If specified, returns DeviceCodes with the specified statuses.
    /// Returns DeviceCodes of status `PAIRED` and `UNPAIRED` if empty.
    /// </summary>
    [JsonIgnore]
    public DeviceCodeStatus? Status { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
