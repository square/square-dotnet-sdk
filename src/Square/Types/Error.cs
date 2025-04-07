using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an error encountered during a request to the Connect API.
///
/// See [Handling errors](https://developer.squareup.com/docs/build-basics/handling-errors) for more information.
/// </summary>
public record Error
{
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
