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
    /// IVendorsApi.
    /// </summary>
    public interface IVendorsApi
    {
        /// <summary>
        /// Creates one or more [Vendor]($m/Vendor) objects to represent suppliers to a seller.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkCreateVendorsResponse response from the API call.</returns>
        Models.BulkCreateVendorsResponse BulkCreateVendors(
                Models.BulkCreateVendorsRequest body);

        /// <summary>
        /// Creates one or more [Vendor]($m/Vendor) objects to represent suppliers to a seller.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkCreateVendorsResponse response from the API call.</returns>
        Task<Models.BulkCreateVendorsResponse> BulkCreateVendorsAsync(
                Models.BulkCreateVendorsRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves one or more vendors of specified [Vendor]($m/Vendor) IDs.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkRetrieveVendorsResponse response from the API call.</returns>
        Models.BulkRetrieveVendorsResponse BulkRetrieveVendors(
                Models.BulkRetrieveVendorsRequest body);

        /// <summary>
        /// Retrieves one or more vendors of specified [Vendor]($m/Vendor) IDs.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkRetrieveVendorsResponse response from the API call.</returns>
        Task<Models.BulkRetrieveVendorsResponse> BulkRetrieveVendorsAsync(
                Models.BulkRetrieveVendorsRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates one or more of existing [Vendor]($m/Vendor) objects as suppliers to a seller.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkUpdateVendorsResponse response from the API call.</returns>
        Models.BulkUpdateVendorsResponse BulkUpdateVendors(
                Models.BulkUpdateVendorsRequest body);

        /// <summary>
        /// Updates one or more of existing [Vendor]($m/Vendor) objects as suppliers to a seller.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkUpdateVendorsResponse response from the API call.</returns>
        Task<Models.BulkUpdateVendorsResponse> BulkUpdateVendorsAsync(
                Models.BulkUpdateVendorsRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a single [Vendor]($m/Vendor) object to represent a supplier to a seller.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateVendorResponse response from the API call.</returns>
        Models.CreateVendorResponse CreateVendor(
                Models.CreateVendorRequest body);

        /// <summary>
        /// Creates a single [Vendor]($m/Vendor) object to represent a supplier to a seller.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateVendorResponse response from the API call.</returns>
        Task<Models.CreateVendorResponse> CreateVendorAsync(
                Models.CreateVendorRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Searches for vendors using a filter against supported [Vendor]($m/Vendor) properties and a supported sorter.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchVendorsResponse response from the API call.</returns>
        Models.SearchVendorsResponse SearchVendors(
                Models.SearchVendorsRequest body);

        /// <summary>
        /// Searches for vendors using a filter against supported [Vendor]($m/Vendor) properties and a supported sorter.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchVendorsResponse response from the API call.</returns>
        Task<Models.SearchVendorsResponse> SearchVendorsAsync(
                Models.SearchVendorsRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves the vendor of a specified [Vendor]($m/Vendor) ID.
        /// </summary>
        /// <param name="vendorId">Required parameter: ID of the [Vendor](entity:Vendor) to retrieve..</param>
        /// <returns>Returns the Models.RetrieveVendorResponse response from the API call.</returns>
        Models.RetrieveVendorResponse RetrieveVendor(
                string vendorId);

        /// <summary>
        /// Retrieves the vendor of a specified [Vendor]($m/Vendor) ID.
        /// </summary>
        /// <param name="vendorId">Required parameter: ID of the [Vendor](entity:Vendor) to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveVendorResponse response from the API call.</returns>
        Task<Models.RetrieveVendorResponse> RetrieveVendorAsync(
                string vendorId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing [Vendor]($m/Vendor) object as a supplier to a seller.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="vendorId">Required parameter: Example: .</param>
        /// <returns>Returns the Models.UpdateVendorResponse response from the API call.</returns>
        Models.UpdateVendorResponse UpdateVendor(
                Models.UpdateVendorRequest body,
                string vendorId);

        /// <summary>
        /// Updates an existing [Vendor]($m/Vendor) object as a supplier to a seller.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="vendorId">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateVendorResponse response from the API call.</returns>
        Task<Models.UpdateVendorResponse> UpdateVendorAsync(
                Models.UpdateVendorRequest body,
                string vendorId,
                CancellationToken cancellationToken = default);
    }
}