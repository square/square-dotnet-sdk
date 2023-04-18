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
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// SearchCatalogObjectsResponse.
    /// </summary>
    public class SearchCatalogObjectsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchCatalogObjectsResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="objects">objects.</param>
        /// <param name="relatedObjects">related_objects.</param>
        /// <param name="latestTime">latest_time.</param>
        public SearchCatalogObjectsResponse(
            IList<Models.Error> errors = null,
            string cursor = null,
            IList<Models.CatalogObject> objects = null,
            IList<Models.CatalogObject> relatedObjects = null,
            string latestTime = null)
        {
            this.Errors = errors;
            this.Cursor = cursor;
            this.Objects = objects;
            this.RelatedObjects = relatedObjects;
            this.LatestTime = latestTime;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The pagination cursor to be used in a subsequent request. If unset, this is the final response.
        /// See [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// The CatalogObjects returned.
        /// </summary>
        [JsonProperty("objects", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CatalogObject> Objects { get; }

        /// <summary>
        /// A list of CatalogObjects referenced by the objects in the `objects` field.
        /// </summary>
        [JsonProperty("related_objects", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CatalogObject> RelatedObjects { get; }

        /// <summary>
        /// When the associated product catalog was last updated. Will
        /// match the value for `end_time` or `cursor` if either field is included in the `SearchCatalog` request.
        /// </summary>
        [JsonProperty("latest_time", NullValueHandling = NullValueHandling.Ignore)]
        public string LatestTime { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchCatalogObjectsResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is SearchCatalogObjectsResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.Objects == null && other.Objects == null) || (this.Objects?.Equals(other.Objects) == true)) &&
                ((this.RelatedObjects == null && other.RelatedObjects == null) || (this.RelatedObjects?.Equals(other.RelatedObjects) == true)) &&
                ((this.LatestTime == null && other.LatestTime == null) || (this.LatestTime?.Equals(other.LatestTime) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -544883463;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.Cursor, this.Objects, this.RelatedObjects, this.LatestTime);

            return hashCode;
        }
        internal SearchCatalogObjectsResponse ContextSetter(HttpContext context)
        {
            this.Context = context;
            return this;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
            toStringOutput.Add($"this.Objects = {(this.Objects == null ? "null" : $"[{string.Join(", ", this.Objects)} ]")}");
            toStringOutput.Add($"this.RelatedObjects = {(this.RelatedObjects == null ? "null" : $"[{string.Join(", ", this.RelatedObjects)} ]")}");
            toStringOutput.Add($"this.LatestTime = {(this.LatestTime == null ? "null" : this.LatestTime == string.Empty ? "" : this.LatestTime)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Cursor(this.Cursor)
                .Objects(this.Objects)
                .RelatedObjects(this.RelatedObjects)
                .LatestTime(this.LatestTime);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private string cursor;
            private IList<Models.CatalogObject> objects;
            private IList<Models.CatalogObject> relatedObjects;
            private string latestTime;

             /// <summary>
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

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
             /// Objects.
             /// </summary>
             /// <param name="objects"> objects. </param>
             /// <returns> Builder. </returns>
            public Builder Objects(IList<Models.CatalogObject> objects)
            {
                this.objects = objects;
                return this;
            }

             /// <summary>
             /// RelatedObjects.
             /// </summary>
             /// <param name="relatedObjects"> relatedObjects. </param>
             /// <returns> Builder. </returns>
            public Builder RelatedObjects(IList<Models.CatalogObject> relatedObjects)
            {
                this.relatedObjects = relatedObjects;
                return this;
            }

             /// <summary>
             /// LatestTime.
             /// </summary>
             /// <param name="latestTime"> latestTime. </param>
             /// <returns> Builder. </returns>
            public Builder LatestTime(string latestTime)
            {
                this.latestTime = latestTime;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchCatalogObjectsResponse. </returns>
            public SearchCatalogObjectsResponse Build()
            {
                return new SearchCatalogObjectsResponse(
                    this.errors,
                    this.cursor,
                    this.objects,
                    this.relatedObjects,
                    this.latestTime);
            }
        }
    }
}