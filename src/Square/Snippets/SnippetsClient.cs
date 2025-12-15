using System.Text.Json;
using Square;
using Square.Core;

namespace Square.Snippets;

public partial class SnippetsClient
{
    private RawClient _client;

    internal SnippetsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Retrieves your snippet from a Square Online site. A site can contain snippets from multiple snippet applications, but you can retrieve only the snippet that was added by your application.
    ///
    /// You can call [ListSites](api-endpoint:Sites-ListSites) to get the IDs of the sites that belong to a seller.
    ///
    ///
    /// __Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
    /// </summary>
    /// <example><code>
    /// await client.Snippets.GetAsync(new GetSnippetsRequest { SiteId = "site_id" });
    /// </code></example>
    public async Task<GetSnippetResponse> GetAsync(
        GetSnippetsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/sites/{0}/snippet",
                        ValueConvert.ToPathParameterString(request.SiteId)
                    ),
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<GetSnippetResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Adds a snippet to a Square Online site or updates the existing snippet on the site.
    /// The snippet code is appended to the end of the `head` element on every page of the site, except checkout pages. A snippet application can add one snippet to a given site.
    ///
    /// You can call [ListSites](api-endpoint:Sites-ListSites) to get the IDs of the sites that belong to a seller.
    ///
    ///
    /// __Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
    /// </summary>
    /// <example><code>
    /// await client.Snippets.UpsertAsync(
    ///     new UpsertSnippetRequest
    ///     {
    ///         SiteId = "site_id",
    ///         Snippet = new Snippet { Content = "&lt;script&gt;var js = 1;&lt;/script&gt;" },
    ///     }
    /// );
    /// </code></example>
    public async Task<UpsertSnippetResponse> UpsertAsync(
        UpsertSnippetRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "v2/sites/{0}/snippet",
                        ValueConvert.ToPathParameterString(request.SiteId)
                    ),
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<UpsertSnippetResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Removes your snippet from a Square Online site.
    ///
    /// You can call [ListSites](api-endpoint:Sites-ListSites) to get the IDs of the sites that belong to a seller.
    ///
    ///
    /// __Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
    /// </summary>
    /// <example><code>
    /// await client.Snippets.DeleteAsync(new DeleteSnippetsRequest { SiteId = "site_id" });
    /// </code></example>
    public async Task<DeleteSnippetResponse> DeleteAsync(
        DeleteSnippetsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "v2/sites/{0}/snippet",
                        ValueConvert.ToPathParameterString(request.SiteId)
                    ),
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<DeleteSnippetResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }
}
