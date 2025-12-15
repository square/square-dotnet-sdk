using System.Text.Json;
using Square;
using Square.Core;

namespace Square.BankAccounts;

public partial class BankAccountsClient
{
    private RawClient _client;

    internal BankAccountsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Returns a list of [BankAccount](entity:BankAccount) objects linked to a Square account.
    /// </summary>
    private async Task<ListBankAccountsResponse> ListInternalAsync(
        ListBankAccountsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.Value.ToString();
        }
        if (request.LocationId != null)
        {
            _query["location_id"] = request.LocationId;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v2/bank-accounts",
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
                return JsonUtils.Deserialize<ListBankAccountsResponse>(responseBody)!;
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
    /// Returns a list of [BankAccount](entity:BankAccount) objects linked to a Square account.
    /// </summary>
    /// <example><code>
    /// await client.BankAccounts.ListAsync(
    ///     new ListBankAccountsRequest
    ///     {
    ///         Cursor = "cursor",
    ///         Limit = 1,
    ///         LocationId = "location_id",
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<BankAccount>> ListAsync(
        ListBankAccountsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListBankAccountsRequest,
            RequestOptions?,
            ListBankAccountsResponse,
            string?,
            BankAccount
        >
            .CreateInstanceAsync(
                request,
                options,
                ListInternalAsync,
                (request, cursor) =>
                {
                    request.Cursor = cursor;
                },
                response => response.Cursor,
                response => response.BankAccounts?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Returns details of a [BankAccount](entity:BankAccount) identified by V1 bank account ID.
    /// </summary>
    /// <example><code>
    /// await client.BankAccounts.GetByV1IdAsync(
    ///     new GetByV1IdBankAccountsRequest { V1BankAccountId = "v1_bank_account_id" }
    /// );
    /// </code></example>
    public async Task<GetBankAccountByV1IdResponse> GetByV1IdAsync(
        GetByV1IdBankAccountsRequest request,
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
                        "v2/bank-accounts/by-v1-id/{0}",
                        ValueConvert.ToPathParameterString(request.V1BankAccountId)
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
                return JsonUtils.Deserialize<GetBankAccountByV1IdResponse>(responseBody)!;
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
    /// Returns details of a [BankAccount](entity:BankAccount)
    /// linked to a Square account.
    /// </summary>
    /// <example><code>
    /// await client.BankAccounts.GetAsync(
    ///     new GetBankAccountsRequest { BankAccountId = "bank_account_id" }
    /// );
    /// </code></example>
    public async Task<GetBankAccountResponse> GetAsync(
        GetBankAccountsRequest request,
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
                        "v2/bank-accounts/{0}",
                        ValueConvert.ToPathParameterString(request.BankAccountId)
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
                return JsonUtils.Deserialize<GetBankAccountResponse>(responseBody)!;
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
