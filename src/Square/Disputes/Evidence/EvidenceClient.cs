using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Core;

namespace Square.Disputes.Evidence;

public partial class EvidenceClient
{
    private RawClient _client;

    internal EvidenceClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Returns a list of evidence associated with a dispute.
    /// </summary>
    private async Task<ListDisputeEvidenceResponse> ListInternalAsync(
        ListEvidenceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/disputes/{0}/evidence",
                        ValueConvert.ToPathParameterString(request.DisputeId)
                    ),
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
                return JsonUtils.Deserialize<ListDisputeEvidenceResponse>(responseBody)!;
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
    /// Returns a list of evidence associated with a dispute.
    /// </summary>
    /// <example><code>
    /// await client.Disputes.Evidence.ListAsync(
    ///     new ListEvidenceRequest { DisputeId = "dispute_id", Cursor = "cursor" }
    /// );
    /// </code></example>
    public async Task<Pager<DisputeEvidence>> ListAsync(
        ListEvidenceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListEvidenceRequest,
            RequestOptions?,
            ListDisputeEvidenceResponse,
            string?,
            DisputeEvidence
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
                response => response?.Evidence?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Returns the metadata for the evidence specified in the request URL path.
    ///
    /// You must maintain a copy of any evidence uploaded if you want to reference it later. Evidence cannot be downloaded after you upload it.
    /// </summary>
    /// <example><code>
    /// await client.Disputes.Evidence.GetAsync(
    ///     new GetEvidenceRequest { DisputeId = "dispute_id", EvidenceId = "evidence_id" }
    /// );
    /// </code></example>
    public async Task<GetDisputeEvidenceResponse> GetAsync(
        GetEvidenceRequest request,
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
                        "v2/disputes/{0}/evidence/{1}",
                        ValueConvert.ToPathParameterString(request.DisputeId),
                        ValueConvert.ToPathParameterString(request.EvidenceId)
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
                return JsonUtils.Deserialize<GetDisputeEvidenceResponse>(responseBody)!;
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
    /// Removes specified evidence from a dispute.
    /// Square does not send the bank any evidence that is removed.
    /// </summary>
    /// <example><code>
    /// await client.Disputes.Evidence.DeleteAsync(
    ///     new DeleteEvidenceRequest { DisputeId = "dispute_id", EvidenceId = "evidence_id" }
    /// );
    /// </code></example>
    public async Task<DeleteDisputeEvidenceResponse> DeleteAsync(
        DeleteEvidenceRequest request,
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
                        "v2/disputes/{0}/evidence/{1}",
                        ValueConvert.ToPathParameterString(request.DisputeId),
                        ValueConvert.ToPathParameterString(request.EvidenceId)
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
                return JsonUtils.Deserialize<DeleteDisputeEvidenceResponse>(responseBody)!;
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
