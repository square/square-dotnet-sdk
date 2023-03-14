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
    /// RetrieveCustomerSegmentResponse.
    /// </summary>
    public class RetrieveCustomerSegmentResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveCustomerSegmentResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="segment">segment.</param>
        public RetrieveCustomerSegmentResponse(
            IList<Models.Error> errors = null,
            Models.CustomerSegment segment = null)
        {
            this.Errors = errors;
            this.Segment = segment;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a group of customer profiles that match one or more predefined filter criteria.
        /// Segments (also known as Smart Groups) are defined and created within the Customer Directory in the
        /// Square Seller Dashboard or Point of Sale.
        /// </summary>
        [JsonProperty("segment", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomerSegment Segment { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RetrieveCustomerSegmentResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is RetrieveCustomerSegmentResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.Segment == null && other.Segment == null) || (this.Segment?.Equals(other.Segment) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -584513434;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.Segment);

            return hashCode;
        }
        internal RetrieveCustomerSegmentResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.Segment = {(this.Segment == null ? "null" : this.Segment.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Segment(this.Segment);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.CustomerSegment segment;

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
             /// Segment.
             /// </summary>
             /// <param name="segment"> segment. </param>
             /// <returns> Builder. </returns>
            public Builder Segment(Models.CustomerSegment segment)
            {
                this.segment = segment;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> RetrieveCustomerSegmentResponse. </returns>
            public RetrieveCustomerSegmentResponse Build()
            {
                return new RetrieveCustomerSegmentResponse(
                    this.errors,
                    this.segment);
            }
        }
    }
}