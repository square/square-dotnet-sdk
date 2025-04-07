using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines supported query expressions to search for vendors by.
/// </summary>
public record SearchVendorsRequestFilter
{
    /// <summary>
    /// The names of the [Vendor](entity:Vendor) objects to retrieve.
    /// </summary>
    [JsonPropertyName("name")]
    public IEnumerable<string>? Name { get; set; }

    /// <summary>
    /// The statuses of the [Vendor](entity:Vendor) objects to retrieve.
    /// See [VendorStatus](#type-vendorstatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public IEnumerable<VendorStatus>? Status { get; set; }

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
