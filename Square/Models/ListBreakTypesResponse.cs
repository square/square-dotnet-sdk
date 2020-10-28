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
    public class ListBreakTypesResponse 
    {
        public ListBreakTypesResponse(IList<Models.BreakType> breakTypes = null,
            string cursor = null,
            IList<Models.Error> errors = null)
        {
            BreakTypes = breakTypes;
            Cursor = cursor;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// A page of `BreakType` results.
        /// </summary>
        [JsonProperty("break_types", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.BreakType> BreakTypes { get; }

        /// <summary>
        /// Value supplied in the subsequent request to fetch the next next page
        /// of Break Type results.
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
                .BreakTypes(BreakTypes)
                .Cursor(Cursor)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private IList<Models.BreakType> breakTypes;
            private string cursor;
            private IList<Models.Error> errors;



            public Builder BreakTypes(IList<Models.BreakType> breakTypes)
            {
                this.breakTypes = breakTypes;
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

            public ListBreakTypesResponse Build()
            {
                return new ListBreakTypesResponse(breakTypes,
                    cursor,
                    errors);
            }
        }
    }
}