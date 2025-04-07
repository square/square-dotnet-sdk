using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines the fields that are included in the response body of
/// a request to the [RegisterDomain](api-endpoint:ApplePay-RegisterDomain) endpoint.
///
/// Either `errors` or `status` are present in a given response (never both).
/// </summary>
public record RegisterDomainResponse
{
    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The status of the domain registration.
    ///
    /// See [RegisterDomainResponseStatus](entity:RegisterDomainResponseStatus) for possible values.
    /// See [RegisterDomainResponseStatus](#type-registerdomainresponsestatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public RegisterDomainResponseStatus? Status { get; set; }

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
