using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Snippets;

public record DeleteSnippetsRequest
{
    /// <summary>
    /// The ID of the site that contains the snippet.
    /// </summary>
    [JsonIgnore]
    public required string SiteId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
