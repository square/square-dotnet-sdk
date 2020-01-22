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
    public class RetrieveInventoryAdjustmentResponse 
    {
        public RetrieveInventoryAdjustmentResponse(IList<Models.Error> errors = null,
            Models.InventoryAdjustment adjustment = null)
        {
            Errors = errors;
            Adjustment = adjustment;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a change in state or quantity of product inventory at a
        /// particular time and location.
        /// </summary>
        [JsonProperty("adjustment")]
        public Models.InventoryAdjustment Adjustment { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Adjustment(Adjustment);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private Models.InventoryAdjustment adjustment;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Adjustment(Models.InventoryAdjustment value)
            {
                adjustment = value;
                return this;
            }

            public RetrieveInventoryAdjustmentResponse Build()
            {
                return new RetrieveInventoryAdjustmentResponse(errors,
                    adjustment);
            }
        }
    }
}