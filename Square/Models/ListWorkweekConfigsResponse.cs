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
    /// ListWorkweekConfigsResponse.
    /// </summary>
    public class ListWorkweekConfigsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListWorkweekConfigsResponse"/> class.
        /// </summary>
        /// <param name="workweekConfigs">workweek_configs.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="errors">errors.</param>
        public ListWorkweekConfigsResponse(
            IList<Models.WorkweekConfig> workweekConfigs = null,
            string cursor = null,
            IList<Models.Error> errors = null)
        {
            this.WorkweekConfigs = workweekConfigs;
            this.Cursor = cursor;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// A page of `WorkweekConfig` results.
        /// </summary>
        [JsonProperty("workweek_configs", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.WorkweekConfig> WorkweekConfigs { get; }

        /// <summary>
        /// The value supplied in the subsequent request to fetch the next page of
        /// `WorkweekConfig` results.
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

            return $"ListWorkweekConfigsResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is ListWorkweekConfigsResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.WorkweekConfigs == null && other.WorkweekConfigs == null) || (this.WorkweekConfigs?.Equals(other.WorkweekConfigs) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 232618959;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.WorkweekConfigs, this.Cursor, this.Errors);

            return hashCode;
        }
        internal ListWorkweekConfigsResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.WorkweekConfigs = {(this.WorkweekConfigs == null ? "null" : $"[{string.Join(", ", this.WorkweekConfigs)} ]")}");
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
                .WorkweekConfigs(this.WorkweekConfigs)
                .Cursor(this.Cursor)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.WorkweekConfig> workweekConfigs;
            private string cursor;
            private IList<Models.Error> errors;

             /// <summary>
             /// WorkweekConfigs.
             /// </summary>
             /// <param name="workweekConfigs"> workweekConfigs. </param>
             /// <returns> Builder. </returns>
            public Builder WorkweekConfigs(IList<Models.WorkweekConfig> workweekConfigs)
            {
                this.workweekConfigs = workweekConfigs;
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
            /// <returns> ListWorkweekConfigsResponse. </returns>
            public ListWorkweekConfigsResponse Build()
            {
                return new ListWorkweekConfigsResponse(
                    this.workweekConfigs,
                    this.cursor,
                    this.errors);
            }
        }
    }
}