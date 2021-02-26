
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListBreakTypesResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"BreakTypes = {(BreakTypes == null ? "null" : $"[{ string.Join(", ", BreakTypes)} ]")}");
            toStringOutput.Add($"Cursor = {(Cursor == null ? "null" : Cursor == string.Empty ? "" : Cursor)}");
            toStringOutput.Add($"Errors = {(Errors == null ? "null" : $"[{ string.Join(", ", Errors)} ]")}");
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

            return obj is ListBreakTypesResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((BreakTypes == null && other.BreakTypes == null) || (BreakTypes?.Equals(other.BreakTypes) == true)) &&
                ((Cursor == null && other.Cursor == null) || (Cursor?.Equals(other.Cursor) == true)) &&
                ((Errors == null && other.Errors == null) || (Errors?.Equals(other.Errors) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -285838355;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (BreakTypes != null)
            {
               hashCode += BreakTypes.GetHashCode();
            }

            if (Cursor != null)
            {
               hashCode += Cursor.GetHashCode();
            }

            if (Errors != null)
            {
               hashCode += Errors.GetHashCode();
            }

            return hashCode;
        }

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