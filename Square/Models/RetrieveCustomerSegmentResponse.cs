
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
    public class RetrieveCustomerSegmentResponse 
    {
        public RetrieveCustomerSegmentResponse(IList<Models.Error> errors = null,
            Models.CustomerSegment segment = null)
        {
            Errors = errors;
            Segment = segment;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a group of customer profiles that match one or more predefined filter criteria. 
        /// Segments (also known as Smart Groups) are defined and created within Customer Directory in the Square Dashboard or Point of Sale.
        /// </summary>
        [JsonProperty("segment", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomerSegment Segment { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RetrieveCustomerSegmentResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Errors = {(Errors == null ? "null" : $"[{ string.Join(", ", Errors)} ]")}");
            toStringOutput.Add($"Segment = {(Segment == null ? "null" : Segment.ToString())}");
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

            return obj is RetrieveCustomerSegmentResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((Errors == null && other.Errors == null) || (Errors?.Equals(other.Errors) == true)) &&
                ((Segment == null && other.Segment == null) || (Segment?.Equals(other.Segment) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -584513434;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (Errors != null)
            {
               hashCode += Errors.GetHashCode();
            }

            if (Segment != null)
            {
               hashCode += Segment.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Segment(Segment);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.CustomerSegment segment;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Segment(Models.CustomerSegment segment)
            {
                this.segment = segment;
                return this;
            }

            public RetrieveCustomerSegmentResponse Build()
            {
                return new RetrieveCustomerSegmentResponse(errors,
                    segment);
            }
        }
    }
}