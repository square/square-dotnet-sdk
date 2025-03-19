using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Additional details about Clearpay payments.
/// </summary>
public record ClearpayDetails
{
    /// <summary>
    /// Email address on the buyer's Clearpay account.
    /// </summary>
    [JsonPropertyName("email_address")]
    public string? EmailAddress { get; set; }

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
