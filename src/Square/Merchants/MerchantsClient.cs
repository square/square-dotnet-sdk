using System.Net.Http;
using System.Text.Json;
using System.Threading;
using Square;
using Square.Core;
using Square.Merchants.CustomAttributeDefinitions;
using Square.Merchants.CustomAttributes;

namespace Square.Merchants;

public partial class MerchantsClient
{
    private RawClient _client;

    internal MerchantsClient(RawClient client)
    {
        _client = client;
        CustomAttributeDefinitions = new CustomAttributeDefinitionsClient(_client);
        CustomAttributes = new CustomAttributesClient(_client);
    }

    public CustomAttributeDefinitionsClient CustomAttributeDefinitions { get; }

    public CustomAttributesClient CustomAttributes { get; }

    /// <summary>
    /// Provides details about the merchant associated with a given access token.
    ///
    /// The access token used to connect your application to a Square seller is associated
    /// with a single merchant. That means that `ListMerchants` returns a list
    /// with a single `Merchant` object. You can specify your personal access token
    /// to get your own merchant information or specify an OAuth token to get the
    /// information for the merchant that granted your application access.
    ///
    /// If you know the merchant ID, you can also use the [RetrieveMerchant](api-endpoint:Merchants-RetrieveMerchant)
    /// endpoint to retrieve the merchant information.
    /// </summary>
    private async Task<ListMerchantsResponse> ListInternalAsync(
        ListMerchantsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor.Value.ToString();
        }
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v2/merchants",
                    Query = _query,
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
                return JsonUtils.Deserialize<ListMerchantsResponse>(responseBody)!;
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
    /// Provides details about the merchant associated with a given access token.
    ///
    /// The access token used to connect your application to a Square seller is associated
    /// with a single merchant. That means that `ListMerchants` returns a list
    /// with a single `Merchant` object. You can specify your personal access token
    /// to get your own merchant information or specify an OAuth token to get the
    /// information for the merchant that granted your application access.
    ///
    /// If you know the merchant ID, you can also use the [RetrieveMerchant](api-endpoint:Merchants-RetrieveMerchant)
    /// endpoint to retrieve the merchant information.
    /// </summary>
    /// <example><code>
    /// await client.Merchants.ListAsync(new ListMerchantsRequest());
    /// </code></example>
    public async Task<Pager<Merchant>> ListAsync(
        ListMerchantsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListMerchantsRequest,
            RequestOptions?,
            ListMerchantsResponse,
            int?,
            Merchant
        >
            .CreateInstanceAsync(
                request,
                options,
                ListInternalAsync,
                (request, cursor) =>
                {
                    request.Cursor = cursor;
                },
                response => response?.Cursor,
                response => response?.Merchant?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Retrieves the `Merchant` object for the given `merchant_id`.
    /// </summary>
    /// <example><code>
    /// await client.Merchants.GetAsync(new GetMerchantsRequest { MerchantId = "merchant_id" });
    /// </code></example>
    public async Task<GetMerchantResponse> GetAsync(
        GetMerchantsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/merchants/{0}",
                        ValueConvert.ToPathParameterString(request.MerchantId)
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
                return JsonUtils.Deserialize<GetMerchantResponse>(responseBody)!;
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
