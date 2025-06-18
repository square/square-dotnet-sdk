using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// An object that contains the customer associated with the event.
/// </summary>
public record CustomerCreatedEventObject
{
    /// <summary>
    /// The new customer.
    /// </summary>
    [JsonPropertyName("customer")]
    public Customer? Customer { get; set; }

    /// <summary>
    /// Information about the change that triggered the event. This field is returned only if the customer is created by a merge operation.
    /// </summary>
    [JsonPropertyName("event_context")]
    public CustomerCreatedEventEventContext? EventContext { get; set; }

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
