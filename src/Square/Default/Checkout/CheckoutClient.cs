using System.Text.Json;
using Square;
using Square.Core;
using Square.Default;
using Square.Default.Checkout.PaymentLinks;

namespace Square.Default.Checkout;

public partial class CheckoutClient : ICheckoutClient
{
    private RawClient _client;

    internal CheckoutClient(RawClient client)
    {
        _client = client;
        PaymentLinks = new PaymentLinksClient(_client);
    }

    public PaymentLinksClient PaymentLinks { get; }

    /// <summary>
    /// Retrieves the location-level settings for a Square-hosted checkout page.
    /// </summary>
    /// <example><code>
    /// await client.Default.Checkout.RetrieveLocationSettingsAsync(
    ///     new RetrieveLocationSettingsRequest { LocationId = "location_id" }
    /// );
    /// </code></example>
    public async Task<RetrieveLocationSettingsResponse> RetrieveLocationSettingsAsync(
        RetrieveLocationSettingsRequest request,
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
                        "v2/online-checkout/location-settings/{0}",
                        ValueConvert.ToPathParameterString(request.LocationId)
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
                return JsonUtils.Deserialize<RetrieveLocationSettingsResponse>(responseBody)!;
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
    /// Updates the location-level settings for a Square-hosted checkout page.
    /// </summary>
    /// <example><code>
    /// await client.Default.Checkout.UpdateLocationSettingsAsync(
    ///     new UpdateLocationSettingsRequest
    ///     {
    ///         LocationId = "location_id",
    ///         LocationSettings = new CheckoutLocationSettings(),
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdateLocationSettingsResponse> UpdateLocationSettingsAsync(
        UpdateLocationSettingsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "v2/online-checkout/location-settings/{0}",
                        ValueConvert.ToPathParameterString(request.LocationId)
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
                return JsonUtils.Deserialize<UpdateLocationSettingsResponse>(responseBody)!;
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
    /// Retrieves the merchant-level settings for a Square-hosted checkout page.
    /// </summary>
    /// <example><code>
    /// await client.Default.Checkout.RetrieveMerchantSettingsAsync();
    /// </code></example>
    public async Task<RetrieveMerchantSettingsResponse> RetrieveMerchantSettingsAsync(
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
                    Path = "v2/online-checkout/merchant-settings",
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
                return JsonUtils.Deserialize<RetrieveMerchantSettingsResponse>(responseBody)!;
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
    /// Updates the merchant-level settings for a Square-hosted checkout page.
    /// </summary>
    /// <example><code>
    /// await client.Default.Checkout.UpdateMerchantSettingsAsync(
    ///     new UpdateMerchantSettingsRequest { MerchantSettings = new CheckoutMerchantSettings() }
    /// );
    /// </code></example>
    public async Task<UpdateMerchantSettingsResponse> UpdateMerchantSettingsAsync(
        UpdateMerchantSettingsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Put,
                    Path = "v2/online-checkout/merchant-settings",
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
                return JsonUtils.Deserialize<UpdateMerchantSettingsResponse>(responseBody)!;
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
