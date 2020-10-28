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
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a change in state or quantity of product inventory at a
        /// particular time and location.
        /// </summary>
        [JsonProperty("adjustment", NullValueHandling = NullValueHandling.Ignore)]
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
            private IList<Models.Error> errors;
            private Models.InventoryAdjustment adjustment;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Adjustment(Models.InventoryAdjustment adjustment)
            {
                this.adjustment = adjustment;
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