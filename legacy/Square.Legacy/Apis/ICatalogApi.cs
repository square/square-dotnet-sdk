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
    /// ICatalogApi.
    /// </summary>
    public interface ICatalogApi
    {
        /// <summary>
        /// Deletes a set of [CatalogItem]($m/CatalogItem)s based on the.
        /// provided list of target IDs and returns a set of successfully deleted IDs in.
        /// the response. Deletion is a cascading event such that all children of the.
        /// targeted object are also deleted. For example, deleting a CatalogItem will.
        /// also delete all of its [CatalogItemVariation]($m/CatalogItemVariation).
        /// children.
        /// `BatchDeleteCatalogObjects` succeeds even if only a portion of the targeted.
        /// IDs can be deleted. The response will only include IDs that were.
        /// actually deleted.
        /// To ensure consistency, only one delete request is processed at a time per seller account.
        /// While one (batch or non-batch) delete request is being processed, other (batched and non-batched).
        /// delete requests are rejected with the `429` error code.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BatchDeleteCatalogObjectsResponse response from the API call.</returns>
        Models.BatchDeleteCatalogObjectsResponse BatchDeleteCatalogObjects(
            Models.BatchDeleteCatalogObjectsRequest body
        );

        /// <summary>
        /// Deletes a set of [CatalogItem]($m/CatalogItem)s based on the.
        /// provided list of target IDs and returns a set of successfully deleted IDs in.
        /// the response. Deletion is a cascading event such that all children of the.
        /// targeted object are also deleted. For example, deleting a CatalogItem will.
        /// also delete all of its [CatalogItemVariation]($m/CatalogItemVariation).
        /// children.
        /// `BatchDeleteCatalogObjects` succeeds even if only a portion of the targeted.
        /// IDs can be deleted. The response will only include IDs that were.
        /// actually deleted.
        /// To ensure consistency, only one delete request is processed at a time per seller account.
        /// While one (batch or non-batch) delete request is being processed, other (batched and non-batched).
        /// delete requests are rejected with the `429` error code.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BatchDeleteCatalogObjectsResponse response from the API call.</returns>
        Task<Models.BatchDeleteCatalogObjectsResponse> BatchDeleteCatalogObjectsAsync(
            Models.BatchDeleteCatalogObjectsRequest body,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Returns a set of objects based on the provided ID.
        /// Each [CatalogItem]($m/CatalogItem) returned in the set includes all of its.
        /// child information including: all of its.
        /// [CatalogItemVariation]($m/CatalogItemVariation) objects, references to.
        /// its [CatalogModifierList]($m/CatalogModifierList) objects, and the ids of.
        /// any [CatalogTax]($m/CatalogTax) objects that apply to it.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BatchRetrieveCatalogObjectsResponse response from the API call.</returns>
        Models.BatchRetrieveCatalogObjectsResponse BatchRetrieveCatalogObjects(
            Models.BatchRetrieveCatalogObjectsRequest body
        );

        /// <summary>
        /// Returns a set of objects based on the provided ID.
        /// Each [CatalogItem]($m/CatalogItem) returned in the set includes all of its.
        /// child information including: all of its.
        /// [CatalogItemVariation]($m/CatalogItemVariation) objects, references to.
        /// its [CatalogModifierList]($m/CatalogModifierList) objects, and the ids of.
        /// any [CatalogTax]($m/CatalogTax) objects that apply to it.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BatchRetrieveCatalogObjectsResponse response from the API call.</returns>
        Task<Models.BatchRetrieveCatalogObjectsResponse> BatchRetrieveCatalogObjectsAsync(
            Models.BatchRetrieveCatalogObjectsRequest body,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Creates or updates up to 10,000 target objects based on the provided.
        /// list of objects. The target objects are grouped into batches and each batch is.
        /// inserted/updated in an all-or-nothing manner. If an object within a batch is.
        /// malformed in some way, or violates a database constraint, the entire batch.
        /// containing that item will be disregarded. However, other batches in the same.
        /// request may still succeed. Each batch may contain up to 1,000 objects, and.
        /// batches will be processed in order as long as the total object count for the.
        /// request (items, variations, modifier lists, discounts, and taxes) is no more.
        /// than 10,000.
        /// To ensure consistency, only one update request is processed at a time per seller account.
        /// While one (batch or non-batch) update request is being processed, other (batched and non-batched).
        /// update requests are rejected with the `429` error code.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BatchUpsertCatalogObjectsResponse response from the API call.</returns>
        Models.BatchUpsertCatalogObjectsResponse BatchUpsertCatalogObjects(
            Models.BatchUpsertCatalogObjectsRequest body
        );

        /// <summary>
        /// Creates or updates up to 10,000 target objects based on the provided.
        /// list of objects. The target objects are grouped into batches and each batch is.
        /// inserted/updated in an all-or-nothing manner. If an object within a batch is.
        /// malformed in some way, or violates a database constraint, the entire batch.
        /// containing that item will be disregarded. However, other batches in the same.
        /// request may still succeed. Each batch may contain up to 1,000 objects, and.
        /// batches will be processed in order as long as the total object count for the.
        /// request (items, variations, modifier lists, discounts, and taxes) is no more.
        /// than 10,000.
        /// To ensure consistency, only one update request is processed at a time per seller account.
        /// While one (batch or non-batch) update request is being processed, other (batched and non-batched).
        /// update requests are rejected with the `429` error code.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BatchUpsertCatalogObjectsResponse response from the API call.</returns>
        Task<Models.BatchUpsertCatalogObjectsResponse> BatchUpsertCatalogObjectsAsync(
            Models.BatchUpsertCatalogObjectsRequest body,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Uploads an image file to be represented by a [CatalogImage]($m/CatalogImage) object that can be linked to an existing.
        /// [CatalogObject]($m/CatalogObject) instance. The resulting `CatalogImage` is unattached to any `CatalogObject` if the `object_id`.
        /// is not specified.
        /// This `CreateCatalogImage` endpoint accepts HTTP multipart/form-data requests with a JSON part and an image file part in.
        /// JPEG, PJPEG, PNG, or GIF format. The maximum file size is 15MB.
        /// </summary>
        /// <param name="request">Optional parameter: Example: .</param>
        /// <param name="imageFile">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.CreateCatalogImageResponse response from the API call.</returns>
        Models.CreateCatalogImageResponse CreateCatalogImage(
            Models.CreateCatalogImageRequest request = null,
            FileStreamInfo imageFile = null
        );

        /// <summary>
        /// Uploads an image file to be represented by a [CatalogImage]($m/CatalogImage) object that can be linked to an existing.
        /// [CatalogObject]($m/CatalogObject) instance. The resulting `CatalogImage` is unattached to any `CatalogObject` if the `object_id`.
        /// is not specified.
        /// This `CreateCatalogImage` endpoint accepts HTTP multipart/form-data requests with a JSON part and an image file part in.
        /// JPEG, PJPEG, PNG, or GIF format. The maximum file size is 15MB.
        /// </summary>
        /// <param name="request">Optional parameter: Example: .</param>
        /// <param name="imageFile">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateCatalogImageResponse response from the API call.</returns>
        Task<Models.CreateCatalogImageResponse> CreateCatalogImageAsync(
            Models.CreateCatalogImageRequest request = null,
            FileStreamInfo imageFile = null,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Uploads a new image file to replace the existing one in the specified [CatalogImage]($m/CatalogImage) object.
        /// This `UpdateCatalogImage` endpoint accepts HTTP multipart/form-data requests with a JSON part and an image file part in.
        /// JPEG, PJPEG, PNG, or GIF format. The maximum file size is 15MB.
        /// </summary>
        /// <param name="imageId">Required parameter: The ID of the `CatalogImage` object to update the encapsulated image file..</param>
        /// <param name="request">Optional parameter: Example: .</param>
        /// <param name="imageFile">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.UpdateCatalogImageResponse response from the API call.</returns>
        Models.UpdateCatalogImageResponse UpdateCatalogImage(
            string imageId,
            Models.UpdateCatalogImageRequest request = null,
            FileStreamInfo imageFile = null
        );

        /// <summary>
        /// Uploads a new image file to replace the existing one in the specified [CatalogImage]($m/CatalogImage) object.
        /// This `UpdateCatalogImage` endpoint accepts HTTP multipart/form-data requests with a JSON part and an image file part in.
        /// JPEG, PJPEG, PNG, or GIF format. The maximum file size is 15MB.
        /// </summary>
        /// <param name="imageId">Required parameter: The ID of the `CatalogImage` object to update the encapsulated image file..</param>
        /// <param name="request">Optional parameter: Example: .</param>
        /// <param name="imageFile">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateCatalogImageResponse response from the API call.</returns>
        Task<Models.UpdateCatalogImageResponse> UpdateCatalogImageAsync(
            string imageId,
            Models.UpdateCatalogImageRequest request = null,
            FileStreamInfo imageFile = null,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Retrieves information about the Square Catalog API, such as batch size.
        /// limits that can be used by the `BatchUpsertCatalogObjects` endpoint.
        /// </summary>
        /// <returns>Returns the Models.CatalogInfoResponse response from the API call.</returns>
        Models.CatalogInfoResponse CatalogInfo();

        /// <summary>
        /// Retrieves information about the Square Catalog API, such as batch size.
        /// limits that can be used by the `BatchUpsertCatalogObjects` endpoint.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CatalogInfoResponse response from the API call.</returns>
        Task<Models.CatalogInfoResponse> CatalogInfoAsync(
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Returns a list of all [CatalogObject]($m/CatalogObject)s of the specified types in the catalog.
        /// The `types` parameter is specified as a comma-separated list of the [CatalogObjectType]($m/CatalogObjectType) values,.
        /// for example, "`ITEM`, `ITEM_VARIATION`, `MODIFIER`, `MODIFIER_LIST`, `CATEGORY`, `DISCOUNT`, `TAX`, `IMAGE`".
        /// __Important:__ ListCatalog does not return deleted catalog items. To retrieve.
        /// deleted catalog items, use [SearchCatalogObjects]($e/Catalog/SearchCatalogObjects).
        /// and set the `include_deleted_objects` attribute value to `true`.
        /// </summary>
        /// <param name="cursor">Optional parameter: The pagination cursor returned in the previous response. Leave unset for an initial request. The page size is currently set to be 100. See [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination) for more information..</param>
        /// <param name="types">Optional parameter: An optional case-insensitive, comma-separated list of object types to retrieve.  The valid values are defined in the [CatalogObjectType](entity:CatalogObjectType) enum, for example, `ITEM`, `ITEM_VARIATION`, `CATEGORY`, `DISCOUNT`, `TAX`, `MODIFIER`, `MODIFIER_LIST`, `IMAGE`, etc.  If this is unspecified, the operation returns objects of all the top level types at the version of the Square API used to make the request. Object types that are nested onto other object types are not included in the defaults.  At the current API version the default object types are: ITEM, CATEGORY, TAX, DISCOUNT, MODIFIER_LIST,  PRICING_RULE, PRODUCT_SET, TIME_PERIOD, MEASUREMENT_UNIT, SUBSCRIPTION_PLAN, ITEM_OPTION, CUSTOM_ATTRIBUTE_DEFINITION, QUICK_AMOUNT_SETTINGS..</param>
        /// <param name="catalogVersion">Optional parameter: The specific version of the catalog objects to be included in the response. This allows you to retrieve historical versions of objects. The specified version value is matched against the [CatalogObject]($m/CatalogObject)s' `version` attribute.  If not included, results will be from the current version of the catalog..</param>
        /// <returns>Returns the Models.ListCatalogResponse response from the API call.</returns>
        Models.ListCatalogResponse ListCatalog(
            string cursor = null,
            string types = null,
            long? catalogVersion = null
        );

        /// <summary>
        /// Returns a list of all [CatalogObject]($m/CatalogObject)s of the specified types in the catalog.
        /// The `types` parameter is specified as a comma-separated list of the [CatalogObjectType]($m/CatalogObjectType) values,.
        /// for example, "`ITEM`, `ITEM_VARIATION`, `MODIFIER`, `MODIFIER_LIST`, `CATEGORY`, `DISCOUNT`, `TAX`, `IMAGE`".
        /// __Important:__ ListCatalog does not return deleted catalog items. To retrieve.
        /// deleted catalog items, use [SearchCatalogObjects]($e/Catalog/SearchCatalogObjects).
        /// and set the `include_deleted_objects` attribute value to `true`.
        /// </summary>
        /// <param name="cursor">Optional parameter: The pagination cursor returned in the previous response. Leave unset for an initial request. The page size is currently set to be 100. See [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination) for more information..</param>
        /// <param name="types">Optional parameter: An optional case-insensitive, comma-separated list of object types to retrieve.  The valid values are defined in the [CatalogObjectType](entity:CatalogObjectType) enum, for example, `ITEM`, `ITEM_VARIATION`, `CATEGORY`, `DISCOUNT`, `TAX`, `MODIFIER`, `MODIFIER_LIST`, `IMAGE`, etc.  If this is unspecified, the operation returns objects of all the top level types at the version of the Square API used to make the request. Object types that are nested onto other object types are not included in the defaults.  At the current API version the default object types are: ITEM, CATEGORY, TAX, DISCOUNT, MODIFIER_LIST,  PRICING_RULE, PRODUCT_SET, TIME_PERIOD, MEASUREMENT_UNIT, SUBSCRIPTION_PLAN, ITEM_OPTION, CUSTOM_ATTRIBUTE_DEFINITION, QUICK_AMOUNT_SETTINGS..</param>
        /// <param name="catalogVersion">Optional parameter: The specific version of the catalog objects to be included in the response. This allows you to retrieve historical versions of objects. The specified version value is matched against the [CatalogObject]($m/CatalogObject)s' `version` attribute.  If not included, results will be from the current version of the catalog..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListCatalogResponse response from the API call.</returns>
        Task<Models.ListCatalogResponse> ListCatalogAsync(
            string cursor = null,
            string types = null,
            long? catalogVersion = null,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Creates a new or updates the specified [CatalogObject]($m/CatalogObject).
        /// To ensure consistency, only one update request is processed at a time per seller account.
        /// While one (batch or non-batch) update request is being processed, other (batched and non-batched).
        /// update requests are rejected with the `429` error code.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpsertCatalogObjectResponse response from the API call.</returns>
        Models.UpsertCatalogObjectResponse UpsertCatalogObject(
            Models.UpsertCatalogObjectRequest body
        );

        /// <summary>
        /// Creates a new or updates the specified [CatalogObject]($m/CatalogObject).
        /// To ensure consistency, only one update request is processed at a time per seller account.
        /// While one (batch or non-batch) update request is being processed, other (batched and non-batched).
        /// update requests are rejected with the `429` error code.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpsertCatalogObjectResponse response from the API call.</returns>
        Task<Models.UpsertCatalogObjectResponse> UpsertCatalogObjectAsync(
            Models.UpsertCatalogObjectRequest body,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Deletes a single [CatalogObject]($m/CatalogObject) based on the.
        /// provided ID and returns the set of successfully deleted IDs in the response.
        /// Deletion is a cascading event such that all children of the targeted object.
        /// are also deleted. For example, deleting a [CatalogItem]($m/CatalogItem).
        /// will also delete all of its.
        /// [CatalogItemVariation]($m/CatalogItemVariation) children.
        /// To ensure consistency, only one delete request is processed at a time per seller account.
        /// While one (batch or non-batch) delete request is being processed, other (batched and non-batched).
        /// delete requests are rejected with the `429` error code.
        /// </summary>
        /// <param name="objectId">Required parameter: The ID of the catalog object to be deleted. When an object is deleted, other objects in the graph that depend on that object will be deleted as well (for example, deleting a catalog item will delete its catalog item variations)..</param>
        /// <returns>Returns the Models.DeleteCatalogObjectResponse response from the API call.</returns>
        Models.DeleteCatalogObjectResponse DeleteCatalogObject(string objectId);

        /// <summary>
        /// Deletes a single [CatalogObject]($m/CatalogObject) based on the.
        /// provided ID and returns the set of successfully deleted IDs in the response.
        /// Deletion is a cascading event such that all children of the targeted object.
        /// are also deleted. For example, deleting a [CatalogItem]($m/CatalogItem).
        /// will also delete all of its.
        /// [CatalogItemVariation]($m/CatalogItemVariation) children.
        /// To ensure consistency, only one delete request is processed at a time per seller account.
        /// While one (batch or non-batch) delete request is being processed, other (batched and non-batched).
        /// delete requests are rejected with the `429` error code.
        /// </summary>
        /// <param name="objectId">Required parameter: The ID of the catalog object to be deleted. When an object is deleted, other objects in the graph that depend on that object will be deleted as well (for example, deleting a catalog item will delete its catalog item variations)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteCatalogObjectResponse response from the API call.</returns>
        Task<Models.DeleteCatalogObjectResponse> DeleteCatalogObjectAsync(
            string objectId,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Returns a single [CatalogItem]($m/CatalogItem) as a.
        /// [CatalogObject]($m/CatalogObject) based on the provided ID. The returned.
        /// object includes all of the relevant [CatalogItem]($m/CatalogItem).
        /// information including: [CatalogItemVariation]($m/CatalogItemVariation).
        /// children, references to its.
        /// [CatalogModifierList]($m/CatalogModifierList) objects, and the ids of.
        /// any [CatalogTax]($m/CatalogTax) objects that apply to it.
        /// </summary>
        /// <param name="objectId">Required parameter: The object ID of any type of catalog objects to be retrieved..</param>
        /// <param name="includeRelatedObjects">Optional parameter: If `true`, the response will include additional objects that are related to the requested objects. Related objects are defined as any objects referenced by ID by the results in the `objects` field of the response. These objects are put in the `related_objects` field. Setting this to `true` is helpful when the objects are needed for immediate display to a user. This process only goes one level deep. Objects referenced by the related objects will not be included. For example,  if the `objects` field of the response contains a CatalogItem, its associated CatalogCategory objects, CatalogTax objects, CatalogImage objects and CatalogModifierLists will be returned in the `related_objects` field of the response. If the `objects` field of the response contains a CatalogItemVariation, its parent CatalogItem will be returned in the `related_objects` field of the response.  Default value: `false`.</param>
        /// <param name="catalogVersion">Optional parameter: Requests objects as of a specific version of the catalog. This allows you to retrieve historical versions of objects. The value to retrieve a specific version of an object can be found in the version field of [CatalogObject]($m/CatalogObject)s. If not included, results will be from the current version of the catalog..</param>
        /// <param name="includeCategoryPathToRoot">Optional parameter: Specifies whether or not to include the `path_to_root` list for each returned category instance. The `path_to_root` list consists of `CategoryPathToRootNode` objects and specifies the path that starts with the immediate parent category of the returned category and ends with its root category. If the returned category is a top-level category, the `path_to_root` list is empty and is not returned in the response payload..</param>
        /// <returns>Returns the Models.RetrieveCatalogObjectResponse response from the API call.</returns>
        Models.RetrieveCatalogObjectResponse RetrieveCatalogObject(
            string objectId,
            bool? includeRelatedObjects = false,
            long? catalogVersion = null,
            bool? includeCategoryPathToRoot = false
        );

        /// <summary>
        /// Returns a single [CatalogItem]($m/CatalogItem) as a.
        /// [CatalogObject]($m/CatalogObject) based on the provided ID. The returned.
        /// object includes all of the relevant [CatalogItem]($m/CatalogItem).
        /// information including: [CatalogItemVariation]($m/CatalogItemVariation).
        /// children, references to its.
        /// [CatalogModifierList]($m/CatalogModifierList) objects, and the ids of.
        /// any [CatalogTax]($m/CatalogTax) objects that apply to it.
        /// </summary>
        /// <param name="objectId">Required parameter: The object ID of any type of catalog objects to be retrieved..</param>
        /// <param name="includeRelatedObjects">Optional parameter: If `true`, the response will include additional objects that are related to the requested objects. Related objects are defined as any objects referenced by ID by the results in the `objects` field of the response. These objects are put in the `related_objects` field. Setting this to `true` is helpful when the objects are needed for immediate display to a user. This process only goes one level deep. Objects referenced by the related objects will not be included. For example,  if the `objects` field of the response contains a CatalogItem, its associated CatalogCategory objects, CatalogTax objects, CatalogImage objects and CatalogModifierLists will be returned in the `related_objects` field of the response. If the `objects` field of the response contains a CatalogItemVariation, its parent CatalogItem will be returned in the `related_objects` field of the response.  Default value: `false`.</param>
        /// <param name="catalogVersion">Optional parameter: Requests objects as of a specific version of the catalog. This allows you to retrieve historical versions of objects. The value to retrieve a specific version of an object can be found in the version field of [CatalogObject]($m/CatalogObject)s. If not included, results will be from the current version of the catalog..</param>
        /// <param name="includeCategoryPathToRoot">Optional parameter: Specifies whether or not to include the `path_to_root` list for each returned category instance. The `path_to_root` list consists of `CategoryPathToRootNode` objects and specifies the path that starts with the immediate parent category of the returned category and ends with its root category. If the returned category is a top-level category, the `path_to_root` list is empty and is not returned in the response payload..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveCatalogObjectResponse response from the API call.</returns>
        Task<Models.RetrieveCatalogObjectResponse> RetrieveCatalogObjectAsync(
            string objectId,
            bool? includeRelatedObjects = false,
            long? catalogVersion = null,
            bool? includeCategoryPathToRoot = false,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Searches for [CatalogObject]($m/CatalogObject) of any type by matching supported search attribute values,.
        /// excluding custom attribute values on items or item variations, against one or more of the specified query filters.
        /// This (`SearchCatalogObjects`) endpoint differs from the [SearchCatalogItems]($e/Catalog/SearchCatalogItems).
        /// endpoint in the following aspects:.
        /// - `SearchCatalogItems` can only search for items or item variations, whereas `SearchCatalogObjects` can search for any type of catalog objects.
        /// - `SearchCatalogItems` supports the custom attribute query filters to return items or item variations that contain custom attribute values, where `SearchCatalogObjects` does not.
        /// - `SearchCatalogItems` does not support the `include_deleted_objects` filter to search for deleted items or item variations, whereas `SearchCatalogObjects` does.
        /// - The both endpoints have different call conventions, including the query filter formats.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchCatalogObjectsResponse response from the API call.</returns>
        Models.SearchCatalogObjectsResponse SearchCatalogObjects(
            Models.SearchCatalogObjectsRequest body
        );

        /// <summary>
        /// Searches for [CatalogObject]($m/CatalogObject) of any type by matching supported search attribute values,.
        /// excluding custom attribute values on items or item variations, against one or more of the specified query filters.
        /// This (`SearchCatalogObjects`) endpoint differs from the [SearchCatalogItems]($e/Catalog/SearchCatalogItems).
        /// endpoint in the following aspects:.
        /// - `SearchCatalogItems` can only search for items or item variations, whereas `SearchCatalogObjects` can search for any type of catalog objects.
        /// - `SearchCatalogItems` supports the custom attribute query filters to return items or item variations that contain custom attribute values, where `SearchCatalogObjects` does not.
        /// - `SearchCatalogItems` does not support the `include_deleted_objects` filter to search for deleted items or item variations, whereas `SearchCatalogObjects` does.
        /// - The both endpoints have different call conventions, including the query filter formats.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchCatalogObjectsResponse response from the API call.</returns>
        Task<Models.SearchCatalogObjectsResponse> SearchCatalogObjectsAsync(
            Models.SearchCatalogObjectsRequest body,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Searches for catalog items or item variations by matching supported search attribute values, including.
        /// custom attribute values, against one or more of the specified query filters.
        /// This (`SearchCatalogItems`) endpoint differs from the [SearchCatalogObjects]($e/Catalog/SearchCatalogObjects).
        /// endpoint in the following aspects:.
        /// - `SearchCatalogItems` can only search for items or item variations, whereas `SearchCatalogObjects` can search for any type of catalog objects.
        /// - `SearchCatalogItems` supports the custom attribute query filters to return items or item variations that contain custom attribute values, where `SearchCatalogObjects` does not.
        /// - `SearchCatalogItems` does not support the `include_deleted_objects` filter to search for deleted items or item variations, whereas `SearchCatalogObjects` does.
        /// - The both endpoints use different call conventions, including the query filter formats.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchCatalogItemsResponse response from the API call.</returns>
        Models.SearchCatalogItemsResponse SearchCatalogItems(Models.SearchCatalogItemsRequest body);

        /// <summary>
        /// Searches for catalog items or item variations by matching supported search attribute values, including.
        /// custom attribute values, against one or more of the specified query filters.
        /// This (`SearchCatalogItems`) endpoint differs from the [SearchCatalogObjects]($e/Catalog/SearchCatalogObjects).
        /// endpoint in the following aspects:.
        /// - `SearchCatalogItems` can only search for items or item variations, whereas `SearchCatalogObjects` can search for any type of catalog objects.
        /// - `SearchCatalogItems` supports the custom attribute query filters to return items or item variations that contain custom attribute values, where `SearchCatalogObjects` does not.
        /// - `SearchCatalogItems` does not support the `include_deleted_objects` filter to search for deleted items or item variations, whereas `SearchCatalogObjects` does.
        /// - The both endpoints use different call conventions, including the query filter formats.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchCatalogItemsResponse response from the API call.</returns>
        Task<Models.SearchCatalogItemsResponse> SearchCatalogItemsAsync(
            Models.SearchCatalogItemsRequest body,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Updates the [CatalogModifierList]($m/CatalogModifierList) objects.
        /// that apply to the targeted [CatalogItem]($m/CatalogItem) without having.
        /// to perform an upsert on the entire item.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateItemModifierListsResponse response from the API call.</returns>
        Models.UpdateItemModifierListsResponse UpdateItemModifierLists(
            Models.UpdateItemModifierListsRequest body
        );

        /// <summary>
        /// Updates the [CatalogModifierList]($m/CatalogModifierList) objects.
        /// that apply to the targeted [CatalogItem]($m/CatalogItem) without having.
        /// to perform an upsert on the entire item.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateItemModifierListsResponse response from the API call.</returns>
        Task<Models.UpdateItemModifierListsResponse> UpdateItemModifierListsAsync(
            Models.UpdateItemModifierListsRequest body,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Updates the [CatalogTax]($m/CatalogTax) objects that apply to the.
        /// targeted [CatalogItem]($m/CatalogItem) without having to perform an.
        /// upsert on the entire item.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateItemTaxesResponse response from the API call.</returns>
        Models.UpdateItemTaxesResponse UpdateItemTaxes(Models.UpdateItemTaxesRequest body);

        /// <summary>
        /// Updates the [CatalogTax]($m/CatalogTax) objects that apply to the.
        /// targeted [CatalogItem]($m/CatalogItem) without having to perform an.
        /// upsert on the entire item.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateItemTaxesResponse response from the API call.</returns>
        Task<Models.UpdateItemTaxesResponse> UpdateItemTaxesAsync(
            Models.UpdateItemTaxesRequest body,
            CancellationToken cancellationToken = default
        );
    }
}
