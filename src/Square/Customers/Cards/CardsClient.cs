using System.Text.Json;
using Square;
using Square.Core;

namespace Square.Customers.Cards;

public partial class CardsClient : ICardsClient
{
    private RawClient _client;

    internal CardsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Adds a card on file to an existing customer.
    ///
    /// As with charges, calls to `CreateCustomerCard` are idempotent. Multiple
    /// calls with the same card nonce return the same card record that was created
    /// with the provided nonce during the _first_ call.
    /// </summary>
    /// <example><code>
    /// await client.Customers.Cards.CreateAsync(
    ///     new CreateCustomerCardRequest
    ///     {
    ///         CustomerId = "customer_id",
    ///         CardNonce = "YOUR_CARD_NONCE",
    ///         BillingAddress = new Address
    ///         {
    ///             AddressLine1 = "500 Electric Ave",
    ///             AddressLine2 = "Suite 600",
    ///             Locality = "New York",
    ///             AdministrativeDistrictLevel1 = "NY",
    ///             PostalCode = "10003",
    ///             Country = Country.Us,
    ///         },
    ///         CardholderName = "Amelia Earhart",
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateCustomerCardResponse> CreateAsync(
        CreateCustomerCardRequest request,
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
                        "v2/customers/{0}/cards",
                        ValueConvert.ToPathParameterString(request.CustomerId)
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
                return JsonUtils.Deserialize<CreateCustomerCardResponse>(responseBody)!;
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
    /// Removes a card on file from a customer.
    /// </summary>
    /// <example><code>
    /// await client.Customers.Cards.DeleteAsync(
    ///     new DeleteCardsRequest { CustomerId = "customer_id", CardId = "card_id" }
    /// );
    /// </code></example>
    public async Task<DeleteCustomerCardResponse> DeleteAsync(
        DeleteCardsRequest request,
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
                        "v2/customers/{0}/cards/{1}",
                        ValueConvert.ToPathParameterString(request.CustomerId),
                        ValueConvert.ToPathParameterString(request.CardId)
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
                return JsonUtils.Deserialize<DeleteCustomerCardResponse>(responseBody)!;
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
