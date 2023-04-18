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
    /// IBookingCustomAttributesApi.
    /// </summary>
    public interface IBookingCustomAttributesApi
    {
        /// <summary>
        /// Get all bookings custom attribute definitions.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory. The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100. The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <returns>Returns the Models.ListBookingCustomAttributeDefinitionsResponse response from the API call.</returns>
        Models.ListBookingCustomAttributeDefinitionsResponse ListBookingCustomAttributeDefinitions(
                int? limit = null,
                string cursor = null);

        /// <summary>
        /// Get all bookings custom attribute definitions.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory. The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100. The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListBookingCustomAttributeDefinitionsResponse response from the API call.</returns>
        Task<Models.ListBookingCustomAttributeDefinitionsResponse> ListBookingCustomAttributeDefinitionsAsync(
                int? limit = null,
                string cursor = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a bookings custom attribute definition.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateBookingCustomAttributeDefinitionResponse response from the API call.</returns>
        Models.CreateBookingCustomAttributeDefinitionResponse CreateBookingCustomAttributeDefinition(
                Models.CreateBookingCustomAttributeDefinitionRequest body);

        /// <summary>
        /// Creates a bookings custom attribute definition.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateBookingCustomAttributeDefinitionResponse response from the API call.</returns>
        Task<Models.CreateBookingCustomAttributeDefinitionResponse> CreateBookingCustomAttributeDefinitionAsync(
                Models.CreateBookingCustomAttributeDefinitionRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a bookings custom attribute definition.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to delete..</param>
        /// <returns>Returns the Models.DeleteBookingCustomAttributeDefinitionResponse response from the API call.</returns>
        Models.DeleteBookingCustomAttributeDefinitionResponse DeleteBookingCustomAttributeDefinition(
                string key);

        /// <summary>
        /// Deletes a bookings custom attribute definition.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to delete..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteBookingCustomAttributeDefinitionResponse response from the API call.</returns>
        Task<Models.DeleteBookingCustomAttributeDefinitionResponse> DeleteBookingCustomAttributeDefinitionAsync(
                string key,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a bookings custom attribute definition.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to retrieve. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="version">Optional parameter: The current version of the custom attribute definition, which is used for strongly consistent reads to guarantee that you receive the most up-to-date data. When included in the request, Square returns the specified version or a higher version if one exists. If the specified version is higher than the current version, Square returns a `BAD_REQUEST` error..</param>
        /// <returns>Returns the Models.RetrieveBookingCustomAttributeDefinitionResponse response from the API call.</returns>
        Models.RetrieveBookingCustomAttributeDefinitionResponse RetrieveBookingCustomAttributeDefinition(
                string key,
                int? version = null);

        /// <summary>
        /// Retrieves a bookings custom attribute definition.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to retrieve. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="version">Optional parameter: The current version of the custom attribute definition, which is used for strongly consistent reads to guarantee that you receive the most up-to-date data. When included in the request, Square returns the specified version or a higher version if one exists. If the specified version is higher than the current version, Square returns a `BAD_REQUEST` error..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveBookingCustomAttributeDefinitionResponse response from the API call.</returns>
        Task<Models.RetrieveBookingCustomAttributeDefinitionResponse> RetrieveBookingCustomAttributeDefinitionAsync(
                string key,
                int? version = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a bookings custom attribute definition.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateBookingCustomAttributeDefinitionResponse response from the API call.</returns>
        Models.UpdateBookingCustomAttributeDefinitionResponse UpdateBookingCustomAttributeDefinition(
                string key,
                Models.UpdateBookingCustomAttributeDefinitionRequest body);

        /// <summary>
        /// Updates a bookings custom attribute definition.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateBookingCustomAttributeDefinitionResponse response from the API call.</returns>
        Task<Models.UpdateBookingCustomAttributeDefinitionResponse> UpdateBookingCustomAttributeDefinitionAsync(
                string key,
                Models.UpdateBookingCustomAttributeDefinitionRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Bulk deletes bookings custom attributes.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkDeleteBookingCustomAttributesResponse response from the API call.</returns>
        Models.BulkDeleteBookingCustomAttributesResponse BulkDeleteBookingCustomAttributes(
                Models.BulkDeleteBookingCustomAttributesRequest body);

        /// <summary>
        /// Bulk deletes bookings custom attributes.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkDeleteBookingCustomAttributesResponse response from the API call.</returns>
        Task<Models.BulkDeleteBookingCustomAttributesResponse> BulkDeleteBookingCustomAttributesAsync(
                Models.BulkDeleteBookingCustomAttributesRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Bulk upserts bookings custom attributes.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkUpsertBookingCustomAttributesResponse response from the API call.</returns>
        Models.BulkUpsertBookingCustomAttributesResponse BulkUpsertBookingCustomAttributes(
                Models.BulkUpsertBookingCustomAttributesRequest body);

        /// <summary>
        /// Bulk upserts bookings custom attributes.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkUpsertBookingCustomAttributesResponse response from the API call.</returns>
        Task<Models.BulkUpsertBookingCustomAttributesResponse> BulkUpsertBookingCustomAttributesAsync(
                Models.BulkUpsertBookingCustomAttributesRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists a booking's custom attributes.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the target [booking](entity:Booking)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory. The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100. The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="withDefinitions">Optional parameter: Indicates whether to return the [custom attribute definition](entity:CustomAttributeDefinition) in the `definition` field of each custom attribute. Set this parameter to `true` to get the name and description of each custom attribute, information about the data type, or other definition details. The default value is `false`..</param>
        /// <returns>Returns the Models.ListBookingCustomAttributesResponse response from the API call.</returns>
        Models.ListBookingCustomAttributesResponse ListBookingCustomAttributes(
                string bookingId,
                int? limit = null,
                string cursor = null,
                bool? withDefinitions = false);

        /// <summary>
        /// Lists a booking's custom attributes.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the target [booking](entity:Booking)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory. The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100. The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="withDefinitions">Optional parameter: Indicates whether to return the [custom attribute definition](entity:CustomAttributeDefinition) in the `definition` field of each custom attribute. Set this parameter to `true` to get the name and description of each custom attribute, information about the data type, or other definition details. The default value is `false`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListBookingCustomAttributesResponse response from the API call.</returns>
        Task<Models.ListBookingCustomAttributesResponse> ListBookingCustomAttributesAsync(
                string bookingId,
                int? limit = null,
                string cursor = null,
                bool? withDefinitions = false,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a bookings custom attribute.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the target [booking](entity:Booking)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to delete. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <returns>Returns the Models.DeleteBookingCustomAttributeResponse response from the API call.</returns>
        Models.DeleteBookingCustomAttributeResponse DeleteBookingCustomAttribute(
                string bookingId,
                string key);

        /// <summary>
        /// Deletes a bookings custom attribute.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the target [booking](entity:Booking)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to delete. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteBookingCustomAttributeResponse response from the API call.</returns>
        Task<Models.DeleteBookingCustomAttributeResponse> DeleteBookingCustomAttributeAsync(
                string bookingId,
                string key,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a bookings custom attribute.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the target [booking](entity:Booking)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to retrieve. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="withDefinition">Optional parameter: Indicates whether to return the [custom attribute definition](entity:CustomAttributeDefinition) in the `definition` field of the custom attribute. Set this parameter to `true` to get the name and description of the custom attribute, information about the data type, or other definition details. The default value is `false`..</param>
        /// <param name="version">Optional parameter: The current version of the custom attribute, which is used for strongly consistent reads to guarantee that you receive the most up-to-date data. When included in the request, Square returns the specified version or a higher version if one exists. If the specified version is higher than the current version, Square returns a `BAD_REQUEST` error..</param>
        /// <returns>Returns the Models.RetrieveBookingCustomAttributeResponse response from the API call.</returns>
        Models.RetrieveBookingCustomAttributeResponse RetrieveBookingCustomAttribute(
                string bookingId,
                string key,
                bool? withDefinition = false,
                int? version = null);

        /// <summary>
        /// Retrieves a bookings custom attribute.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the target [booking](entity:Booking)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to retrieve. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="withDefinition">Optional parameter: Indicates whether to return the [custom attribute definition](entity:CustomAttributeDefinition) in the `definition` field of the custom attribute. Set this parameter to `true` to get the name and description of the custom attribute, information about the data type, or other definition details. The default value is `false`..</param>
        /// <param name="version">Optional parameter: The current version of the custom attribute, which is used for strongly consistent reads to guarantee that you receive the most up-to-date data. When included in the request, Square returns the specified version or a higher version if one exists. If the specified version is higher than the current version, Square returns a `BAD_REQUEST` error..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveBookingCustomAttributeResponse response from the API call.</returns>
        Task<Models.RetrieveBookingCustomAttributeResponse> RetrieveBookingCustomAttributeAsync(
                string bookingId,
                string key,
                bool? withDefinition = false,
                int? version = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Upserts a bookings custom attribute.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the target [booking](entity:Booking)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to create or update. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpsertBookingCustomAttributeResponse response from the API call.</returns>
        Models.UpsertBookingCustomAttributeResponse UpsertBookingCustomAttribute(
                string bookingId,
                string key,
                Models.UpsertBookingCustomAttributeRequest body);

        /// <summary>
        /// Upserts a bookings custom attribute.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the target [booking](entity:Booking)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to create or update. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpsertBookingCustomAttributeResponse response from the API call.</returns>
        Task<Models.UpsertBookingCustomAttributeResponse> UpsertBookingCustomAttributeAsync(
                string bookingId,
                string key,
                Models.UpsertBookingCustomAttributeRequest body,
                CancellationToken cancellationToken = default);
    }
}