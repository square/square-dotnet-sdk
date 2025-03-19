using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Snippets;

public record UpsertSnippetRequest
{
    /// <summary>
    /// The ID of the site where you want to add or update the snippet.
    /// </summary>
    [JsonIgnore]
    public required string SiteId { get; set; }

    /// <summary>
    /// The snippet for the site.
    /// </summary>
    [JsonPropertyName("snippet")]
    public required Snippet Snippet { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
