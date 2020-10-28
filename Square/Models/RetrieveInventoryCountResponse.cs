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
    public class RetrieveInventoryCountResponse 
    {
        public RetrieveInventoryCountResponse(IList<Models.Error> errors = null,
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
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The current calculated inventory counts for the requested object and
        /// locations.
        /// </summary>
        [JsonProperty("counts", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.InventoryCount> Counts { get; }

        /// <summary>
        /// The pagination cursor to be used in a subsequent request. If unset,
        /// this is the final response.
        /// See the [Pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination) guide for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
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
            private IList<Models.Error> errors;
            private IList<Models.InventoryCount> counts;
            private string cursor;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Counts(IList<Models.InventoryCount> counts)
            {
                this.counts = counts;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public RetrieveInventoryCountResponse Build()
            {
                return new RetrieveInventoryCountResponse(errors,
                    counts,
                    cursor);
            }
        }
    }
}