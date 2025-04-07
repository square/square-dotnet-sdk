using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Links an order line item to a fulfillment. Each entry must reference
/// a valid `uid` for an order line item in the `line_item_uid` field, as well as a `quantity` to
/// fulfill.
/// </summary>
public record FulfillmentFulfillmentEntry
{
    /// <summary>
    /// A unique ID that identifies the fulfillment entry only within this order.
    /// </summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>
    /// The `uid` from the order line item.
    /// </summary>
    [JsonPropertyName("line_item_uid")]
    public required string LineItemUid { get; set; }

    /// <summary>
    /// The quantity of the line item being fulfilled, formatted as a decimal number.
    /// For example, `"3"`.
    ///
    /// Fulfillments for line items with a `quantity_unit` can have non-integer quantities.
    /// For example, `"1.70000"`.
    /// </summary>
    [JsonPropertyName("quantity")]
    public required string Quantity { get; set; }

    /// <summary>
    /// Application-defined data attached to this fulfillment entry. Metadata fields are intended
    /// to store descriptive references or associations with an entity in another system or store brief
    /// information about the object. Square does not process this field; it only stores and returns it
    /// in relevant API calls. Do not use metadata to store any sensitive information (such as personally
    /// identifiable information or card details).
    ///
    /// Keys written by applications must be 60 characters or less and must be in the character set
    /// `[a-zA-Z0-9_-]`. Entries can also include metadata generated by Square. These keys are prefixed
    /// with a namespace, separated from the key with a ':' character.
    ///
    /// Values have a maximum length of 255 characters.
    ///
    /// An application can have up to 10 entries per metadata field.
    ///
    /// Entries written by applications are private and can only be read or modified by the same
    /// application.
    ///
    /// For more information, see [Metadata](https://developer.squareup.com/docs/build-basics/metadata).
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, string?>? Metadata { get; set; }

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
