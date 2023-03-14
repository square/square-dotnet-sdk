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
    /// SearchAvailabilityResponse.
    /// </summary>
    public class SearchAvailabilityResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchAvailabilityResponse"/> class.
        /// </summary>
        /// <param name="availabilities">availabilities.</param>
        /// <param name="errors">errors.</param>
        public SearchAvailabilityResponse(
            IList<Models.Availability> availabilities = null,
            IList<Models.Error> errors = null)
        {
            this.Availabilities = availabilities;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// List of appointment slots available for booking.
        /// </summary>
        [JsonProperty("availabilities", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Availability> Availabilities { get; }

        /// <summary>
        /// Errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchAvailabilityResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is SearchAvailabilityResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Availabilities == null && other.Availabilities == null) || (this.Availabilities?.Equals(other.Availabilities) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 130152793;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Availabilities, this.Errors);

            return hashCode;
        }
        internal SearchAvailabilityResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.Availabilities = {(this.Availabilities == null ? "null" : $"[{string.Join(", ", this.Availabilities)} ]")}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Availabilities(this.Availabilities)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Availability> availabilities;
            private IList<Models.Error> errors;

             /// <summary>
             /// Availabilities.
             /// </summary>
             /// <param name="availabilities"> availabilities. </param>
             /// <returns> Builder. </returns>
            public Builder Availabilities(IList<Models.Availability> availabilities)
            {
                this.availabilities = availabilities;
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
            /// <returns> SearchAvailabilityResponse. </returns>
            public SearchAvailabilityResponse Build()
            {
                return new SearchAvailabilityResponse(
                    this.availabilities,
                    this.errors);
            }
        }
    }
}