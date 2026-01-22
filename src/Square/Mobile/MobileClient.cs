using Square;
using Square.Core;

namespace Square.Mobile;

public partial class MobileClient : IMobileClient
{
    private RawClient _client;

    internal MobileClient(RawClient client)
    {
        _client = client;
    }

    /// <example><code>
    /// await client.Mobile.AuthorizationCodeAsync();
    /// </code></example>
    public async Task AuthorizationCodeAsync(
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
                    Path = "mobile/authorization-code",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            return;
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
