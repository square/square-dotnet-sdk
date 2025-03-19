using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A custom attribute value. Each custom attribute value has a corresponding
/// `CustomAttributeDefinition` object.
/// </summary>
public record CustomAttribute
{
    /// <summary>
    /// The identifier
    /// of the custom attribute definition and its corresponding custom attributes. This value
    /// can be a simple key, which is the key that is provided when the custom attribute definition
    /// is created, or a qualified key, if the requesting
    /// application is not the definition owner. The qualified key consists of the application ID
    /// of the custom attribute definition owner
    /// followed by the simple key that was provided when the definition was created. It has the
    /// format application_id:simple key.
    ///
    /// The value for a simple key can contain up to 60 alphanumeric characters, periods (.),
    /// underscores (_), and hyphens (-).
    /// </summary>
    [JsonPropertyName("key")]
    public string? Key { get; set; }

    [JsonPropertyName("value")]
    public object? Value { get; set; }

    /// <summary>
    /// Read only. The current version of the custom attribute. This field is incremented when the custom attribute is changed.
    /// When updating an existing custom attribute value, you can provide this field
    /// and specify the current version of the custom attribute to enable
    /// [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency).
    /// This field can also be used to enforce strong consistency for reads. For more information about strong consistency for reads,
    /// see [Custom Attributes Overview](https://developer.squareup.com/docs/devtools/customattributes/overview).
    /// </summary>
    [JsonPropertyName("version")]
    public int? Version { get; set; }

    /// <summary>
    /// A copy of the `visibility` field value for the associated custom attribute definition.
    /// See [CustomAttributeDefinitionVisibility](#type-customattributedefinitionvisibility) for possible values
    /// </summary>
    [JsonPropertyName("visibility")]
    public CustomAttributeDefinitionVisibility? Visibility { get; set; }

    /// <summary>
    /// A copy of the associated custom attribute definition object. This field is only set when
    /// the optional field is specified on the request.
    /// </summary>
    [JsonPropertyName("definition")]
    public CustomAttributeDefinition? Definition { get; set; }

    /// <summary>
    /// The timestamp that indicates when the custom attribute was created or was most recently
    /// updated, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// The timestamp that indicates when the custom attribute was created, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

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
