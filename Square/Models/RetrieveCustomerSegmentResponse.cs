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
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a group of customer profiles that match one or more predefined filter criteria. 
        /// Segments (also known as Smart Groups) are defined and created within Customer Directory in the Square Dashboard or Point of Sale.
        /// </summary>
        [JsonProperty("segment")]
        public Models.CustomerSegment Segment { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Segment(Segment);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private Models.CustomerSegment segment;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Segment(Models.CustomerSegment value)
            {
                segment = value;
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