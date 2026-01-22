using Square;

namespace Square.Default;

public partial interface ITeamClient
{
    /// <summary>
    /// Lists jobs in a seller account. Results are sorted by title in ascending order.
    /// </summary>
    Task<ListJobsResponse> ListJobsAsync(
        ListJobsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a job in a seller account. A job defines a title and tip eligibility. Note that
    /// compensation is defined in a [job assignment](entity:JobAssignment) in a team member's wage setting.
    /// </summary>
    Task<CreateJobResponse> CreateJobAsync(
        CreateJobRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a specified job.
    /// </summary>
    Task<RetrieveJobResponse> RetrieveJobAsync(
        RetrieveJobRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates the title or tip eligibility of a job. Changes to the title propagate to all
    /// `JobAssignment`, `Shift`, and `TeamMemberWage` objects that reference the job ID. Changes to
    /// tip eligibility propagate to all `TeamMemberWage` objects that reference the job ID.
    /// </summary>
    Task<UpdateJobResponse> UpdateJobAsync(
        UpdateJobRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
