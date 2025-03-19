using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents the details of a tender with `type` `SQUARE_ACCOUNT`.
/// </summary>
public record TenderSquareAccountDetails
{
    /// <summary>
    /// The Square Account payment's current state (such as `AUTHORIZED` or
    /// `CAPTURED`). See [TenderSquareAccountDetailsStatus](entity:TenderSquareAccountDetailsStatus)
    /// for possible values.
    /// See [Status](#type-status) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public TenderSquareAccountDetailsStatus? Status { get; set; }

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
