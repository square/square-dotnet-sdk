
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class SearchCatalogObjectsRequest 
    {
        public SearchCatalogObjectsRequest(string cursor = null,
            IList<string> objectTypes = null,
            bool? includeDeletedObjects = null,
            bool? includeRelatedObjects = null,
            string beginTime = null,
            Models.CatalogQuery query = null,
            int? limit = null)
        {
            Cursor = cursor;
            ObjectTypes = objectTypes;
            IncludeDeletedObjects = includeDeletedObjects;
            IncludeRelatedObjects = includeRelatedObjects;
            BeginTime = beginTime;
            Query = query;
            Limit = limit;
        }

        /// <summary>
        /// The pagination cursor returned in the previous response. Leave unset for an initial request.
        /// See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// The desired set of object types to appear in the search results.
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
        /// requested object, as follows:
        /// If a CatalogItem is returned in the object field of the response,
        /// its associated CatalogCategory, CatalogTax objects,
        /// CatalogImage objects and CatalogModifierList objects
        /// will be included in the `related_objects` field of the response.
        /// If a CatalogItemVariation is returned in the object field of the
        /// response, its parent CatalogItem will be included in the `related_objects` field of
        /// the response.
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
        /// Although a query can have multiple filters, only certain query types can be combined per call to [SearchCatalogObjects](#endpoint-Catalog-SearchCatalogObjects).
        /// Any combination of the following types may be used together:
        /// - [exact_query](#type-CatalogExactQuery)
        /// - [prefix_query](#type-CatalogPrefixQuery)
        /// - [range_query](#type-CatalogRangeQuery)
        /// - [sorted_attribute_query](#type-CatalogSortedAttribute)
        /// - [text_query](#type-CatalogTextQuery)
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
        /// For example, to search for [CatalogItem](#type-CatalogItem) objects by searchable attributes, you can use
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchCatalogObjectsRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Cursor = {(Cursor == null ? "null" : Cursor == string.Empty ? "" : Cursor)}");
            toStringOutput.Add($"ObjectTypes = {(ObjectTypes == null ? "null" : $"[{ string.Join(", ", ObjectTypes)} ]")}");
            toStringOutput.Add($"IncludeDeletedObjects = {(IncludeDeletedObjects == null ? "null" : IncludeDeletedObjects.ToString())}");
            toStringOutput.Add($"IncludeRelatedObjects = {(IncludeRelatedObjects == null ? "null" : IncludeRelatedObjects.ToString())}");
            toStringOutput.Add($"BeginTime = {(BeginTime == null ? "null" : BeginTime == string.Empty ? "" : BeginTime)}");
            toStringOutput.Add($"Query = {(Query == null ? "null" : Query.ToString())}");
            toStringOutput.Add($"Limit = {(Limit == null ? "null" : Limit.ToString())}");
        }

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
                ((Cursor == null && other.Cursor == null) || (Cursor?.Equals(other.Cursor) == true)) &&
                ((ObjectTypes == null && other.ObjectTypes == null) || (ObjectTypes?.Equals(other.ObjectTypes) == true)) &&
                ((IncludeDeletedObjects == null && other.IncludeDeletedObjects == null) || (IncludeDeletedObjects?.Equals(other.IncludeDeletedObjects) == true)) &&
                ((IncludeRelatedObjects == null && other.IncludeRelatedObjects == null) || (IncludeRelatedObjects?.Equals(other.IncludeRelatedObjects) == true)) &&
                ((BeginTime == null && other.BeginTime == null) || (BeginTime?.Equals(other.BeginTime) == true)) &&
                ((Query == null && other.Query == null) || (Query?.Equals(other.Query) == true)) &&
                ((Limit == null && other.Limit == null) || (Limit?.Equals(other.Limit) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 405501134;

            if (Cursor != null)
            {
               hashCode += Cursor.GetHashCode();
            }

            if (ObjectTypes != null)
            {
               hashCode += ObjectTypes.GetHashCode();
            }

            if (IncludeDeletedObjects != null)
            {
               hashCode += IncludeDeletedObjects.GetHashCode();
            }

            if (IncludeRelatedObjects != null)
            {
               hashCode += IncludeRelatedObjects.GetHashCode();
            }

            if (BeginTime != null)
            {
               hashCode += BeginTime.GetHashCode();
            }

            if (Query != null)
            {
               hashCode += Query.GetHashCode();
            }

            if (Limit != null)
            {
               hashCode += Limit.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Cursor(Cursor)
                .ObjectTypes(ObjectTypes)
                .IncludeDeletedObjects(IncludeDeletedObjects)
                .IncludeRelatedObjects(IncludeRelatedObjects)
                .BeginTime(BeginTime)
                .Query(Query)
                .Limit(Limit);
            return builder;
        }

        public class Builder
        {
            private string cursor;
            private IList<string> objectTypes;
            private bool? includeDeletedObjects;
            private bool? includeRelatedObjects;
            private string beginTime;
            private Models.CatalogQuery query;
            private int? limit;



            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public Builder ObjectTypes(IList<string> objectTypes)
            {
                this.objectTypes = objectTypes;
                return this;
            }

            public Builder IncludeDeletedObjects(bool? includeDeletedObjects)
            {
                this.includeDeletedObjects = includeDeletedObjects;
                return this;
            }

            public Builder IncludeRelatedObjects(bool? includeRelatedObjects)
            {
                this.includeRelatedObjects = includeRelatedObjects;
                return this;
            }

            public Builder BeginTime(string beginTime)
            {
                this.beginTime = beginTime;
                return this;
            }

            public Builder Query(Models.CatalogQuery query)
            {
                this.query = query;
                return this;
            }

            public Builder Limit(int? limit)
            {
                this.limit = limit;
                return this;
            }

            public SearchCatalogObjectsRequest Build()
            {
                return new SearchCatalogObjectsRequest(cursor,
                    objectTypes,
                    includeDeletedObjects,
                    includeRelatedObjects,
                    beginTime,
                    query,
                    limit);
            }
        }
    }
}