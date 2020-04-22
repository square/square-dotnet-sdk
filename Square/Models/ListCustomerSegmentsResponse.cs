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
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The list of customer segments belonging to the associated Square account.
        /// </summary>
        [JsonProperty("segments")]
        public IList<Models.CustomerSegment> Segments { get; }

        /// <summary>
        /// A pagination cursor to be used in subsequent calls to __ListCustomerSegments__
        /// to retrieve the next set of query results. Only present only if the request succeeded and
        /// additional results are available.
        /// See the [Pagination guide](https://developer.squareup.com/docs/docs/working-with-apis/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor")]
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
            private IList<Models.Error> errors = new List<Models.Error>();
            private IList<Models.CustomerSegment> segments = new List<Models.CustomerSegment>();
            private string cursor;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Segments(IList<Models.CustomerSegment> value)
            {
                segments = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
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