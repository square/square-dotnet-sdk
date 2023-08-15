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
    /// BookingCustomAttributesApi.
    /// </summary>
    internal class BookingCustomAttributesApi : BaseApi, IBookingCustomAttributesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookingCustomAttributesApi"/> class.
        /// </summary>
        internal BookingCustomAttributesApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Get all bookings custom attribute definitions.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory. The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100. The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <returns>Returns the Models.ListBookingCustomAttributeDefinitionsResponse response from the API call.</returns>
        public Models.ListBookingCustomAttributeDefinitionsResponse ListBookingCustomAttributeDefinitions(
                int? limit = null,
                string cursor = null)
            => CoreHelper.RunTask(ListBookingCustomAttributeDefinitionsAsync(limit, cursor));

        /// <summary>
        /// Get all bookings custom attribute definitions.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory. The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100. The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListBookingCustomAttributeDefinitionsResponse response from the API call.</returns>
        public async Task<Models.ListBookingCustomAttributeDefinitionsResponse> ListBookingCustomAttributeDefinitionsAsync(
                int? limit = null,
                string cursor = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListBookingCustomAttributeDefinitionsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/bookings/custom-attribute-definitions")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("limit", limit))
                      .Query(_query => _query.Setup("cursor", cursor))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Creates a bookings custom attribute definition.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateBookingCustomAttributeDefinitionResponse response from the API call.</returns>
        public Models.CreateBookingCustomAttributeDefinitionResponse CreateBookingCustomAttributeDefinition(
                Models.CreateBookingCustomAttributeDefinitionRequest body)
            => CoreHelper.RunTask(CreateBookingCustomAttributeDefinitionAsync(body));

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
        public async Task<Models.CreateBookingCustomAttributeDefinitionResponse> CreateBookingCustomAttributeDefinitionAsync(
                Models.CreateBookingCustomAttributeDefinitionRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CreateBookingCustomAttributeDefinitionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/bookings/custom-attribute-definitions")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Deletes a bookings custom attribute definition.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to delete..</param>
        /// <returns>Returns the Models.DeleteBookingCustomAttributeDefinitionResponse response from the API call.</returns>
        public Models.DeleteBookingCustomAttributeDefinitionResponse DeleteBookingCustomAttributeDefinition(
                string key)
            => CoreHelper.RunTask(DeleteBookingCustomAttributeDefinitionAsync(key));

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
        public async Task<Models.DeleteBookingCustomAttributeDefinitionResponse> DeleteBookingCustomAttributeDefinitionAsync(
                string key,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.DeleteBookingCustomAttributeDefinitionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/v2/bookings/custom-attribute-definitions/{key}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("key", key))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Retrieves a bookings custom attribute definition.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to retrieve. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="version">Optional parameter: The current version of the custom attribute definition, which is used for strongly consistent reads to guarantee that you receive the most up-to-date data. When included in the request, Square returns the specified version or a higher version if one exists. If the specified version is higher than the current version, Square returns a `BAD_REQUEST` error..</param>
        /// <returns>Returns the Models.RetrieveBookingCustomAttributeDefinitionResponse response from the API call.</returns>
        public Models.RetrieveBookingCustomAttributeDefinitionResponse RetrieveBookingCustomAttributeDefinition(
                string key,
                int? version = null)
            => CoreHelper.RunTask(RetrieveBookingCustomAttributeDefinitionAsync(key, version));

        /// <summary>
        /// Retrieves a bookings custom attribute definition.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to retrieve. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="version">Optional parameter: The current version of the custom attribute definition, which is used for strongly consistent reads to guarantee that you receive the most up-to-date data. When included in the request, Square returns the specified version or a higher version if one exists. If the specified version is higher than the current version, Square returns a `BAD_REQUEST` error..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveBookingCustomAttributeDefinitionResponse response from the API call.</returns>
        public async Task<Models.RetrieveBookingCustomAttributeDefinitionResponse> RetrieveBookingCustomAttributeDefinitionAsync(
                string key,
                int? version = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveBookingCustomAttributeDefinitionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/bookings/custom-attribute-definitions/{key}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("key", key))
                      .Query(_query => _query.Setup("version", version))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

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
        public Models.UpdateBookingCustomAttributeDefinitionResponse UpdateBookingCustomAttributeDefinition(
                string key,
                Models.UpdateBookingCustomAttributeDefinitionRequest body)
            => CoreHelper.RunTask(UpdateBookingCustomAttributeDefinitionAsync(key, body));

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
        public async Task<Models.UpdateBookingCustomAttributeDefinitionResponse> UpdateBookingCustomAttributeDefinitionAsync(
                string key,
                Models.UpdateBookingCustomAttributeDefinitionRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.UpdateBookingCustomAttributeDefinitionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/v2/bookings/custom-attribute-definitions/{key}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("key", key))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Bulk deletes bookings custom attributes.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkDeleteBookingCustomAttributesResponse response from the API call.</returns>
        public Models.BulkDeleteBookingCustomAttributesResponse BulkDeleteBookingCustomAttributes(
                Models.BulkDeleteBookingCustomAttributesRequest body)
            => CoreHelper.RunTask(BulkDeleteBookingCustomAttributesAsync(body));

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
        public async Task<Models.BulkDeleteBookingCustomAttributesResponse> BulkDeleteBookingCustomAttributesAsync(
                Models.BulkDeleteBookingCustomAttributesRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.BulkDeleteBookingCustomAttributesResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/bookings/custom-attributes/bulk-delete")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Bulk upserts bookings custom attributes.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkUpsertBookingCustomAttributesResponse response from the API call.</returns>
        public Models.BulkUpsertBookingCustomAttributesResponse BulkUpsertBookingCustomAttributes(
                Models.BulkUpsertBookingCustomAttributesRequest body)
            => CoreHelper.RunTask(BulkUpsertBookingCustomAttributesAsync(body));

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
        public async Task<Models.BulkUpsertBookingCustomAttributesResponse> BulkUpsertBookingCustomAttributesAsync(
                Models.BulkUpsertBookingCustomAttributesRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.BulkUpsertBookingCustomAttributesResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/bookings/custom-attributes/bulk-upsert")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

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
        public Models.ListBookingCustomAttributesResponse ListBookingCustomAttributes(
                string bookingId,
                int? limit = null,
                string cursor = null,
                bool? withDefinitions = false)
            => CoreHelper.RunTask(ListBookingCustomAttributesAsync(bookingId, limit, cursor, withDefinitions));

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
        public async Task<Models.ListBookingCustomAttributesResponse> ListBookingCustomAttributesAsync(
                string bookingId,
                int? limit = null,
                string cursor = null,
                bool? withDefinitions = false,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListBookingCustomAttributesResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/bookings/{booking_id}/custom-attributes")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("booking_id", bookingId))
                      .Query(_query => _query.Setup("limit", limit))
                      .Query(_query => _query.Setup("cursor", cursor))
                      .Query(_query => _query.Setup("with_definitions", (withDefinitions != null) ? withDefinitions : false))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

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
        public Models.DeleteBookingCustomAttributeResponse DeleteBookingCustomAttribute(
                string bookingId,
                string key)
            => CoreHelper.RunTask(DeleteBookingCustomAttributeAsync(bookingId, key));

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
        public async Task<Models.DeleteBookingCustomAttributeResponse> DeleteBookingCustomAttributeAsync(
                string bookingId,
                string key,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.DeleteBookingCustomAttributeResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/v2/bookings/{booking_id}/custom-attributes/{key}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("booking_id", bookingId))
                      .Template(_template => _template.Setup("key", key))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

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
        public Models.RetrieveBookingCustomAttributeResponse RetrieveBookingCustomAttribute(
                string bookingId,
                string key,
                bool? withDefinition = false,
                int? version = null)
            => CoreHelper.RunTask(RetrieveBookingCustomAttributeAsync(bookingId, key, withDefinition, version));

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
        public async Task<Models.RetrieveBookingCustomAttributeResponse> RetrieveBookingCustomAttributeAsync(
                string bookingId,
                string key,
                bool? withDefinition = false,
                int? version = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveBookingCustomAttributeResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/bookings/{booking_id}/custom-attributes/{key}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("booking_id", bookingId))
                      .Template(_template => _template.Setup("key", key))
                      .Query(_query => _query.Setup("with_definition", (withDefinition != null) ? withDefinition : false))
                      .Query(_query => _query.Setup("version", version))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

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
        public Models.UpsertBookingCustomAttributeResponse UpsertBookingCustomAttribute(
                string bookingId,
                string key,
                Models.UpsertBookingCustomAttributeRequest body)
            => CoreHelper.RunTask(UpsertBookingCustomAttributeAsync(bookingId, key, body));

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
        public async Task<Models.UpsertBookingCustomAttributeResponse> UpsertBookingCustomAttributeAsync(
                string bookingId,
                string key,
                Models.UpsertBookingCustomAttributeRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.UpsertBookingCustomAttributeResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/v2/bookings/{booking_id}/custom-attributes/{key}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("booking_id", bookingId))
                      .Template(_template => _template.Setup("key", key))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);
    }
}