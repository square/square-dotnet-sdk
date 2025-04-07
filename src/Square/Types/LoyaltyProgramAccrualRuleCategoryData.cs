using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents additional data for rules with the `CATEGORY` accrual type.
/// </summary>
public record LoyaltyProgramAccrualRuleCategoryData
{
    /// <summary>
    /// The ID of the `CATEGORY` [catalog object](entity:CatalogObject) that buyers can purchase to earn
    /// points.
    /// </summary>
    [JsonPropertyName("category_id")]
    public required string CategoryId { get; set; }

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
