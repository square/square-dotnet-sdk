using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Snippets;

[Serializable]
public record DeleteSnippetsRequest
{
    /// <summary>
    /// The ID of the site that contains the snippet.
    /// </summary>
    [JsonIgnore]
    public required string SiteId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
