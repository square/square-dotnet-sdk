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
    /// MerchantCustomAttributesApi.
    /// </summary>
    internal class MerchantCustomAttributesApi : BaseApi, IMerchantCustomAttributesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MerchantCustomAttributesApi"/> class.
        /// </summary>
        internal MerchantCustomAttributesApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Lists the merchant-related [custom attribute definitions]($m/CustomAttributeDefinition) that belong to a Square seller account.
        /// When all response pages are retrieved, the results include all custom attribute definitions.
        /// that are visible to the requesting application, including those that are created by other.
        /// applications and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="visibilityFilter">Optional parameter: Filters the `CustomAttributeDefinition` results by their `visibility` values..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory. The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100. The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <returns>Returns the Models.ListMerchantCustomAttributeDefinitionsResponse response from the API call.</returns>
        public Models.ListMerchantCustomAttributeDefinitionsResponse ListMerchantCustomAttributeDefinitions(
                string visibilityFilter = null,
                int? limit = null,
                string cursor = null)
            => CoreHelper.RunTask(ListMerchantCustomAttributeDefinitionsAsync(visibilityFilter, limit, cursor));

        /// <summary>
        /// Lists the merchant-related [custom attribute definitions]($m/CustomAttributeDefinition) that belong to a Square seller account.
        /// When all response pages are retrieved, the results include all custom attribute definitions.
        /// that are visible to the requesting application, including those that are created by other.
        /// applications and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="visibilityFilter">Optional parameter: Filters the `CustomAttributeDefinition` results by their `visibility` values..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory. The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100. The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListMerchantCustomAttributeDefinitionsResponse response from the API call.</returns>
        public async Task<Models.ListMerchantCustomAttributeDefinitionsResponse> ListMerchantCustomAttributeDefinitionsAsync(
                string visibilityFilter = null,
                int? limit = null,
                string cursor = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListMerchantCustomAttributeDefinitionsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/merchants/custom-attribute-definitions")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("visibility_filter", visibilityFilter))
                      .Query(_query => _query.Setup("limit", limit))
                      .Query(_query => _query.Setup("cursor", cursor))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Creates a merchant-related [custom attribute definition]($m/CustomAttributeDefinition) for a Square seller account.
        /// Use this endpoint to define a custom attribute that can be associated with a merchant connecting to your application.
        /// A custom attribute definition specifies the `key`, `visibility`, `schema`, and other properties.
        /// for a custom attribute. After the definition is created, you can call.
        /// [UpsertMerchantCustomAttribute]($e/MerchantCustomAttributes/UpsertMerchantCustomAttribute) or.
        /// [BulkUpsertMerchantCustomAttributes]($e/MerchantCustomAttributes/BulkUpsertMerchantCustomAttributes).
        /// to set the custom attribute for a merchant.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateMerchantCustomAttributeDefinitionResponse response from the API call.</returns>
        public Models.CreateMerchantCustomAttributeDefinitionResponse CreateMerchantCustomAttributeDefinition(
                Models.CreateMerchantCustomAttributeDefinitionRequest body)
            => CoreHelper.RunTask(CreateMerchantCustomAttributeDefinitionAsync(body));

        /// <summary>
        /// Creates a merchant-related [custom attribute definition]($m/CustomAttributeDefinition) for a Square seller account.
        /// Use this endpoint to define a custom attribute that can be associated with a merchant connecting to your application.
        /// A custom attribute definition specifies the `key`, `visibility`, `schema`, and other properties.
        /// for a custom attribute. After the definition is created, you can call.
        /// [UpsertMerchantCustomAttribute]($e/MerchantCustomAttributes/UpsertMerchantCustomAttribute) or.
        /// [BulkUpsertMerchantCustomAttributes]($e/MerchantCustomAttributes/BulkUpsertMerchantCustomAttributes).
        /// to set the custom attribute for a merchant.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateMerchantCustomAttributeDefinitionResponse response from the API call.</returns>
        public async Task<Models.CreateMerchantCustomAttributeDefinitionResponse> CreateMerchantCustomAttributeDefinitionAsync(
                Models.CreateMerchantCustomAttributeDefinitionRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CreateMerchantCustomAttributeDefinitionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/merchants/custom-attribute-definitions")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Deletes a merchant-related [custom attribute definition]($m/CustomAttributeDefinition) from a Square seller account.
        /// Deleting a custom attribute definition also deletes the corresponding custom attribute from.
        /// the merchant.
        /// Only the definition owner can delete a custom attribute definition.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to delete..</param>
        /// <returns>Returns the Models.DeleteMerchantCustomAttributeDefinitionResponse response from the API call.</returns>
        public Models.DeleteMerchantCustomAttributeDefinitionResponse DeleteMerchantCustomAttributeDefinition(
                string key)
            => CoreHelper.RunTask(DeleteMerchantCustomAttributeDefinitionAsync(key));

        /// <summary>
        /// Deletes a merchant-related [custom attribute definition]($m/CustomAttributeDefinition) from a Square seller account.
        /// Deleting a custom attribute definition also deletes the corresponding custom attribute from.
        /// the merchant.
        /// Only the definition owner can delete a custom attribute definition.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to delete..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteMerchantCustomAttributeDefinitionResponse response from the API call.</returns>
        public async Task<Models.DeleteMerchantCustomAttributeDefinitionResponse> DeleteMerchantCustomAttributeDefinitionAsync(
                string key,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.DeleteMerchantCustomAttributeDefinitionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/v2/merchants/custom-attribute-definitions/{key}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("key", key))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Retrieves a merchant-related [custom attribute definition]($m/CustomAttributeDefinition) from a Square seller account.
        /// To retrieve a custom attribute definition created by another application, the `visibility`.
        /// setting must be `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to retrieve. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="version">Optional parameter: The current version of the custom attribute definition, which is used for strongly consistent reads to guarantee that you receive the most up-to-date data. When included in the request, Square returns the specified version or a higher version if one exists. If the specified version is higher than the current version, Square returns a `BAD_REQUEST` error..</param>
        /// <returns>Returns the Models.RetrieveMerchantCustomAttributeDefinitionResponse response from the API call.</returns>
        public Models.RetrieveMerchantCustomAttributeDefinitionResponse RetrieveMerchantCustomAttributeDefinition(
                string key,
                int? version = null)
            => CoreHelper.RunTask(RetrieveMerchantCustomAttributeDefinitionAsync(key, version));

        /// <summary>
        /// Retrieves a merchant-related [custom attribute definition]($m/CustomAttributeDefinition) from a Square seller account.
        /// To retrieve a custom attribute definition created by another application, the `visibility`.
        /// setting must be `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to retrieve. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="version">Optional parameter: The current version of the custom attribute definition, which is used for strongly consistent reads to guarantee that you receive the most up-to-date data. When included in the request, Square returns the specified version or a higher version if one exists. If the specified version is higher than the current version, Square returns a `BAD_REQUEST` error..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveMerchantCustomAttributeDefinitionResponse response from the API call.</returns>
        public async Task<Models.RetrieveMerchantCustomAttributeDefinitionResponse> RetrieveMerchantCustomAttributeDefinitionAsync(
                string key,
                int? version = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveMerchantCustomAttributeDefinitionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/merchants/custom-attribute-definitions/{key}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("key", key))
                      .Query(_query => _query.Setup("version", version))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Updates a merchant-related [custom attribute definition]($m/CustomAttributeDefinition) for a Square seller account.
        /// Use this endpoint to update the following fields: `name`, `description`, `visibility`, or the.
        /// `schema` for a `Selection` data type.
        /// Only the definition owner can update a custom attribute definition.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateMerchantCustomAttributeDefinitionResponse response from the API call.</returns>
        public Models.UpdateMerchantCustomAttributeDefinitionResponse UpdateMerchantCustomAttributeDefinition(
                string key,
                Models.UpdateMerchantCustomAttributeDefinitionRequest body)
            => CoreHelper.RunTask(UpdateMerchantCustomAttributeDefinitionAsync(key, body));

        /// <summary>
        /// Updates a merchant-related [custom attribute definition]($m/CustomAttributeDefinition) for a Square seller account.
        /// Use this endpoint to update the following fields: `name`, `description`, `visibility`, or the.
        /// `schema` for a `Selection` data type.
        /// Only the definition owner can update a custom attribute definition.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateMerchantCustomAttributeDefinitionResponse response from the API call.</returns>
        public async Task<Models.UpdateMerchantCustomAttributeDefinitionResponse> UpdateMerchantCustomAttributeDefinitionAsync(
                string key,
                Models.UpdateMerchantCustomAttributeDefinitionRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.UpdateMerchantCustomAttributeDefinitionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/v2/merchants/custom-attribute-definitions/{key}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("key", key))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Deletes [custom attributes]($m/CustomAttribute) for a merchant as a bulk operation.
        /// To delete a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkDeleteMerchantCustomAttributesResponse response from the API call.</returns>
        public Models.BulkDeleteMerchantCustomAttributesResponse BulkDeleteMerchantCustomAttributes(
                Models.BulkDeleteMerchantCustomAttributesRequest body)
            => CoreHelper.RunTask(BulkDeleteMerchantCustomAttributesAsync(body));

        /// <summary>
        /// Deletes [custom attributes]($m/CustomAttribute) for a merchant as a bulk operation.
        /// To delete a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkDeleteMerchantCustomAttributesResponse response from the API call.</returns>
        public async Task<Models.BulkDeleteMerchantCustomAttributesResponse> BulkDeleteMerchantCustomAttributesAsync(
                Models.BulkDeleteMerchantCustomAttributesRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.BulkDeleteMerchantCustomAttributesResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/merchants/custom-attributes/bulk-delete")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Creates or updates [custom attributes]($m/CustomAttribute) for a merchant as a bulk operation.
        /// Use this endpoint to set the value of one or more custom attributes for a merchant.
        /// A custom attribute is based on a custom attribute definition in a Square seller account, which is.
        /// created using the [CreateMerchantCustomAttributeDefinition]($e/MerchantCustomAttributes/CreateMerchantCustomAttributeDefinition) endpoint.
        /// This `BulkUpsertMerchantCustomAttributes` endpoint accepts a map of 1 to 25 individual upsert.
        /// requests and returns a map of individual upsert responses. Each upsert request has a unique ID.
        /// and provides a merchant ID and custom attribute. Each upsert response is returned with the ID.
        /// of the corresponding request.
        /// To create or update a custom attribute owned by another application, the `visibility` setting.
        /// must be `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkUpsertMerchantCustomAttributesResponse response from the API call.</returns>
        public Models.BulkUpsertMerchantCustomAttributesResponse BulkUpsertMerchantCustomAttributes(
                Models.BulkUpsertMerchantCustomAttributesRequest body)
            => CoreHelper.RunTask(BulkUpsertMerchantCustomAttributesAsync(body));

        /// <summary>
        /// Creates or updates [custom attributes]($m/CustomAttribute) for a merchant as a bulk operation.
        /// Use this endpoint to set the value of one or more custom attributes for a merchant.
        /// A custom attribute is based on a custom attribute definition in a Square seller account, which is.
        /// created using the [CreateMerchantCustomAttributeDefinition]($e/MerchantCustomAttributes/CreateMerchantCustomAttributeDefinition) endpoint.
        /// This `BulkUpsertMerchantCustomAttributes` endpoint accepts a map of 1 to 25 individual upsert.
        /// requests and returns a map of individual upsert responses. Each upsert request has a unique ID.
        /// and provides a merchant ID and custom attribute. Each upsert response is returned with the ID.
        /// of the corresponding request.
        /// To create or update a custom attribute owned by another application, the `visibility` setting.
        /// must be `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkUpsertMerchantCustomAttributesResponse response from the API call.</returns>
        public async Task<Models.BulkUpsertMerchantCustomAttributesResponse> BulkUpsertMerchantCustomAttributesAsync(
                Models.BulkUpsertMerchantCustomAttributesRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.BulkUpsertMerchantCustomAttributesResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/merchants/custom-attributes/bulk-upsert")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Lists the [custom attributes]($m/CustomAttribute) associated with a merchant.
        /// You can use the `with_definitions` query parameter to also retrieve custom attribute definitions.
        /// in the same call.
        /// When all response pages are retrieved, the results include all custom attributes that are.
        /// visible to the requesting application, including those that are owned by other applications.
        /// and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="merchantId">Required parameter: The ID of the target [merchant](entity:Merchant)..</param>
        /// <param name="visibilityFilter">Optional parameter: Filters the `CustomAttributeDefinition` results by their `visibility` values..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory. The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100. The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="withDefinitions">Optional parameter: Indicates whether to return the [custom attribute definition](entity:CustomAttributeDefinition) in the `definition` field of each custom attribute. Set this parameter to `true` to get the name and description of each custom attribute, information about the data type, or other definition details. The default value is `false`..</param>
        /// <returns>Returns the Models.ListMerchantCustomAttributesResponse response from the API call.</returns>
        public Models.ListMerchantCustomAttributesResponse ListMerchantCustomAttributes(
                string merchantId,
                string visibilityFilter = null,
                int? limit = null,
                string cursor = null,
                bool? withDefinitions = false)
            => CoreHelper.RunTask(ListMerchantCustomAttributesAsync(merchantId, visibilityFilter, limit, cursor, withDefinitions));

        /// <summary>
        /// Lists the [custom attributes]($m/CustomAttribute) associated with a merchant.
        /// You can use the `with_definitions` query parameter to also retrieve custom attribute definitions.
        /// in the same call.
        /// When all response pages are retrieved, the results include all custom attributes that are.
        /// visible to the requesting application, including those that are owned by other applications.
        /// and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="merchantId">Required parameter: The ID of the target [merchant](entity:Merchant)..</param>
        /// <param name="visibilityFilter">Optional parameter: Filters the `CustomAttributeDefinition` results by their `visibility` values..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory. The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100. The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="withDefinitions">Optional parameter: Indicates whether to return the [custom attribute definition](entity:CustomAttributeDefinition) in the `definition` field of each custom attribute. Set this parameter to `true` to get the name and description of each custom attribute, information about the data type, or other definition details. The default value is `false`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListMerchantCustomAttributesResponse response from the API call.</returns>
        public async Task<Models.ListMerchantCustomAttributesResponse> ListMerchantCustomAttributesAsync(
                string merchantId,
                string visibilityFilter = null,
                int? limit = null,
                string cursor = null,
                bool? withDefinitions = false,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListMerchantCustomAttributesResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/merchants/{merchant_id}/custom-attributes")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("merchant_id", merchantId))
                      .Query(_query => _query.Setup("visibility_filter", visibilityFilter))
                      .Query(_query => _query.Setup("limit", limit))
                      .Query(_query => _query.Setup("cursor", cursor))
                      .Query(_query => _query.Setup("with_definitions", (withDefinitions != null) ? withDefinitions : false))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Deletes a [custom attribute]($m/CustomAttribute) associated with a merchant.
        /// To delete a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="merchantId">Required parameter: The ID of the target [merchant](entity:Merchant)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to delete. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <returns>Returns the Models.DeleteMerchantCustomAttributeResponse response from the API call.</returns>
        public Models.DeleteMerchantCustomAttributeResponse DeleteMerchantCustomAttribute(
                string merchantId,
                string key)
            => CoreHelper.RunTask(DeleteMerchantCustomAttributeAsync(merchantId, key));

        /// <summary>
        /// Deletes a [custom attribute]($m/CustomAttribute) associated with a merchant.
        /// To delete a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="merchantId">Required parameter: The ID of the target [merchant](entity:Merchant)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to delete. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteMerchantCustomAttributeResponse response from the API call.</returns>
        public async Task<Models.DeleteMerchantCustomAttributeResponse> DeleteMerchantCustomAttributeAsync(
                string merchantId,
                string key,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.DeleteMerchantCustomAttributeResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/v2/merchants/{merchant_id}/custom-attributes/{key}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("merchant_id", merchantId))
                      .Template(_template => _template.Setup("key", key))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Retrieves a [custom attribute]($m/CustomAttribute) associated with a merchant.
        /// You can use the `with_definition` query parameter to also retrieve the custom attribute definition.
        /// in the same call.
        /// To retrieve a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="merchantId">Required parameter: The ID of the target [merchant](entity:Merchant)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to retrieve. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="withDefinition">Optional parameter: Indicates whether to return the [custom attribute definition](entity:CustomAttributeDefinition) in the `definition` field of the custom attribute. Set this parameter to `true` to get the name and description of the custom attribute, information about the data type, or other definition details. The default value is `false`..</param>
        /// <param name="version">Optional parameter: The current version of the custom attribute, which is used for strongly consistent reads to guarantee that you receive the most up-to-date data. When included in the request, Square returns the specified version or a higher version if one exists. If the specified version is higher than the current version, Square returns a `BAD_REQUEST` error..</param>
        /// <returns>Returns the Models.RetrieveMerchantCustomAttributeResponse response from the API call.</returns>
        public Models.RetrieveMerchantCustomAttributeResponse RetrieveMerchantCustomAttribute(
                string merchantId,
                string key,
                bool? withDefinition = false,
                int? version = null)
            => CoreHelper.RunTask(RetrieveMerchantCustomAttributeAsync(merchantId, key, withDefinition, version));

        /// <summary>
        /// Retrieves a [custom attribute]($m/CustomAttribute) associated with a merchant.
        /// You can use the `with_definition` query parameter to also retrieve the custom attribute definition.
        /// in the same call.
        /// To retrieve a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="merchantId">Required parameter: The ID of the target [merchant](entity:Merchant)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to retrieve. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="withDefinition">Optional parameter: Indicates whether to return the [custom attribute definition](entity:CustomAttributeDefinition) in the `definition` field of the custom attribute. Set this parameter to `true` to get the name and description of the custom attribute, information about the data type, or other definition details. The default value is `false`..</param>
        /// <param name="version">Optional parameter: The current version of the custom attribute, which is used for strongly consistent reads to guarantee that you receive the most up-to-date data. When included in the request, Square returns the specified version or a higher version if one exists. If the specified version is higher than the current version, Square returns a `BAD_REQUEST` error..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveMerchantCustomAttributeResponse response from the API call.</returns>
        public async Task<Models.RetrieveMerchantCustomAttributeResponse> RetrieveMerchantCustomAttributeAsync(
                string merchantId,
                string key,
                bool? withDefinition = false,
                int? version = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveMerchantCustomAttributeResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/merchants/{merchant_id}/custom-attributes/{key}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("merchant_id", merchantId))
                      .Template(_template => _template.Setup("key", key))
                      .Query(_query => _query.Setup("with_definition", (withDefinition != null) ? withDefinition : false))
                      .Query(_query => _query.Setup("version", version))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Creates or updates a [custom attribute]($m/CustomAttribute) for a merchant.
        /// Use this endpoint to set the value of a custom attribute for a specified merchant.
        /// A custom attribute is based on a custom attribute definition in a Square seller account, which.
        /// is created using the [CreateMerchantCustomAttributeDefinition]($e/MerchantCustomAttributes/CreateMerchantCustomAttributeDefinition) endpoint.
        /// To create or update a custom attribute owned by another application, the `visibility` setting.
        /// must be `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="merchantId">Required parameter: The ID of the target [merchant](entity:Merchant)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to create or update. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpsertMerchantCustomAttributeResponse response from the API call.</returns>
        public Models.UpsertMerchantCustomAttributeResponse UpsertMerchantCustomAttribute(
                string merchantId,
                string key,
                Models.UpsertMerchantCustomAttributeRequest body)
            => CoreHelper.RunTask(UpsertMerchantCustomAttributeAsync(merchantId, key, body));

        /// <summary>
        /// Creates or updates a [custom attribute]($m/CustomAttribute) for a merchant.
        /// Use this endpoint to set the value of a custom attribute for a specified merchant.
        /// A custom attribute is based on a custom attribute definition in a Square seller account, which.
        /// is created using the [CreateMerchantCustomAttributeDefinition]($e/MerchantCustomAttributes/CreateMerchantCustomAttributeDefinition) endpoint.
        /// To create or update a custom attribute owned by another application, the `visibility` setting.
        /// must be `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="merchantId">Required parameter: The ID of the target [merchant](entity:Merchant)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to create or update. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpsertMerchantCustomAttributeResponse response from the API call.</returns>
        public async Task<Models.UpsertMerchantCustomAttributeResponse> UpsertMerchantCustomAttributeAsync(
                string merchantId,
                string key,
                Models.UpsertMerchantCustomAttributeRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.UpsertMerchantCustomAttributeResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/merchants/{merchant_id}/custom-attributes/{key}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("merchant_id", merchantId))
                      .Template(_template => _template.Setup("key", key))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);
    }
}