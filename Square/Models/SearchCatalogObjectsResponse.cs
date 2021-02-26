
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class SearchCatalogObjectsResponse 
    {
        public SearchCatalogObjectsResponse(IList<Models.Error> errors = null,
            string cursor = null,
            IList<Models.CatalogObject> objects = null,
            IList<Models.CatalogObject> relatedObjects = null,
            string latestTime = null)
        {
            Errors = errors;
            Cursor = cursor;
            Objects = objects;
            RelatedObjects = relatedObjects;
            LatestTime = latestTime;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The pagination cursor to be used in a subsequent request. If unset, this is the final response.
        /// See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information.
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchCatalogObjectsResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Errors = {(Errors == null ? "null" : $"[{ string.Join(", ", Errors)} ]")}");
            toStringOutput.Add($"Cursor = {(Cursor == null ? "null" : Cursor == string.Empty ? "" : Cursor)}");
            toStringOutput.Add($"Objects = {(Objects == null ? "null" : $"[{ string.Join(", ", Objects)} ]")}");
            toStringOutput.Add($"RelatedObjects = {(RelatedObjects == null ? "null" : $"[{ string.Join(", ", RelatedObjects)} ]")}");
            toStringOutput.Add($"LatestTime = {(LatestTime == null ? "null" : LatestTime == string.Empty ? "" : LatestTime)}");
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

            return obj is SearchCatalogObjectsResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((Errors == null && other.Errors == null) || (Errors?.Equals(other.Errors) == true)) &&
                ((Cursor == null && other.Cursor == null) || (Cursor?.Equals(other.Cursor) == true)) &&
                ((Objects == null && other.Objects == null) || (Objects?.Equals(other.Objects) == true)) &&
                ((RelatedObjects == null && other.RelatedObjects == null) || (RelatedObjects?.Equals(other.RelatedObjects) == true)) &&
                ((LatestTime == null && other.LatestTime == null) || (LatestTime?.Equals(other.LatestTime) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -544883463;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (Errors != null)
            {
               hashCode += Errors.GetHashCode();
            }

            if (Cursor != null)
            {
               hashCode += Cursor.GetHashCode();
            }

            if (Objects != null)
            {
               hashCode += Objects.GetHashCode();
            }

            if (RelatedObjects != null)
            {
               hashCode += RelatedObjects.GetHashCode();
            }

            if (LatestTime != null)
            {
               hashCode += LatestTime.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Cursor(Cursor)
                .Objects(Objects)
                .RelatedObjects(RelatedObjects)
                .LatestTime(LatestTime);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private string cursor;
            private IList<Models.CatalogObject> objects;
            private IList<Models.CatalogObject> relatedObjects;
            private string latestTime;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public Builder Objects(IList<Models.CatalogObject> objects)
            {
                this.objects = objects;
                return this;
            }

            public Builder RelatedObjects(IList<Models.CatalogObject> relatedObjects)
            {
                this.relatedObjects = relatedObjects;
                return this;
            }

            public Builder LatestTime(string latestTime)
            {
                this.latestTime = latestTime;
                return this;
            }

            public SearchCatalogObjectsResponse Build()
            {
                return new SearchCatalogObjectsResponse(errors,
                    cursor,
                    objects,
                    relatedObjects,
                    latestTime);
            }
        }
    }
}