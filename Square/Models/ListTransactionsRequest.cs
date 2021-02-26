
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
    public class ListTransactionsRequest 
    {
        public ListTransactionsRequest(string beginTime = null,
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
        [JsonProperty("begin_time", NullValueHandling = NullValueHandling.Ignore)]
        public string BeginTime { get; }

        /// <summary>
        /// The end of the requested reporting period, in RFC 3339 format.
        /// See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.
        /// Default value: The current time.
        /// </summary>
        [JsonProperty("end_time", NullValueHandling = NullValueHandling.Ignore)]
        public string EndTime { get; }

        /// <summary>
        /// The order (e.g., chronological or alphabetical) in which results from a request are returned.
        /// </summary>
        [JsonProperty("sort_order", NullValueHandling = NullValueHandling.Ignore)]
        public string SortOrder { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this to retrieve the next set of results for your original query.
        /// See [Paginating results](#paginatingresults) for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListTransactionsRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"BeginTime = {(BeginTime == null ? "null" : BeginTime == string.Empty ? "" : BeginTime)}");
            toStringOutput.Add($"EndTime = {(EndTime == null ? "null" : EndTime == string.Empty ? "" : EndTime)}");
            toStringOutput.Add($"SortOrder = {(SortOrder == null ? "null" : SortOrder.ToString())}");
            toStringOutput.Add($"Cursor = {(Cursor == null ? "null" : Cursor == string.Empty ? "" : Cursor)}");
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

            return obj is ListTransactionsRequest other &&
                ((BeginTime == null && other.BeginTime == null) || (BeginTime?.Equals(other.BeginTime) == true)) &&
                ((EndTime == null && other.EndTime == null) || (EndTime?.Equals(other.EndTime) == true)) &&
                ((SortOrder == null && other.SortOrder == null) || (SortOrder?.Equals(other.SortOrder) == true)) &&
                ((Cursor == null && other.Cursor == null) || (Cursor?.Equals(other.Cursor) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -617430017;

            if (BeginTime != null)
            {
               hashCode += BeginTime.GetHashCode();
            }

            if (EndTime != null)
            {
               hashCode += EndTime.GetHashCode();
            }

            if (SortOrder != null)
            {
               hashCode += SortOrder.GetHashCode();
            }

            if (Cursor != null)
            {
               hashCode += Cursor.GetHashCode();
            }

            return hashCode;
        }

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



            public Builder BeginTime(string beginTime)
            {
                this.beginTime = beginTime;
                return this;
            }

            public Builder EndTime(string endTime)
            {
                this.endTime = endTime;
                return this;
            }

            public Builder SortOrder(string sortOrder)
            {
                this.sortOrder = sortOrder;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public ListTransactionsRequest Build()
            {
                return new ListTransactionsRequest(beginTime,
                    endTime,
                    sortOrder,
                    cursor);
            }
        }
    }
}