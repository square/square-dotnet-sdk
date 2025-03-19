using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Square.Legacy;
using Square.Legacy.Http.Client;
using Square.Legacy.Http.Request;
using Square.Legacy.Http.Response;
using Square.Legacy.Utilities;

namespace Square.Legacy.Apis
{
    /// <summary>
    /// IOrderCustomAttributesApi.
    /// </summary>
    public interface IOrderCustomAttributesApi
    {
        /// <summary>
        /// Lists the order-related [custom attribute definitions]($m/CustomAttributeDefinition) that belong to a Square seller account.
        /// When all response pages are retrieved, the results include all custom attribute definitions.
        /// that are visible to the requesting application, including those that are created by other.
        /// applications and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that.
        /// seller-defined custom attributes (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="visibilityFilter">Optional parameter: Requests that all of the custom attributes be returned, or only those that are read-only or read-write..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint.  Provide this cursor to retrieve the next page of results for your original request.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory.  The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100.  The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <returns>Returns the Models.ListOrderCustomAttributeDefinitionsResponse response from the API call.</returns>
        Models.ListOrderCustomAttributeDefinitionsResponse ListOrderCustomAttributeDefinitions(
            string visibilityFilter = null,
            string cursor = null,
            int? limit = null
        );

        /// <summary>
        /// Lists the order-related [custom attribute definitions]($m/CustomAttributeDefinition) that belong to a Square seller account.
        /// When all response pages are retrieved, the results include all custom attribute definitions.
        /// that are visible to the requesting application, including those that are created by other.
        /// applications and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that.
        /// seller-defined custom attributes (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="visibilityFilter">Optional parameter: Requests that all of the custom attributes be returned, or only those that are read-only or read-write..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint.  Provide this cursor to retrieve the next page of results for your original request.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory.  The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100.  The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListOrderCustomAttributeDefinitionsResponse response from the API call.</returns>
        Task<Models.ListOrderCustomAttributeDefinitionsResponse> ListOrderCustomAttributeDefinitionsAsync(
            string visibilityFilter = null,
            string cursor = null,
            int? limit = null,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Creates an order-related custom attribute definition.  Use this endpoint to.
        /// define a custom attribute that can be associated with orders.
        /// After creating a custom attribute definition, you can set the custom attribute for orders.
        /// in the Square seller account.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateOrderCustomAttributeDefinitionResponse response from the API call.</returns>
        Models.CreateOrderCustomAttributeDefinitionResponse CreateOrderCustomAttributeDefinition(
            Models.CreateOrderCustomAttributeDefinitionRequest body
        );

        /// <summary>
        /// Creates an order-related custom attribute definition.  Use this endpoint to.
        /// define a custom attribute that can be associated with orders.
        /// After creating a custom attribute definition, you can set the custom attribute for orders.
        /// in the Square seller account.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateOrderCustomAttributeDefinitionResponse response from the API call.</returns>
        Task<Models.CreateOrderCustomAttributeDefinitionResponse> CreateOrderCustomAttributeDefinitionAsync(
            Models.CreateOrderCustomAttributeDefinitionRequest body,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Deletes an order-related [custom attribute definition]($m/CustomAttributeDefinition) from a Square seller account.
        /// Only the definition owner can delete a custom attribute definition.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to delete..</param>
        /// <returns>Returns the Models.DeleteOrderCustomAttributeDefinitionResponse response from the API call.</returns>
        Models.DeleteOrderCustomAttributeDefinitionResponse DeleteOrderCustomAttributeDefinition(
            string key
        );

        /// <summary>
        /// Deletes an order-related [custom attribute definition]($m/CustomAttributeDefinition) from a Square seller account.
        /// Only the definition owner can delete a custom attribute definition.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to delete..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteOrderCustomAttributeDefinitionResponse response from the API call.</returns>
        Task<Models.DeleteOrderCustomAttributeDefinitionResponse> DeleteOrderCustomAttributeDefinitionAsync(
            string key,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Retrieves an order-related [custom attribute definition]($m/CustomAttributeDefinition) from a Square seller account.
        /// To retrieve a custom attribute definition created by another application, the `visibility`.
        /// setting must be `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to retrieve..</param>
        /// <param name="version">Optional parameter: To enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency) control, include this optional field and specify the current version of the custom attribute..</param>
        /// <returns>Returns the Models.RetrieveOrderCustomAttributeDefinitionResponse response from the API call.</returns>
        Models.RetrieveOrderCustomAttributeDefinitionResponse RetrieveOrderCustomAttributeDefinition(
            string key,
            int? version = null
        );

        /// <summary>
        /// Retrieves an order-related [custom attribute definition]($m/CustomAttributeDefinition) from a Square seller account.
        /// To retrieve a custom attribute definition created by another application, the `visibility`.
        /// setting must be `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to retrieve..</param>
        /// <param name="version">Optional parameter: To enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency) control, include this optional field and specify the current version of the custom attribute..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveOrderCustomAttributeDefinitionResponse response from the API call.</returns>
        Task<Models.RetrieveOrderCustomAttributeDefinitionResponse> RetrieveOrderCustomAttributeDefinitionAsync(
            string key,
            int? version = null,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Updates an order-related custom attribute definition for a Square seller account.
        /// Only the definition owner can update a custom attribute definition. Note that sellers can view all custom attributes in exported customer data, including those set to `VISIBILITY_HIDDEN`.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateOrderCustomAttributeDefinitionResponse response from the API call.</returns>
        Models.UpdateOrderCustomAttributeDefinitionResponse UpdateOrderCustomAttributeDefinition(
            string key,
            Models.UpdateOrderCustomAttributeDefinitionRequest body
        );

        /// <summary>
        /// Updates an order-related custom attribute definition for a Square seller account.
        /// Only the definition owner can update a custom attribute definition. Note that sellers can view all custom attributes in exported customer data, including those set to `VISIBILITY_HIDDEN`.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateOrderCustomAttributeDefinitionResponse response from the API call.</returns>
        Task<Models.UpdateOrderCustomAttributeDefinitionResponse> UpdateOrderCustomAttributeDefinitionAsync(
            string key,
            Models.UpdateOrderCustomAttributeDefinitionRequest body,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Deletes order [custom attributes]($m/CustomAttribute) as a bulk operation.
        /// Use this endpoint to delete one or more custom attributes from one or more orders.
        /// A custom attribute is based on a custom attribute definition in a Square seller account.  (To create a.
        /// custom attribute definition, use the [CreateOrderCustomAttributeDefinition]($e/OrderCustomAttributes/CreateOrderCustomAttributeDefinition) endpoint.).
        /// This `BulkDeleteOrderCustomAttributes` endpoint accepts a map of 1 to 25 individual delete.
        /// requests and returns a map of individual delete responses. Each delete request has a unique ID.
        /// and provides an order ID and custom attribute. Each delete response is returned with the ID.
        /// of the corresponding request.
        /// To delete a custom attribute owned by another application, the `visibility` setting.
        /// must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkDeleteOrderCustomAttributesResponse response from the API call.</returns>
        Models.BulkDeleteOrderCustomAttributesResponse BulkDeleteOrderCustomAttributes(
            Models.BulkDeleteOrderCustomAttributesRequest body
        );

        /// <summary>
        /// Deletes order [custom attributes]($m/CustomAttribute) as a bulk operation.
        /// Use this endpoint to delete one or more custom attributes from one or more orders.
        /// A custom attribute is based on a custom attribute definition in a Square seller account.  (To create a.
        /// custom attribute definition, use the [CreateOrderCustomAttributeDefinition]($e/OrderCustomAttributes/CreateOrderCustomAttributeDefinition) endpoint.).
        /// This `BulkDeleteOrderCustomAttributes` endpoint accepts a map of 1 to 25 individual delete.
        /// requests and returns a map of individual delete responses. Each delete request has a unique ID.
        /// and provides an order ID and custom attribute. Each delete response is returned with the ID.
        /// of the corresponding request.
        /// To delete a custom attribute owned by another application, the `visibility` setting.
        /// must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkDeleteOrderCustomAttributesResponse response from the API call.</returns>
        Task<Models.BulkDeleteOrderCustomAttributesResponse> BulkDeleteOrderCustomAttributesAsync(
            Models.BulkDeleteOrderCustomAttributesRequest body,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Creates or updates order [custom attributes]($m/CustomAttribute) as a bulk operation.
        /// Use this endpoint to delete one or more custom attributes from one or more orders.
        /// A custom attribute is based on a custom attribute definition in a Square seller account.  (To create a.
        /// custom attribute definition, use the [CreateOrderCustomAttributeDefinition]($e/OrderCustomAttributes/CreateOrderCustomAttributeDefinition) endpoint.).
        /// This `BulkUpsertOrderCustomAttributes` endpoint accepts a map of 1 to 25 individual upsert.
        /// requests and returns a map of individual upsert responses. Each upsert request has a unique ID.
        /// and provides an order ID and custom attribute. Each upsert response is returned with the ID.
        /// of the corresponding request.
        /// To create or update a custom attribute owned by another application, the `visibility` setting.
        /// must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkUpsertOrderCustomAttributesResponse response from the API call.</returns>
        Models.BulkUpsertOrderCustomAttributesResponse BulkUpsertOrderCustomAttributes(
            Models.BulkUpsertOrderCustomAttributesRequest body
        );

        /// <summary>
        /// Creates or updates order [custom attributes]($m/CustomAttribute) as a bulk operation.
        /// Use this endpoint to delete one or more custom attributes from one or more orders.
        /// A custom attribute is based on a custom attribute definition in a Square seller account.  (To create a.
        /// custom attribute definition, use the [CreateOrderCustomAttributeDefinition]($e/OrderCustomAttributes/CreateOrderCustomAttributeDefinition) endpoint.).
        /// This `BulkUpsertOrderCustomAttributes` endpoint accepts a map of 1 to 25 individual upsert.
        /// requests and returns a map of individual upsert responses. Each upsert request has a unique ID.
        /// and provides an order ID and custom attribute. Each upsert response is returned with the ID.
        /// of the corresponding request.
        /// To create or update a custom attribute owned by another application, the `visibility` setting.
        /// must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkUpsertOrderCustomAttributesResponse response from the API call.</returns>
        Task<Models.BulkUpsertOrderCustomAttributesResponse> BulkUpsertOrderCustomAttributesAsync(
            Models.BulkUpsertOrderCustomAttributesRequest body,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Lists the [custom attributes]($m/CustomAttribute) associated with an order.
        /// You can use the `with_definitions` query parameter to also retrieve custom attribute definitions.
        /// in the same call.
        /// When all response pages are retrieved, the results include all custom attributes that are.
        /// visible to the requesting application, including those that are owned by other applications.
        /// and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the target [order](entity:Order)..</param>
        /// <param name="visibilityFilter">Optional parameter: Requests that all of the custom attributes be returned, or only those that are read-only or read-write..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint.  Provide this cursor to retrieve the next page of results for your original request.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory.  The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100.  The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="withDefinitions">Optional parameter: Indicates whether to return the [custom attribute definition](entity:CustomAttributeDefinition) in the `definition` field of each custom attribute. Set this parameter to `true` to get the name and description of each custom attribute,  information about the data type, or other definition details. The default value is `false`..</param>
        /// <returns>Returns the Models.ListOrderCustomAttributesResponse response from the API call.</returns>
        Models.ListOrderCustomAttributesResponse ListOrderCustomAttributes(
            string orderId,
            string visibilityFilter = null,
            string cursor = null,
            int? limit = null,
            bool? withDefinitions = false
        );

        /// <summary>
        /// Lists the [custom attributes]($m/CustomAttribute) associated with an order.
        /// You can use the `with_definitions` query parameter to also retrieve custom attribute definitions.
        /// in the same call.
        /// When all response pages are retrieved, the results include all custom attributes that are.
        /// visible to the requesting application, including those that are owned by other applications.
        /// and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the target [order](entity:Order)..</param>
        /// <param name="visibilityFilter">Optional parameter: Requests that all of the custom attributes be returned, or only those that are read-only or read-write..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint.  Provide this cursor to retrieve the next page of results for your original request.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory.  The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100.  The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="withDefinitions">Optional parameter: Indicates whether to return the [custom attribute definition](entity:CustomAttributeDefinition) in the `definition` field of each custom attribute. Set this parameter to `true` to get the name and description of each custom attribute,  information about the data type, or other definition details. The default value is `false`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListOrderCustomAttributesResponse response from the API call.</returns>
        Task<Models.ListOrderCustomAttributesResponse> ListOrderCustomAttributesAsync(
            string orderId,
            string visibilityFilter = null,
            string cursor = null,
            int? limit = null,
            bool? withDefinitions = false,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Deletes a [custom attribute]($m/CustomAttribute) associated with a customer profile.
        /// To delete a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the target [order](entity:Order)..</param>
        /// <param name="customAttributeKey">Required parameter: The key of the custom attribute to delete.  This key must match the key of an existing custom attribute definition..</param>
        /// <returns>Returns the Models.DeleteOrderCustomAttributeResponse response from the API call.</returns>
        Models.DeleteOrderCustomAttributeResponse DeleteOrderCustomAttribute(
            string orderId,
            string customAttributeKey
        );

        /// <summary>
        /// Deletes a [custom attribute]($m/CustomAttribute) associated with a customer profile.
        /// To delete a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the target [order](entity:Order)..</param>
        /// <param name="customAttributeKey">Required parameter: The key of the custom attribute to delete.  This key must match the key of an existing custom attribute definition..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteOrderCustomAttributeResponse response from the API call.</returns>
        Task<Models.DeleteOrderCustomAttributeResponse> DeleteOrderCustomAttributeAsync(
            string orderId,
            string customAttributeKey,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Retrieves a [custom attribute]($m/CustomAttribute) associated with an order.
        /// You can use the `with_definition` query parameter to also retrieve the custom attribute definition.
        /// in the same call.
        /// To retrieve a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the target [order](entity:Order)..</param>
        /// <param name="customAttributeKey">Required parameter: The key of the custom attribute to retrieve.  This key must match the key of an existing custom attribute definition..</param>
        /// <param name="version">Optional parameter: To enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency) control, include this optional field and specify the current version of the custom attribute..</param>
        /// <param name="withDefinition">Optional parameter: Indicates whether to return the [custom attribute definition](entity:CustomAttributeDefinition) in the `definition` field of each  custom attribute. Set this parameter to `true` to get the name and description of each custom attribute,  information about the data type, or other definition details. The default value is `false`..</param>
        /// <returns>Returns the Models.RetrieveOrderCustomAttributeResponse response from the API call.</returns>
        Models.RetrieveOrderCustomAttributeResponse RetrieveOrderCustomAttribute(
            string orderId,
            string customAttributeKey,
            int? version = null,
            bool? withDefinition = false
        );

        /// <summary>
        /// Retrieves a [custom attribute]($m/CustomAttribute) associated with an order.
        /// You can use the `with_definition` query parameter to also retrieve the custom attribute definition.
        /// in the same call.
        /// To retrieve a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the target [order](entity:Order)..</param>
        /// <param name="customAttributeKey">Required parameter: The key of the custom attribute to retrieve.  This key must match the key of an existing custom attribute definition..</param>
        /// <param name="version">Optional parameter: To enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency) control, include this optional field and specify the current version of the custom attribute..</param>
        /// <param name="withDefinition">Optional parameter: Indicates whether to return the [custom attribute definition](entity:CustomAttributeDefinition) in the `definition` field of each  custom attribute. Set this parameter to `true` to get the name and description of each custom attribute,  information about the data type, or other definition details. The default value is `false`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveOrderCustomAttributeResponse response from the API call.</returns>
        Task<Models.RetrieveOrderCustomAttributeResponse> RetrieveOrderCustomAttributeAsync(
            string orderId,
            string customAttributeKey,
            int? version = null,
            bool? withDefinition = false,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Creates or updates a [custom attribute]($m/CustomAttribute) for an order.
        /// Use this endpoint to set the value of a custom attribute for a specific order.
        /// A custom attribute is based on a custom attribute definition in a Square seller account. (To create a.
        /// custom attribute definition, use the [CreateOrderCustomAttributeDefinition]($e/OrderCustomAttributes/CreateOrderCustomAttributeDefinition) endpoint.).
        /// To create or update a custom attribute owned by another application, the `visibility` setting.
        /// must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the target [order](entity:Order)..</param>
        /// <param name="customAttributeKey">Required parameter: The key of the custom attribute to create or update.  This key must match the key  of an existing custom attribute definition..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpsertOrderCustomAttributeResponse response from the API call.</returns>
        Models.UpsertOrderCustomAttributeResponse UpsertOrderCustomAttribute(
            string orderId,
            string customAttributeKey,
            Models.UpsertOrderCustomAttributeRequest body
        );

        /// <summary>
        /// Creates or updates a [custom attribute]($m/CustomAttribute) for an order.
        /// Use this endpoint to set the value of a custom attribute for a specific order.
        /// A custom attribute is based on a custom attribute definition in a Square seller account. (To create a.
        /// custom attribute definition, use the [CreateOrderCustomAttributeDefinition]($e/OrderCustomAttributes/CreateOrderCustomAttributeDefinition) endpoint.).
        /// To create or update a custom attribute owned by another application, the `visibility` setting.
        /// must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes.
        /// (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="orderId">Required parameter: The ID of the target [order](entity:Order)..</param>
        /// <param name="customAttributeKey">Required parameter: The key of the custom attribute to create or update.  This key must match the key  of an existing custom attribute definition..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpsertOrderCustomAttributeResponse response from the API call.</returns>
        Task<Models.UpsertOrderCustomAttributeResponse> UpsertOrderCustomAttributeAsync(
            string orderId,
            string customAttributeKey,
            Models.UpsertOrderCustomAttributeRequest body,
            CancellationToken cancellationToken = default
        );
    }
}
