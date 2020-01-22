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
    public class ListCashDrawerShiftEventsResponse 
    {
        public ListCashDrawerShiftEventsResponse(IList<Models.CashDrawerShiftEvent> events = null,
            string cursor = null,
            IList<Models.Error> errors = null)
        {
            Events = events;
            Cursor = cursor;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// All of the events (payments, refunds, etc.) for a cash drawer during
        /// the shift.
        /// </summary>
        [JsonProperty("events")]
        public IList<Models.CashDrawerShiftEvent> Events { get; }

        /// <summary>
        /// Opaque cursor for fetching the next page. Cursor is not present in
        /// the last page of results.
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
                .Events(Events)
                .Cursor(Cursor)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private IList<Models.CashDrawerShiftEvent> events = new List<Models.CashDrawerShiftEvent>();
            private string cursor;
            private IList<Models.Error> errors = new List<Models.Error>();

            public Builder() { }
            public Builder Events(IList<Models.CashDrawerShiftEvent> value)
            {
                events = value;
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

            public ListCashDrawerShiftEventsResponse Build()
            {
                return new ListCashDrawerShiftEventsResponse(events,
                    cursor,
                    errors);
            }
        }
    }
}