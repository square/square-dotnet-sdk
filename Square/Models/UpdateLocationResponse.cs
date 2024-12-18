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
    /// UpdateLocationResponse.
    /// </summary>
    public class UpdateLocationResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateLocationResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="location">location.</param>
        public UpdateLocationResponse(
            IList<Models.Error> errors = null,
            Models.Location location = null)
        {
            this.Errors = errors;
            this.Location = location;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information about errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents one of a business' [locations](https://developer.squareup.com/docs/locations-api).
        /// </summary>
        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Location Location { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"UpdateLocationResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is UpdateLocationResponse other && 
                ((this.Context == null && other.Context == null) 
                 || this.Context?.Equals(other.Context) == true) && 
                (this.Errors == null && other.Errors == null ||
                 this.Errors?.Equals(other.Errors) == true) &&
                (this.Location == null && other.Location == null ||
                 this.Location?.Equals(other.Location) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1207857507;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Errors, this.Location);

            return hashCode;
        }

        internal UpdateLocationResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.Location = {(this.Location == null ? "null" : this.Location.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Location(this.Location);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.Location location;

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
             /// Location.
             /// </summary>
             /// <param name="location"> location. </param>
             /// <returns> Builder. </returns>
            public Builder Location(Models.Location location)
            {
                this.location = location;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> UpdateLocationResponse. </returns>
            public UpdateLocationResponse Build()
            {
                return new UpdateLocationResponse(
                    this.errors,
                    this.location);
            }
        }
    }
}