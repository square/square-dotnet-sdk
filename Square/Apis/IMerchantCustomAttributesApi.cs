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
    /// IMerchantCustomAttributesApi.
    /// </summary>
    public interface IMerchantCustomAttributesApi
    {
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
        Models.ListMerchantCustomAttributeDefinitionsResponse ListMerchantCustomAttributeDefinitions(
                string visibilityFilter = null,
                int? limit = null,
                string cursor = null);

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
        Task<Models.ListMerchantCustomAttributeDefinitionsResponse> ListMerchantCustomAttributeDefinitionsAsync(
                string visibilityFilter = null,
                int? limit = null,
                string cursor = null,
                CancellationToken cancellationToken = default);

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
        Models.CreateMerchantCustomAttributeDefinitionResponse CreateMerchantCustomAttributeDefinition(
                Models.CreateMerchantCustomAttributeDefinitionRequest body);

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
        Task<Models.CreateMerchantCustomAttributeDefinitionResponse> CreateMerchantCustomAttributeDefinitionAsync(
                Models.CreateMerchantCustomAttributeDefinitionRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a merchant-related [custom attribute definition]($m/CustomAttributeDefinition) from a Square seller account.
        /// Deleting a custom attribute definition also deletes the corresponding custom attribute from.
        /// the merchant.
        /// Only the definition owner can delete a custom attribute definition.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to delete..</param>
        /// <returns>Returns the Models.DeleteMerchantCustomAttributeDefinitionResponse response from the API call.</returns>
        Models.DeleteMerchantCustomAttributeDefinitionResponse DeleteMerchantCustomAttributeDefinition(
                string key);

        /// <summary>
        /// Deletes a merchant-related [custom attribute definition]($m/CustomAttributeDefinition) from a Square seller account.
        /// Deleting a custom attribute definition also deletes the corresponding custom attribute from.
        /// the merchant.
        /// Only the definition owner can delete a custom attribute definition.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to delete..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteMerchantCustomAttributeDefinitionResponse response from the API call.</returns>
        Task<Models.DeleteMerchantCustomAttributeDefinitionResponse> DeleteMerchantCustomAttributeDefinitionAsync(
                string key,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a merchant-related [custom attribute definition]($m/CustomAttributeDefinition) from a Square seller account.
        /// To retrieve a custom attribute definition created by another application, the `visibility`.
        /// setting must be `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to retrieve. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="version">Optional parameter: The current version of the custom attribute definition, which is used for strongly consistent reads to guarantee that you receive the most up-to-date data. When included in the request, Square returns the specified version or a higher version if one exists. If the specified version is higher than the current version, Square returns a `BAD_REQUEST` error..</param>
        /// <returns>Returns the Models.RetrieveMerchantCustomAttributeDefinitionResponse response from the API call.</returns>
        Models.RetrieveMerchantCustomAttributeDefinitionResponse RetrieveMerchantCustomAttributeDefinition(
                string key,
                int? version = null);

        /// <summary>
        /// Retrieves a merchant-related [custom attribute definition]($m/CustomAttributeDefinition) from a Square seller account.
        /// To retrieve a custom attribute definition created by another application, the `visibility`.
        /// setting must be `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to retrieve. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="version">Optional parameter: The current version of the custom attribute definition, which is used for strongly consistent reads to guarantee that you receive the most up-to-date data. When included in the request, Square returns the specified version or a higher version if one exists. If the specified version is higher than the current version, Square returns a `BAD_REQUEST` error..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveMerchantCustomAttributeDefinitionResponse response from the API call.</returns>
        Task<Models.RetrieveMerchantCustomAttributeDefinitionResponse> RetrieveMerchantCustomAttributeDefinitionAsync(
                string key,
                int? version = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a merchant-related [custom attribute definition]($m/CustomAttributeDefinition) for a Square seller account.
        /// Use this endpoint to update the following fields: `name`, `description`, `visibility`, or the.
        /// `schema` for a `Selection` data type.
        /// Only the definition owner can update a custom attribute definition.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateMerchantCustomAttributeDefinitionResponse response from the API call.</returns>
        Models.UpdateMerchantCustomAttributeDefinitionResponse UpdateMerchantCustomAttributeDefinition(
                string key,
                Models.UpdateMerchantCustomAttributeDefinitionRequest body);

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
        Task<Models.UpdateMerchantCustomAttributeDefinitionResponse> UpdateMerchantCustomAttributeDefinitionAsync(
                string key,
                Models.UpdateMerchantCustomAttributeDefinitionRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes [custom attributes]($m/CustomAttribute) for a merchant as a bulk operation.
        /// To delete a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkDeleteMerchantCustomAttributesResponse response from the API call.</returns>
        Models.BulkDeleteMerchantCustomAttributesResponse BulkDeleteMerchantCustomAttributes(
                Models.BulkDeleteMerchantCustomAttributesRequest body);

        /// <summary>
        /// Deletes [custom attributes]($m/CustomAttribute) for a merchant as a bulk operation.
        /// To delete a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkDeleteMerchantCustomAttributesResponse response from the API call.</returns>
        Task<Models.BulkDeleteMerchantCustomAttributesResponse> BulkDeleteMerchantCustomAttributesAsync(
                Models.BulkDeleteMerchantCustomAttributesRequest body,
                CancellationToken cancellationToken = default);

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
        Models.BulkUpsertMerchantCustomAttributesResponse BulkUpsertMerchantCustomAttributes(
                Models.BulkUpsertMerchantCustomAttributesRequest body);

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
        Task<Models.BulkUpsertMerchantCustomAttributesResponse> BulkUpsertMerchantCustomAttributesAsync(
                Models.BulkUpsertMerchantCustomAttributesRequest body,
                CancellationToken cancellationToken = default);

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
        Models.ListMerchantCustomAttributesResponse ListMerchantCustomAttributes(
                string merchantId,
                string visibilityFilter = null,
                int? limit = null,
                string cursor = null,
                bool? withDefinitions = false);

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
        Task<Models.ListMerchantCustomAttributesResponse> ListMerchantCustomAttributesAsync(
                string merchantId,
                string visibilityFilter = null,
                int? limit = null,
                string cursor = null,
                bool? withDefinitions = false,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a [custom attribute]($m/CustomAttribute) associated with a merchant.
        /// To delete a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="merchantId">Required parameter: The ID of the target [merchant](entity:Merchant)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to delete. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <returns>Returns the Models.DeleteMerchantCustomAttributeResponse response from the API call.</returns>
        Models.DeleteMerchantCustomAttributeResponse DeleteMerchantCustomAttribute(
                string merchantId,
                string key);

        /// <summary>
        /// Deletes a [custom attribute]($m/CustomAttribute) associated with a merchant.
        /// To delete a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="merchantId">Required parameter: The ID of the target [merchant](entity:Merchant)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to delete. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteMerchantCustomAttributeResponse response from the API call.</returns>
        Task<Models.DeleteMerchantCustomAttributeResponse> DeleteMerchantCustomAttributeAsync(
                string merchantId,
                string key,
                CancellationToken cancellationToken = default);

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
        Models.RetrieveMerchantCustomAttributeResponse RetrieveMerchantCustomAttribute(
                string merchantId,
                string key,
                bool? withDefinition = false,
                int? version = null);

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
        Task<Models.RetrieveMerchantCustomAttributeResponse> RetrieveMerchantCustomAttributeAsync(
                string merchantId,
                string key,
                bool? withDefinition = false,
                int? version = null,
                CancellationToken cancellationToken = default);

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
        Models.UpsertMerchantCustomAttributeResponse UpsertMerchantCustomAttribute(
                string merchantId,
                string key,
                Models.UpsertMerchantCustomAttributeRequest body);

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
        Task<Models.UpsertMerchantCustomAttributeResponse> UpsertMerchantCustomAttributeAsync(
                string merchantId,
                string key,
                Models.UpsertMerchantCustomAttributeRequest body,
                CancellationToken cancellationToken = default);
    }
}