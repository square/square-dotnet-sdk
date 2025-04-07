using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Describes a `ListInvoice` response.
/// </summary>
public record ListInvoicesResponse
{
    /// <summary>
    /// The invoices retrieved.
    /// </summary>
    [JsonPropertyName("invoices")]
    public IEnumerable<Invoice>? Invoices { get; set; }

    /// <summary>
    /// When a response is truncated, it includes a cursor that you can use in a
    /// subsequent request to retrieve the next set of invoices. If empty, this is the final
    /// response.
    /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// Information about errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

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
