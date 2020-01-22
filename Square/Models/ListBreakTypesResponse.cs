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
        [JsonProperty("break_types")]
        public IList<Models.BreakType> BreakTypes { get; }

        /// <summary>
        /// Value supplied in the subsequent request to fetch the next next page
        /// of Break Type results.
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
                .BreakTypes(BreakTypes)
                .Cursor(Cursor)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private IList<Models.BreakType> breakTypes = new List<Models.BreakType>();
            private string cursor;
            private IList<Models.Error> errors = new List<Models.Error>();

            public Builder() { }
            public Builder BreakTypes(IList<Models.BreakType> value)
            {
                breakTypes = value;
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

            public ListBreakTypesResponse Build()
            {
                return new ListBreakTypesResponse(breakTypes,
                    cursor,
                    errors);
            }
        }
    }
}