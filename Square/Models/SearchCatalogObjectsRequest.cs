namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// SearchCatalogObjectsRequest.
    /// </summary>
    public class SearchCatalogObjectsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchCatalogObjectsRequest"/> class.
        /// </summary>
        /// <param name="cursor">cursor.</param>
        /// <param name="objectTypes">object_types.</param>
        /// <param name="includeDeletedObjects">include_deleted_objects.</param>
        /// <param name="includeRelatedObjects">include_related_objects.</param>
        /// <param name="beginTime">begin_time.</param>
        /// <param name="query">query.</param>
        /// <param name="limit">limit.</param>
        public SearchCatalogObjectsRequest(
            string cursor = null,
            IList<string> objectTypes = null,
            bool? includeDeletedObjects = null,
            bool? includeRelatedObjects = null,
            string beginTime = null,
            Models.CatalogQuery query = null,
            int? limit = null)
        {
            this.Cursor = cursor;
            this.ObjectTypes = objectTypes;
            this.IncludeDeletedObjects = includeDeletedObjects;
            this.IncludeRelatedObjects = includeRelatedObjects;
            this.BeginTime = beginTime;
            this.Query = query;
            this.Limit = limit;
        }

        /// <summary>
        /// The pagination cursor returned in the previous response. Leave unset for an initial request.
        /// See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// The desired set of object types to appear in the search results.
        /// If this is unspecified, the operation returns objects of all the top level types at the version
        /// of the Square API used to make the request. Object types that are nested onto other object types
        /// are not included in the defaults.
        /// At the current API version the default object types are:
        /// ITEM, CATEGORY, TAX, DISCOUNT, MODIFIER_LIST,
        /// PRICING_RULE, PRODUCT_SET, TIME_PERIOD, MEASUREMENT_UNIT,
        /// SUBSCRIPTION_PLAN, ITEM_OPTION, CUSTOM_ATTRIBUTE_DEFINITION, QUICK_AMOUNT_SETTINGS.
        /// </summary>
        [JsonProperty("object_types", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> ObjectTypes { get; }

        /// <summary>
        /// If `true`, deleted objects will be included in the results. Deleted objects will have their
        /// `is_deleted` field set to `true`.
        /// </summary>
        [JsonProperty("include_deleted_objects", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IncludeDeletedObjects { get; }

        /// <summary>
        /// If `true`, the response will include additional objects that are related to the
        /// requested objects. Related objects are objects that are referenced by object ID by the objects
        /// in the response. This is helpful if the objects are being fetched for immediate display to a user.
        /// This process only goes one level deep. Objects referenced by the related objects will not be included.
        /// For example:
        /// If the `objects` field of the response contains a CatalogItem, its associated
        /// CatalogCategory objects, CatalogTax objects, CatalogImage objects and
        /// CatalogModifierLists will be returned in the `related_objects` field of the
        /// response. If the `objects` field of the response contains a CatalogItemVariation,
        /// its parent CatalogItem will be returned in the `related_objects` field of
        /// the response.
        /// Default value: `false`
        /// </summary>
        [JsonProperty("include_related_objects", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IncludeRelatedObjects { get; }

        /// <summary>
        /// Return objects modified after this [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates), in RFC 3339
        /// format, e.g., `2016-09-04T23:59:33.123Z`. The timestamp is exclusive - objects with a
        /// timestamp equal to `begin_time` will not be included in the response.
        /// </summary>
        [JsonProperty("begin_time", NullValueHandling = NullValueHandling.Ignore)]
        public string BeginTime { get; }

        /// <summary>
        /// A query composed of one or more different types of filters to narrow the scope of targeted objects when calling the `SearchCatalogObjects` endpoint.
        /// Although a query can have multiple filters, only certain query types can be combined per call to [SearchCatalogObjects]($e/Catalog/SearchCatalogObjects).
        /// Any combination of the following types may be used together:
        /// - [exact_query]($m/CatalogQueryExact)
        /// - [prefix_query]($m/CatalogQueryPrefix)
        /// - [range_query]($m/CatalogQueryRange)
        /// - [sorted_attribute_query]($m/CatalogQuerySortedAttribute)
        /// - [text_query]($m/CatalogQueryText)
        /// All other query types cannot be combined with any others.
        /// When a query filter is based on an attribute, the attribute must be searchable.
        /// Searchable attributes are listed as follows, along their parent types that can be searched for with applicable query filters.
        /// * Searchable attribute and objects queryable by searchable attributes **
        /// - `name`:  `CatalogItem`, `CatalogItemVariation`, `CatalogCategory`, `CatalogTax`, `CatalogDiscount`, `CatalogModifier`, 'CatalogModifierList`, `CatalogItemOption`, `CatalogItemOptionValue`
        /// - `description`: `CatalogItem`, `CatalogItemOptionValue`
        /// - `abbreviation`: `CatalogItem`
        /// - `upc`: `CatalogItemVariation`
        /// - `sku`: `CatalogItemVariation`
        /// - `caption`: `CatalogImage`
        /// - `display_name`: `CatalogItemOption`
        /// For example, to search for [CatalogItem]($m/CatalogItem) objects by searchable attributes, you can use
        /// the `"name"`, `"description"`, or `"abbreviation"` attribute in an applicable query filter.
        /// </summary>
        [JsonProperty("query", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogQuery Query { get; }

        /// <summary>
        /// A limit on the number of results to be returned in a single page. The limit is advisory -
        /// the implementation may return more or fewer results. If the supplied limit is negative, zero, or
        /// is higher than the maximum limit of 1,000, it will be ignored.
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchCatalogObjectsRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is SearchCatalogObjectsRequest other &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.ObjectTypes == null && other.ObjectTypes == null) || (this.ObjectTypes?.Equals(other.ObjectTypes) == true)) &&
                ((this.IncludeDeletedObjects == null && other.IncludeDeletedObjects == null) || (this.IncludeDeletedObjects?.Equals(other.IncludeDeletedObjects) == true)) &&
                ((this.IncludeRelatedObjects == null && other.IncludeRelatedObjects == null) || (this.IncludeRelatedObjects?.Equals(other.IncludeRelatedObjects) == true)) &&
                ((this.BeginTime == null && other.BeginTime == null) || (this.BeginTime?.Equals(other.BeginTime) == true)) &&
                ((this.Query == null && other.Query == null) || (this.Query?.Equals(other.Query) == true)) &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 405501134;
            hashCode = HashCode.Combine(this.Cursor, this.ObjectTypes, this.IncludeDeletedObjects, this.IncludeRelatedObjects, this.BeginTime, this.Query, this.Limit);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
            toStringOutput.Add($"this.ObjectTypes = {(this.ObjectTypes == null ? "null" : $"[{string.Join(", ", this.ObjectTypes)} ]")}");
            toStringOutput.Add($"this.IncludeDeletedObjects = {(this.IncludeDeletedObjects == null ? "null" : this.IncludeDeletedObjects.ToString())}");
            toStringOutput.Add($"this.IncludeRelatedObjects = {(this.IncludeRelatedObjects == null ? "null" : this.IncludeRelatedObjects.ToString())}");
            toStringOutput.Add($"this.BeginTime = {(this.BeginTime == null ? "null" : this.BeginTime == string.Empty ? "" : this.BeginTime)}");
            toStringOutput.Add($"this.Query = {(this.Query == null ? "null" : this.Query.ToString())}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Cursor(this.Cursor)
                .ObjectTypes(this.ObjectTypes)
                .IncludeDeletedObjects(this.IncludeDeletedObjects)
                .IncludeRelatedObjects(this.IncludeRelatedObjects)
                .BeginTime(this.BeginTime)
                .Query(this.Query)
                .Limit(this.Limit);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string cursor;
            private IList<string> objectTypes;
            private bool? includeDeletedObjects;
            private bool? includeRelatedObjects;
            private string beginTime;
            private Models.CatalogQuery query;
            private int? limit;

             /// <summary>
             /// Cursor.
             /// </summary>
             /// <param name="cursor"> cursor. </param>
             /// <returns> Builder. </returns>
            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

             /// <summary>
             /// ObjectTypes.
             /// </summary>
             /// <param name="objectTypes"> objectTypes. </param>
             /// <returns> Builder. </returns>
            public Builder ObjectTypes(IList<string> objectTypes)
            {
                this.objectTypes = objectTypes;
                return this;
            }

             /// <summary>
             /// IncludeDeletedObjects.
             /// </summary>
             /// <param name="includeDeletedObjects"> includeDeletedObjects. </param>
             /// <returns> Builder. </returns>
            public Builder IncludeDeletedObjects(bool? includeDeletedObjects)
            {
                this.includeDeletedObjects = includeDeletedObjects;
                return this;
            }

             /// <summary>
             /// IncludeRelatedObjects.
             /// </summary>
             /// <param name="includeRelatedObjects"> includeRelatedObjects. </param>
             /// <returns> Builder. </returns>
            public Builder IncludeRelatedObjects(bool? includeRelatedObjects)
            {
                this.includeRelatedObjects = includeRelatedObjects;
                return this;
            }

             /// <summary>
             /// BeginTime.
             /// </summary>
             /// <param name="beginTime"> beginTime. </param>
             /// <returns> Builder. </returns>
            public Builder BeginTime(string beginTime)
            {
                this.beginTime = beginTime;
                return this;
            }

             /// <summary>
             /// Query.
             /// </summary>
             /// <param name="query"> query. </param>
             /// <returns> Builder. </returns>
            public Builder Query(Models.CatalogQuery query)
            {
                this.query = query;
                return this;
            }

             /// <summary>
             /// Limit.
             /// </summary>
             /// <param name="limit"> limit. </param>
             /// <returns> Builder. </returns>
            public Builder Limit(int? limit)
            {
                this.limit = limit;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchCatalogObjectsRequest. </returns>
            public SearchCatalogObjectsRequest Build()
            {
                return new SearchCatalogObjectsRequest(
                    this.cursor,
                    this.objectTypes,
                    this.includeDeletedObjects,
                    this.includeRelatedObjects,
                    this.beginTime,
                    this.query,
                    this.limit);
            }
        }
    }
}