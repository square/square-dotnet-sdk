
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
    public class BatchRetrieveOrdersResponse 
    {
        public BatchRetrieveOrdersResponse(IList<Models.Order> orders = null,
            IList<Models.Error> errors = null)
        {
            Orders = orders;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The requested orders. This will omit any requested orders that do not exist.
        /// </summary>
        [JsonProperty("orders", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Order> Orders { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BatchRetrieveOrdersResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Orders = {(Orders == null ? "null" : $"[{ string.Join(", ", Orders)} ]")}");
            toStringOutput.Add($"Errors = {(Errors == null ? "null" : $"[{ string.Join(", ", Errors)} ]")}");
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

            return obj is BatchRetrieveOrdersResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((Orders == null && other.Orders == null) || (Orders?.Equals(other.Orders) == true)) &&
                ((Errors == null && other.Errors == null) || (Errors?.Equals(other.Errors) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1621858028;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (Orders != null)
            {
               hashCode += Orders.GetHashCode();
            }

            if (Errors != null)
            {
               hashCode += Errors.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Orders(Orders)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Order> orders;
            private IList<Models.Error> errors;



            public Builder Orders(IList<Models.Order> orders)
            {
                this.orders = orders;
                return this;
            }

            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public BatchRetrieveOrdersResponse Build()
            {
                return new BatchRetrieveOrdersResponse(orders,
                    errors);
            }
        }
    }
}