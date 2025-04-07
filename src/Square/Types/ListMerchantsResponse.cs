using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The response object returned by the [ListMerchant](api-endpoint:Merchants-ListMerchants) endpoint.
/// </summary>
public record ListMerchantsResponse
{
    /// <summary>
    /// Information on errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The requested `Merchant` entities.
    /// </summary>
    [JsonPropertyName("merchant")]
    public IEnumerable<Merchant>? Merchant { get; set; }

    /// <summary>
    /// If the  response is truncated, the cursor to use in next  request to fetch next set of objects.
    /// </summary>
    [JsonPropertyName("cursor")]
    public int? Cursor { get; set; }

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
