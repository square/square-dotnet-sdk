using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents information about the application used to generate a change.
/// </summary>
public record SourceApplication
{
    /// <summary>
    /// __Read only__ The [product](entity:Product) type of the application.
    /// See [Product](#type-product) for possible values
    /// </summary>
    [JsonPropertyName("product")]
    public Product? Product { get; set; }

    /// <summary>
    /// __Read only__ The Square-assigned ID of the application. This field is used only if the
    /// [product](entity:Product) type is `EXTERNAL_API`.
    /// </summary>
    [JsonPropertyName("application_id")]
    public string? ApplicationId { get; set; }

    /// <summary>
    /// __Read only__ The display name of the application
    /// (for example, `"Custom Application"` or `"Square POS 4.74 for Android"`).
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

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
