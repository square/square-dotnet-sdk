using System.Text.Json;
using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.ApplePay;

public partial class ApplePayClient : IApplePayClient
{
    private RawClient _client;

    internal ApplePayClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Activates a domain for use with Apple Pay on the Web and Square. A validation
    /// is performed on this domain by Apple to ensure that it is properly set up as
    /// an Apple Pay enabled domain.
    ///
    /// This endpoint provides an easy way for platform developers to bulk activate
    /// Apple Pay on the Web with Square for merchants using their platform.
    ///
    /// Note: You will need to host a valid domain verification file on your domain to support Apple Pay.  The
    /// current version of this file is always available at https://app.squareup.com/digital-wallets/apple-pay/apple-developer-merchantid-domain-association,
    /// and should be hosted at `.well_known/apple-developer-merchantid-domain-association` on your
    /// domain.  This file is subject to change; we strongly recommend checking for updates regularly and avoiding
    /// long-lived caches that might not keep in sync with the correct file version.
    ///
    /// To learn more about the Web Payments SDK and how to add Apple Pay, see [Take an Apple Pay Payment](https://developer.squareup.com/docs/web-payments/apple-pay).
    /// </summary>
    /// <example><code>
    /// await client.Default.ApplePay.RegisterDomainAsync(
    ///     new RegisterDomainRequest { DomainName = "example.com" }
    /// );
    /// </code></example>
    public async Task<RegisterDomainResponse> RegisterDomainAsync(
        RegisterDomainRequest request,
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
                    Path = "v2/apple-pay/domains",
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
                return JsonUtils.Deserialize<RegisterDomainResponse>(responseBody)!;
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
