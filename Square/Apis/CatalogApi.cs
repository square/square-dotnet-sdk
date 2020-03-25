using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;
using Square.Http.Request;
using Square.Http.Response;
using Square.Http.Client;
using Square.Authentication;
using Square.Exceptions;

namespace Square.Apis
{
    internal class CatalogApi: BaseApi, ICatalogApi
    {
        internal CatalogApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null) :
            base(config, httpClient, authManagers, httpCallBack)
        { }

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
        public Models.BatchDeleteCatalogObjectsResponse BatchDeleteCatalogObjects(Models.BatchDeleteCatalogObjectsRequest body)
        {
            Task<Models.BatchDeleteCatalogObjectsResponse> t = BatchDeleteCatalogObjectsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<Models.BatchDeleteCatalogObjectsResponse> BatchDeleteCatalogObjectsAsync(Models.BatchDeleteCatalogObjectsRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/catalog/batch-delete");

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", "2020-03-25" }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryUrl, _headers, _body);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["default"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.BatchDeleteCatalogObjectsResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

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
        public Models.BatchRetrieveCatalogObjectsResponse BatchRetrieveCatalogObjects(Models.BatchRetrieveCatalogObjectsRequest body)
        {
            Task<Models.BatchRetrieveCatalogObjectsResponse> t = BatchRetrieveCatalogObjectsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<Models.BatchRetrieveCatalogObjectsResponse> BatchRetrieveCatalogObjectsAsync(Models.BatchRetrieveCatalogObjectsRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/catalog/batch-retrieve");

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", "2020-03-25" }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryUrl, _headers, _body);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["default"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.BatchRetrieveCatalogObjectsResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

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
        public Models.BatchUpsertCatalogObjectsResponse BatchUpsertCatalogObjects(Models.BatchUpsertCatalogObjectsRequest body)
        {
            Task<Models.BatchUpsertCatalogObjectsResponse> t = BatchUpsertCatalogObjectsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<Models.BatchUpsertCatalogObjectsResponse> BatchUpsertCatalogObjectsAsync(Models.BatchUpsertCatalogObjectsRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/catalog/batch-upsert");

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", "2020-03-25" }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryUrl, _headers, _body);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["default"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.BatchUpsertCatalogObjectsResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

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
        public Models.CreateCatalogImageResponse CreateCatalogImage(Models.CreateCatalogImageRequest request = null, FileStreamInfo imageFile = null)
        {
            Task<Models.CreateCatalogImageResponse> t = CreateCatalogImageAsync(request, imageFile);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<Models.CreateCatalogImageResponse> CreateCatalogImageAsync(Models.CreateCatalogImageRequest request = null, FileStreamInfo imageFile = null, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/catalog/images");

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "Square-Version", "2020-03-25" }
            };

            var requestHeaders = new Dictionary<string, IReadOnlyCollection<string>>(StringComparer.OrdinalIgnoreCase)
            {
                { "Content-Type", new [] { "application/json; charset=utf-8" } }
            };

            var imageFileHeaders = new Dictionary<string, IReadOnlyCollection<string>>(StringComparer.OrdinalIgnoreCase)
            {
                { "Content-Type", new [] { string.IsNullOrEmpty(imageFile.ContentType) ? "image/jpeg" : imageFile.ContentType } }
            };

            //append form/field parameters
            var _fields = new List<KeyValuePair<string, Object>>()
            {
                new KeyValuePair<string, object>( "image_file", CreateFileMultipartContent(imageFile, imageFileHeaders))
            };
            _fields.Add(new KeyValuePair<string, object>("request", CreateJsonEncodedMultipartContent(request, requestHeaders)));

            //remove null parameters
            _fields = _fields.Where(kvp => kvp.Value != null).ToList();

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().Post(_queryUrl, _headers, _fields);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["default"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.CreateCatalogImageResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Returns information about the Square Catalog API, such as batch size
        /// limits for `BatchUpsertCatalogObjects`.
        /// </summary>
        /// <return>Returns the Models.CatalogInfoResponse response from the API call</return>
        public Models.CatalogInfoResponse CatalogInfo()
        {
            Task<Models.CatalogInfoResponse> t = CatalogInfoAsync();
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns information about the Square Catalog API, such as batch size
        /// limits for `BatchUpsertCatalogObjects`.
        /// </summary>
        /// <return>Returns the Models.CatalogInfoResponse response from the API call</return>
        public async Task<Models.CatalogInfoResponse> CatalogInfoAsync(CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/catalog/info");

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "Square-Version", "2020-03-25" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().Get(_queryUrl,_headers);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["default"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.CatalogInfoResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

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
        public Models.ListCatalogResponse ListCatalog(string cursor = null, string types = null)
        {
            Task<Models.ListCatalogResponse> t = ListCatalogAsync(cursor, types);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<Models.ListCatalogResponse> ListCatalogAsync(string cursor = null, string types = null, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/catalog/list");

            //process optional query parameters
            ApiHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "cursor", cursor },
                { "types", types }
            }, ArrayDeserializationFormat, ParameterSeparator);

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "Square-Version", "2020-03-25" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().Get(_queryUrl,_headers);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["default"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.ListCatalogResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Creates or updates the target [CatalogObject](#type-catalogobject).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpsertCatalogObjectResponse response from the API call</return>
        public Models.UpsertCatalogObjectResponse UpsertCatalogObject(Models.UpsertCatalogObjectRequest body)
        {
            Task<Models.UpsertCatalogObjectResponse> t = UpsertCatalogObjectAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates or updates the target [CatalogObject](#type-catalogobject).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpsertCatalogObjectResponse response from the API call</return>
        public async Task<Models.UpsertCatalogObjectResponse> UpsertCatalogObjectAsync(Models.UpsertCatalogObjectRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/catalog/object");

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", "2020-03-25" }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryUrl, _headers, _body);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["default"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.UpsertCatalogObjectResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

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
        public Models.DeleteCatalogObjectResponse DeleteCatalogObject(string objectId)
        {
            Task<Models.DeleteCatalogObjectResponse> t = DeleteCatalogObjectAsync(objectId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<Models.DeleteCatalogObjectResponse> DeleteCatalogObjectAsync(string objectId, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/catalog/object/{object_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "object_id", objectId }
            });

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "Square-Version", "2020-03-25" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().Delete(_queryUrl, _headers, null);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["default"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.DeleteCatalogObjectResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

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
        public Models.RetrieveCatalogObjectResponse RetrieveCatalogObject(string objectId, bool? includeRelatedObjects = null)
        {
            Task<Models.RetrieveCatalogObjectResponse> t = RetrieveCatalogObjectAsync(objectId, includeRelatedObjects);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<Models.RetrieveCatalogObjectResponse> RetrieveCatalogObjectAsync(string objectId, bool? includeRelatedObjects = null, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/catalog/object/{object_id}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "object_id", objectId }
            });

            //process optional query parameters
            ApiHelper.AppendUrlWithQueryParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "include_related_objects", includeRelatedObjects }
            }, ArrayDeserializationFormat, ParameterSeparator);

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "Square-Version", "2020-03-25" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().Get(_queryUrl,_headers);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["default"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.RetrieveCatalogObjectResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

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
        public Models.SearchCatalogObjectsResponse SearchCatalogObjects(Models.SearchCatalogObjectsRequest body)
        {
            Task<Models.SearchCatalogObjectsResponse> t = SearchCatalogObjectsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<Models.SearchCatalogObjectsResponse> SearchCatalogObjectsAsync(Models.SearchCatalogObjectsRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/catalog/search");

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", "2020-03-25" }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryUrl, _headers, _body);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["default"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.SearchCatalogObjectsResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Updates the [CatalogModifierList](#type-catalogmodifierlist) objects
        /// that apply to the targeted [CatalogItem](#type-catalogitem) without having
        /// to perform an upsert on the entire item.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateItemModifierListsResponse response from the API call</return>
        public Models.UpdateItemModifierListsResponse UpdateItemModifierLists(Models.UpdateItemModifierListsRequest body)
        {
            Task<Models.UpdateItemModifierListsResponse> t = UpdateItemModifierListsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates the [CatalogModifierList](#type-catalogmodifierlist) objects
        /// that apply to the targeted [CatalogItem](#type-catalogitem) without having
        /// to perform an upsert on the entire item.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateItemModifierListsResponse response from the API call</return>
        public async Task<Models.UpdateItemModifierListsResponse> UpdateItemModifierListsAsync(Models.UpdateItemModifierListsRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/catalog/update-item-modifier-lists");

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", "2020-03-25" }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryUrl, _headers, _body);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["default"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.UpdateItemModifierListsResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

        /// <summary>
        /// Updates the [CatalogTax](#type-catalogtax) objects that apply to the
        /// targeted [CatalogItem](#type-catalogitem) without having to perform an
        /// upsert on the entire item.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateItemTaxesResponse response from the API call</return>
        public Models.UpdateItemTaxesResponse UpdateItemTaxes(Models.UpdateItemTaxesRequest body)
        {
            Task<Models.UpdateItemTaxesResponse> t = UpdateItemTaxesAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates the [CatalogTax](#type-catalogtax) objects that apply to the
        /// targeted [CatalogItem](#type-catalogitem) without having to perform an
        /// upsert on the entire item.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateItemTaxesResponse response from the API call</return>
        public async Task<Models.UpdateItemTaxesResponse> UpdateItemTaxesAsync(Models.UpdateItemTaxesRequest body, CancellationToken cancellationToken = default)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri();

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/v2/catalog/update-item-taxes");

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string, string>()
            { 
                { "user-agent", userAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", "2020-03-25" }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryUrl, _headers, _body);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), _request);
            }

            _request = await authManagers["default"].ApplyAsync(_request).ConfigureAwait(false);

            //invoke request and get response
            HttpStringResponse _response = await GetClientInstance().ExecuteAsStringAsync(_request, cancellationToken).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);
            if (HttpCallBack != null)
            {
                HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), _response);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _responseModel = ApiHelper.JsonDeserialize<Models.UpdateItemTaxesResponse>(_response.Body);
            _responseModel.Context = _context;
            return _responseModel;
        }

    }
}