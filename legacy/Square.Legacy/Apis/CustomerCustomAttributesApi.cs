using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using APIMatic.Core;
using APIMatic.Core.Types;
using APIMatic.Core.Utilities;
using APIMatic.Core.Utilities.Date.Xml;
using Newtonsoft.Json.Converters;
using Square.Legacy;
using Square.Legacy.Http.Client;
using Square.Legacy.Utilities;

namespace Square.Legacy.Apis
{
    /// <summary>
    /// CustomerCustomAttributesApi.
    /// </summary>
    internal class CustomerCustomAttributesApi : BaseApi, ICustomerCustomAttributesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCustomAttributesApi"/> class.
        /// </summary>
        internal CustomerCustomAttributesApi(GlobalConfiguration globalConfiguration)
            : base(globalConfiguration) { }

        /// <summary>
        /// Lists the customer-related [custom attribute definitions]($m/CustomAttributeDefinition) that belong to a Square seller account.
        /// When all response pages are retrieved, the results include all custom attribute definitions.
        /// that are visible to the requesting application, including those that are created by other.
        /// applications and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that.
        /// seller-defined custom attributes (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory. The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100. The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <returns>Returns the Models.ListCustomerCustomAttributeDefinitionsResponse response from the API call.</returns>
        public Models.ListCustomerCustomAttributeDefinitionsResponse ListCustomerCustomAttributeDefinitions(
            int? limit = null,
            string cursor = null
        ) => CoreHelper.RunTask(ListCustomerCustomAttributeDefinitionsAsync(limit, cursor));

        /// <summary>
        /// Lists the customer-related [custom attribute definitions]($m/CustomAttributeDefinition) that belong to a Square seller account.
        /// When all response pages are retrieved, the results include all custom attribute definitions.
        /// that are visible to the requesting application, including those that are created by other.
        /// applications and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that.
        /// seller-defined custom attributes (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory. The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100. The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListCustomerCustomAttributeDefinitionsResponse response from the API call.</returns>
        public async Task<Models.ListCustomerCustomAttributeDefinitionsResponse> ListCustomerCustomAttributeDefinitionsAsync(
            int? limit = null,
            string cursor = null,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.ListCustomerCustomAttributeDefinitionsResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Get, "/v2/customers/custom-attribute-definitions")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Query(_query => _query.Setup("limit", limit))
                                .Query(_query => _query.Setup("cursor", cursor))
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Creates a customer-related [custom attribute definition]($m/CustomAttributeDefinition) for a Square seller account.
        /// Use this endpoint to define a custom attribute that can be associated with customer profiles.
        /// A custom attribute definition specifies the `key`, `visibility`, `schema`, and other properties.
        /// for a custom attribute. After the definition is created, you can call.
        /// [UpsertCustomerCustomAttribute]($e/CustomerCustomAttributes/UpsertCustomerCustomAttribute) or.
        /// [BulkUpsertCustomerCustomAttributes]($e/CustomerCustomAttributes/BulkUpsertCustomerCustomAttributes).
        /// to set the custom attribute for customer profiles in the seller's Customer Directory.
        /// Sellers can view all custom attributes in exported customer data, including those set to.
        /// `VISIBILITY_HIDDEN`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateCustomerCustomAttributeDefinitionResponse response from the API call.</returns>
        public Models.CreateCustomerCustomAttributeDefinitionResponse CreateCustomerCustomAttributeDefinition(
            Models.CreateCustomerCustomAttributeDefinitionRequest body
        ) => CoreHelper.RunTask(CreateCustomerCustomAttributeDefinitionAsync(body));

        /// <summary>
        /// Creates a customer-related [custom attribute definition]($m/CustomAttributeDefinition) for a Square seller account.
        /// Use this endpoint to define a custom attribute that can be associated with customer profiles.
        /// A custom attribute definition specifies the `key`, `visibility`, `schema`, and other properties.
        /// for a custom attribute. After the definition is created, you can call.
        /// [UpsertCustomerCustomAttribute]($e/CustomerCustomAttributes/UpsertCustomerCustomAttribute) or.
        /// [BulkUpsertCustomerCustomAttributes]($e/CustomerCustomAttributes/BulkUpsertCustomerCustomAttributes).
        /// to set the custom attribute for customer profiles in the seller's Customer Directory.
        /// Sellers can view all custom attributes in exported customer data, including those set to.
        /// `VISIBILITY_HIDDEN`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateCustomerCustomAttributeDefinitionResponse response from the API call.</returns>
        public async Task<Models.CreateCustomerCustomAttributeDefinitionResponse> CreateCustomerCustomAttributeDefinitionAsync(
            Models.CreateCustomerCustomAttributeDefinitionRequest body,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.CreateCustomerCustomAttributeDefinitionResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Post, "/v2/customers/custom-attribute-definitions")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Body(_bodyParameter => _bodyParameter.Setup(body))
                                .Header(_header =>
                                    _header.Setup("Content-Type", "application/json")
                                )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Deletes a customer-related [custom attribute definition]($m/CustomAttributeDefinition) from a Square seller account.
        /// Deleting a custom attribute definition also deletes the corresponding custom attribute from.
        /// all customer profiles in the seller's Customer Directory.
        /// Only the definition owner can delete a custom attribute definition.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to delete..</param>
        /// <returns>Returns the Models.DeleteCustomerCustomAttributeDefinitionResponse response from the API call.</returns>
        public Models.DeleteCustomerCustomAttributeDefinitionResponse DeleteCustomerCustomAttributeDefinition(
            string key
        ) => CoreHelper.RunTask(DeleteCustomerCustomAttributeDefinitionAsync(key));

        /// <summary>
        /// Deletes a customer-related [custom attribute definition]($m/CustomAttributeDefinition) from a Square seller account.
        /// Deleting a custom attribute definition also deletes the corresponding custom attribute from.
        /// all customer profiles in the seller's Customer Directory.
        /// Only the definition owner can delete a custom attribute definition.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to delete..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteCustomerCustomAttributeDefinitionResponse response from the API call.</returns>
        public async Task<Models.DeleteCustomerCustomAttributeDefinitionResponse> DeleteCustomerCustomAttributeDefinitionAsync(
            string key,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.DeleteCustomerCustomAttributeDefinitionResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(
                            HttpMethod.Delete,
                            "/v2/customers/custom-attribute-definitions/{key}"
                        )
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters.Template(_template => _template.Setup("key", key))
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Retrieves a customer-related [custom attribute definition]($m/CustomAttributeDefinition) from a Square seller account.
        /// To retrieve a custom attribute definition created by another application, the `visibility`.
        /// setting must be `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to retrieve. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="version">Optional parameter: The current version of the custom attribute definition, which is used for strongly consistent reads to guarantee that you receive the most up-to-date data. When included in the request, Square returns the specified version or a higher version if one exists. If the specified version is higher than the current version, Square returns a `BAD_REQUEST` error..</param>
        /// <returns>Returns the Models.RetrieveCustomerCustomAttributeDefinitionResponse response from the API call.</returns>
        public Models.RetrieveCustomerCustomAttributeDefinitionResponse RetrieveCustomerCustomAttributeDefinition(
            string key,
            int? version = null
        ) => CoreHelper.RunTask(RetrieveCustomerCustomAttributeDefinitionAsync(key, version));

        /// <summary>
        /// Retrieves a customer-related [custom attribute definition]($m/CustomAttributeDefinition) from a Square seller account.
        /// To retrieve a custom attribute definition created by another application, the `visibility`.
        /// setting must be `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to retrieve. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="version">Optional parameter: The current version of the custom attribute definition, which is used for strongly consistent reads to guarantee that you receive the most up-to-date data. When included in the request, Square returns the specified version or a higher version if one exists. If the specified version is higher than the current version, Square returns a `BAD_REQUEST` error..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveCustomerCustomAttributeDefinitionResponse response from the API call.</returns>
        public async Task<Models.RetrieveCustomerCustomAttributeDefinitionResponse> RetrieveCustomerCustomAttributeDefinitionAsync(
            string key,
            int? version = null,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.RetrieveCustomerCustomAttributeDefinitionResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Get, "/v2/customers/custom-attribute-definitions/{key}")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Template(_template => _template.Setup("key", key))
                                .Query(_query => _query.Setup("version", version))
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Updates a customer-related [custom attribute definition]($m/CustomAttributeDefinition) for a Square seller account.
        /// Use this endpoint to update the following fields: `name`, `description`, `visibility`, or the.
        /// `schema` for a `Selection` data type.
        /// Only the definition owner can update a custom attribute definition. Note that sellers can view.
        /// all custom attributes in exported customer data, including those set to `VISIBILITY_HIDDEN`.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateCustomerCustomAttributeDefinitionResponse response from the API call.</returns>
        public Models.UpdateCustomerCustomAttributeDefinitionResponse UpdateCustomerCustomAttributeDefinition(
            string key,
            Models.UpdateCustomerCustomAttributeDefinitionRequest body
        ) => CoreHelper.RunTask(UpdateCustomerCustomAttributeDefinitionAsync(key, body));

        /// <summary>
        /// Updates a customer-related [custom attribute definition]($m/CustomAttributeDefinition) for a Square seller account.
        /// Use this endpoint to update the following fields: `name`, `description`, `visibility`, or the.
        /// `schema` for a `Selection` data type.
        /// Only the definition owner can update a custom attribute definition. Note that sellers can view.
        /// all custom attributes in exported customer data, including those set to `VISIBILITY_HIDDEN`.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateCustomerCustomAttributeDefinitionResponse response from the API call.</returns>
        public async Task<Models.UpdateCustomerCustomAttributeDefinitionResponse> UpdateCustomerCustomAttributeDefinitionAsync(
            string key,
            Models.UpdateCustomerCustomAttributeDefinitionRequest body,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.UpdateCustomerCustomAttributeDefinitionResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Put, "/v2/customers/custom-attribute-definitions/{key}")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Body(_bodyParameter => _bodyParameter.Setup(body))
                                .Template(_template => _template.Setup("key", key))
                                .Header(_header =>
                                    _header.Setup("Content-Type", "application/json")
                                )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Creates or updates [custom attributes]($m/CustomAttribute) for customer profiles as a bulk operation.
        /// Use this endpoint to set the value of one or more custom attributes for one or more customer profiles.
        /// A custom attribute is based on a custom attribute definition in a Square seller account, which is.
        /// created using the [CreateCustomerCustomAttributeDefinition]($e/CustomerCustomAttributes/CreateCustomerCustomAttributeDefinition) endpoint.
        /// This `BulkUpsertCustomerCustomAttributes` endpoint accepts a map of 1 to 25 individual upsert.
        /// requests and returns a map of individual upsert responses. Each upsert request has a unique ID.
        /// and provides a customer ID and custom attribute. Each upsert response is returned with the ID.
        /// of the corresponding request.
        /// To create or update a custom attribute owned by another application, the `visibility` setting.
        /// must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkUpsertCustomerCustomAttributesResponse response from the API call.</returns>
        public Models.BulkUpsertCustomerCustomAttributesResponse BulkUpsertCustomerCustomAttributes(
            Models.BulkUpsertCustomerCustomAttributesRequest body
        ) => CoreHelper.RunTask(BulkUpsertCustomerCustomAttributesAsync(body));

        /// <summary>
        /// Creates or updates [custom attributes]($m/CustomAttribute) for customer profiles as a bulk operation.
        /// Use this endpoint to set the value of one or more custom attributes for one or more customer profiles.
        /// A custom attribute is based on a custom attribute definition in a Square seller account, which is.
        /// created using the [CreateCustomerCustomAttributeDefinition]($e/CustomerCustomAttributes/CreateCustomerCustomAttributeDefinition) endpoint.
        /// This `BulkUpsertCustomerCustomAttributes` endpoint accepts a map of 1 to 25 individual upsert.
        /// requests and returns a map of individual upsert responses. Each upsert request has a unique ID.
        /// and provides a customer ID and custom attribute. Each upsert response is returned with the ID.
        /// of the corresponding request.
        /// To create or update a custom attribute owned by another application, the `visibility` setting.
        /// must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkUpsertCustomerCustomAttributesResponse response from the API call.</returns>
        public async Task<Models.BulkUpsertCustomerCustomAttributesResponse> BulkUpsertCustomerCustomAttributesAsync(
            Models.BulkUpsertCustomerCustomAttributesRequest body,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.BulkUpsertCustomerCustomAttributesResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Post, "/v2/customers/custom-attributes/bulk-upsert")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Body(_bodyParameter => _bodyParameter.Setup(body))
                                .Header(_header =>
                                    _header.Setup("Content-Type", "application/json")
                                )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Lists the [custom attributes]($m/CustomAttribute) associated with a customer profile.
        /// You can use the `with_definitions` query parameter to also retrieve custom attribute definitions.
        /// in the same call.
        /// When all response pages are retrieved, the results include all custom attributes that are.
        /// visible to the requesting application, including those that are owned by other applications.
        /// and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the target [customer profile](entity:Customer)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory. The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100. The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="withDefinitions">Optional parameter: Indicates whether to return the [custom attribute definition](entity:CustomAttributeDefinition) in the `definition` field of each custom attribute. Set this parameter to `true` to get the name and description of each custom attribute, information about the data type, or other definition details. The default value is `false`..</param>
        /// <returns>Returns the Models.ListCustomerCustomAttributesResponse response from the API call.</returns>
        public Models.ListCustomerCustomAttributesResponse ListCustomerCustomAttributes(
            string customerId,
            int? limit = null,
            string cursor = null,
            bool? withDefinitions = false
        ) =>
            CoreHelper.RunTask(
                ListCustomerCustomAttributesAsync(customerId, limit, cursor, withDefinitions)
            );

        /// <summary>
        /// Lists the [custom attributes]($m/CustomAttribute) associated with a customer profile.
        /// You can use the `with_definitions` query parameter to also retrieve custom attribute definitions.
        /// in the same call.
        /// When all response pages are retrieved, the results include all custom attributes that are.
        /// visible to the requesting application, including those that are owned by other applications.
        /// and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the target [customer profile](entity:Customer)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory. The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100. The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="withDefinitions">Optional parameter: Indicates whether to return the [custom attribute definition](entity:CustomAttributeDefinition) in the `definition` field of each custom attribute. Set this parameter to `true` to get the name and description of each custom attribute, information about the data type, or other definition details. The default value is `false`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListCustomerCustomAttributesResponse response from the API call.</returns>
        public async Task<Models.ListCustomerCustomAttributesResponse> ListCustomerCustomAttributesAsync(
            string customerId,
            int? limit = null,
            string cursor = null,
            bool? withDefinitions = false,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.ListCustomerCustomAttributesResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Get, "/v2/customers/{customer_id}/custom-attributes")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Template(_template => _template.Setup("customer_id", customerId))
                                .Query(_query => _query.Setup("limit", limit))
                                .Query(_query => _query.Setup("cursor", cursor))
                                .Query(_query =>
                                    _query.Setup("with_definitions", withDefinitions ?? false)
                                )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Deletes a [custom attribute]($m/CustomAttribute) associated with a customer profile.
        /// To delete a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the target [customer profile](entity:Customer)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to delete. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <returns>Returns the Models.DeleteCustomerCustomAttributeResponse response from the API call.</returns>
        public Models.DeleteCustomerCustomAttributeResponse DeleteCustomerCustomAttribute(
            string customerId,
            string key
        ) => CoreHelper.RunTask(DeleteCustomerCustomAttributeAsync(customerId, key));

        /// <summary>
        /// Deletes a [custom attribute]($m/CustomAttribute) associated with a customer profile.
        /// To delete a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the target [customer profile](entity:Customer)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to delete. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteCustomerCustomAttributeResponse response from the API call.</returns>
        public async Task<Models.DeleteCustomerCustomAttributeResponse> DeleteCustomerCustomAttributeAsync(
            string customerId,
            string key,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.DeleteCustomerCustomAttributeResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(
                            HttpMethod.Delete,
                            "/v2/customers/{customer_id}/custom-attributes/{key}"
                        )
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Template(_template => _template.Setup("customer_id", customerId))
                                .Template(_template => _template.Setup("key", key))
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Retrieves a [custom attribute]($m/CustomAttribute) associated with a customer profile.
        /// You can use the `with_definition` query parameter to also retrieve the custom attribute definition.
        /// in the same call.
        /// To retrieve a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the target [customer profile](entity:Customer)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to retrieve. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="withDefinition">Optional parameter: Indicates whether to return the [custom attribute definition](entity:CustomAttributeDefinition) in the `definition` field of the custom attribute. Set this parameter to `true` to get the name and description of the custom attribute, information about the data type, or other definition details. The default value is `false`..</param>
        /// <param name="version">Optional parameter: The current version of the custom attribute, which is used for strongly consistent reads to guarantee that you receive the most up-to-date data. When included in the request, Square returns the specified version or a higher version if one exists. If the specified version is higher than the current version, Square returns a `BAD_REQUEST` error..</param>
        /// <returns>Returns the Models.RetrieveCustomerCustomAttributeResponse response from the API call.</returns>
        public Models.RetrieveCustomerCustomAttributeResponse RetrieveCustomerCustomAttribute(
            string customerId,
            string key,
            bool? withDefinition = false,
            int? version = null
        ) =>
            CoreHelper.RunTask(
                RetrieveCustomerCustomAttributeAsync(customerId, key, withDefinition, version)
            );

        /// <summary>
        /// Retrieves a [custom attribute]($m/CustomAttribute) associated with a customer profile.
        /// You can use the `with_definition` query parameter to also retrieve the custom attribute definition.
        /// in the same call.
        /// To retrieve a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the target [customer profile](entity:Customer)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to retrieve. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="withDefinition">Optional parameter: Indicates whether to return the [custom attribute definition](entity:CustomAttributeDefinition) in the `definition` field of the custom attribute. Set this parameter to `true` to get the name and description of the custom attribute, information about the data type, or other definition details. The default value is `false`..</param>
        /// <param name="version">Optional parameter: The current version of the custom attribute, which is used for strongly consistent reads to guarantee that you receive the most up-to-date data. When included in the request, Square returns the specified version or a higher version if one exists. If the specified version is higher than the current version, Square returns a `BAD_REQUEST` error..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveCustomerCustomAttributeResponse response from the API call.</returns>
        public async Task<Models.RetrieveCustomerCustomAttributeResponse> RetrieveCustomerCustomAttributeAsync(
            string customerId,
            string key,
            bool? withDefinition = false,
            int? version = null,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.RetrieveCustomerCustomAttributeResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(
                            HttpMethod.Get,
                            "/v2/customers/{customer_id}/custom-attributes/{key}"
                        )
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Template(_template => _template.Setup("customer_id", customerId))
                                .Template(_template => _template.Setup("key", key))
                                .Query(_query =>
                                    _query.Setup("with_definition", withDefinition ?? false)
                                )
                                .Query(_query => _query.Setup("version", version))
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Creates or updates a [custom attribute]($m/CustomAttribute) for a customer profile.
        /// Use this endpoint to set the value of a custom attribute for a specified customer profile.
        /// A custom attribute is based on a custom attribute definition in a Square seller account, which.
        /// is created using the [CreateCustomerCustomAttributeDefinition]($e/CustomerCustomAttributes/CreateCustomerCustomAttributeDefinition) endpoint.
        /// To create or update a custom attribute owned by another application, the `visibility` setting.
        /// must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the target [customer profile](entity:Customer)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to create or update. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpsertCustomerCustomAttributeResponse response from the API call.</returns>
        public Models.UpsertCustomerCustomAttributeResponse UpsertCustomerCustomAttribute(
            string customerId,
            string key,
            Models.UpsertCustomerCustomAttributeRequest body
        ) => CoreHelper.RunTask(UpsertCustomerCustomAttributeAsync(customerId, key, body));

        /// <summary>
        /// Creates or updates a [custom attribute]($m/CustomAttribute) for a customer profile.
        /// Use this endpoint to set the value of a custom attribute for a specified customer profile.
        /// A custom attribute is based on a custom attribute definition in a Square seller account, which.
        /// is created using the [CreateCustomerCustomAttributeDefinition]($e/CustomerCustomAttributes/CreateCustomerCustomAttributeDefinition) endpoint.
        /// To create or update a custom attribute owned by another application, the `visibility` setting.
        /// must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="customerId">Required parameter: The ID of the target [customer profile](entity:Customer)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to create or update. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpsertCustomerCustomAttributeResponse response from the API call.</returns>
        public async Task<Models.UpsertCustomerCustomAttributeResponse> UpsertCustomerCustomAttributeAsync(
            string customerId,
            string key,
            Models.UpsertCustomerCustomAttributeRequest body,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.UpsertCustomerCustomAttributeResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(
                            HttpMethod.Post,
                            "/v2/customers/{customer_id}/custom-attributes/{key}"
                        )
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Body(_bodyParameter => _bodyParameter.Setup(body))
                                .Template(_template => _template.Setup("customer_id", customerId))
                                .Template(_template => _template.Setup("key", key))
                                .Header(_header =>
                                    _header.Setup("Content-Type", "application/json")
                                )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);
    }
}
