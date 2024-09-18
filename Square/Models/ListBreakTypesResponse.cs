using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Http.Client;
using Square.Utilities;

namespace Square.Models
{
    /// <summary>
    /// ListBreakTypesResponse.
    /// </summary>
    public class ListBreakTypesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListBreakTypesResponse"/> class.
        /// </summary>
        /// <param name="breakTypes">break_types.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="errors">errors.</param>
        public ListBreakTypesResponse(
            IList<Models.BreakType> breakTypes = null,
            string cursor = null,
            IList<Models.Error> errors = null)
        {
            this.BreakTypes = breakTypes;
            this.Cursor = cursor;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// A page of `BreakType` results.
        /// </summary>
        [JsonProperty("break_types", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.BreakType> BreakTypes { get; }

        /// <summary>
        /// The value supplied in the subsequent request to fetch the next page
        /// of `BreakType` results.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListBreakTypesResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
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
            return obj is ListBreakTypesResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.BreakTypes == null && other.BreakTypes == null) || (this.BreakTypes?.Equals(other.BreakTypes) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -285838355;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.BreakTypes, this.Cursor, this.Errors);

            return hashCode;
        }
        internal ListBreakTypesResponse ContextSetter(HttpContext context)
        {
            this.Context = context;
            return this;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BreakTypes = {(this.BreakTypes == null ? "null" : $"[{string.Join(", ", this.BreakTypes)} ]")}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor)}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .BreakTypes(this.BreakTypes)
                .Cursor(this.Cursor)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.BreakType> breakTypes;
            private string cursor;
            private IList<Models.Error> errors;

             /// <summary>
             /// BreakTypes.
             /// </summary>
             /// <param name="breakTypes"> breakTypes. </param>
             /// <returns> Builder. </returns>
            public Builder BreakTypes(IList<Models.BreakType> breakTypes)
            {
                this.breakTypes = breakTypes;
                return this;
            }

             /// <summary>
             /// Cursor.
             /// </summary>
             /// <param name="cursor"> cursor. </param>
             /// <returns> Builder. </returns>
            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

             /// <summary>
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListBreakTypesResponse. </returns>
            public ListBreakTypesResponse Build()
            {
                return new ListBreakTypesResponse(
                    this.breakTypes,
                    this.cursor,
                    this.errors);
            }
        }
    }
}