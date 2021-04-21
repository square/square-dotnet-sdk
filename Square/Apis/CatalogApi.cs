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
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Authentication;
    using Square.Http.Client;
    using Square.Http.Request;
    using Square.Http.Response;
    using Square.Utilities;

    /// <summary>
    /// CatalogApi.
    /// </summary>
    internal class CatalogApi : BaseApi, ICatalogApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogApi"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal CatalogApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

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
        public Models.BatchDeleteCatalogObjectsResponse BatchDeleteCatalogObjects(
                Models.BatchDeleteCatalogObjectsRequest body)
        {
            Task<Models.BatchDeleteCatalogObjectsResponse> t = this.BatchDeleteCatalogObjectsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<Models.BatchDeleteCatalogObjectsResponse> BatchDeleteCatalogObjectsAsync(
                Models.BatchDeleteCatalogObjectsRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/catalog/batch-delete");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.BatchDeleteCatalogObjectsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

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
        public Models.BatchRetrieveCatalogObjectsResponse BatchRetrieveCatalogObjects(
                Models.BatchRetrieveCatalogObjectsRequest body)
        {
            Task<Models.BatchRetrieveCatalogObjectsResponse> t = this.BatchRetrieveCatalogObjectsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<Models.BatchRetrieveCatalogObjectsResponse> BatchRetrieveCatalogObjectsAsync(
                Models.BatchRetrieveCatalogObjectsRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/catalog/batch-retrieve");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.BatchRetrieveCatalogObjectsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

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
        public Models.BatchUpsertCatalogObjectsResponse BatchUpsertCatalogObjects(
                Models.BatchUpsertCatalogObjectsRequest body)
        {
            Task<Models.BatchUpsertCatalogObjectsResponse> t = this.BatchUpsertCatalogObjectsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<Models.BatchUpsertCatalogObjectsResponse> BatchUpsertCatalogObjectsAsync(
                Models.BatchUpsertCatalogObjectsRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/catalog/batch-upsert");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.BatchUpsertCatalogObjectsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

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
        public Models.CreateCatalogImageResponse CreateCatalogImage(
                Models.CreateCatalogImageRequest request = null,
                FileStreamInfo imageFile = null)
        {
            Task<Models.CreateCatalogImageResponse> t = this.CreateCatalogImageAsync(request, imageFile);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<Models.CreateCatalogImageResponse> CreateCatalogImageAsync(
                Models.CreateCatalogImageRequest request = null,
                FileStreamInfo imageFile = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/catalog/images");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            var requestHeaders = new Dictionary<string, IReadOnlyCollection<string>>(StringComparer.OrdinalIgnoreCase)
            {
                { "Content-Type", new[] { "application/json; charset=utf-8" } },
            };

            var imageFileHeaders = new Dictionary<string, IReadOnlyCollection<string>>(StringComparer.OrdinalIgnoreCase)
            {
                { "Content-Type", new[] { string.IsNullOrEmpty(imageFile.ContentType) ? "image/jpeg" : imageFile.ContentType } },
            };

            // append form/field parameters.
            var fields = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("image_file", CreateFileMultipartContent(imageFile, imageFileHeaders)),
            };
            fields.Add(new KeyValuePair<string, object>("request", CreateJsonEncodedMultipartContent(request, requestHeaders)));

            // remove null parameters.
            fields = fields.Where(kvp => kvp.Value != null).ToList();

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Post(queryBuilder.ToString(), headers, fields);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.CreateCatalogImageResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieves information about the Square Catalog API, such as batch size.
        /// limits that can be used by the `BatchUpsertCatalogObjects` endpoint..
        /// </summary>
        /// <returns>Returns the Models.CatalogInfoResponse response from the API call.</returns>
        public Models.CatalogInfoResponse CatalogInfo()
        {
            Task<Models.CatalogInfoResponse> t = this.CatalogInfoAsync();
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves information about the Square Catalog API, such as batch size.
        /// limits that can be used by the `BatchUpsertCatalogObjects` endpoint..
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CatalogInfoResponse response from the API call.</returns>
        public async Task<Models.CatalogInfoResponse> CatalogInfoAsync(CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/catalog/info");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.CatalogInfoResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

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
        public Models.ListCatalogResponse ListCatalog(
                string cursor = null,
                string types = null,
                long? catalogVersion = null)
        {
            Task<Models.ListCatalogResponse> t = this.ListCatalogAsync(cursor, types, catalogVersion);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<Models.ListCatalogResponse> ListCatalogAsync(
                string cursor = null,
                string types = null,
                long? catalogVersion = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/catalog/list");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "cursor", cursor },
                { "types", types },
                { "catalog_version", catalogVersion },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.ListCatalogResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Creates or updates the target [CatalogObject]($m/CatalogObject)..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpsertCatalogObjectResponse response from the API call.</returns>
        public Models.UpsertCatalogObjectResponse UpsertCatalogObject(
                Models.UpsertCatalogObjectRequest body)
        {
            Task<Models.UpsertCatalogObjectResponse> t = this.UpsertCatalogObjectAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates or updates the target [CatalogObject]($m/CatalogObject)..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpsertCatalogObjectResponse response from the API call.</returns>
        public async Task<Models.UpsertCatalogObjectResponse> UpsertCatalogObjectAsync(
                Models.UpsertCatalogObjectRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/catalog/object");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.UpsertCatalogObjectResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

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
        public Models.DeleteCatalogObjectResponse DeleteCatalogObject(
                string objectId)
        {
            Task<Models.DeleteCatalogObjectResponse> t = this.DeleteCatalogObjectAsync(objectId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<Models.DeleteCatalogObjectResponse> DeleteCatalogObjectAsync(
                string objectId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/catalog/object/{object_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "object_id", objectId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Delete(queryBuilder.ToString(), headers, null);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.DeleteCatalogObjectResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

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
        public Models.RetrieveCatalogObjectResponse RetrieveCatalogObject(
                string objectId,
                bool? includeRelatedObjects = false,
                long? catalogVersion = null)
        {
            Task<Models.RetrieveCatalogObjectResponse> t = this.RetrieveCatalogObjectAsync(objectId, includeRelatedObjects, catalogVersion);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<Models.RetrieveCatalogObjectResponse> RetrieveCatalogObjectAsync(
                string objectId,
                bool? includeRelatedObjects = false,
                long? catalogVersion = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/catalog/object/{object_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "object_id", objectId },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "include_related_objects", (includeRelatedObjects != null) ? includeRelatedObjects : false },
                { "catalog_version", catalogVersion },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveCatalogObjectResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

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
        public Models.SearchCatalogObjectsResponse SearchCatalogObjects(
                Models.SearchCatalogObjectsRequest body)
        {
            Task<Models.SearchCatalogObjectsResponse> t = this.SearchCatalogObjectsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<Models.SearchCatalogObjectsResponse> SearchCatalogObjectsAsync(
                Models.SearchCatalogObjectsRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/catalog/search");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.SearchCatalogObjectsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

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
        public Models.SearchCatalogItemsResponse SearchCatalogItems(
                Models.SearchCatalogItemsRequest body)
        {
            Task<Models.SearchCatalogItemsResponse> t = this.SearchCatalogItemsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

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
        public async Task<Models.SearchCatalogItemsResponse> SearchCatalogItemsAsync(
                Models.SearchCatalogItemsRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/catalog/search-catalog-items");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.SearchCatalogItemsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Updates the [CatalogModifierList]($m/CatalogModifierList) objects.
        /// that apply to the targeted [CatalogItem]($m/CatalogItem) without having.
        /// to perform an upsert on the entire item..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateItemModifierListsResponse response from the API call.</returns>
        public Models.UpdateItemModifierListsResponse UpdateItemModifierLists(
                Models.UpdateItemModifierListsRequest body)
        {
            Task<Models.UpdateItemModifierListsResponse> t = this.UpdateItemModifierListsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates the [CatalogModifierList]($m/CatalogModifierList) objects.
        /// that apply to the targeted [CatalogItem]($m/CatalogItem) without having.
        /// to perform an upsert on the entire item..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateItemModifierListsResponse response from the API call.</returns>
        public async Task<Models.UpdateItemModifierListsResponse> UpdateItemModifierListsAsync(
                Models.UpdateItemModifierListsRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/catalog/update-item-modifier-lists");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.UpdateItemModifierListsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Updates the [CatalogTax]($m/CatalogTax) objects that apply to the.
        /// targeted [CatalogItem]($m/CatalogItem) without having to perform an.
        /// upsert on the entire item..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateItemTaxesResponse response from the API call.</returns>
        public Models.UpdateItemTaxesResponse UpdateItemTaxes(
                Models.UpdateItemTaxesRequest body)
        {
            Task<Models.UpdateItemTaxesResponse> t = this.UpdateItemTaxesAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates the [CatalogTax]($m/CatalogTax) objects that apply to the.
        /// targeted [CatalogItem]($m/CatalogItem) without having to perform an.
        /// upsert on the entire item..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateItemTaxesResponse response from the API call.</returns>
        public async Task<Models.UpdateItemTaxesResponse> UpdateItemTaxesAsync(
                Models.UpdateItemTaxesRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/catalog/update-item-taxes");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.UpdateItemTaxesResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }
    }
}