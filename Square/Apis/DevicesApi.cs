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
    /// DevicesApi.
    /// </summary>
    internal class DevicesApi : BaseApi, IDevicesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DevicesApi"/> class.
        /// </summary>
        internal DevicesApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Lists all DeviceCodes associated with the merchant.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Paginating results](https://developer.squareup.com/docs/working-with-apis/pagination) for more information..</param>
        /// <param name="locationId">Optional parameter: If specified, only returns DeviceCodes of the specified location. Returns DeviceCodes of all locations if empty..</param>
        /// <param name="productType">Optional parameter: If specified, only returns DeviceCodes targeting the specified product type. Returns DeviceCodes of all product types if empty..</param>
        /// <param name="status">Optional parameter: If specified, returns DeviceCodes with the specified statuses. Returns DeviceCodes of status `PAIRED` and `UNPAIRED` if empty..</param>
        /// <returns>Returns the Models.ListDeviceCodesResponse response from the API call.</returns>
        public Models.ListDeviceCodesResponse ListDeviceCodes(
                string cursor = null,
                string locationId = null,
                string productType = null,
                string status = null)
            => CoreHelper.RunTask(ListDeviceCodesAsync(cursor, locationId, productType, status));

        /// <summary>
        /// Lists all DeviceCodes associated with the merchant.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Paginating results](https://developer.squareup.com/docs/working-with-apis/pagination) for more information..</param>
        /// <param name="locationId">Optional parameter: If specified, only returns DeviceCodes of the specified location. Returns DeviceCodes of all locations if empty..</param>
        /// <param name="productType">Optional parameter: If specified, only returns DeviceCodes targeting the specified product type. Returns DeviceCodes of all product types if empty..</param>
        /// <param name="status">Optional parameter: If specified, returns DeviceCodes with the specified statuses. Returns DeviceCodes of status `PAIRED` and `UNPAIRED` if empty..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListDeviceCodesResponse response from the API call.</returns>
        public async Task<Models.ListDeviceCodesResponse> ListDeviceCodesAsync(
                string cursor = null,
                string locationId = null,
                string productType = null,
                string status = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListDeviceCodesResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/devices/codes")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("cursor", cursor))
                      .Query(_query => _query.Setup("location_id", locationId))
                      .Query(_query => _query.Setup("product_type", productType))
                      .Query(_query => _query.Setup("status", status))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Creates a DeviceCode that can be used to login to a Square Terminal device to enter the connected.
        /// terminal mode.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateDeviceCodeResponse response from the API call.</returns>
        public Models.CreateDeviceCodeResponse CreateDeviceCode(
                Models.CreateDeviceCodeRequest body)
            => CoreHelper.RunTask(CreateDeviceCodeAsync(body));

        /// <summary>
        /// Creates a DeviceCode that can be used to login to a Square Terminal device to enter the connected.
        /// terminal mode.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateDeviceCodeResponse response from the API call.</returns>
        public async Task<Models.CreateDeviceCodeResponse> CreateDeviceCodeAsync(
                Models.CreateDeviceCodeRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CreateDeviceCodeResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/devices/codes")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Retrieves DeviceCode with the associated ID.
        /// </summary>
        /// <param name="id">Required parameter: The unique identifier for the device code..</param>
        /// <returns>Returns the Models.GetDeviceCodeResponse response from the API call.</returns>
        public Models.GetDeviceCodeResponse GetDeviceCode(
                string id)
            => CoreHelper.RunTask(GetDeviceCodeAsync(id));

        /// <summary>
        /// Retrieves DeviceCode with the associated ID.
        /// </summary>
        /// <param name="id">Required parameter: The unique identifier for the device code..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetDeviceCodeResponse response from the API call.</returns>
        public async Task<Models.GetDeviceCodeResponse> GetDeviceCodeAsync(
                string id,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.GetDeviceCodeResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/devices/codes/{id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("id", id))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);
    }
}