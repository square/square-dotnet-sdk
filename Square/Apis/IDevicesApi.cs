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
    public interface IDevicesApi
    {
        /// <summary>
        /// Lists all DeviceCodes associated with the merchant.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Paginating results](#paginatingresults) for more information.</param>
        /// <param name="locationId">Optional parameter: If specified, only returns DeviceCodes of the specified location. Returns DeviceCodes of all locations if empty.</param>
        /// <param name="productType">Optional parameter: If specified, only returns DeviceCodes targeting the specified product type. Returns DeviceCodes of all product types if empty.</param>
        /// <return>Returns the Models.ListDeviceCodesResponse response from the API call</return>
        Models.ListDeviceCodesResponse ListDeviceCodes(string cursor = null, string locationId = null, string productType = null);

        /// <summary>
        /// Lists all DeviceCodes associated with the merchant.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Paginating results](#paginatingresults) for more information.</param>
        /// <param name="locationId">Optional parameter: If specified, only returns DeviceCodes of the specified location. Returns DeviceCodes of all locations if empty.</param>
        /// <param name="productType">Optional parameter: If specified, only returns DeviceCodes targeting the specified product type. Returns DeviceCodes of all product types if empty.</param>
        /// <return>Returns the Models.ListDeviceCodesResponse response from the API call</return>
        Task<Models.ListDeviceCodesResponse> ListDeviceCodesAsync(string cursor = null, string locationId = null, string productType = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a DeviceCode that can be used to login to a Square Terminal device to enter the connected
        /// terminal mode.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateDeviceCodeResponse response from the API call</return>
        Models.CreateDeviceCodeResponse CreateDeviceCode(Models.CreateDeviceCodeRequest body);

        /// <summary>
        /// Creates a DeviceCode that can be used to login to a Square Terminal device to enter the connected
        /// terminal mode.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateDeviceCodeResponse response from the API call</return>
        Task<Models.CreateDeviceCodeResponse> CreateDeviceCodeAsync(Models.CreateDeviceCodeRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves DeviceCode with the associated ID.
        /// </summary>
        /// <param name="id">Required parameter: The unique identifier for the device code.</param>
        /// <return>Returns the Models.GetDeviceCodeResponse response from the API call</return>
        Models.GetDeviceCodeResponse GetDeviceCode(string id);

        /// <summary>
        /// Retrieves DeviceCode with the associated ID.
        /// </summary>
        /// <param name="id">Required parameter: The unique identifier for the device code.</param>
        /// <return>Returns the Models.GetDeviceCodeResponse response from the API call</return>
        Task<Models.GetDeviceCodeResponse> GetDeviceCodeAsync(string id, CancellationToken cancellationToken = default);

    }
}