using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
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
        Task<Models.BatchDeleteCatalogObjectsResponse> BatchDeleteCatalogObjectsAsync(Models.BatchDeleteCatalogObjectsRequest body);

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
        Task<Models.BatchRetrieveCatalogObjectsResponse> BatchRetrieveCatalogObjectsAsync(Models.BatchRetrieveCatalogObjectsRequest body);

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
        Task<Models.BatchUpsertCatalogObjectsResponse> BatchUpsertCatalogObjectsAsync(Models.BatchUpsertCatalogObjectsRequest body);

        /// <summary>
        /// Upload an image file to create a new [CatalogImage](#type-catalogimage) for an existing
        /// [CatalogObject](#type-catalogobject). Images can be uploaded and linked in this request or created independently
        /// (without an object assignment) and linked to a [CatalogObject](#type-catalogobject) at a later time.
        /// CreateCatalogImage accepts HTTP multipart/form-data requests with a JSON part and an image file part in
        /// JPEG, PJPEG, PNG, or GIF format. The maximum file size is 15MB. The following is an example of such an HTTP request:
        /// ```
        /// POST /v2/catalog/images
        /// Accept: application/json
        /// Content-Type: multipart/form-data;boundary="boundary"
        /// Square-Version: XXXX-XX-XX
        /// Authorization: Bearer {ACCESS_TOKEN}
        /// --boundary
        /// Content-Disposition: form-data; name="request"
        /// Content-Type: application/json
        /// {
        /// "idempotency_key":"528dea59-7bfb-43c1-bd48-4a6bba7dd61f86",
        /// "object_id": "ND6EA5AAJEO5WL3JNNIAQA32",
        /// "image":{
        /// "id":"#TEMP_ID",
        /// "type":"IMAGE",
        /// "image_data":{
        /// "caption":"A picture of a cup of coffee"
        /// }
        /// }
        /// }
        /// --boundary
        /// Content-Disposition: form-data; name="image"; filename="Coffee.jpg"
        /// Content-Type: image/jpeg
        /// {ACTUAL_IMAGE_BYTES}
        /// --boundary
        /// ```
        /// Additional information and an example cURL request can be found in the [Create a Catalog Image recipe](https://developer.squareup.com/docs/more-apis/catalog/cookbook/create-catalog-images).
        /// </summary>
        /// <param name="request">Optional parameter: Example: </param>
        /// <param name="imageFile">Optional parameter: Example: </param>
        /// <return>Returns the Models.CreateCatalogImageResponse response from the API call</return>
        Models.CreateCatalogImageResponse CreateCatalogImage(Models.CreateCatalogImageRequest request = null, FileStreamInfo imageFile = null);

        /// <summary>
        /// Upload an image file to create a new [CatalogImage](#type-catalogimage) for an existing
        /// [CatalogObject](#type-catalogobject). Images can be uploaded and linked in this request or created independently
        /// (without an object assignment) and linked to a [CatalogObject](#type-catalogobject) at a later time.
        /// CreateCatalogImage accepts HTTP multipart/form-data requests with a JSON part and an image file part in
        /// JPEG, PJPEG, PNG, or GIF format. The maximum file size is 15MB. The following is an example of such an HTTP request:
        /// ```
        /// POST /v2/catalog/images
        /// Accept: application/json
        /// Content-Type: multipart/form-data;boundary="boundary"
        /// Square-Version: XXXX-XX-XX
        /// Authorization: Bearer {ACCESS_TOKEN}
        /// --boundary
        /// Content-Disposition: form-data; name="request"
        /// Content-Type: application/json
        /// {
        /// "idempotency_key":"528dea59-7bfb-43c1-bd48-4a6bba7dd61f86",
        /// "object_id": "ND6EA5AAJEO5WL3JNNIAQA32",
        /// "image":{
        /// "id":"#TEMP_ID",
        /// "type":"IMAGE",
        /// "image_data":{
        /// "caption":"A picture of a cup of coffee"
        /// }
        /// }
        /// }
        /// --boundary
        /// Content-Disposition: form-data; name="image"; filename="Coffee.jpg"
        /// Content-Type: image/jpeg
        /// {ACTUAL_IMAGE_BYTES}
        /// --boundary
        /// ```
        /// Additional information and an example cURL request can be found in the [Create a Catalog Image recipe](https://developer.squareup.com/docs/more-apis/catalog/cookbook/create-catalog-images).
        /// </summary>
        /// <param name="request">Optional parameter: Example: </param>
        /// <param name="imageFile">Optional parameter: Example: </param>
        /// <return>Returns the Models.CreateCatalogImageResponse response from the API call</return>
        Task<Models.CreateCatalogImageResponse> CreateCatalogImageAsync(Models.CreateCatalogImageRequest request = null, FileStreamInfo imageFile = null);

        /// <summary>
        /// Returns information about the Square Catalog API, such as batch size
        /// limits for `BatchUpsertCatalogObjects`.
        /// </summary>
        /// <return>Returns the Models.CatalogInfoResponse response from the API call</return>
        Models.CatalogInfoResponse CatalogInfo();

        /// <summary>
        /// Returns information about the Square Catalog API, such as batch size
        /// limits for `BatchUpsertCatalogObjects`.
        /// </summary>
        /// <return>Returns the Models.CatalogInfoResponse response from the API call</return>
        Task<Models.CatalogInfoResponse> CatalogInfoAsync();

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
        Task<Models.ListCatalogResponse> ListCatalogAsync(string cursor = null, string types = null);

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
        Task<Models.UpsertCatalogObjectResponse> UpsertCatalogObjectAsync(Models.UpsertCatalogObjectRequest body);

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
        Task<Models.DeleteCatalogObjectResponse> DeleteCatalogObjectAsync(string objectId);

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
        Models.RetrieveCatalogObjectResponse RetrieveCatalogObject(string objectId, bool? includeRelatedObjects = null);

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
        Task<Models.RetrieveCatalogObjectResponse> RetrieveCatalogObjectAsync(string objectId, bool? includeRelatedObjects = null);

        /// <summary>
        /// Queries the targeted catalog using a variety of query types:
        /// [CatalogQuerySortedAttribute](#type-catalogquerysortedattribute),
        /// [CatalogQueryExact](#type-catalogqueryexact),
        /// [CatalogQueryRange](#type-catalogqueryrange),
        /// [CatalogQueryText](#type-catalogquerytext),
        /// [CatalogQueryItemsForTax](#type-catalogqueryitemsfortax), and
        /// [CatalogQueryItemsForModifierList](#type-catalogqueryitemsformodifierlist).
        /// --
        /// --
        /// Future end of the above comment:
        /// [CatalogQueryItemsForTax](#type-catalogqueryitemsfortax),
        /// [CatalogQueryItemsForModifierList](#type-catalogqueryitemsformodifierlist),
        /// [CatalogQueryItemsForItemOptions](#type-catalogqueryitemsforitemoptions), and
        /// [CatalogQueryItemVariationsForItemOptionValues](#type-catalogqueryitemvariationsforitemoptionvalues).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchCatalogObjectsResponse response from the API call</return>
        Models.SearchCatalogObjectsResponse SearchCatalogObjects(Models.SearchCatalogObjectsRequest body);

        /// <summary>
        /// Queries the targeted catalog using a variety of query types:
        /// [CatalogQuerySortedAttribute](#type-catalogquerysortedattribute),
        /// [CatalogQueryExact](#type-catalogqueryexact),
        /// [CatalogQueryRange](#type-catalogqueryrange),
        /// [CatalogQueryText](#type-catalogquerytext),
        /// [CatalogQueryItemsForTax](#type-catalogqueryitemsfortax), and
        /// [CatalogQueryItemsForModifierList](#type-catalogqueryitemsformodifierlist).
        /// --
        /// --
        /// Future end of the above comment:
        /// [CatalogQueryItemsForTax](#type-catalogqueryitemsfortax),
        /// [CatalogQueryItemsForModifierList](#type-catalogqueryitemsformodifierlist),
        /// [CatalogQueryItemsForItemOptions](#type-catalogqueryitemsforitemoptions), and
        /// [CatalogQueryItemVariationsForItemOptionValues](#type-catalogqueryitemvariationsforitemoptionvalues).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchCatalogObjectsResponse response from the API call</return>
        Task<Models.SearchCatalogObjectsResponse> SearchCatalogObjectsAsync(Models.SearchCatalogObjectsRequest body);

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
        Task<Models.UpdateItemModifierListsResponse> UpdateItemModifierListsAsync(Models.UpdateItemModifierListsRequest body);

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
        Task<Models.UpdateItemTaxesResponse> UpdateItemTaxesAsync(Models.UpdateItemTaxesRequest body);

    }
} 