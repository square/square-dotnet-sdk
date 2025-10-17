using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Core;

namespace Square.Webhooks.EventTypes;

public partial class EventTypesClient
{
    private RawClient _client;

    internal EventTypesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Lists all webhook event types that can be subscribed to.
    /// </summary>
    /// <example><code>
    /// await client.Webhooks.EventTypes.ListAsync(
    ///     new Square.Webhooks.EventTypes.ListEventTypesRequest { ApiVersion = "api_version" }
    /// );
    /// </code></example>
    public async Task<ListWebhookEventTypesResponse> ListAsync(
        ListEventTypesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ApiVersion != null)
        {
            _query["api_version"] = request.ApiVersion;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v2/webhooks/event-types",
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
                return JsonUtils.Deserialize<ListWebhookEventTypesResponse>(responseBody)!;
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
