namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// SearchShiftsResponse.
    /// </summary>
    public class SearchShiftsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchShiftsResponse"/> class.
        /// </summary>
        /// <param name="shifts">shifts.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="errors">errors.</param>
        public SearchShiftsResponse(
            IList<Models.Shift> shifts = null,
            string cursor = null,
            IList<Models.Error> errors = null)
        {
            this.Shifts = shifts;
            this.Cursor = cursor;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Shifts.
        /// </summary>
        [JsonProperty("shifts", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Shift> Shifts { get; }

        /// <summary>
        /// An opaque cursor for fetching the next page.
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

            return $"SearchShiftsResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is SearchShiftsResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Shifts == null && other.Shifts == null) || (this.Shifts?.Equals(other.Shifts) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -614202023;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }

            if (this.Shifts != null)
            {
               hashCode += this.Shifts.GetHashCode();
            }

            if (this.Cursor != null)
            {
               hashCode += this.Cursor.GetHashCode();
            }

            if (this.Errors != null)
            {
               hashCode += this.Errors.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Shifts = {(this.Shifts == null ? "null" : $"[{string.Join(", ", this.Shifts)} ]")}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Shifts(this.Shifts)
                .Cursor(this.Cursor)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Shift> shifts;
            private string cursor;
            private IList<Models.Error> errors;

             /// <summary>
             /// Shifts.
             /// </summary>
             /// <param name="shifts"> shifts. </param>
             /// <returns> Builder. </returns>
            public Builder Shifts(IList<Models.Shift> shifts)
            {
                this.shifts = shifts;
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
            /// <returns> SearchShiftsResponse. </returns>
            public SearchShiftsResponse Build()
            {
                return new SearchShiftsResponse(
                    this.shifts,
                    this.cursor,
                    this.errors);
            }
        }
    }
}