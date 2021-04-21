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
        /// children..
        /// `BatchDeleteCatalogObjects` succeeds even if only a portion of the targeted.
        /// IDs can be deleted. The response will only include IDs that were.
        /// actually deleted..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BatchDeleteCatalogObjectsResponse response from the API call.</returns>
        Models.BatchDeleteCatalogObjectsResponse BatchDeleteCatalogObjects(
                Models.BatchDeleteCatalogObjectsRequest body);

        /// <summary>
        /// Deletes a set of [CatalogItem]($m/CatalogItem)s based on the.
        /// provided list of target IDs and returns a set of successfully deleted IDs in.
        /// the response. Deletion is a cascading event such that all children of the.
        /// targeted object are also deleted. For example, deleting a CatalogItem will.
        /// also delete all of its [CatalogItemVariation]($m/CatalogItemVariation).
        /// children..
        /// `BatchDeleteCatalogObjects` succeeds even if only a portion of the targeted.
        /// IDs can be deleted. The response will only include IDs that were.
        /// actually deleted..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BatchDeleteCatalogObjectsResponse response from the API call.</returns>
        Task<Models.BatchDeleteCatalogObjectsResponse> BatchDeleteCatalogObjectsAsync(
                Models.BatchDeleteCatalogObjectsRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a set of objects based on the provided ID..
        /// Each [CatalogItem]($m/CatalogItem) returned in the set includes all of its.
        /// child information including: all of its.
        /// [CatalogItemVariation]($m/CatalogItemVariation) objects, references to.
        /// its [CatalogModifierList]($m/CatalogModifierList) objects, and the ids of.
        /// any [CatalogTax]($m/CatalogTax) objects that apply to it..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BatchRetrieveCatalogObjectsResponse response from the API call.</returns>
        Models.BatchRetrieveCatalogObjectsResponse BatchRetrieveCatalogObjects(
                Models.BatchRetrieveCatalogObjectsRequest body);

        /// <summary>
        /// Returns a set of objects based on the provided ID..
        /// Each [CatalogItem]($m/CatalogItem) returned in the set includes all of its.
        /// child information including: all of its.
        /// [CatalogItemVariation]($m/CatalogItemVariation) objects, references to.
        /// its [CatalogModifierList]($m/CatalogModifierList) objects, and the ids of.
        /// any [CatalogTax]($m/CatalogTax) objects that apply to it..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BatchRetrieveCatalogObjectsResponse response from the API call.</returns>
        Task<Models.BatchRetrieveCatalogObjectsResponse> BatchRetrieveCatalogObjectsAsync(
                Models.BatchRetrieveCatalogObjectsRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates or updates up to 10,000 target objects based on the provided.
        /// list of objects. The target objects are grouped into batches and each batch is.
        /// inserted/updated in an all-or-nothing manner. If an object within a batch is.
        /// malformed in some way, or violates a database constraint, the entire batch.
        /// containing that item will be disregarded. However, other batches in the same.
        /// request may still succeed. Each batch may contain up to 1,000 objects, and.
        /// batches will be processed in order as long as the total object count for the.
        /// request (items, variations, modifier lists, discounts, and taxes) is no more.
        /// than 10,000..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BatchUpsertCatalogObjectsResponse response from the API call.</returns>
        Models.BatchUpsertCatalogObjectsResponse BatchUpsertCatalogObjects(
                Models.BatchUpsertCatalogObjectsRequest body);

        /// <summary>
        /// Creates or updates up to 10,000 target objects based on the provided.
        /// list of objects. The target objects are grouped into batches and each batch is.
        /// inserted/updated in an all-or-nothing manner. If an object within a batch is.
        /// malformed in some way, or violates a database constraint, the entire batch.
        /// containing that item will be disregarded. However, other batches in the same.
        /// request may still succeed. Each batch may contain up to 1,000 objects, and.
        /// batches will be processed in order as long as the total object count for the.
        /// request (items, variations, modifier lists, discounts, and taxes) is no more.
        /// than 10,000..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BatchUpsertCatalogObjectsResponse response from the API call.</returns>
        Task<Models.BatchUpsertCatalogObjectsResponse> BatchUpsertCatalogObjectsAsync(
                Models.BatchUpsertCatalogObjectsRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Uploads an image file to be represented by a [CatalogImage]($m/CatalogImage) object linked to an existing.
        /// [CatalogObject]($m/CatalogObject) instance. A call to this endpoint can upload an image, link an image to.
        /// a catalog object, or do both..
        /// This `CreateCatalogImage` endpoint accepts HTTP multipart/form-data requests with a JSON part and an image file part in.
        /// JPEG, PJPEG, PNG, or GIF format. The maximum file size is 15MB..
        /// </summary>
        /// <param name="request">Optional parameter: Example: .</param>
        /// <param name="imageFile">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.CreateCatalogImageResponse response from the API call.</returns>
        Models.CreateCatalogImageResponse CreateCatalogImage(
                Models.CreateCatalogImageRequest request = null,
                FileStreamInfo imageFile = null);

        /// <summary>
        /// Uploads an image file to be represented by a [CatalogImage]($m/CatalogImage) object linked to an existing.
        /// [CatalogObject]($m/CatalogObject) instance. A call to this endpoint can upload an image, link an image to.
        /// a catalog object, or do both..
        /// This `CreateCatalogImage` endpoint accepts HTTP multipart/form-data requests with a JSON part and an image file part in.
        /// JPEG, PJPEG, PNG, or GIF format. The maximum file size is 15MB..
        /// </summary>
        /// <param name="request">Optional parameter: Example: .</param>
        /// <param name="imageFile">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateCatalogImageResponse response from the API call.</returns>
        Task<Models.CreateCatalogImageResponse> CreateCatalogImageAsync(
                Models.CreateCatalogImageRequest request = null,
                FileStreamInfo imageFile = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves information about the Square Catalog API, such as batch size.
        /// limits that can be used by the `BatchUpsertCatalogObjects` endpoint..
        /// </summary>
        /// <returns>Returns the Models.CatalogInfoResponse response from the API call.</returns>
        Models.CatalogInfoResponse CatalogInfo();

        /// <summary>
        /// Retrieves information about the Square Catalog API, such as batch size.
        /// limits that can be used by the `BatchUpsertCatalogObjects` endpoint..
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CatalogInfoResponse response from the API call.</returns>
        Task<Models.CatalogInfoResponse> CatalogInfoAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a list of [CatalogObject]($m/CatalogObject)s that includes.
        /// all objects of a set of desired types (for example, all [CatalogItem]($m/CatalogItem).
        /// and [CatalogTax]($m/CatalogTax) objects) in the catalog. The `types` parameter.
        /// is specified as a comma-separated list of valid [CatalogObject]($m/CatalogObject) types:.
        /// `ITEM`, `ITEM_VARIATION`, `MODIFIER`, `MODIFIER_LIST`, `CATEGORY`, `DISCOUNT`, `TAX`, `IMAGE`..
        /// __Important:__ ListCatalog does not return deleted catalog items. To retrieve.
        /// deleted catalog items, use [SearchCatalogObjects]($e/Catalog/SearchCatalogObjects).
        /// and set the `include_deleted_objects` attribute value to `true`..
        /// </summary>
        /// <param name="cursor">Optional parameter: The pagination cursor returned in the previous response. Leave unset for an initial request. See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information..</param>
        /// <param name="types">Optional parameter: An optional case-insensitive, comma-separated list of object types to retrieve, for example `ITEM,ITEM_VARIATION,CATEGORY,IMAGE`.  The legal values are taken from the CatalogObjectType enum: `ITEM`, `ITEM_VARIATION`, `CATEGORY`, `DISCOUNT`, `TAX`, `MODIFIER`, `MODIFIER_LIST`, or `IMAGE`..</param>
        /// <param name="catalogVersion">Optional parameter: The specific version of the catalog objects to be included in the response.  This allows you to retrieve historical versions of objects. The specified version value is matched against the [CatalogObject]($m/CatalogObject)s' `version` attribute..</param>
        /// <returns>Returns the Models.ListCatalogResponse response from the API call.</returns>
        Models.ListCatalogResponse ListCatalog(
                string cursor = null,
                string types = null,
                long? catalogVersion = null);

        /// <summary>
        /// Returns a list of [CatalogObject]($m/CatalogObject)s that includes.
        /// all objects of a set of desired types (for example, all [CatalogItem]($m/CatalogItem).
        /// and [CatalogTax]($m/CatalogTax) objects) in the catalog. The `types` parameter.
        /// is specified as a comma-separated list of valid [CatalogObject]($m/CatalogObject) types:.
        /// `ITEM`, `ITEM_VARIATION`, `MODIFIER`, `MODIFIER_LIST`, `CATEGORY`, `DISCOUNT`, `TAX`, `IMAGE`..
        /// __Important:__ ListCatalog does not return deleted catalog items. To retrieve.
        /// deleted catalog items, use [SearchCatalogObjects]($e/Catalog/SearchCatalogObjects).
        /// and set the `include_deleted_objects` attribute value to `true`..
        /// </summary>
        /// <param name="cursor">Optional parameter: The pagination cursor returned in the previous response. Leave unset for an initial request. See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information..</param>
        /// <param name="types">Optional parameter: An optional case-insensitive, comma-separated list of object types to retrieve, for example `ITEM,ITEM_VARIATION,CATEGORY,IMAGE`.  The legal values are taken from the CatalogObjectType enum: `ITEM`, `ITEM_VARIATION`, `CATEGORY`, `DISCOUNT`, `TAX`, `MODIFIER`, `MODIFIER_LIST`, or `IMAGE`..</param>
        /// <param name="catalogVersion">Optional parameter: The specific version of the catalog objects to be included in the response.  This allows you to retrieve historical versions of objects. The specified version value is matched against the [CatalogObject]($m/CatalogObject)s' `version` attribute..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListCatalogResponse response from the API call.</returns>
        Task<Models.ListCatalogResponse> ListCatalogAsync(
                string cursor = null,
                string types = null,
                long? catalogVersion = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates or updates the target [CatalogObject]($m/CatalogObject)..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpsertCatalogObjectResponse response from the API call.</returns>
        Models.UpsertCatalogObjectResponse UpsertCatalogObject(
                Models.UpsertCatalogObjectRequest body);

        /// <summary>
        /// Creates or updates the target [CatalogObject]($m/CatalogObject)..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpsertCatalogObjectResponse response from the API call.</returns>
        Task<Models.UpsertCatalogObjectResponse> UpsertCatalogObjectAsync(
                Models.UpsertCatalogObjectRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a single [CatalogObject]($m/CatalogObject) based on the.
        /// provided ID and returns the set of successfully deleted IDs in the response..
        /// Deletion is a cascading event such that all children of the targeted object.
        /// are also deleted. For example, deleting a [CatalogItem]($m/CatalogItem).
        /// will also delete all of its.
        /// [CatalogItemVariation]($m/CatalogItemVariation) children..
        /// </summary>
        /// <param name="objectId">Required parameter: The ID of the catalog object to be deleted. When an object is deleted, other objects in the graph that depend on that object will be deleted as well (for example, deleting a catalog item will delete its catalog item variations)..</param>
        /// <returns>Returns the Models.DeleteCatalogObjectResponse response from the API call.</returns>
        Models.DeleteCatalogObjectResponse DeleteCatalogObject(
                string objectId);

        /// <summary>
        /// Deletes a single [CatalogObject]($m/CatalogObject) based on the.
        /// provided ID and returns the set of successfully deleted IDs in the response..
        /// Deletion is a cascading event such that all children of the targeted object.
        /// are also deleted. For example, deleting a [CatalogItem]($m/CatalogItem).
        /// will also delete all of its.
        /// [CatalogItemVariation]($m/CatalogItemVariation) children..
        /// </summary>
        /// <param name="objectId">Required parameter: The ID of the catalog object to be deleted. When an object is deleted, other objects in the graph that depend on that object will be deleted as well (for example, deleting a catalog item will delete its catalog item variations)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteCatalogObjectResponse response from the API call.</returns>
        Task<Models.DeleteCatalogObjectResponse> DeleteCatalogObjectAsync(
                string objectId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a single [CatalogItem]($m/CatalogItem) as a.
        /// [CatalogObject]($m/CatalogObject) based on the provided ID. The returned.
        /// object includes all of the relevant [CatalogItem]($m/CatalogItem).
        /// information including: [CatalogItemVariation]($m/CatalogItemVariation).
        /// children, references to its.
        /// [CatalogModifierList]($m/CatalogModifierList) objects, and the ids of.
        /// any [CatalogTax]($m/CatalogTax) objects that apply to it..
        /// </summary>
        /// <param name="objectId">Required parameter: The object ID of any type of catalog objects to be retrieved..</param>
        /// <param name="includeRelatedObjects">Optional parameter: If `true`, the response will include additional objects that are related to the requested object, as follows:  If the `object` field of the response contains a `CatalogItem`, its associated `CatalogCategory`, `CatalogTax`, `CatalogImage` and `CatalogModifierList` objects will be returned in the `related_objects` field of the response. If the `object` field of the response contains a `CatalogItemVariation`, its parent `CatalogItem` will be returned in the `related_objects` field of the response.  Default value: `false`.</param>
        /// <param name="catalogVersion">Optional parameter: Requests objects as of a specific version of the catalog. This allows you to retrieve historical versions of objects. The value to retrieve a specific version of an object can be found in the version field of [CatalogObject]($m/CatalogObject)s..</param>
        /// <returns>Returns the Models.RetrieveCatalogObjectResponse response from the API call.</returns>
        Models.RetrieveCatalogObjectResponse RetrieveCatalogObject(
                string objectId,
                bool? includeRelatedObjects = false,
                long? catalogVersion = null);

        /// <summary>
        /// Returns a single [CatalogItem]($m/CatalogItem) as a.
        /// [CatalogObject]($m/CatalogObject) based on the provided ID. The returned.
        /// object includes all of the relevant [CatalogItem]($m/CatalogItem).
        /// information including: [CatalogItemVariation]($m/CatalogItemVariation).
        /// children, references to its.
        /// [CatalogModifierList]($m/CatalogModifierList) objects, and the ids of.
        /// any [CatalogTax]($m/CatalogTax) objects that apply to it..
        /// </summary>
        /// <param name="objectId">Required parameter: The object ID of any type of catalog objects to be retrieved..</param>
        /// <param name="includeRelatedObjects">Optional parameter: If `true`, the response will include additional objects that are related to the requested object, as follows:  If the `object` field of the response contains a `CatalogItem`, its associated `CatalogCategory`, `CatalogTax`, `CatalogImage` and `CatalogModifierList` objects will be returned in the `related_objects` field of the response. If the `object` field of the response contains a `CatalogItemVariation`, its parent `CatalogItem` will be returned in the `related_objects` field of the response.  Default value: `false`.</param>
        /// <param name="catalogVersion">Optional parameter: Requests objects as of a specific version of the catalog. This allows you to retrieve historical versions of objects. The value to retrieve a specific version of an object can be found in the version field of [CatalogObject]($m/CatalogObject)s..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveCatalogObjectResponse response from the API call.</returns>
        Task<Models.RetrieveCatalogObjectResponse> RetrieveCatalogObjectAsync(
                string objectId,
                bool? includeRelatedObjects = false,
                long? catalogVersion = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Searches for [CatalogObject]($m/CatalogObject) of any type by matching supported search attribute values,.
        /// excluding custom attribute values on items or item variations, against one or more of the specified query expressions..
        /// This (`SearchCatalogObjects`) endpoint differs from the [SearchCatalogItems]($e/Catalog/SearchCatalogItems).
        /// endpoint in the following aspects:.
        /// - `SearchCatalogItems` can only search for items or item variations, whereas `SearchCatalogObjects` can search for any type of catalog objects..
        /// - `SearchCatalogItems` supports the custom attribute query filters to return items or item variations that contain custom attribute values, where `SearchCatalogObjects` does not..
        /// - `SearchCatalogItems` does not support the `include_deleted_objects` filter to search for deleted items or item variations, whereas `SearchCatalogObjects` does..
        /// - The both endpoints have different call conventions, including the query filter formats..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchCatalogObjectsResponse response from the API call.</returns>
        Models.SearchCatalogObjectsResponse SearchCatalogObjects(
                Models.SearchCatalogObjectsRequest body);

        /// <summary>
        /// Searches for [CatalogObject]($m/CatalogObject) of any type by matching supported search attribute values,.
        /// excluding custom attribute values on items or item variations, against one or more of the specified query expressions..
        /// This (`SearchCatalogObjects`) endpoint differs from the [SearchCatalogItems]($e/Catalog/SearchCatalogItems).
        /// endpoint in the following aspects:.
        /// - `SearchCatalogItems` can only search for items or item variations, whereas `SearchCatalogObjects` can search for any type of catalog objects..
        /// - `SearchCatalogItems` supports the custom attribute query filters to return items or item variations that contain custom attribute values, where `SearchCatalogObjects` does not..
        /// - `SearchCatalogItems` does not support the `include_deleted_objects` filter to search for deleted items or item variations, whereas `SearchCatalogObjects` does..
        /// - The both endpoints have different call conventions, including the query filter formats..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchCatalogObjectsResponse response from the API call.</returns>
        Task<Models.SearchCatalogObjectsResponse> SearchCatalogObjectsAsync(
                Models.SearchCatalogObjectsRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Searches for catalog items or item variations by matching supported search attribute values, including.
        /// custom attribute values, against one or more of the specified query expressions..
        /// This (`SearchCatalogItems`) endpoint differs from the [SearchCatalogObjects]($e/Catalog/SearchCatalogObjects).
        /// endpoint in the following aspects:.
        /// - `SearchCatalogItems` can only search for items or item variations, whereas `SearchCatalogObjects` can search for any type of catalog objects..
        /// - `SearchCatalogItems` supports the custom attribute query filters to return items or item variations that contain custom attribute values, where `SearchCatalogObjects` does not..
        /// - `SearchCatalogItems` does not support the `include_deleted_objects` filter to search for deleted items or item variations, whereas `SearchCatalogObjects` does..
        /// - The both endpoints use different call conventions, including the query filter formats..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchCatalogItemsResponse response from the API call.</returns>
        Models.SearchCatalogItemsResponse SearchCatalogItems(
                Models.SearchCatalogItemsRequest body);

        /// <summary>
        /// Searches for catalog items or item variations by matching supported search attribute values, including.
        /// custom attribute values, against one or more of the specified query expressions..
        /// This (`SearchCatalogItems`) endpoint differs from the [SearchCatalogObjects]($e/Catalog/SearchCatalogObjects).
        /// endpoint in the following aspects:.
        /// - `SearchCatalogItems` can only search for items or item variations, whereas `SearchCatalogObjects` can search for any type of catalog objects..
        /// - `SearchCatalogItems` supports the custom attribute query filters to return items or item variations that contain custom attribute values, where `SearchCatalogObjects` does not..
        /// - `SearchCatalogItems` does not support the `include_deleted_objects` filter to search for deleted items or item variations, whereas `SearchCatalogObjects` does..
        /// - The both endpoints use different call conventions, including the query filter formats..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchCatalogItemsResponse response from the API call.</returns>
        Task<Models.SearchCatalogItemsResponse> SearchCatalogItemsAsync(
                Models.SearchCatalogItemsRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the [CatalogModifierList]($m/CatalogModifierList) objects.
        /// that apply to the targeted [CatalogItem]($m/CatalogItem) without having.
        /// to perform an upsert on the entire item..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateItemModifierListsResponse response from the API call.</returns>
        Models.UpdateItemModifierListsResponse UpdateItemModifierLists(
                Models.UpdateItemModifierListsRequest body);

        /// <summary>
        /// Updates the [CatalogModifierList]($m/CatalogModifierList) objects.
        /// that apply to the targeted [CatalogItem]($m/CatalogItem) without having.
        /// to perform an upsert on the entire item..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateItemModifierListsResponse response from the API call.</returns>
        Task<Models.UpdateItemModifierListsResponse> UpdateItemModifierListsAsync(
                Models.UpdateItemModifierListsRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the [CatalogTax]($m/CatalogTax) objects that apply to the.
        /// targeted [CatalogItem]($m/CatalogItem) without having to perform an.
        /// upsert on the entire item..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateItemTaxesResponse response from the API call.</returns>
        Models.UpdateItemTaxesResponse UpdateItemTaxes(
                Models.UpdateItemTaxesRequest body);

        /// <summary>
        /// Updates the [CatalogTax]($m/CatalogTax) objects that apply to the.
        /// targeted [CatalogItem]($m/CatalogItem) without having to perform an.
        /// upsert on the entire item..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateItemTaxesResponse response from the API call.</returns>
        Task<Models.UpdateItemTaxesResponse> UpdateItemTaxesAsync(
                Models.UpdateItemTaxesRequest body,
                CancellationToken cancellationToken = default);
    }
}