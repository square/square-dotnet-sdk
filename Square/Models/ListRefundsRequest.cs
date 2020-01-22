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
    public class ListRefundsRequest 
    {
        public ListRefundsRequest(string beginTime = null,
            string endTime = null,
            string sortOrder = null,
            string cursor = null)
        {
            BeginTime = beginTime;
            EndTime = endTime;
            SortOrder = sortOrder;
            Cursor = cursor;
        }

        /// <summary>
        /// The beginning of the requested reporting period, in RFC 3339 format.
        /// See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.
        /// Default value: The current time minus one year.
        /// </summary>
        [JsonProperty("begin_time")]
        public string BeginTime { get; }

        /// <summary>
        /// The end of the requested reporting period, in RFC 3339 format.
        /// See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.
        /// Default value: The current time.
        /// </summary>
        [JsonProperty("end_time")]
        public string EndTime { get; }

        /// <summary>
        /// The order (e.g., chronological or alphabetical) in which results from a request are returned.
        /// </summary>
        [JsonProperty("sort_order")]
        public string SortOrder { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this to retrieve the next set of results for your original query.
        /// See [Paginating results](#paginatingresults) for more information.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .BeginTime(BeginTime)
                .EndTime(EndTime)
                .SortOrder(SortOrder)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private string beginTime;
            private string endTime;
            private string sortOrder;
            private string cursor;

            public Builder() { }
            public Builder BeginTime(string value)
            {
                beginTime = value;
                return this;
            }

            public Builder EndTime(string value)
            {
                endTime = value;
                return this;
            }

            public Builder SortOrder(string value)
            {
                sortOrder = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public ListRefundsRequest Build()
            {
                return new ListRefundsRequest(beginTime,
                    endTime,
                    sortOrder,
                    cursor);
            }
        }
    }
}