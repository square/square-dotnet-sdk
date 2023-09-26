namespace Square.Apis
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Square;
    using Square.Http.Client;
    using Square.Http.Request;
    using Square.Http.Response;
    using Square.Utilities;

    /// <summary>
    /// IDevicesApi.
    /// </summary>
    public interface IDevicesApi
    {
        /// <summary>
        /// List devices associated with the merchant. Currently, only Terminal API.
        /// devices are supported.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. See [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination) for more information..</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed. - `ASC` - Oldest to newest. - `DESC` - Newest to oldest (default)..</param>
        /// <param name="limit">Optional parameter: The number of results to return in a single page..</param>
        /// <param name="locationId">Optional parameter: If present, only returns devices at the target location..</param>
        /// <returns>Returns the Models.ListDevicesResponse response from the API call.</returns>
        Models.ListDevicesResponse ListDevices(
                string cursor = null,
                string sortOrder = null,
                int? limit = null,
                string locationId = null);

        /// <summary>
        /// List devices associated with the merchant. Currently, only Terminal API.
        /// devices are supported.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. See [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination) for more information..</param>
        /// <param name="sortOrder">Optional parameter: The order in which results are listed. - `ASC` - Oldest to newest. - `DESC` - Newest to oldest (default)..</param>
        /// <param name="limit">Optional parameter: The number of results to return in a single page..</param>
        /// <param name="locationId">Optional parameter: If present, only returns devices at the target location..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListDevicesResponse response from the API call.</returns>
        Task<Models.ListDevicesResponse> ListDevicesAsync(
                string cursor = null,
                string sortOrder = null,
                int? limit = null,
                string locationId = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists all DeviceCodes associated with the merchant.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Paginating results](https://developer.squareup.com/docs/working-with-apis/pagination) for more information..</param>
        /// <param name="locationId">Optional parameter: If specified, only returns DeviceCodes of the specified location. Returns DeviceCodes of all locations if empty..</param>
        /// <param name="productType">Optional parameter: If specified, only returns DeviceCodes targeting the specified product type. Returns DeviceCodes of all product types if empty..</param>
        /// <param name="status">Optional parameter: If specified, returns DeviceCodes with the specified statuses. Returns DeviceCodes of status `PAIRED` and `UNPAIRED` if empty..</param>
        /// <returns>Returns the Models.ListDeviceCodesResponse response from the API call.</returns>
        Models.ListDeviceCodesResponse ListDeviceCodes(
                string cursor = null,
                string locationId = null,
                string productType = null,
                string status = null);

        /// <summary>
        /// Lists all DeviceCodes associated with the merchant.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this to retrieve the next set of results for your original query.  See [Paginating results](https://developer.squareup.com/docs/working-with-apis/pagination) for more information..</param>
        /// <param name="locationId">Optional parameter: If specified, only returns DeviceCodes of the specified location. Returns DeviceCodes of all locations if empty..</param>
        /// <param name="productType">Optional parameter: If specified, only returns DeviceCodes targeting the specified product type. Returns DeviceCodes of all product types if empty..</param>
        /// <param name="status">Optional parameter: If specified, returns DeviceCodes with the specified statuses. Returns DeviceCodes of status `PAIRED` and `UNPAIRED` if empty..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListDeviceCodesResponse response from the API call.</returns>
        Task<Models.ListDeviceCodesResponse> ListDeviceCodesAsync(
                string cursor = null,
                string locationId = null,
                string productType = null,
                string status = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a DeviceCode that can be used to login to a Square Terminal device to enter the connected.
        /// terminal mode.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateDeviceCodeResponse response from the API call.</returns>
        Models.CreateDeviceCodeResponse CreateDeviceCode(
                Models.CreateDeviceCodeRequest body);

        /// <summary>
        /// Creates a DeviceCode that can be used to login to a Square Terminal device to enter the connected.
        /// terminal mode.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateDeviceCodeResponse response from the API call.</returns>
        Task<Models.CreateDeviceCodeResponse> CreateDeviceCodeAsync(
                Models.CreateDeviceCodeRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves DeviceCode with the associated ID.
        /// </summary>
        /// <param name="id">Required parameter: The unique identifier for the device code..</param>
        /// <returns>Returns the Models.GetDeviceCodeResponse response from the API call.</returns>
        Models.GetDeviceCodeResponse GetDeviceCode(
                string id);

        /// <summary>
        /// Retrieves DeviceCode with the associated ID.
        /// </summary>
        /// <param name="id">Required parameter: The unique identifier for the device code..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetDeviceCodeResponse response from the API call.</returns>
        Task<Models.GetDeviceCodeResponse> GetDeviceCodeAsync(
                string id,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves Device with the associated `device_id`.
        /// </summary>
        /// <param name="deviceId">Required parameter: The unique ID for the desired `Device`..</param>
        /// <returns>Returns the Models.GetDeviceResponse response from the API call.</returns>
        Models.GetDeviceResponse GetDevice(
                string deviceId);

        /// <summary>
        /// Retrieves Device with the associated `device_id`.
        /// </summary>
        /// <param name="deviceId">Required parameter: The unique ID for the desired `Device`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetDeviceResponse response from the API call.</returns>
        Task<Models.GetDeviceResponse> GetDeviceAsync(
                string deviceId,
                CancellationToken cancellationToken = default);
    }
}