using System.Text.Json;
using Square;
using Square.Core;
using Square.Disputes.Evidence;

namespace Square.Disputes;

public partial class DisputesClient
{
    private RawClient _client;

    internal DisputesClient(RawClient client)
    {
        _client = client;
        Evidence = new EvidenceClient(_client);
    }

    public EvidenceClient Evidence { get; }

    /// <summary>
    /// Returns a list of disputes associated with a particular account.
    /// </summary>
    private async Task<ListDisputesResponse> ListInternalAsync(
        ListDisputesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        if (request.States != null)
        {
            _query["states"] = request.States.Value.ToString();
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
                    Path = "v2/disputes",
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
                return JsonUtils.Deserialize<ListDisputesResponse>(responseBody)!;
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
    /// Returns a list of disputes associated with a particular account.
    /// </summary>
    /// <example><code>
    /// await client.Disputes.ListAsync(
    ///     new ListDisputesRequest
    ///     {
    ///         Cursor = "cursor",
    ///         States = DisputeState.InquiryEvidenceRequired,
    ///         LocationId = "location_id",
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<Dispute>> ListAsync(
        ListDisputesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListDisputesRequest,
            RequestOptions?,
            ListDisputesResponse,
            string?,
            Dispute
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
                response => response.Disputes?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Returns details about a specific dispute.
    /// </summary>
    /// <example><code>
    /// await client.Disputes.GetAsync(new GetDisputesRequest { DisputeId = "dispute_id" });
    /// </code></example>
    public async Task<GetDisputeResponse> GetAsync(
        GetDisputesRequest request,
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
                        "v2/disputes/{0}",
                        ValueConvert.ToPathParameterString(request.DisputeId)
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
                return JsonUtils.Deserialize<GetDisputeResponse>(responseBody)!;
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
    /// Accepts the loss on a dispute. Square returns the disputed amount to the cardholder and
    /// updates the dispute state to ACCEPTED.
    ///
    /// Square debits the disputed amount from the seller’s Square account. If the Square account
    /// does not have sufficient funds, Square debits the associated bank account.
    /// </summary>
    /// <example><code>
    /// await client.Disputes.AcceptAsync(new AcceptDisputesRequest { DisputeId = "dispute_id" });
    /// </code></example>
    public async Task<AcceptDisputeResponse> AcceptAsync(
        AcceptDisputesRequest request,
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
                        "v2/disputes/{0}/accept",
                        ValueConvert.ToPathParameterString(request.DisputeId)
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
                return JsonUtils.Deserialize<AcceptDisputeResponse>(responseBody)!;
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
    /// Uploads a file to use as evidence in a dispute challenge. The endpoint accepts HTTP
    /// multipart/form-data file uploads in HEIC, HEIF, JPEG, PDF, PNG, and TIFF formats.
    /// </summary>
    /// <example><code>
    /// await client.Disputes.CreateEvidenceFileAsync(
    ///     new CreateEvidenceFileDisputesRequest { DisputeId = "dispute_id" }
    /// );
    /// </code></example>
    public async Task<CreateDisputeEvidenceFileResponse> CreateEvidenceFileAsync(
        CreateEvidenceFileDisputesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var multipartFormRequest_ = new MultipartFormRequest
        {
            BaseUrl = _client.Options.BaseUrl,
            Method = HttpMethod.Post,
            Path = string.Format(
                "v2/disputes/{0}/evidence-files",
                ValueConvert.ToPathParameterString(request.DisputeId)
            ),
            Options = options,
        };
        multipartFormRequest_.AddJsonPart(
            "request",
            request.Request,
            "application/json; charset=utf-8"
        );
        multipartFormRequest_.AddFileParameterPart("image_file", request.ImageFile, "image/jpeg");
        var response = await _client
            .SendRequestAsync(multipartFormRequest_, cancellationToken)
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<CreateDisputeEvidenceFileResponse>(responseBody)!;
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
    /// Uploads text to use as evidence for a dispute challenge.
    /// </summary>
    /// <example><code>
    /// await client.Disputes.CreateEvidenceTextAsync(
    ///     new CreateDisputeEvidenceTextRequest
    ///     {
    ///         DisputeId = "dispute_id",
    ///         IdempotencyKey = "ed3ee3933d946f1514d505d173c82648",
    ///         EvidenceType = DisputeEvidenceType.TrackingNumber,
    ///         EvidenceText = "1Z8888888888888888",
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateDisputeEvidenceTextResponse> CreateEvidenceTextAsync(
        CreateDisputeEvidenceTextRequest request,
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
                        "v2/disputes/{0}/evidence-text",
                        ValueConvert.ToPathParameterString(request.DisputeId)
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
                return JsonUtils.Deserialize<CreateDisputeEvidenceTextResponse>(responseBody)!;
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
    /// Submits evidence to the cardholder's bank.
    ///
    /// The evidence submitted by this endpoint includes evidence uploaded
    /// using the [CreateDisputeEvidenceFile](api-endpoint:Disputes-CreateDisputeEvidenceFile) and
    /// [CreateDisputeEvidenceText](api-endpoint:Disputes-CreateDisputeEvidenceText) endpoints and
    /// evidence automatically provided by Square, when available. Evidence cannot be removed from
    /// a dispute after submission.
    /// </summary>
    /// <example><code>
    /// await client.Disputes.SubmitEvidenceAsync(
    ///     new SubmitEvidenceDisputesRequest { DisputeId = "dispute_id" }
    /// );
    /// </code></example>
    public async Task<SubmitEvidenceResponse> SubmitEvidenceAsync(
        SubmitEvidenceDisputesRequest request,
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
                        "v2/disputes/{0}/submit-evidence",
                        ValueConvert.ToPathParameterString(request.DisputeId)
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
                return JsonUtils.Deserialize<SubmitEvidenceResponse>(responseBody)!;
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
