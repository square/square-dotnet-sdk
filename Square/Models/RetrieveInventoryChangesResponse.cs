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
    public class RetrieveInventoryChangesResponse 
    {
        public RetrieveInventoryChangesResponse(IList<Models.Error> errors = null,
            IList<Models.InventoryChange> changes = null,
            string cursor = null)
        {
            Errors = errors;
            Changes = changes;
            Cursor = cursor;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The set of inventory changes for the requested object and locations.
        /// </summary>
        [JsonProperty("changes")]
        public IList<Models.InventoryChange> Changes { get; }

        /// <summary>
        /// The pagination cursor to be used in a subsequent request. If unset,
        /// this is the final response.
        /// See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Changes(Changes)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private IList<Models.InventoryChange> changes = new List<Models.InventoryChange>();
            private string cursor;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Changes(IList<Models.InventoryChange> value)
            {
                changes = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public RetrieveInventoryChangesResponse Build()
            {
                return new RetrieveInventoryChangesResponse(errors,
                    changes,
                    cursor);
            }
        }
    }
}