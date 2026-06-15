using System.Text.Json;
using Square.Core;

namespace Square;

public partial class ReportingClient : IReportingClient
{
    private RawClient _client;

    internal ReportingClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Describes the data available to query: the cubes, views, measures, dimensions, and segments you can reference in a reporting query. Call this first to discover the schema, then pass the members you need to `load`.
    /// </summary>
    /// <example><code>
    /// await client.Reporting.GetMetadataAsync();
    /// </code></example>
    public async Task<MetadataResponse> GetMetadataAsync(
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
                    Path = "reporting/v1/meta",
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
                return JsonUtils.Deserialize<MetadataResponse>(responseBody)!;
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
    /// Runs a reporting query against the discovered schema and returns the aggregated results. Long-running queries may return a "Continue wait" response while processing — retry the same request until results are ready.
    /// </summary>
    /// <example><code>
    /// await client.Reporting.LoadAsync(new LoadRequest());
    /// </code></example>
    public async Task<LoadResponse> LoadAsync(
        LoadRequest request,
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
                    Path = "reporting/v1/load",
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
                return JsonUtils.Deserialize<LoadResponse>(responseBody)!;
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
