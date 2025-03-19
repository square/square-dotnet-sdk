using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents communication preferences for the customer profile.
/// </summary>
public record CustomerPreferences
{
    /// <summary>
    /// Indicates whether the customer has unsubscribed from marketing campaign emails. A value of `true` means that the customer chose to opt out of email marketing from the current Square seller or from all Square sellers. This value is read-only from the Customers API.
    /// </summary>
    [JsonPropertyName("email_unsubscribed")]
    public bool? EmailUnsubscribed { get; set; }

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
