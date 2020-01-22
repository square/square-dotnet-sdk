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
    public class DeleteCatalogObjectResponse 
    {
        public DeleteCatalogObjectResponse(IList<Models.Error> errors = null,
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
        /// Information on any errors encountered.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The IDs of all catalog objects deleted by this request.
        /// Multiple IDs may be returned when associated objects are also deleted, for example
        /// a catalog item variation will be deleted (and its ID included in this field)
        /// when its parent catalog item is deleted.
        /// </summary>
        [JsonProperty("deleted_object_ids")]
        public IList<string> DeletedObjectIds { get; }

        /// <summary>
        /// The database [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// of this deletion in RFC 3339 format, e.g., `2016-09-04T23:59:33.123Z`.
        /// </summary>
        [JsonProperty("deleted_at")]
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
            private IList<Models.Error> errors = new List<Models.Error>();
            private IList<string> deletedObjectIds = new List<string>();
            private string deletedAt;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder DeletedObjectIds(IList<string> value)
            {
                deletedObjectIds = value;
                return this;
            }

            public Builder DeletedAt(string value)
            {
                deletedAt = value;
                return this;
            }

            public DeleteCatalogObjectResponse Build()
            {
                return new DeleteCatalogObjectResponse(errors,
                    deletedObjectIds,
                    deletedAt);
            }
        }
    }
}