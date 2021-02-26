
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class V1ListOrdersResponse 
    {
        public V1ListOrdersResponse(IList<Models.V1Order> items = null)
        {
            Items = items;
        }

        /// <summary>
        /// Getter for items
        /// </summary>
        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.V1Order> Items { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1ListOrdersResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Items = {(Items == null ? "null" : $"[{ string.Join(", ", Items)} ]")}");
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

            return obj is V1ListOrdersResponse other &&
                ((Items == null && other.Items == null) || (Items?.Equals(other.Items) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 166605431;

            if (Items != null)
            {
               hashCode += Items.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Items(Items);
            return builder;
        }

        public class Builder
        {
            private IList<Models.V1Order> items;



            public Builder Items(IList<Models.V1Order> items)
            {
                this.items = items;
                return this;
            }

            public V1ListOrdersResponse Build()
            {
                return new V1ListOrdersResponse(items);
            }
        }
    }
}