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
    public class ListCustomerSegmentsResponse 
    {
        public ListCustomerSegmentsResponse(IList<Models.Error> errors = null,
            IList<Models.CustomerSegment> segments = null,
            string cursor = null)
        {
            Errors = errors;
            Segments = segments;
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
        /// The list of customer segments belonging to the associated Square account.
        /// </summary>
        [JsonProperty("segments", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CustomerSegment> Segments { get; }

        /// <summary>
        /// A pagination cursor to be used in subsequent calls to __ListCustomerSegments__
        /// to retrieve the next set of query results. Only present only if the request succeeded and
        /// additional results are available.
        /// See the [Pagination guide](https://developer.squareup.com/docs/working-with-apis/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Segments(Segments)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.CustomerSegment> segments;
            private string cursor;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Segments(IList<Models.CustomerSegment> segments)
            {
                this.segments = segments;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public ListCustomerSegmentsResponse Build()
            {
                return new ListCustomerSegmentsResponse(errors,
                    segments,
                    cursor);
            }
        }
    }
}