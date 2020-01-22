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
    public class ListCashDrawerShiftsResponse 
    {
        public ListCashDrawerShiftsResponse(IList<Models.CashDrawerShiftSummary> items = null,
            string cursor = null,
            IList<Models.Error> errors = null)
        {
            Items = items;
            Cursor = cursor;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// A collection of CashDrawerShiftSummary objects for shifts that match
        /// the query.
        /// </summary>
        [JsonProperty("items")]
        public IList<Models.CashDrawerShiftSummary> Items { get; }

        /// <summary>
        /// Opaque cursor for fetching the next page of results. Cursor is not
        /// present in the last page of results.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Items(Items)
                .Cursor(Cursor)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private IList<Models.CashDrawerShiftSummary> items = new List<Models.CashDrawerShiftSummary>();
            private string cursor;
            private IList<Models.Error> errors = new List<Models.Error>();

            public Builder() { }
            public Builder Items(IList<Models.CashDrawerShiftSummary> value)
            {
                items = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public ListCashDrawerShiftsResponse Build()
            {
                return new ListCashDrawerShiftsResponse(items,
                    cursor,
                    errors);
            }
        }
    }
}