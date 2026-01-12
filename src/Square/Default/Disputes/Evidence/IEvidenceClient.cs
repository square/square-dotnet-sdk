using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.Disputes.Evidence;

public partial interface IEvidenceClient
{
    /// <summary>
    /// Returns a list of evidence associated with a dispute.
    /// </summary>
    Task<Pager<DisputeEvidence>> ListAsync(
        ListEvidenceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the metadata for the evidence specified in the request URL path.
    ///
    /// You must maintain a copy of any evidence uploaded if you want to reference it later. Evidence cannot be downloaded after you upload it.
    /// </summary>
    Task<GetDisputeEvidenceResponse> GetAsync(
        GetEvidenceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes specified evidence from a dispute.
    /// Square does not send the bank any evidence that is removed.
    /// </summary>
    Task<DeleteDisputeEvidenceResponse> DeleteAsync(
        DeleteEvidenceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
