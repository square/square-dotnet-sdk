using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;
using Square.Http.Request;
using Square.Http.Response;
using Square.Http.Client;
using Square.Exceptions;

namespace Square.Apis
{
    internal class ReportingApi: BaseApi, IReportingApi
    {
        internal ReportingApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null) :
            base(config, httpClient, authManagers, httpCallBack)
        { }

        /// <summary>
        /// Returns a list of refunded transactions (across all possible originating locations) relating to monies
        /// credited to the provided location ID by another Square account using the `additional_recipients` field in a transaction.
        /// Max results per [page](#paginatingresults): 50
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list AdditionalRecipientReceivableRefunds for.</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in RFC 3339 format.  See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.  Default value: The current time minus one year.</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in RFC 3339 format.  See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.  Default value: The current time.</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed in the response (`ASC` for oldest first, `DESC` for newest first).  Default value: `DESC`</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Paginating results](#paginatingresults) for more information.</param>
        /// <return>Returns the Models.ListAdditionalRecipientReceivableRefundsResponse response from the API call</return>
        [Obsolete]
        public Models.ListAdditionalRecipientReceivableRefundsResponse ListAdditionalRecipientReceivableRefunds(
                string locationId,
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null)
        {
            Task<Models.ListAdditionalRecipientReceivableRefundsResponse> t = ListAdditionalRecipientReceivableRefundsAsync(locationId, beginTime, endTime, sortOrder, cursor);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a list of refunded transactions (across all possible originating locations) relating to monies
        /// credited to the provided location ID by another Square account using the `additional_recipients` field in a transaction.
        /// Max results per [page](#paginatingresults): 50
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list AdditionalRecipientReceivableRefunds for.</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in RFC 3339 format.  See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.  Default value: The current time minus one year.</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in RFC 3339 format.  See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.  Default value: The current time.</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed in the response (`ASC` for oldest first, `DESC` for newest first).  Default value: `DESC`</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Paginating results](#paginatingresults) for more information.</param>
        /// <return>Returns the Models.ListAdditionalRecipientReceivableRefundsResponse response from the API call</return>
        [Obsolete]
        public async Task<Models.ListAdditionalRecipientReceivableRefundsResponse> ListAdditionalRecipientReceivableRefundsAsync(
                string locationId,
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/locations/{location_id}/additional-recipient-receivable-refunds");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId }
            });

            //process optional query parameters
            ApiHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "begin_time", beginTime },
                { "end_time", endTime },
                { "sort_order", sortOrder },
                { "cursor", cursor }
            },ArrayDeserializationFormat,ParameterSeparator);

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            { 
                { "user-agent", "Square-DotNet-SDK/4.0.0" },
                { "accept", "application/json" },
                { "Square-Version", "2019-12-17" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().Get(_queryUrl,_headers);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = authManagers["default"].Apply(_request);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await GetClientInstance().ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.ListAdditionalRecipientReceivableRefundsResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Returns a list of receivables (across all possible sending locations) representing monies credited
        /// to the provided location ID by another Square account using the `additional_recipients` field in a transaction.
        /// Max results per [page](#paginatingresults): 50
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list AdditionalRecipientReceivables for.</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in RFC 3339 format.  See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.  Default value: The current time minus one year.</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in RFC 3339 format.  See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.  Default value: The current time.</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed in the response (`ASC` for oldest first, `DESC` for newest first).  Default value: `DESC`</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Paginating results](#paginatingresults) for more information.</param>
        /// <return>Returns the Models.ListAdditionalRecipientReceivablesResponse response from the API call</return>
        [Obsolete]
        public Models.ListAdditionalRecipientReceivablesResponse ListAdditionalRecipientReceivables(
                string locationId,
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null)
        {
            Task<Models.ListAdditionalRecipientReceivablesResponse> t = ListAdditionalRecipientReceivablesAsync(locationId, beginTime, endTime, sortOrder, cursor);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a list of receivables (across all possible sending locations) representing monies credited
        /// to the provided location ID by another Square account using the `additional_recipients` field in a transaction.
        /// Max results per [page](#paginatingresults): 50
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to list AdditionalRecipientReceivables for.</param>
        /// <param name="beginTime">Optional parameter: The beginning of the requested reporting period, in RFC 3339 format.  See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.  Default value: The current time minus one year.</param>
        /// <param name="endTime">Optional parameter: The end of the requested reporting period, in RFC 3339 format.  See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.  Default value: The current time.</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed in the response (`ASC` for oldest first, `DESC` for newest first).  Default value: `DESC`</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Paginating results](#paginatingresults) for more information.</param>
        /// <return>Returns the Models.ListAdditionalRecipientReceivablesResponse response from the API call</return>
        [Obsolete]
        public async Task<Models.ListAdditionalRecipientReceivablesResponse> ListAdditionalRecipientReceivablesAsync(
                string locationId,
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/locations/{location_id}/additional-recipient-receivables");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "location_id", locationId }
            });

            //process optional query parameters
            ApiHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "begin_time", beginTime },
                { "end_time", endTime },
                { "sort_order", sortOrder },
                { "cursor", cursor }
            },ArrayDeserializationFormat,ParameterSeparator);

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            { 
                { "user-agent", "Square-DotNet-SDK/4.0.0" },
                { "accept", "application/json" },
                { "Square-Version", "2019-12-17" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().Get(_queryUrl,_headers);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = authManagers["default"].Apply(_request);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await GetClientInstance().ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.ListAdditionalRecipientReceivablesResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

    }
} 