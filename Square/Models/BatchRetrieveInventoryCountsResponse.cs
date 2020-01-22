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
    public class BatchRetrieveInventoryCountsResponse 
    {
        public BatchRetrieveInventoryCountsResponse(IList<Models.Error> errors = null,
            IList<Models.InventoryCount> counts = null,
            string cursor = null)
        {
            Errors = errors;
            Counts = counts;
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
        /// The current calculated inventory counts for the requested objects
        /// and locations.
        /// </summary>
        [JsonProperty("counts")]
        public IList<Models.InventoryCount> Counts { get; }

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
                .Counts(Counts)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private IList<Models.InventoryCount> counts = new List<Models.InventoryCount>();
            private string cursor;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Counts(IList<Models.InventoryCount> value)
            {
                counts = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public BatchRetrieveInventoryCountsResponse Build()
            {
                return new BatchRetrieveInventoryCountsResponse(errors,
                    counts,
                    cursor);
            }
        }
    }
}