using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Details about the application that took the payment.
/// </summary>
public record ApplicationDetails
{
    /// <summary>
    /// The Square product, such as Square Point of Sale (POS),
    /// Square Invoices, or Square Virtual Terminal.
    /// See [ExternalSquareProduct](#type-externalsquareproduct) for possible values
    /// </summary>
    [JsonPropertyName("square_product")]
    public ApplicationDetailsExternalSquareProduct? SquareProduct { get; set; }

    /// <summary>
    /// The Square ID assigned to the application used to take the payment.
    /// Application developers can use this information to identify payments that
    /// their application processed.
    /// For example, if a developer uses a custom application to process payments,
    /// this field contains the application ID from the Developer Dashboard.
    /// If a seller uses a [Square App Marketplace](https://developer.squareup.com/docs/app-marketplace)
    /// application to process payments, the field contains the corresponding application ID.
    /// </summary>
    [JsonPropertyName("application_id")]
    public string? ApplicationId { get; set; }

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
