using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents an error encountered during a request to the Connect API.
///
/// See [Handling errors](https://developer.squareup.com/docs/build-basics/handling-errors) for more information.
/// </summary>
[Serializable]
public record Error : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The high-level category for the error.
    /// See [ErrorCategory](#type-errorcategory) for possible values
    /// </summary>
    [JsonPropertyName("category")]
    public required ErrorCategory Category { get; set; }

    /// <summary>
    /// The specific code of the error.
    /// See [ErrorCode](#type-errorcode) for possible values
    /// </summary>
    [JsonPropertyName("code")]
    public required ErrorCode Code { get; set; }

    /// <summary>
    /// A human-readable description of the error for debugging purposes.
    /// </summary>
    [JsonPropertyName("detail")]
    public string? Detail { get; set; }

    /// <summary>
    /// The name of the field provided in the original request (if any) that
    /// the error pertains to.
    /// </summary>
    [JsonPropertyName("field")]
    public string? Field { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
