using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Core;

namespace Square.Mobile;

public partial class MobileClient
{
    private RawClient _client;

    internal MobileClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// __Note:__ This endpoint is used by the deprecated Reader SDK.
    /// Developers should update their integration to use the [Mobile Payments SDK](https://developer.squareup.com/docs/mobile-payments-sdk), which includes its own authorization methods.
    ///
    /// Generates code to authorize a mobile application to connect to a Square card reader.
    ///
    /// Authorization codes are one-time-use codes and expire 60 minutes after being issued.
    ///
    /// The `Authorization` header you provide to this endpoint must have the following format:
    ///
    /// ```
    /// Authorization: Bearer ACCESS_TOKEN
    /// ```
    ///
    /// Replace `ACCESS_TOKEN` with a
    /// [valid production authorization credential](https://developer.squareup.com/docs/build-basics/access-tokens).
    /// </summary>
    /// <example><code>
    /// await client.Mobile.AuthorizationCodeAsync(
    ///     new CreateMobileAuthorizationCodeRequest { LocationId = "YOUR_LOCATION_ID" }
    /// );
    /// </code></example>
    public async Task<CreateMobileAuthorizationCodeResponse> AuthorizationCodeAsync(
        CreateMobileAuthorizationCodeRequest request,
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
                return JsonUtils.Deserialize<CreateMobileAuthorizationCodeResponse>(responseBody)!;
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
