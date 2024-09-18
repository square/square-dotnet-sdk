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
using Square.Http.Client;
using Square.Utilities;
using System.Net.Http;

namespace Square.Apis
{
    /// <summary>
    /// VendorsApi.
    /// </summary>
    internal class VendorsApi : BaseApi, IVendorsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VendorsApi"/> class.
        /// </summary>
        internal VendorsApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Creates one or more [Vendor]($m/Vendor) objects to represent suppliers to a seller.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkCreateVendorsResponse response from the API call.</returns>
        public Models.BulkCreateVendorsResponse BulkCreateVendors(
                Models.BulkCreateVendorsRequest body)
            => CoreHelper.RunTask(BulkCreateVendorsAsync(body));

        /// <summary>
        /// Creates one or more [Vendor]($m/Vendor) objects to represent suppliers to a seller.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkCreateVendorsResponse response from the API call.</returns>
        public async Task<Models.BulkCreateVendorsResponse> BulkCreateVendorsAsync(
                Models.BulkCreateVendorsRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.BulkCreateVendorsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/vendors/bulk-create")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Retrieves one or more vendors of specified [Vendor]($m/Vendor) IDs.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkRetrieveVendorsResponse response from the API call.</returns>
        public Models.BulkRetrieveVendorsResponse BulkRetrieveVendors(
                Models.BulkRetrieveVendorsRequest body)
            => CoreHelper.RunTask(BulkRetrieveVendorsAsync(body));

        /// <summary>
        /// Retrieves one or more vendors of specified [Vendor]($m/Vendor) IDs.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkRetrieveVendorsResponse response from the API call.</returns>
        public async Task<Models.BulkRetrieveVendorsResponse> BulkRetrieveVendorsAsync(
                Models.BulkRetrieveVendorsRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.BulkRetrieveVendorsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/vendors/bulk-retrieve")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Updates one or more of existing [Vendor]($m/Vendor) objects as suppliers to a seller.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkUpdateVendorsResponse response from the API call.</returns>
        public Models.BulkUpdateVendorsResponse BulkUpdateVendors(
                Models.BulkUpdateVendorsRequest body)
            => CoreHelper.RunTask(BulkUpdateVendorsAsync(body));

        /// <summary>
        /// Updates one or more of existing [Vendor]($m/Vendor) objects as suppliers to a seller.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkUpdateVendorsResponse response from the API call.</returns>
        public async Task<Models.BulkUpdateVendorsResponse> BulkUpdateVendorsAsync(
                Models.BulkUpdateVendorsRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.BulkUpdateVendorsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/v2/vendors/bulk-update")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates a single [Vendor]($m/Vendor) object to represent a supplier to a seller.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateVendorResponse response from the API call.</returns>
        public Models.CreateVendorResponse CreateVendor(
                Models.CreateVendorRequest body)
            => CoreHelper.RunTask(CreateVendorAsync(body));

        /// <summary>
        /// Creates a single [Vendor]($m/Vendor) object to represent a supplier to a seller.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateVendorResponse response from the API call.</returns>
        public async Task<Models.CreateVendorResponse> CreateVendorAsync(
                Models.CreateVendorRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CreateVendorResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/vendors/create")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Searches for vendors using a filter against supported [Vendor]($m/Vendor) properties and a supported sorter.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchVendorsResponse response from the API call.</returns>
        public Models.SearchVendorsResponse SearchVendors(
                Models.SearchVendorsRequest body)
            => CoreHelper.RunTask(SearchVendorsAsync(body));

        /// <summary>
        /// Searches for vendors using a filter against supported [Vendor]($m/Vendor) properties and a supported sorter.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchVendorsResponse response from the API call.</returns>
        public async Task<Models.SearchVendorsResponse> SearchVendorsAsync(
                Models.SearchVendorsRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.SearchVendorsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/vendors/search")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Retrieves the vendor of a specified [Vendor]($m/Vendor) ID.
        /// </summary>
        /// <param name="vendorId">Required parameter: ID of the [Vendor](entity:Vendor) to retrieve..</param>
        /// <returns>Returns the Models.RetrieveVendorResponse response from the API call.</returns>
        public Models.RetrieveVendorResponse RetrieveVendor(
                string vendorId)
            => CoreHelper.RunTask(RetrieveVendorAsync(vendorId));

        /// <summary>
        /// Retrieves the vendor of a specified [Vendor]($m/Vendor) ID.
        /// </summary>
        /// <param name="vendorId">Required parameter: ID of the [Vendor](entity:Vendor) to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveVendorResponse response from the API call.</returns>
        public async Task<Models.RetrieveVendorResponse> RetrieveVendorAsync(
                string vendorId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveVendorResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/vendors/{vendor_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("vendor_id", vendorId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Updates an existing [Vendor]($m/Vendor) object as a supplier to a seller.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="vendorId">Required parameter: Example: .</param>
        /// <returns>Returns the Models.UpdateVendorResponse response from the API call.</returns>
        public Models.UpdateVendorResponse UpdateVendor(
                Models.UpdateVendorRequest body,
                string vendorId)
            => CoreHelper.RunTask(UpdateVendorAsync(body, vendorId));

        /// <summary>
        /// Updates an existing [Vendor]($m/Vendor) object as a supplier to a seller.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="vendorId">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateVendorResponse response from the API call.</returns>
        public async Task<Models.UpdateVendorResponse> UpdateVendorAsync(
                Models.UpdateVendorRequest body,
                string vendorId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.UpdateVendorResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/v2/vendors/{vendor_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))
                      .Template(_template => _template.Setup("vendor_id", vendorId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}