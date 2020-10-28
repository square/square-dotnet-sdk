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
    public class BatchDeleteCatalogObjectsResponse 
    {
        public BatchDeleteCatalogObjectsResponse(IList<Models.Error> errors = null,
            IList<string> deletedObjectIds = null,
            string deletedAt = null)
        {
            Errors = errors;
            DeletedObjectIds = deletedObjectIds;
            DeletedAt = deletedAt;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The IDs of all CatalogObjects deleted by this request.
        /// </summary>
        [JsonProperty("deleted_object_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> DeletedObjectIds { get; }

        /// <summary>
        /// The database [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates) of this deletion in RFC 3339 format, e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("deleted_at", NullValueHandling = NullValueHandling.Ignore)]
        public string DeletedAt { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .DeletedObjectIds(DeletedObjectIds)
                .DeletedAt(DeletedAt);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<string> deletedObjectIds;
            private string deletedAt;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder DeletedObjectIds(IList<string> deletedObjectIds)
            {
                this.deletedObjectIds = deletedObjectIds;
                return this;
            }

            public Builder DeletedAt(string deletedAt)
            {
                this.deletedAt = deletedAt;
                return this;
            }

            public BatchDeleteCatalogObjectsResponse Build()
            {
                return new BatchDeleteCatalogObjectsResponse(errors,
                    deletedObjectIds,
                    deletedAt);
            }
        }
    }
}