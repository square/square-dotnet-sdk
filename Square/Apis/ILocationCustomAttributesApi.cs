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
    /// ILocationCustomAttributesApi.
    /// </summary>
    public interface ILocationCustomAttributesApi
    {
        /// <summary>
        /// Lists the location-related [custom attribute definitions]($m/CustomAttributeDefinition) that belong to a Square seller account.
        /// When all response pages are retrieved, the results include all custom attribute definitions.
        /// that are visible to the requesting application, including those that are created by other.
        /// applications and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="visibilityFilter">Optional parameter: Filters the `CustomAttributeDefinition` results by their `visibility` values..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory. The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100. The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <returns>Returns the Models.ListLocationCustomAttributeDefinitionsResponse response from the API call.</returns>
        Models.ListLocationCustomAttributeDefinitionsResponse ListLocationCustomAttributeDefinitions(
                string visibilityFilter = null,
                int? limit = null,
                string cursor = null);

        /// <summary>
        /// Lists the location-related [custom attribute definitions]($m/CustomAttributeDefinition) that belong to a Square seller account.
        /// When all response pages are retrieved, the results include all custom attribute definitions.
        /// that are visible to the requesting application, including those that are created by other.
        /// applications and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="visibilityFilter">Optional parameter: Filters the `CustomAttributeDefinition` results by their `visibility` values..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory. The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100. The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListLocationCustomAttributeDefinitionsResponse response from the API call.</returns>
        Task<Models.ListLocationCustomAttributeDefinitionsResponse> ListLocationCustomAttributeDefinitionsAsync(
                string visibilityFilter = null,
                int? limit = null,
                string cursor = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a location-related [custom attribute definition]($m/CustomAttributeDefinition) for a Square seller account.
        /// Use this endpoint to define a custom attribute that can be associated with locations.
        /// A custom attribute definition specifies the `key`, `visibility`, `schema`, and other properties.
        /// for a custom attribute. After the definition is created, you can call.
        /// [UpsertLocationCustomAttribute]($e/LocationCustomAttributes/UpsertLocationCustomAttribute) or.
        /// [BulkUpsertLocationCustomAttributes]($e/LocationCustomAttributes/BulkUpsertLocationCustomAttributes).
        /// to set the custom attribute for locations.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateLocationCustomAttributeDefinitionResponse response from the API call.</returns>
        Models.CreateLocationCustomAttributeDefinitionResponse CreateLocationCustomAttributeDefinition(
                Models.CreateLocationCustomAttributeDefinitionRequest body);

        /// <summary>
        /// Creates a location-related [custom attribute definition]($m/CustomAttributeDefinition) for a Square seller account.
        /// Use this endpoint to define a custom attribute that can be associated with locations.
        /// A custom attribute definition specifies the `key`, `visibility`, `schema`, and other properties.
        /// for a custom attribute. After the definition is created, you can call.
        /// [UpsertLocationCustomAttribute]($e/LocationCustomAttributes/UpsertLocationCustomAttribute) or.
        /// [BulkUpsertLocationCustomAttributes]($e/LocationCustomAttributes/BulkUpsertLocationCustomAttributes).
        /// to set the custom attribute for locations.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateLocationCustomAttributeDefinitionResponse response from the API call.</returns>
        Task<Models.CreateLocationCustomAttributeDefinitionResponse> CreateLocationCustomAttributeDefinitionAsync(
                Models.CreateLocationCustomAttributeDefinitionRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a location-related [custom attribute definition]($m/CustomAttributeDefinition) from a Square seller account.
        /// Deleting a custom attribute definition also deletes the corresponding custom attribute from.
        /// all locations.
        /// Only the definition owner can delete a custom attribute definition.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to delete..</param>
        /// <returns>Returns the Models.DeleteLocationCustomAttributeDefinitionResponse response from the API call.</returns>
        Models.DeleteLocationCustomAttributeDefinitionResponse DeleteLocationCustomAttributeDefinition(
                string key);

        /// <summary>
        /// Deletes a location-related [custom attribute definition]($m/CustomAttributeDefinition) from a Square seller account.
        /// Deleting a custom attribute definition also deletes the corresponding custom attribute from.
        /// all locations.
        /// Only the definition owner can delete a custom attribute definition.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to delete..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteLocationCustomAttributeDefinitionResponse response from the API call.</returns>
        Task<Models.DeleteLocationCustomAttributeDefinitionResponse> DeleteLocationCustomAttributeDefinitionAsync(
                string key,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a location-related [custom attribute definition]($m/CustomAttributeDefinition) from a Square seller account.
        /// To retrieve a custom attribute definition created by another application, the `visibility`.
        /// setting must be `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to retrieve. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="version">Optional parameter: The current version of the custom attribute definition, which is used for strongly consistent reads to guarantee that you receive the most up-to-date data. When included in the request, Square returns the specified version or a higher version if one exists. If the specified version is higher than the current version, Square returns a `BAD_REQUEST` error..</param>
        /// <returns>Returns the Models.RetrieveLocationCustomAttributeDefinitionResponse response from the API call.</returns>
        Models.RetrieveLocationCustomAttributeDefinitionResponse RetrieveLocationCustomAttributeDefinition(
                string key,
                int? version = null);

        /// <summary>
        /// Retrieves a location-related [custom attribute definition]($m/CustomAttributeDefinition) from a Square seller account.
        /// To retrieve a custom attribute definition created by another application, the `visibility`.
        /// setting must be `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to retrieve. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="version">Optional parameter: The current version of the custom attribute definition, which is used for strongly consistent reads to guarantee that you receive the most up-to-date data. When included in the request, Square returns the specified version or a higher version if one exists. If the specified version is higher than the current version, Square returns a `BAD_REQUEST` error..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveLocationCustomAttributeDefinitionResponse response from the API call.</returns>
        Task<Models.RetrieveLocationCustomAttributeDefinitionResponse> RetrieveLocationCustomAttributeDefinitionAsync(
                string key,
                int? version = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a location-related [custom attribute definition]($m/CustomAttributeDefinition) for a Square seller account.
        /// Use this endpoint to update the following fields: `name`, `description`, `visibility`, or the.
        /// `schema` for a `Selection` data type.
        /// Only the definition owner can update a custom attribute definition.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateLocationCustomAttributeDefinitionResponse response from the API call.</returns>
        Models.UpdateLocationCustomAttributeDefinitionResponse UpdateLocationCustomAttributeDefinition(
                string key,
                Models.UpdateLocationCustomAttributeDefinitionRequest body);

        /// <summary>
        /// Updates a location-related [custom attribute definition]($m/CustomAttributeDefinition) for a Square seller account.
        /// Use this endpoint to update the following fields: `name`, `description`, `visibility`, or the.
        /// `schema` for a `Selection` data type.
        /// Only the definition owner can update a custom attribute definition.
        /// </summary>
        /// <param name="key">Required parameter: The key of the custom attribute definition to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateLocationCustomAttributeDefinitionResponse response from the API call.</returns>
        Task<Models.UpdateLocationCustomAttributeDefinitionResponse> UpdateLocationCustomAttributeDefinitionAsync(
                string key,
                Models.UpdateLocationCustomAttributeDefinitionRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes [custom attributes]($m/CustomAttribute) for locations as a bulk operation.
        /// To delete a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkDeleteLocationCustomAttributesResponse response from the API call.</returns>
        Models.BulkDeleteLocationCustomAttributesResponse BulkDeleteLocationCustomAttributes(
                Models.BulkDeleteLocationCustomAttributesRequest body);

        /// <summary>
        /// Deletes [custom attributes]($m/CustomAttribute) for locations as a bulk operation.
        /// To delete a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkDeleteLocationCustomAttributesResponse response from the API call.</returns>
        Task<Models.BulkDeleteLocationCustomAttributesResponse> BulkDeleteLocationCustomAttributesAsync(
                Models.BulkDeleteLocationCustomAttributesRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates or updates [custom attributes]($m/CustomAttribute) for locations as a bulk operation.
        /// Use this endpoint to set the value of one or more custom attributes for one or more locations.
        /// A custom attribute is based on a custom attribute definition in a Square seller account, which is.
        /// created using the [CreateLocationCustomAttributeDefinition]($e/LocationCustomAttributes/CreateLocationCustomAttributeDefinition) endpoint.
        /// This `BulkUpsertLocationCustomAttributes` endpoint accepts a map of 1 to 25 individual upsert.
        /// requests and returns a map of individual upsert responses. Each upsert request has a unique ID.
        /// and provides a location ID and custom attribute. Each upsert response is returned with the ID.
        /// of the corresponding request.
        /// To create or update a custom attribute owned by another application, the `visibility` setting.
        /// must be `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkUpsertLocationCustomAttributesResponse response from the API call.</returns>
        Models.BulkUpsertLocationCustomAttributesResponse BulkUpsertLocationCustomAttributes(
                Models.BulkUpsertLocationCustomAttributesRequest body);

        /// <summary>
        /// Creates or updates [custom attributes]($m/CustomAttribute) for locations as a bulk operation.
        /// Use this endpoint to set the value of one or more custom attributes for one or more locations.
        /// A custom attribute is based on a custom attribute definition in a Square seller account, which is.
        /// created using the [CreateLocationCustomAttributeDefinition]($e/LocationCustomAttributes/CreateLocationCustomAttributeDefinition) endpoint.
        /// This `BulkUpsertLocationCustomAttributes` endpoint accepts a map of 1 to 25 individual upsert.
        /// requests and returns a map of individual upsert responses. Each upsert request has a unique ID.
        /// and provides a location ID and custom attribute. Each upsert response is returned with the ID.
        /// of the corresponding request.
        /// To create or update a custom attribute owned by another application, the `visibility` setting.
        /// must be `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkUpsertLocationCustomAttributesResponse response from the API call.</returns>
        Task<Models.BulkUpsertLocationCustomAttributesResponse> BulkUpsertLocationCustomAttributesAsync(
                Models.BulkUpsertLocationCustomAttributesRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists the [custom attributes]($m/CustomAttribute) associated with a location.
        /// You can use the `with_definitions` query parameter to also retrieve custom attribute definitions.
        /// in the same call.
        /// When all response pages are retrieved, the results include all custom attributes that are.
        /// visible to the requesting application, including those that are owned by other applications.
        /// and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the target [location](entity:Location)..</param>
        /// <param name="visibilityFilter">Optional parameter: Filters the `CustomAttributeDefinition` results by their `visibility` values..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory. The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100. The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="withDefinitions">Optional parameter: Indicates whether to return the [custom attribute definition](entity:CustomAttributeDefinition) in the `definition` field of each custom attribute. Set this parameter to `true` to get the name and description of each custom attribute, information about the data type, or other definition details. The default value is `false`..</param>
        /// <returns>Returns the Models.ListLocationCustomAttributesResponse response from the API call.</returns>
        Models.ListLocationCustomAttributesResponse ListLocationCustomAttributes(
                string locationId,
                string visibilityFilter = null,
                int? limit = null,
                string cursor = null,
                bool? withDefinitions = false);

        /// <summary>
        /// Lists the [custom attributes]($m/CustomAttribute) associated with a location.
        /// You can use the `with_definitions` query parameter to also retrieve custom attribute definitions.
        /// in the same call.
        /// When all response pages are retrieved, the results include all custom attributes that are.
        /// visible to the requesting application, including those that are owned by other applications.
        /// and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the target [location](entity:Location)..</param>
        /// <param name="visibilityFilter">Optional parameter: Filters the `CustomAttributeDefinition` results by their `visibility` values..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single paged response. This limit is advisory. The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100. The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cursor">Optional parameter: The cursor returned in the paged response from the previous call to this endpoint. Provide this cursor to retrieve the next page of results for your original request. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="withDefinitions">Optional parameter: Indicates whether to return the [custom attribute definition](entity:CustomAttributeDefinition) in the `definition` field of each custom attribute. Set this parameter to `true` to get the name and description of each custom attribute, information about the data type, or other definition details. The default value is `false`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListLocationCustomAttributesResponse response from the API call.</returns>
        Task<Models.ListLocationCustomAttributesResponse> ListLocationCustomAttributesAsync(
                string locationId,
                string visibilityFilter = null,
                int? limit = null,
                string cursor = null,
                bool? withDefinitions = false,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a [custom attribute]($m/CustomAttribute) associated with a location.
        /// To delete a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the target [location](entity:Location)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to delete. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <returns>Returns the Models.DeleteLocationCustomAttributeResponse response from the API call.</returns>
        Models.DeleteLocationCustomAttributeResponse DeleteLocationCustomAttribute(
                string locationId,
                string key);

        /// <summary>
        /// Deletes a [custom attribute]($m/CustomAttribute) associated with a location.
        /// To delete a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the target [location](entity:Location)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to delete. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteLocationCustomAttributeResponse response from the API call.</returns>
        Task<Models.DeleteLocationCustomAttributeResponse> DeleteLocationCustomAttributeAsync(
                string locationId,
                string key,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a [custom attribute]($m/CustomAttribute) associated with a location.
        /// You can use the `with_definition` query parameter to also retrieve the custom attribute definition.
        /// in the same call.
        /// To retrieve a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the target [location](entity:Location)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to retrieve. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="withDefinition">Optional parameter: Indicates whether to return the [custom attribute definition](entity:CustomAttributeDefinition) in the `definition` field of the custom attribute. Set this parameter to `true` to get the name and description of the custom attribute, information about the data type, or other definition details. The default value is `false`..</param>
        /// <param name="version">Optional parameter: The current version of the custom attribute, which is used for strongly consistent reads to guarantee that you receive the most up-to-date data. When included in the request, Square returns the specified version or a higher version if one exists. If the specified version is higher than the current version, Square returns a `BAD_REQUEST` error..</param>
        /// <returns>Returns the Models.RetrieveLocationCustomAttributeResponse response from the API call.</returns>
        Models.RetrieveLocationCustomAttributeResponse RetrieveLocationCustomAttribute(
                string locationId,
                string key,
                bool? withDefinition = false,
                int? version = null);

        /// <summary>
        /// Retrieves a [custom attribute]($m/CustomAttribute) associated with a location.
        /// You can use the `with_definition` query parameter to also retrieve the custom attribute definition.
        /// in the same call.
        /// To retrieve a custom attribute owned by another application, the `visibility` setting must be.
        /// `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the target [location](entity:Location)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to retrieve. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="withDefinition">Optional parameter: Indicates whether to return the [custom attribute definition](entity:CustomAttributeDefinition) in the `definition` field of the custom attribute. Set this parameter to `true` to get the name and description of the custom attribute, information about the data type, or other definition details. The default value is `false`..</param>
        /// <param name="version">Optional parameter: The current version of the custom attribute, which is used for strongly consistent reads to guarantee that you receive the most up-to-date data. When included in the request, Square returns the specified version or a higher version if one exists. If the specified version is higher than the current version, Square returns a `BAD_REQUEST` error..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveLocationCustomAttributeResponse response from the API call.</returns>
        Task<Models.RetrieveLocationCustomAttributeResponse> RetrieveLocationCustomAttributeAsync(
                string locationId,
                string key,
                bool? withDefinition = false,
                int? version = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates or updates a [custom attribute]($m/CustomAttribute) for a location.
        /// Use this endpoint to set the value of a custom attribute for a specified location.
        /// A custom attribute is based on a custom attribute definition in a Square seller account, which.
        /// is created using the [CreateLocationCustomAttributeDefinition]($e/LocationCustomAttributes/CreateLocationCustomAttributeDefinition) endpoint.
        /// To create or update a custom attribute owned by another application, the `visibility` setting.
        /// must be `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the target [location](entity:Location)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to create or update. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpsertLocationCustomAttributeResponse response from the API call.</returns>
        Models.UpsertLocationCustomAttributeResponse UpsertLocationCustomAttribute(
                string locationId,
                string key,
                Models.UpsertLocationCustomAttributeRequest body);

        /// <summary>
        /// Creates or updates a [custom attribute]($m/CustomAttribute) for a location.
        /// Use this endpoint to set the value of a custom attribute for a specified location.
        /// A custom attribute is based on a custom attribute definition in a Square seller account, which.
        /// is created using the [CreateLocationCustomAttributeDefinition]($e/LocationCustomAttributes/CreateLocationCustomAttributeDefinition) endpoint.
        /// To create or update a custom attribute owned by another application, the `visibility` setting.
        /// must be `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the target [location](entity:Location)..</param>
        /// <param name="key">Required parameter: The key of the custom attribute to create or update. This key must match the `key` of a custom attribute definition in the Square seller account. If the requesting application is not the definition owner, you must use the qualified key..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpsertLocationCustomAttributeResponse response from the API call.</returns>
        Task<Models.UpsertLocationCustomAttributeResponse> UpsertLocationCustomAttributeAsync(
                string locationId,
                string key,
                Models.UpsertLocationCustomAttributeRequest body,
                CancellationToken cancellationToken = default);
    }
}