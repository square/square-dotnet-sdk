using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The response object returned by the [RetrieveMerchant](api-endpoint:Merchants-RetrieveMerchant) endpoint.
/// </summary>
public record GetMerchantResponse
{
    /// <summary>
    /// Information on errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The requested `Merchant` object.
    /// </summary>
    [JsonPropertyName("merchant")]
    public Merchant? Merchant { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
