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
    public class CalculateLoyaltyPointsResponse 
    {
        public CalculateLoyaltyPointsResponse(IList<Models.Error> errors = null,
            int? points = null)
        {
            Errors = errors;
            Points = points;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The points that the buyer can earn from a specified purchase.
        /// </summary>
        [JsonProperty("points", NullValueHandling = NullValueHandling.Ignore)]
        public int? Points { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Points(Points);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private int? points;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Points(int? points)
            {
                this.points = points;
                return this;
            }

            public CalculateLoyaltyPointsResponse Build()
            {
                return new CalculateLoyaltyPointsResponse(errors,
                    points);
            }
        }
    }
}