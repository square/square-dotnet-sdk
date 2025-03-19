using System.Net.Http;
using System.Text.Json;
using System.Threading;
using Square;
using Square.Core;

namespace Square.Team;

public partial class TeamClient
{
    private RawClient _client;

    internal TeamClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Lists jobs in a seller account. Results are sorted by title in ascending order.
    /// </summary>
    /// <example><code>
    /// await client.Team.ListJobsAsync(new ListJobsRequest());
    /// </code></example>
    public async Task<ListJobsResponse> ListJobsAsync(
        ListJobsRequest request,
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
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v2/team-members/jobs",
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
                return JsonUtils.Deserialize<ListJobsResponse>(responseBody)!;
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
    /// Creates a job in a seller account. A job defines a title and tip eligibility. Note that
    /// compensation is defined in a [job assignment](entity:JobAssignment) in a team member's wage setting.
    /// </summary>
    /// <example><code>
    /// await client.Team.CreateJobAsync(
    ///     new CreateJobRequest
    ///     {
    ///         Job = new Job { Title = "Cashier", IsTipEligible = true },
    ///         IdempotencyKey = "idempotency-key-0",
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateJobResponse> CreateJobAsync(
        CreateJobRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "v2/team-members/jobs",
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
                return JsonUtils.Deserialize<CreateJobResponse>(responseBody)!;
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
    /// Retrieves a specified job.
    /// </summary>
    /// <example><code>
    /// await client.Team.RetrieveJobAsync(new RetrieveJobRequest { JobId = "job_id" });
    /// </code></example>
    public async Task<RetrieveJobResponse> RetrieveJobAsync(
        RetrieveJobRequest request,
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
                        "v2/team-members/jobs/{0}",
                        ValueConvert.ToPathParameterString(request.JobId)
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
                return JsonUtils.Deserialize<RetrieveJobResponse>(responseBody)!;
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
    /// Updates the title or tip eligibility of a job. Changes to the title propagate to all
    /// `JobAssignment`, `Shift`, and `TeamMemberWage` objects that reference the job ID. Changes to
    /// tip eligibility propagate to all `TeamMemberWage` objects that reference the job ID.
    /// </summary>
    /// <example><code>
    /// await client.Team.UpdateJobAsync(
    ///     new UpdateJobRequest
    ///     {
    ///         JobId = "job_id",
    ///         Job = new Job { Title = "Cashier 1", IsTipEligible = true },
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdateJobResponse> UpdateJobAsync(
        UpdateJobRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "v2/team-members/jobs/{0}",
                        ValueConvert.ToPathParameterString(request.JobId)
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
                return JsonUtils.Deserialize<UpdateJobResponse>(responseBody)!;
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
