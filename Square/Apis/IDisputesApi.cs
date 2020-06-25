using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Utilities;
using Square.Http.Request;
using Square.Http.Response;
using Square.Http.Client;

namespace Square.Apis
{
    public interface IDisputesApi
    {
        /// <summary>
        /// Returns a list of disputes associated
        /// with a particular account.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for the original query. For more information, see [Paginating](https://developer.squareup.com/docs/basics/api101/pagination).</param>
        /// <param name="states">Optional parameter: The dispute states to filter the result. If not specified, the endpoint returns all open disputes (dispute status is not `INQUIRY_CLOSED`, `WON`, or `LOST`).</param>
        /// <param name="locationId">Optional parameter: The ID of the location for which to return  a list of disputes. If not specified, the endpoint returns all open disputes (dispute status is not `INQUIRY_CLOSED`, `WON`, or  `LOST`) associated with all locations.</param>
        /// <return>Returns the Models.ListDisputesResponse response from the API call</return>
        Models.ListDisputesResponse ListDisputes(string cursor = null, string states = null, string locationId = null);

        /// <summary>
        /// Returns a list of disputes associated
        /// with a particular account.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for the original query. For more information, see [Paginating](https://developer.squareup.com/docs/basics/api101/pagination).</param>
        /// <param name="states">Optional parameter: The dispute states to filter the result. If not specified, the endpoint returns all open disputes (dispute status is not `INQUIRY_CLOSED`, `WON`, or `LOST`).</param>
        /// <param name="locationId">Optional parameter: The ID of the location for which to return  a list of disputes. If not specified, the endpoint returns all open disputes (dispute status is not `INQUIRY_CLOSED`, `WON`, or  `LOST`) associated with all locations.</param>
        /// <return>Returns the Models.ListDisputesResponse response from the API call</return>
        Task<Models.ListDisputesResponse> ListDisputesAsync(string cursor = null, string states = null, string locationId = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns details of a specific dispute.
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute you want more details about.</param>
        /// <return>Returns the Models.RetrieveDisputeResponse response from the API call</return>
        Models.RetrieveDisputeResponse RetrieveDispute(string disputeId);

        /// <summary>
        /// Returns details of a specific dispute.
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute you want more details about.</param>
        /// <return>Returns the Models.RetrieveDisputeResponse response from the API call</return>
        Task<Models.RetrieveDisputeResponse> RetrieveDisputeAsync(string disputeId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Accepts loss on a dispute. Square returns
        /// the disputed amount to the cardholder and updates the
        /// dispute state to ACCEPTED.
        /// Square debits the disputed amount from the seller’s Square
        /// account. If the Square account balance does not have
        /// sufficient funds, Square debits the associated bank account.
        /// For an overview of the Disputes API, see [Overview](https://developer.squareup.com/docs/docs/disputes-api/overview).
        /// </summary>
        /// <param name="disputeId">Required parameter: ID of the dispute you want to accept.</param>
        /// <return>Returns the Models.AcceptDisputeResponse response from the API call</return>
        Models.AcceptDisputeResponse AcceptDispute(string disputeId);

        /// <summary>
        /// Accepts loss on a dispute. Square returns
        /// the disputed amount to the cardholder and updates the
        /// dispute state to ACCEPTED.
        /// Square debits the disputed amount from the seller’s Square
        /// account. If the Square account balance does not have
        /// sufficient funds, Square debits the associated bank account.
        /// For an overview of the Disputes API, see [Overview](https://developer.squareup.com/docs/docs/disputes-api/overview).
        /// </summary>
        /// <param name="disputeId">Required parameter: ID of the dispute you want to accept.</param>
        /// <return>Returns the Models.AcceptDisputeResponse response from the API call</return>
        Task<Models.AcceptDisputeResponse> AcceptDisputeAsync(string disputeId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a list of evidence associated with a dispute.
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute.</param>
        /// <return>Returns the Models.ListDisputeEvidenceResponse response from the API call</return>
        Models.ListDisputeEvidenceResponse ListDisputeEvidence(string disputeId);

        /// <summary>
        /// Returns a list of evidence associated with a dispute.
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute.</param>
        /// <return>Returns the Models.ListDisputeEvidenceResponse response from the API call</return>
        Task<Models.ListDisputeEvidenceResponse> ListDisputeEvidenceAsync(string disputeId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes specified evidence from a dispute.
        /// Square does not send the bank any evidence that
        /// is removed. Also, you cannot remove evidence after
        /// submitting it to the bank using [SubmitEvidence](https://developer.squareup.com/docs/reference/square/disputes-api/submit-evidence).
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute you want to remove evidence from.</param>
        /// <param name="evidenceId">Required parameter: The ID of the evidence you want to remove.</param>
        /// <return>Returns the Models.RemoveDisputeEvidenceResponse response from the API call</return>
        Models.RemoveDisputeEvidenceResponse RemoveDisputeEvidence(string disputeId, string evidenceId);

        /// <summary>
        /// Removes specified evidence from a dispute.
        /// Square does not send the bank any evidence that
        /// is removed. Also, you cannot remove evidence after
        /// submitting it to the bank using [SubmitEvidence](https://developer.squareup.com/docs/reference/square/disputes-api/submit-evidence).
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute you want to remove evidence from.</param>
        /// <param name="evidenceId">Required parameter: The ID of the evidence you want to remove.</param>
        /// <return>Returns the Models.RemoveDisputeEvidenceResponse response from the API call</return>
        Task<Models.RemoveDisputeEvidenceResponse> RemoveDisputeEvidenceAsync(string disputeId, string evidenceId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the specific evidence metadata associated with a specific dispute.
        /// You must maintain a copy of the evidence you upload if you want to
        /// reference it later. You cannot download the evidence
        /// after you upload it.
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute that you want to retrieve evidence from.</param>
        /// <param name="evidenceId">Required parameter: The ID of the evidence to retrieve.</param>
        /// <return>Returns the Models.RetrieveDisputeEvidenceResponse response from the API call</return>
        Models.RetrieveDisputeEvidenceResponse RetrieveDisputeEvidence(string disputeId, string evidenceId);

        /// <summary>
        /// Returns the specific evidence metadata associated with a specific dispute.
        /// You must maintain a copy of the evidence you upload if you want to
        /// reference it later. You cannot download the evidence
        /// after you upload it.
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute that you want to retrieve evidence from.</param>
        /// <param name="evidenceId">Required parameter: The ID of the evidence to retrieve.</param>
        /// <return>Returns the Models.RetrieveDisputeEvidenceResponse response from the API call</return>
        Task<Models.RetrieveDisputeEvidenceResponse> RetrieveDisputeEvidenceAsync(string disputeId, string evidenceId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Uploads a file to use as evidence in a dispute challenge. The endpoint accepts
        /// HTTP multipart/form-data file uploads in HEIC, HEIF, JPEG, PDF, PNG,
        /// and TIFF formats.
        /// For more information, see [Challenge a Dispute](https://developer.squareup.com/docs/docs/disputes-api/process-disputes#challenge-a-dispute).
        /// </summary>
        /// <param name="disputeId">Required parameter: ID of the dispute you want to upload evidence for.</param>
        /// <param name="request">Optional parameter: Defines parameters for a CreateDisputeEvidenceFile request.</param>
        /// <param name="imageFile">Optional parameter: Example: </param>
        /// <return>Returns the Models.CreateDisputeEvidenceFileResponse response from the API call</return>
        Models.CreateDisputeEvidenceFileResponse CreateDisputeEvidenceFile(string disputeId, Models.CreateDisputeEvidenceFileRequest request = null, FileStreamInfo imageFile = null);

        /// <summary>
        /// Uploads a file to use as evidence in a dispute challenge. The endpoint accepts
        /// HTTP multipart/form-data file uploads in HEIC, HEIF, JPEG, PDF, PNG,
        /// and TIFF formats.
        /// For more information, see [Challenge a Dispute](https://developer.squareup.com/docs/docs/disputes-api/process-disputes#challenge-a-dispute).
        /// </summary>
        /// <param name="disputeId">Required parameter: ID of the dispute you want to upload evidence for.</param>
        /// <param name="request">Optional parameter: Defines parameters for a CreateDisputeEvidenceFile request.</param>
        /// <param name="imageFile">Optional parameter: Example: </param>
        /// <return>Returns the Models.CreateDisputeEvidenceFileResponse response from the API call</return>
        Task<Models.CreateDisputeEvidenceFileResponse> CreateDisputeEvidenceFileAsync(string disputeId, Models.CreateDisputeEvidenceFileRequest request = null, FileStreamInfo imageFile = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Uploads text to use as evidence for a dispute challenge. For more information, see
        /// [Challenge a Dispute](https://developer.squareup.com/docs/docs/disputes-api/process-disputes#challenge-a-dispute).
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute you want to upload evidence for.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateDisputeEvidenceTextResponse response from the API call</return>
        Models.CreateDisputeEvidenceTextResponse CreateDisputeEvidenceText(string disputeId, Models.CreateDisputeEvidenceTextRequest body);

        /// <summary>
        /// Uploads text to use as evidence for a dispute challenge. For more information, see
        /// [Challenge a Dispute](https://developer.squareup.com/docs/docs/disputes-api/process-disputes#challenge-a-dispute).
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute you want to upload evidence for.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateDisputeEvidenceTextResponse response from the API call</return>
        Task<Models.CreateDisputeEvidenceTextResponse> CreateDisputeEvidenceTextAsync(string disputeId, Models.CreateDisputeEvidenceTextRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Submits evidence to the cardholder's bank.
        /// Before submitting evidence, Square compiles all available evidence. This includes
        /// evidence uploaded using the
        /// [CreateDisputeEvidenceFile](https://developer.squareup.com/docs/reference/square/disputes-api/create-dispute-evidence-file) and
        /// [CreateDisputeEvidenceText](https://developer.squareup.com/docs/reference/square/disputes-api/create-dispute-evidence-text) endpoints,
        /// and evidence automatically provided by Square, when
        /// available. For more information, see
        /// [Challenge a Dispute](https://developer.squareup.com/docs/docs/disputes-api/process-disputes#challenge-a-dispute).
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute you want to submit evidence for.</param>
        /// <return>Returns the Models.SubmitEvidenceResponse response from the API call</return>
        Models.SubmitEvidenceResponse SubmitEvidence(string disputeId);

        /// <summary>
        /// Submits evidence to the cardholder's bank.
        /// Before submitting evidence, Square compiles all available evidence. This includes
        /// evidence uploaded using the
        /// [CreateDisputeEvidenceFile](https://developer.squareup.com/docs/reference/square/disputes-api/create-dispute-evidence-file) and
        /// [CreateDisputeEvidenceText](https://developer.squareup.com/docs/reference/square/disputes-api/create-dispute-evidence-text) endpoints,
        /// and evidence automatically provided by Square, when
        /// available. For more information, see
        /// [Challenge a Dispute](https://developer.squareup.com/docs/docs/disputes-api/process-disputes#challenge-a-dispute).
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute you want to submit evidence for.</param>
        /// <return>Returns the Models.SubmitEvidenceResponse response from the API call</return>
        Task<Models.SubmitEvidenceResponse> SubmitEvidenceAsync(string disputeId, CancellationToken cancellationToken = default);

    }
}