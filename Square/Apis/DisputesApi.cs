namespace Square.Apis
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using APIMatic.Core;
    using APIMatic.Core.Types;
    using APIMatic.Core.Utilities;
    using APIMatic.Core.Utilities.Date.Xml;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Authentication;
    using Square.Http.Client;
    using Square.Utilities;
    using System.Net.Http;

    /// <summary>
    /// DisputesApi.
    /// </summary>
    internal class DisputesApi : BaseApi, IDisputesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisputesApi"/> class.
        /// </summary>
        internal DisputesApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Returns a list of disputes associated with a particular account.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="states">Optional parameter: The dispute states used to filter the result. If not specified, the endpoint returns all disputes..</param>
        /// <param name="locationId">Optional parameter: The ID of the location for which to return a list of disputes. If not specified, the endpoint returns disputes associated with all locations..</param>
        /// <returns>Returns the Models.ListDisputesResponse response from the API call.</returns>
        public Models.ListDisputesResponse ListDisputes(
                string cursor = null,
                string states = null,
                string locationId = null)
            => CoreHelper.RunTask(ListDisputesAsync(cursor, states, locationId));

        /// <summary>
        /// Returns a list of disputes associated with a particular account.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="states">Optional parameter: The dispute states used to filter the result. If not specified, the endpoint returns all disputes..</param>
        /// <param name="locationId">Optional parameter: The ID of the location for which to return a list of disputes. If not specified, the endpoint returns disputes associated with all locations..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListDisputesResponse response from the API call.</returns>
        public async Task<Models.ListDisputesResponse> ListDisputesAsync(
                string cursor = null,
                string states = null,
                string locationId = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListDisputesResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/disputes")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("cursor", cursor))
                      .Query(_query => _query.Setup("states", states))
                      .Query(_query => _query.Setup("location_id", locationId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Returns details about a specific dispute.
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute you want more details about..</param>
        /// <returns>Returns the Models.RetrieveDisputeResponse response from the API call.</returns>
        public Models.RetrieveDisputeResponse RetrieveDispute(
                string disputeId)
            => CoreHelper.RunTask(RetrieveDisputeAsync(disputeId));

        /// <summary>
        /// Returns details about a specific dispute.
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute you want more details about..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveDisputeResponse response from the API call.</returns>
        public async Task<Models.RetrieveDisputeResponse> RetrieveDisputeAsync(
                string disputeId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveDisputeResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/disputes/{dispute_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("dispute_id", disputeId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Accepts the loss on a dispute. Square returns the disputed amount to the cardholder and.
        /// updates the dispute state to ACCEPTED.
        /// Square debits the disputed amount from the seller’s Square account. If the Square account.
        /// does not have sufficient funds, Square debits the associated bank account.
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute you want to accept..</param>
        /// <returns>Returns the Models.AcceptDisputeResponse response from the API call.</returns>
        public Models.AcceptDisputeResponse AcceptDispute(
                string disputeId)
            => CoreHelper.RunTask(AcceptDisputeAsync(disputeId));

        /// <summary>
        /// Accepts the loss on a dispute. Square returns the disputed amount to the cardholder and.
        /// updates the dispute state to ACCEPTED.
        /// Square debits the disputed amount from the seller’s Square account. If the Square account.
        /// does not have sufficient funds, Square debits the associated bank account.
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute you want to accept..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.AcceptDisputeResponse response from the API call.</returns>
        public async Task<Models.AcceptDisputeResponse> AcceptDisputeAsync(
                string disputeId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.AcceptDisputeResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/disputes/{dispute_id}/accept")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("dispute_id", disputeId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Returns a list of evidence associated with a dispute.
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <returns>Returns the Models.ListDisputeEvidenceResponse response from the API call.</returns>
        public Models.ListDisputeEvidenceResponse ListDisputeEvidence(
                string disputeId,
                string cursor = null)
            => CoreHelper.RunTask(ListDisputeEvidenceAsync(disputeId, cursor));

        /// <summary>
        /// Returns a list of evidence associated with a dispute.
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListDisputeEvidenceResponse response from the API call.</returns>
        public async Task<Models.ListDisputeEvidenceResponse> ListDisputeEvidenceAsync(
                string disputeId,
                string cursor = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListDisputeEvidenceResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/disputes/{dispute_id}/evidence")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("dispute_id", disputeId))
                      .Query(_query => _query.Setup("cursor", cursor))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Uploads a file to use as evidence in a dispute challenge. The endpoint accepts HTTP.
        /// multipart/form-data file uploads in HEIC, HEIF, JPEG, PDF, PNG, and TIFF formats.
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute for which you want to upload evidence..</param>
        /// <param name="request">Optional parameter: Defines the parameters for a `CreateDisputeEvidenceFile` request..</param>
        /// <param name="imageFile">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.CreateDisputeEvidenceFileResponse response from the API call.</returns>
        public Models.CreateDisputeEvidenceFileResponse CreateDisputeEvidenceFile(
                string disputeId,
                Models.CreateDisputeEvidenceFileRequest request = null,
                FileStreamInfo imageFile = null)
            => CoreHelper.RunTask(CreateDisputeEvidenceFileAsync(disputeId, request, imageFile));

        /// <summary>
        /// Uploads a file to use as evidence in a dispute challenge. The endpoint accepts HTTP.
        /// multipart/form-data file uploads in HEIC, HEIF, JPEG, PDF, PNG, and TIFF formats.
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute for which you want to upload evidence..</param>
        /// <param name="request">Optional parameter: Defines the parameters for a `CreateDisputeEvidenceFile` request..</param>
        /// <param name="imageFile">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateDisputeEvidenceFileResponse response from the API call.</returns>
        public async Task<Models.CreateDisputeEvidenceFileResponse> CreateDisputeEvidenceFileAsync(
                string disputeId,
                Models.CreateDisputeEvidenceFileRequest request = null,
                FileStreamInfo imageFile = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CreateDisputeEvidenceFileResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/disputes/{dispute_id}/evidence-files")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("dispute_id", disputeId))
                      .Form(_form => _form.EncodingHeader("Content-Type", "application/json; charset=utf-8").Setup("request", request))
                      .Form(_form => _form.EncodingHeader("Content-Type", string.IsNullOrEmpty(imageFile.ContentType) ? "image/jpeg" : imageFile.ContentType).Setup("image_file", imageFile))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Uploads text to use as evidence for a dispute challenge.
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute for which you want to upload evidence..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateDisputeEvidenceTextResponse response from the API call.</returns>
        public Models.CreateDisputeEvidenceTextResponse CreateDisputeEvidenceText(
                string disputeId,
                Models.CreateDisputeEvidenceTextRequest body)
            => CoreHelper.RunTask(CreateDisputeEvidenceTextAsync(disputeId, body));

        /// <summary>
        /// Uploads text to use as evidence for a dispute challenge.
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute for which you want to upload evidence..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateDisputeEvidenceTextResponse response from the API call.</returns>
        public async Task<Models.CreateDisputeEvidenceTextResponse> CreateDisputeEvidenceTextAsync(
                string disputeId,
                Models.CreateDisputeEvidenceTextRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CreateDisputeEvidenceTextResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/disputes/{dispute_id}/evidence-text")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("dispute_id", disputeId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Removes specified evidence from a dispute.
        /// Square does not send the bank any evidence that is removed.
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute from which you want to remove evidence..</param>
        /// <param name="evidenceId">Required parameter: The ID of the evidence you want to remove..</param>
        /// <returns>Returns the Models.DeleteDisputeEvidenceResponse response from the API call.</returns>
        public Models.DeleteDisputeEvidenceResponse DeleteDisputeEvidence(
                string disputeId,
                string evidenceId)
            => CoreHelper.RunTask(DeleteDisputeEvidenceAsync(disputeId, evidenceId));

        /// <summary>
        /// Removes specified evidence from a dispute.
        /// Square does not send the bank any evidence that is removed.
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute from which you want to remove evidence..</param>
        /// <param name="evidenceId">Required parameter: The ID of the evidence you want to remove..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteDisputeEvidenceResponse response from the API call.</returns>
        public async Task<Models.DeleteDisputeEvidenceResponse> DeleteDisputeEvidenceAsync(
                string disputeId,
                string evidenceId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.DeleteDisputeEvidenceResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/v2/disputes/{dispute_id}/evidence/{evidence_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("dispute_id", disputeId))
                      .Template(_template => _template.Setup("evidence_id", evidenceId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Returns the metadata for the evidence specified in the request URL path.
        /// You must maintain a copy of any evidence uploaded if you want to reference it later. Evidence cannot be downloaded after you upload it.
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute from which you want to retrieve evidence metadata..</param>
        /// <param name="evidenceId">Required parameter: The ID of the evidence to retrieve..</param>
        /// <returns>Returns the Models.RetrieveDisputeEvidenceResponse response from the API call.</returns>
        public Models.RetrieveDisputeEvidenceResponse RetrieveDisputeEvidence(
                string disputeId,
                string evidenceId)
            => CoreHelper.RunTask(RetrieveDisputeEvidenceAsync(disputeId, evidenceId));

        /// <summary>
        /// Returns the metadata for the evidence specified in the request URL path.
        /// You must maintain a copy of any evidence uploaded if you want to reference it later. Evidence cannot be downloaded after you upload it.
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute from which you want to retrieve evidence metadata..</param>
        /// <param name="evidenceId">Required parameter: The ID of the evidence to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveDisputeEvidenceResponse response from the API call.</returns>
        public async Task<Models.RetrieveDisputeEvidenceResponse> RetrieveDisputeEvidenceAsync(
                string disputeId,
                string evidenceId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveDisputeEvidenceResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/disputes/{dispute_id}/evidence/{evidence_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("dispute_id", disputeId))
                      .Template(_template => _template.Setup("evidence_id", evidenceId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Submits evidence to the cardholder's bank.
        /// The evidence submitted by this endpoint includes evidence uploaded.
        /// using the [CreateDisputeEvidenceFile]($e/Disputes/CreateDisputeEvidenceFile) and.
        /// [CreateDisputeEvidenceText]($e/Disputes/CreateDisputeEvidenceText) endpoints and.
        /// evidence automatically provided by Square, when available. Evidence cannot be removed from.
        /// a dispute after submission.
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute for which you want to submit evidence..</param>
        /// <returns>Returns the Models.SubmitEvidenceResponse response from the API call.</returns>
        public Models.SubmitEvidenceResponse SubmitEvidence(
                string disputeId)
            => CoreHelper.RunTask(SubmitEvidenceAsync(disputeId));

        /// <summary>
        /// Submits evidence to the cardholder's bank.
        /// The evidence submitted by this endpoint includes evidence uploaded.
        /// using the [CreateDisputeEvidenceFile]($e/Disputes/CreateDisputeEvidenceFile) and.
        /// [CreateDisputeEvidenceText]($e/Disputes/CreateDisputeEvidenceText) endpoints and.
        /// evidence automatically provided by Square, when available. Evidence cannot be removed from.
        /// a dispute after submission.
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute for which you want to submit evidence..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SubmitEvidenceResponse response from the API call.</returns>
        public async Task<Models.SubmitEvidenceResponse> SubmitEvidenceAsync(
                string disputeId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.SubmitEvidenceResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/disputes/{dispute_id}/submit-evidence")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("dispute_id", disputeId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}