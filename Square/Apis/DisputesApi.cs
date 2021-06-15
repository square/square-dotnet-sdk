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
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Authentication;
    using Square.Http.Client;
    using Square.Http.Request;
    using Square.Http.Response;
    using Square.Utilities;

    /// <summary>
    /// DisputesApi.
    /// </summary>
    internal class DisputesApi : BaseApi, IDisputesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisputesApi"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal DisputesApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Returns a list of disputes associated with a particular account..
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. For more information, see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination)..</param>
        /// <param name="states">Optional parameter: The dispute states to filter the result. If not specified, the endpoint returns all open disputes (the dispute status is not `INQUIRY_CLOSED`, `WON`, or `LOST`)..</param>
        /// <param name="locationId">Optional parameter: The ID of the location for which to return a list of disputes. If not specified, the endpoint returns all open disputes (the dispute status is not `INQUIRY_CLOSED`, `WON`, or `LOST`) associated with all locations..</param>
        /// <returns>Returns the Models.ListDisputesResponse response from the API call.</returns>
        public Models.ListDisputesResponse ListDisputes(
                string cursor = null,
                string states = null,
                string locationId = null)
        {
            Task<Models.ListDisputesResponse> t = this.ListDisputesAsync(cursor, states, locationId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a list of disputes associated with a particular account..
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. For more information, see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination)..</param>
        /// <param name="states">Optional parameter: The dispute states to filter the result. If not specified, the endpoint returns all open disputes (the dispute status is not `INQUIRY_CLOSED`, `WON`, or `LOST`)..</param>
        /// <param name="locationId">Optional parameter: The ID of the location for which to return a list of disputes. If not specified, the endpoint returns all open disputes (the dispute status is not `INQUIRY_CLOSED`, `WON`, or `LOST`) associated with all locations..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListDisputesResponse response from the API call.</returns>
        public async Task<Models.ListDisputesResponse> ListDisputesAsync(
                string cursor = null,
                string states = null,
                string locationId = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/disputes");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "cursor", cursor },
                { "states", states },
                { "location_id", locationId },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.ListDisputesResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Returns details about a specific dispute..
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute you want more details about..</param>
        /// <returns>Returns the Models.RetrieveDisputeResponse response from the API call.</returns>
        public Models.RetrieveDisputeResponse RetrieveDispute(
                string disputeId)
        {
            Task<Models.RetrieveDisputeResponse> t = this.RetrieveDisputeAsync(disputeId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns details about a specific dispute..
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute you want more details about..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveDisputeResponse response from the API call.</returns>
        public async Task<Models.RetrieveDisputeResponse> RetrieveDisputeAsync(
                string disputeId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/disputes/{dispute_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "dispute_id", disputeId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveDisputeResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Accepts the loss on a dispute. Square returns the disputed amount to the cardholder and.
        /// updates the dispute state to ACCEPTED..
        /// Square debits the disputed amount from the seller’s Square account. If the Square account.
        /// does not have sufficient funds, Square debits the associated bank account..
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute you want to accept..</param>
        /// <returns>Returns the Models.AcceptDisputeResponse response from the API call.</returns>
        public Models.AcceptDisputeResponse AcceptDispute(
                string disputeId)
        {
            Task<Models.AcceptDisputeResponse> t = this.AcceptDisputeAsync(disputeId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Accepts the loss on a dispute. Square returns the disputed amount to the cardholder and.
        /// updates the dispute state to ACCEPTED..
        /// Square debits the disputed amount from the seller’s Square account. If the Square account.
        /// does not have sufficient funds, Square debits the associated bank account..
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute you want to accept..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.AcceptDisputeResponse response from the API call.</returns>
        public async Task<Models.AcceptDisputeResponse> AcceptDisputeAsync(
                string disputeId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/disputes/{dispute_id}/accept");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "dispute_id", disputeId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Post(queryBuilder.ToString(), headers, null);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.AcceptDisputeResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Returns a list of evidence associated with a dispute..
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. For more information, see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination)..</param>
        /// <returns>Returns the Models.ListDisputeEvidenceResponse response from the API call.</returns>
        public Models.ListDisputeEvidenceResponse ListDisputeEvidence(
                string disputeId,
                string cursor = null)
        {
            Task<Models.ListDisputeEvidenceResponse> t = this.ListDisputeEvidenceAsync(disputeId, cursor);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a list of evidence associated with a dispute..
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. For more information, see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListDisputeEvidenceResponse response from the API call.</returns>
        public async Task<Models.ListDisputeEvidenceResponse> ListDisputeEvidenceAsync(
                string disputeId,
                string cursor = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/disputes/{dispute_id}/evidence");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "dispute_id", disputeId },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "cursor", cursor },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.ListDisputeEvidenceResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Uploads a file to use as evidence in a dispute challenge. The endpoint accepts HTTP.
        /// multipart/form-data file uploads in HEIC, HEIF, JPEG, PDF, PNG, and TIFF formats..
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute you want to upload evidence for..</param>
        /// <param name="request">Optional parameter: Defines the parameters for a `CreateDisputeEvidenceFile` request..</param>
        /// <param name="imageFile">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.CreateDisputeEvidenceFileResponse response from the API call.</returns>
        public Models.CreateDisputeEvidenceFileResponse CreateDisputeEvidenceFile(
                string disputeId,
                Models.CreateDisputeEvidenceFileRequest request = null,
                FileStreamInfo imageFile = null)
        {
            Task<Models.CreateDisputeEvidenceFileResponse> t = this.CreateDisputeEvidenceFileAsync(disputeId, request, imageFile);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Uploads a file to use as evidence in a dispute challenge. The endpoint accepts HTTP.
        /// multipart/form-data file uploads in HEIC, HEIF, JPEG, PDF, PNG, and TIFF formats..
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute you want to upload evidence for..</param>
        /// <param name="request">Optional parameter: Defines the parameters for a `CreateDisputeEvidenceFile` request..</param>
        /// <param name="imageFile">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateDisputeEvidenceFileResponse response from the API call.</returns>
        public async Task<Models.CreateDisputeEvidenceFileResponse> CreateDisputeEvidenceFileAsync(
                string disputeId,
                Models.CreateDisputeEvidenceFileRequest request = null,
                FileStreamInfo imageFile = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/disputes/{dispute_id}/evidence-files");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "dispute_id", disputeId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            var requestHeaders = new Dictionary<string, IReadOnlyCollection<string>>(StringComparer.OrdinalIgnoreCase)
            {
                { "Content-Type", new[] { "application/json; charset=utf-8" } },
            };

            var imageFileHeaders = new Dictionary<string, IReadOnlyCollection<string>>(StringComparer.OrdinalIgnoreCase)
            {
                { "Content-Type", new[] { string.IsNullOrEmpty(imageFile.ContentType) ? "image/jpeg" : imageFile.ContentType } },
            };

            // append form/field parameters.
            var fields = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("image_file", CreateFileMultipartContent(imageFile, imageFileHeaders)),
            };
            fields.Add(new KeyValuePair<string, object>("request", CreateJsonEncodedMultipartContent(request, requestHeaders)));

            // remove null parameters.
            fields = fields.Where(kvp => kvp.Value != null).ToList();

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Post(queryBuilder.ToString(), headers, fields);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.CreateDisputeEvidenceFileResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Uploads text to use as evidence for a dispute challenge..
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute you want to upload evidence for..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateDisputeEvidenceTextResponse response from the API call.</returns>
        public Models.CreateDisputeEvidenceTextResponse CreateDisputeEvidenceText(
                string disputeId,
                Models.CreateDisputeEvidenceTextRequest body)
        {
            Task<Models.CreateDisputeEvidenceTextResponse> t = this.CreateDisputeEvidenceTextAsync(disputeId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Uploads text to use as evidence for a dispute challenge..
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute you want to upload evidence for..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateDisputeEvidenceTextResponse response from the API call.</returns>
        public async Task<Models.CreateDisputeEvidenceTextResponse> CreateDisputeEvidenceTextAsync(
                string disputeId,
                Models.CreateDisputeEvidenceTextRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/disputes/{dispute_id}/evidence-text");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "dispute_id", disputeId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.CreateDisputeEvidenceTextResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Removes specified evidence from a dispute..
        /// Square does not send the bank any evidence that is removed. Also, you cannot remove evidence after.
        /// submitting it to the bank using [SubmitEvidence]($e/Disputes/SubmitEvidence)..
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute you want to remove evidence from..</param>
        /// <param name="evidenceId">Required parameter: The ID of the evidence you want to remove..</param>
        /// <returns>Returns the Models.DeleteDisputeEvidenceResponse response from the API call.</returns>
        public Models.DeleteDisputeEvidenceResponse DeleteDisputeEvidence(
                string disputeId,
                string evidenceId)
        {
            Task<Models.DeleteDisputeEvidenceResponse> t = this.DeleteDisputeEvidenceAsync(disputeId, evidenceId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Removes specified evidence from a dispute..
        /// Square does not send the bank any evidence that is removed. Also, you cannot remove evidence after.
        /// submitting it to the bank using [SubmitEvidence]($e/Disputes/SubmitEvidence)..
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute you want to remove evidence from..</param>
        /// <param name="evidenceId">Required parameter: The ID of the evidence you want to remove..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteDisputeEvidenceResponse response from the API call.</returns>
        public async Task<Models.DeleteDisputeEvidenceResponse> DeleteDisputeEvidenceAsync(
                string disputeId,
                string evidenceId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/disputes/{dispute_id}/evidence/{evidence_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "dispute_id", disputeId },
                { "evidence_id", evidenceId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Delete(queryBuilder.ToString(), headers, null);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.DeleteDisputeEvidenceResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Returns the evidence metadata specified by the evidence ID in the request URL path.
        /// You must maintain a copy of the evidence you upload if you want to reference it later. You cannot.
        /// download the evidence after you upload it..
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute that you want to retrieve evidence from..</param>
        /// <param name="evidenceId">Required parameter: The ID of the evidence to retrieve..</param>
        /// <returns>Returns the Models.RetrieveDisputeEvidenceResponse response from the API call.</returns>
        public Models.RetrieveDisputeEvidenceResponse RetrieveDisputeEvidence(
                string disputeId,
                string evidenceId)
        {
            Task<Models.RetrieveDisputeEvidenceResponse> t = this.RetrieveDisputeEvidenceAsync(disputeId, evidenceId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns the evidence metadata specified by the evidence ID in the request URL path.
        /// You must maintain a copy of the evidence you upload if you want to reference it later. You cannot.
        /// download the evidence after you upload it..
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute that you want to retrieve evidence from..</param>
        /// <param name="evidenceId">Required parameter: The ID of the evidence to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveDisputeEvidenceResponse response from the API call.</returns>
        public async Task<Models.RetrieveDisputeEvidenceResponse> RetrieveDisputeEvidenceAsync(
                string disputeId,
                string evidenceId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/disputes/{dispute_id}/evidence/{evidence_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "dispute_id", disputeId },
                { "evidence_id", evidenceId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveDisputeEvidenceResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Submits evidence to the cardholder's bank..
        /// Before submitting evidence, Square compiles all available evidence. This includes evidence uploaded.
        /// using the [CreateDisputeEvidenceFile]($e/Disputes/CreateDisputeEvidenceFile) and.
        /// [CreateDisputeEvidenceText]($e/Disputes/CreateDisputeEvidenceText) endpoints and.
        /// evidence automatically provided by Square, when available..
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute that you want to submit evidence for..</param>
        /// <returns>Returns the Models.SubmitEvidenceResponse response from the API call.</returns>
        public Models.SubmitEvidenceResponse SubmitEvidence(
                string disputeId)
        {
            Task<Models.SubmitEvidenceResponse> t = this.SubmitEvidenceAsync(disputeId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Submits evidence to the cardholder's bank..
        /// Before submitting evidence, Square compiles all available evidence. This includes evidence uploaded.
        /// using the [CreateDisputeEvidenceFile]($e/Disputes/CreateDisputeEvidenceFile) and.
        /// [CreateDisputeEvidenceText]($e/Disputes/CreateDisputeEvidenceText) endpoints and.
        /// evidence automatically provided by Square, when available..
        /// </summary>
        /// <param name="disputeId">Required parameter: The ID of the dispute that you want to submit evidence for..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SubmitEvidenceResponse response from the API call.</returns>
        public async Task<Models.SubmitEvidenceResponse> SubmitEvidenceAsync(
                string disputeId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/disputes/{dispute_id}/submit-evidence");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "dispute_id", disputeId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Post(queryBuilder.ToString(), headers, null);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.SubmitEvidenceResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }
    }
}