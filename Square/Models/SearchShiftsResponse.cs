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
    public class SearchShiftsResponse 
    {
        public SearchShiftsResponse(IList<Models.Shift> shifts = null,
            string cursor = null,
            IList<Models.Error> errors = null)
        {
            Shifts = shifts;
            Cursor = cursor;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Shifts
        /// </summary>
        [JsonProperty("shifts", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Shift> Shifts { get; }

        /// <summary>
        /// Opaque cursor for fetching the next page.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Shifts(Shifts)
                .Cursor(Cursor)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Shift> shifts;
            private string cursor;
            private IList<Models.Error> errors;



            public Builder Shifts(IList<Models.Shift> shifts)
            {
                this.shifts = shifts;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public SearchShiftsResponse Build()
            {
                return new SearchShiftsResponse(shifts,
                    cursor,
                    errors);
            }
        }
    }
}