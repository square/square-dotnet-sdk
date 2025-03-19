using System.Text.Json.Serialization;
using Square.Core;

namespace Square.ApplePay;

public record RegisterDomainRequest
{
    /// <summary>
    /// A domain name as described in RFC-1034 that will be registered with ApplePay.
    /// </summary>
    [JsonPropertyName("domain_name")]
    public required string DomainName { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
