using System.Text.Json;
using Square;
using Square.Core;

namespace Square.Sites;

public partial class SitesClient : ISitesClient
{
    private RawClient _client;

    internal SitesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Lists the Square Online sites that belong to a seller. Sites are listed in descending order by the `created_at` date.
    ///
    ///
    /// __Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
    /// </summary>
    /// <example><code>
    /// await client.Sites.ListAsync();
    /// </code></example>
    public async Task<ListSitesResponse> ListAsync(
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
                    Path = "v2/sites",
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
                return JsonUtils.Deserialize<ListSitesResponse>(responseBody)!;
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
