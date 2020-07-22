using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Utilities;
using Square.Http.Request;
using Square.Http.Response;
using Square.Http.Client;

namespace Square.Apis
{
    public interface ICatalogApi
    {
        /// <summary>
        /// Deletes a set of [CatalogItem](#type-catalogitem)s based on the
        /// provided list of target IDs and returns a set of successfully deleted IDs in
        /// the response. Deletion is a cascading event such that all children of the
        /// targeted object are also deleted. For example, deleting a CatalogItem will
        /// also delete all of its [CatalogItemVariation](#type-catalogitemvariation)
        /// children.
        /// `BatchDeleteCatalogObjects` succeeds even if only a portion of the targeted
        /// IDs can be deleted. The response will only include IDs that were
        /// actually deleted.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BatchDeleteCatalogObjectsResponse response from the API call</return>
        Models.BatchDeleteCatalogObjectsResponse BatchDeleteCatalogObjects(Models.BatchDeleteCatalogObjectsRequest body);

        /// <summary>
        /// Deletes a set of [CatalogItem](#type-catalogitem)s based on the
        /// provided list of target IDs and returns a set of successfully deleted IDs in
        /// the response. Deletion is a cascading event such that all children of the
        /// targeted object are also deleted. For example, deleting a CatalogItem will
        /// also delete all of its [CatalogItemVariation](#type-catalogitemvariation)
        /// children.
        /// `BatchDeleteCatalogObjects` succeeds even if only a portion of the targeted
        /// IDs can be deleted. The response will only include IDs that were
        /// actually deleted.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BatchDeleteCatalogObjectsResponse response from the API call</return>
        Task<Models.BatchDeleteCatalogObjectsResponse> BatchDeleteCatalogObjectsAsync(Models.BatchDeleteCatalogObjectsRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a set of objects based on the provided ID.
        /// Each [CatalogItem](#type-catalogitem) returned in the set includes all of its
        /// child information including: all of its
        /// [CatalogItemVariation](#type-catalogitemvariation) objects, references to
        /// its [CatalogModifierList](#type-catalogmodifierlist) objects, and the ids of
        /// any [CatalogTax](#type-catalogtax) objects that apply to it.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BatchRetrieveCatalogObjectsResponse response from the API call</return>
        Models.BatchRetrieveCatalogObjectsResponse BatchRetrieveCatalogObjects(Models.BatchRetrieveCatalogObjectsRequest body);

        /// <summary>
        /// Returns a set of objects based on the provided ID.
        /// Each [CatalogItem](#type-catalogitem) returned in the set includes all of its
        /// child information including: all of its
        /// [CatalogItemVariation](#type-catalogitemvariation) objects, references to
        /// its [CatalogModifierList](#type-catalogmodifierlist) objects, and the ids of
        /// any [CatalogTax](#type-catalogtax) objects that apply to it.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BatchRetrieveCatalogObjectsResponse response from the API call</return>
        Task<Models.BatchRetrieveCatalogObjectsResponse> BatchRetrieveCatalogObjectsAsync(Models.BatchRetrieveCatalogObjectsRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates or updates up to 10,000 target objects based on the provided
        /// list of objects. The target objects are grouped into batches and each batch is
        /// inserted/updated in an all-or-nothing manner. If an object within a batch is
        /// malformed in some way, or violates a database constraint, the entire batch
        /// containing that item will be disregarded. However, other batches in the same
        /// request may still succeed. Each batch may contain up to 1,000 objects, and
        /// batches will be processed in order as long as the total object count for the
        /// request (items, variations, modifier lists, discounts, and taxes) is no more
        /// than 10,000.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BatchUpsertCatalogObjectsResponse response from the API call</return>
        Models.BatchUpsertCatalogObjectsResponse BatchUpsertCatalogObjects(Models.BatchUpsertCatalogObjectsRequest body);

        /// <summary>
        /// Creates or updates up to 10,000 target objects based on the provided
        /// list of objects. The target objects are grouped into batches and each batch is
        /// inserted/updated in an all-or-nothing manner. If an object within a batch is
        /// malformed in some way, or violates a database constraint, the entire batch
        /// containing that item will be disregarded. However, other batches in the same
        /// request may still succeed. Each batch may contain up to 1,000 objects, and
        /// batches will be processed in order as long as the total object count for the
        /// request (items, variations, modifier lists, discounts, and taxes) is no more
        /// than 10,000.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.BatchUpsertCatalogObjectsResponse response from the API call</return>
        Task<Models.BatchUpsertCatalogObjectsResponse> BatchUpsertCatalogObjectsAsync(Models.BatchUpsertCatalogObjectsRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Uploads an image file to be represented by an [CatalogImage](#type-catalogimage) object linked to an existing
        /// [CatalogObject](#type-catalogobject) instance. A call to this endpoint can upload an image, link an image to
        /// a catalog object, or do both.
        /// This `CreateCatalogImage` endpoint accepts HTTP multipart/form-data requests with a JSON part and an image file part in
        /// JPEG, PJPEG, PNG, or GIF format. The maximum file size is 15MB.
        /// Additional information and an example cURL request can be found in the [Create a Catalog Image recipe](https://developer.squareup.com/docs/more-apis/catalog/cookbook/create-catalog-images).
        /// </summary>
        /// <param name="request">Optional parameter: Example: </param>
        /// <param name="imageFile">Optional parameter: Example: </param>
        /// <return>Returns the Models.CreateCatalogImageResponse response from the API call</return>
        Models.CreateCatalogImageResponse CreateCatalogImage(Models.CreateCatalogImageRequest request = null, FileStreamInfo imageFile = null);

        /// <summary>
        /// Uploads an image file to be represented by an [CatalogImage](#type-catalogimage) object linked to an existing
        /// [CatalogObject](#type-catalogobject) instance. A call to this endpoint can upload an image, link an image to
        /// a catalog object, or do both.
        /// This `CreateCatalogImage` endpoint accepts HTTP multipart/form-data requests with a JSON part and an image file part in
        /// JPEG, PJPEG, PNG, or GIF format. The maximum file size is 15MB.
        /// Additional information and an example cURL request can be found in the [Create a Catalog Image recipe](https://developer.squareup.com/docs/more-apis/catalog/cookbook/create-catalog-images).
        /// </summary>
        /// <param name="request">Optional parameter: Example: </param>
        /// <param name="imageFile">Optional parameter: Example: </param>
        /// <return>Returns the Models.CreateCatalogImageResponse response from the API call</return>
        Task<Models.CreateCatalogImageResponse> CreateCatalogImageAsync(Models.CreateCatalogImageRequest request = null, FileStreamInfo imageFile = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves information about the Square Catalog API, such as batch size
        /// limits that can be used by the `BatchUpsertCatalogObjects` endpoint.
        /// </summary>
        /// <return>Returns the Models.CatalogInfoResponse response from the API call</return>
        Models.CatalogInfoResponse CatalogInfo();

        /// <summary>
        /// Retrieves information about the Square Catalog API, such as batch size
        /// limits that can be used by the `BatchUpsertCatalogObjects` endpoint.
        /// </summary>
        /// <return>Returns the Models.CatalogInfoResponse response from the API call</return>
        Task<Models.CatalogInfoResponse> CatalogInfoAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a list of [CatalogObject](#type-catalogobject)s that includes
        /// all objects of a set of desired types (for example, all [CatalogItem](#type-catalogitem)
        /// and [CatalogTax](#type-catalogtax) objects) in the catalog. The `types` parameter
        /// is specified as a comma-separated list of valid [CatalogObject](#type-catalogobject) types:
        /// `ITEM`, `ITEM_VARIATION`, `MODIFIER`, `MODIFIER_LIST`, `CATEGORY`, `DISCOUNT`, `TAX`, `IMAGE`.
        /// __Important:__ ListCatalog does not return deleted catalog items. To retrieve
        /// deleted catalog items, use SearchCatalogObjects and set `include_deleted_objects`
        /// to `true`.
        /// </summary>
        /// <param name="cursor">Optional parameter: The pagination cursor returned in the previous response. Leave unset for an initial request. See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information.</param>
        /// <param name="types">Optional parameter: An optional case-insensitive, comma-separated list of object types to retrieve, for example `ITEM,ITEM_VARIATION,CATEGORY,IMAGE`.  The legal values are taken from the CatalogObjectType enum: `ITEM`, `ITEM_VARIATION`, `CATEGORY`, `DISCOUNT`, `TAX`, `MODIFIER`, `MODIFIER_LIST`, or `IMAGE`.</param>
        /// <return>Returns the Models.ListCatalogResponse response from the API call</return>
        Models.ListCatalogResponse ListCatalog(string cursor = null, string types = null);

        /// <summary>
        /// Returns a list of [CatalogObject](#type-catalogobject)s that includes
        /// all objects of a set of desired types (for example, all [CatalogItem](#type-catalogitem)
        /// and [CatalogTax](#type-catalogtax) objects) in the catalog. The `types` parameter
        /// is specified as a comma-separated list of valid [CatalogObject](#type-catalogobject) types:
        /// `ITEM`, `ITEM_VARIATION`, `MODIFIER`, `MODIFIER_LIST`, `CATEGORY`, `DISCOUNT`, `TAX`, `IMAGE`.
        /// __Important:__ ListCatalog does not return deleted catalog items. To retrieve
        /// deleted catalog items, use SearchCatalogObjects and set `include_deleted_objects`
        /// to `true`.
        /// </summary>
        /// <param name="cursor">Optional parameter: The pagination cursor returned in the previous response. Leave unset for an initial request. See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information.</param>
        /// <param name="types">Optional parameter: An optional case-insensitive, comma-separated list of object types to retrieve, for example `ITEM,ITEM_VARIATION,CATEGORY,IMAGE`.  The legal values are taken from the CatalogObjectType enum: `ITEM`, `ITEM_VARIATION`, `CATEGORY`, `DISCOUNT`, `TAX`, `MODIFIER`, `MODIFIER_LIST`, or `IMAGE`.</param>
        /// <return>Returns the Models.ListCatalogResponse response from the API call</return>
        Task<Models.ListCatalogResponse> ListCatalogAsync(string cursor = null, string types = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates or updates the target [CatalogObject](#type-catalogobject).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpsertCatalogObjectResponse response from the API call</return>
        Models.UpsertCatalogObjectResponse UpsertCatalogObject(Models.UpsertCatalogObjectRequest body);

        /// <summary>
        /// Creates or updates the target [CatalogObject](#type-catalogobject).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpsertCatalogObjectResponse response from the API call</return>
        Task<Models.UpsertCatalogObjectResponse> UpsertCatalogObjectAsync(Models.UpsertCatalogObjectRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a single [CatalogObject](#type-catalogobject) based on the
        /// provided ID and returns the set of successfully deleted IDs in the response.
        /// Deletion is a cascading event such that all children of the targeted object
        /// are also deleted. For example, deleting a [CatalogItem](#type-catalogitem)
        /// will also delete all of its
        /// [CatalogItemVariation](#type-catalogitemvariation) children.
        /// </summary>
        /// <param name="objectId">Required parameter: The ID of the catalog object to be deleted. When an object is deleted, other objects in the graph that depend on that object will be deleted as well (for example, deleting a catalog item will delete its catalog item variations).</param>
        /// <return>Returns the Models.DeleteCatalogObjectResponse response from the API call</return>
        Models.DeleteCatalogObjectResponse DeleteCatalogObject(string objectId);

        /// <summary>
        /// Deletes a single [CatalogObject](#type-catalogobject) based on the
        /// provided ID and returns the set of successfully deleted IDs in the response.
        /// Deletion is a cascading event such that all children of the targeted object
        /// are also deleted. For example, deleting a [CatalogItem](#type-catalogitem)
        /// will also delete all of its
        /// [CatalogItemVariation](#type-catalogitemvariation) children.
        /// </summary>
        /// <param name="objectId">Required parameter: The ID of the catalog object to be deleted. When an object is deleted, other objects in the graph that depend on that object will be deleted as well (for example, deleting a catalog item will delete its catalog item variations).</param>
        /// <return>Returns the Models.DeleteCatalogObjectResponse response from the API call</return>
        Task<Models.DeleteCatalogObjectResponse> DeleteCatalogObjectAsync(string objectId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a single [CatalogItem](#type-catalogitem) as a
        /// [CatalogObject](#type-catalogobject) based on the provided ID. The returned
        /// object includes all of the relevant [CatalogItem](#type-catalogitem)
        /// information including: [CatalogItemVariation](#type-catalogitemvariation)
        /// children, references to its
        /// [CatalogModifierList](#type-catalogmodifierlist) objects, and the ids of
        /// any [CatalogTax](#type-catalogtax) objects that apply to it.
        /// </summary>
        /// <param name="objectId">Required parameter: The object ID of any type of catalog objects to be retrieved.</param>
        /// <param name="includeRelatedObjects">Optional parameter: If `true`, the response will include additional objects that are related to the requested object, as follows:  If the `object` field of the response contains a CatalogItem, its associated CatalogCategory, CatalogTax objects, CatalogImages and CatalogModifierLists will be returned in the `related_objects` field of the response. If the `object` field of the response contains a CatalogItemVariation, its parent CatalogItem will be returned in the `related_objects` field of the response.  Default value: `false`</param>
        /// <return>Returns the Models.RetrieveCatalogObjectResponse response from the API call</return>
        Models.RetrieveCatalogObjectResponse RetrieveCatalogObject(string objectId, bool? includeRelatedObjects = false);

        /// <summary>
        /// Returns a single [CatalogItem](#type-catalogitem) as a
        /// [CatalogObject](#type-catalogobject) based on the provided ID. The returned
        /// object includes all of the relevant [CatalogItem](#type-catalogitem)
        /// information including: [CatalogItemVariation](#type-catalogitemvariation)
        /// children, references to its
        /// [CatalogModifierList](#type-catalogmodifierlist) objects, and the ids of
        /// any [CatalogTax](#type-catalogtax) objects that apply to it.
        /// </summary>
        /// <param name="objectId">Required parameter: The object ID of any type of catalog objects to be retrieved.</param>
        /// <param name="includeRelatedObjects">Optional parameter: If `true`, the response will include additional objects that are related to the requested object, as follows:  If the `object` field of the response contains a CatalogItem, its associated CatalogCategory, CatalogTax objects, CatalogImages and CatalogModifierLists will be returned in the `related_objects` field of the response. If the `object` field of the response contains a CatalogItemVariation, its parent CatalogItem will be returned in the `related_objects` field of the response.  Default value: `false`</param>
        /// <return>Returns the Models.RetrieveCatalogObjectResponse response from the API call</return>
        Task<Models.RetrieveCatalogObjectResponse> RetrieveCatalogObjectAsync(string objectId, bool? includeRelatedObjects = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// Searches for [CatalogObject](#type-CatalogObject) of any types against supported search attribute values, 
        /// excluding custom attribute values on items or item variations, against one or more of the specified query expressions, 
        /// This (`SearchCatalogObjects`) endpoint differs from the [SearchCatalogItems](#endpoint-Catalog-SearchCatalogItems)
        /// endpoint in the following aspects:
        /// - `SearchCatalogItems` can only search for items or item variations, whereas `SearchCatalogObjects` can search for any type of catalog objects.
        /// - `SearchCatalogItems` supports the custom attribute query filters to return items or item variations that contain custom attribute values, where `SearchCatalogObjects` does not.
        /// - `SearchCatalogItems` does not support the `include_deleted_objects` filter to search for deleted items or item variations, whereas `SearchCatalogObjects` does.
        /// - The both endpoints have different call conventions, including the query filter formats.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchCatalogObjectsResponse response from the API call</return>
        Models.SearchCatalogObjectsResponse SearchCatalogObjects(Models.SearchCatalogObjectsRequest body);

        /// <summary>
        /// Searches for [CatalogObject](#type-CatalogObject) of any types against supported search attribute values, 
        /// excluding custom attribute values on items or item variations, against one or more of the specified query expressions, 
        /// This (`SearchCatalogObjects`) endpoint differs from the [SearchCatalogItems](#endpoint-Catalog-SearchCatalogItems)
        /// endpoint in the following aspects:
        /// - `SearchCatalogItems` can only search for items or item variations, whereas `SearchCatalogObjects` can search for any type of catalog objects.
        /// - `SearchCatalogItems` supports the custom attribute query filters to return items or item variations that contain custom attribute values, where `SearchCatalogObjects` does not.
        /// - `SearchCatalogItems` does not support the `include_deleted_objects` filter to search for deleted items or item variations, whereas `SearchCatalogObjects` does.
        /// - The both endpoints have different call conventions, including the query filter formats.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchCatalogObjectsResponse response from the API call</return>
        Task<Models.SearchCatalogObjectsResponse> SearchCatalogObjectsAsync(Models.SearchCatalogObjectsRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Searches for catalog items or item variations by matching supported search attribute values, including
        /// custom attribute values, against one or more of the specified query expressions, 
        /// This (`SearchCatalogItems`) endpoint differs from the [SearchCatalogObjects](#endpoint-Catalog-SearchCatalogObjects)
        /// endpoint in the following aspects:
        /// - `SearchCatalogItems` can only search for items or item variations, whereas `SearchCatalogObjects` can search for any type of catalog objects.
        /// - `SearchCatalogItems` supports the custom attribute query filters to return items or item variations that contain custom attribute values, where `SearchCatalogObjects` does not.
        /// - `SearchCatalogItems` does not support the `include_deleted_objects` filter to search for deleted items or item variations, whereas `SearchCatalogObjects` does.
        /// - The both endpoints use different call conventions, including the query filter formats.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchCatalogItemsResponse response from the API call</return>
        Models.SearchCatalogItemsResponse SearchCatalogItems(Models.SearchCatalogItemsRequest body);

        /// <summary>
        /// Searches for catalog items or item variations by matching supported search attribute values, including
        /// custom attribute values, against one or more of the specified query expressions, 
        /// This (`SearchCatalogItems`) endpoint differs from the [SearchCatalogObjects](#endpoint-Catalog-SearchCatalogObjects)
        /// endpoint in the following aspects:
        /// - `SearchCatalogItems` can only search for items or item variations, whereas `SearchCatalogObjects` can search for any type of catalog objects.
        /// - `SearchCatalogItems` supports the custom attribute query filters to return items or item variations that contain custom attribute values, where `SearchCatalogObjects` does not.
        /// - `SearchCatalogItems` does not support the `include_deleted_objects` filter to search for deleted items or item variations, whereas `SearchCatalogObjects` does.
        /// - The both endpoints use different call conventions, including the query filter formats.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchCatalogItemsResponse response from the API call</return>
        Task<Models.SearchCatalogItemsResponse> SearchCatalogItemsAsync(Models.SearchCatalogItemsRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the [CatalogModifierList](#type-catalogmodifierlist) objects
        /// that apply to the targeted [CatalogItem](#type-catalogitem) without having
        /// to perform an upsert on the entire item.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateItemModifierListsResponse response from the API call</return>
        Models.UpdateItemModifierListsResponse UpdateItemModifierLists(Models.UpdateItemModifierListsRequest body);

        /// <summary>
        /// Updates the [CatalogModifierList](#type-catalogmodifierlist) objects
        /// that apply to the targeted [CatalogItem](#type-catalogitem) without having
        /// to perform an upsert on the entire item.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateItemModifierListsResponse response from the API call</return>
        Task<Models.UpdateItemModifierListsResponse> UpdateItemModifierListsAsync(Models.UpdateItemModifierListsRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the [CatalogTax](#type-catalogtax) objects that apply to the
        /// targeted [CatalogItem](#type-catalogitem) without having to perform an
        /// upsert on the entire item.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateItemTaxesResponse response from the API call</return>
        Models.UpdateItemTaxesResponse UpdateItemTaxes(Models.UpdateItemTaxesRequest body);

        /// <summary>
        /// Updates the [CatalogTax](#type-catalogtax) objects that apply to the
        /// targeted [CatalogItem](#type-catalogitem) without having to perform an
        /// upsert on the entire item.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateItemTaxesResponse response from the API call</return>
        Task<Models.UpdateItemTaxesResponse> UpdateItemTaxesAsync(Models.UpdateItemTaxesRequest body, CancellationToken cancellationToken = default);

    }
}