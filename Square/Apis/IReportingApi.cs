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
    public interface IReportingApi
    {
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
        Models.ListAdditionalRecipientReceivableRefundsResponse ListAdditionalRecipientReceivableRefunds(
                string locationId,
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null);

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
        Task<Models.ListAdditionalRecipientReceivableRefundsResponse> ListAdditionalRecipientReceivableRefundsAsync(
                string locationId,
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null, CancellationToken cancellationToken = default);

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
        Models.ListAdditionalRecipientReceivablesResponse ListAdditionalRecipientReceivables(
                string locationId,
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null);

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
        Task<Models.ListAdditionalRecipientReceivablesResponse> ListAdditionalRecipientReceivablesAsync(
                string locationId,
                string beginTime = null,
                string endTime = null,
                string sortOrder = null,
                string cursor = null, CancellationToken cancellationToken = default);

    }
}