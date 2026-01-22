using Square;
using Square.Core;
using Square.Default.Disputes;

namespace Square.Default;

public partial interface IDisputesClient
{
    public EvidenceClient Evidence { get; }

    /// <summary>
    /// Returns a list of disputes associated with a particular account.
    /// </summary>
    Task<Pager<Dispute>> ListAsync(
        ListDisputesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns details about a specific dispute.
    /// </summary>
    Task<GetDisputeResponse> GetAsync(
        GetDisputesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Accepts the loss on a dispute. Square returns the disputed amount to the cardholder and
    /// updates the dispute state to ACCEPTED.
    ///
    /// Square debits the disputed amount from the seller’s Square account. If the Square account
    /// does not have sufficient funds, Square debits the associated bank account.
    /// </summary>
    Task<AcceptDisputeResponse> AcceptAsync(
        AcceptDisputesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Uploads a file to use as evidence in a dispute challenge. The endpoint accepts HTTP
    /// multipart/form-data file uploads in HEIC, HEIF, JPEG, PDF, PNG, and TIFF formats.
    /// </summary>
    Task<CreateDisputeEvidenceFileResponse> CreateEvidenceFileAsync(
        CreateEvidenceFileDisputesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Uploads text to use as evidence for a dispute challenge.
    /// </summary>
    Task<CreateDisputeEvidenceTextResponse> CreateEvidenceTextAsync(
        CreateDisputeEvidenceTextRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Submits evidence to the cardholder's bank.
    ///
    /// The evidence submitted by this endpoint includes evidence uploaded
    /// using the [CreateDisputeEvidenceFile](api-endpoint:Disputes-CreateDisputeEvidenceFile) and
    /// [CreateDisputeEvidenceText](api-endpoint:Disputes-CreateDisputeEvidenceText) endpoints and
    /// evidence automatically provided by Square, when available. Evidence cannot be removed from
    /// a dispute after submission.
    /// </summary>
    Task<SubmitEvidenceResponse> SubmitEvidenceAsync(
        SubmitEvidenceDisputesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
