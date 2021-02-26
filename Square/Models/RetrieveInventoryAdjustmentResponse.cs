
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RetrieveInventoryAdjustmentResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Errors = {(Errors == null ? "null" : $"[{ string.Join(", ", Errors)} ]")}");
            toStringOutput.Add($"Adjustment = {(Adjustment == null ? "null" : Adjustment.ToString())}");
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

            return obj is RetrieveInventoryAdjustmentResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((Errors == null && other.Errors == null) || (Errors?.Equals(other.Errors) == true)) &&
                ((Adjustment == null && other.Adjustment == null) || (Adjustment?.Equals(other.Adjustment) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 277601890;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (Errors != null)
            {
               hashCode += Errors.GetHashCode();
            }

            if (Adjustment != null)
            {
               hashCode += Adjustment.GetHashCode();
            }

            return hashCode;
        }

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