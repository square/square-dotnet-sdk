
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
    public class TerminalCheckoutQuerySort 
    {
        public TerminalCheckoutQuerySort(string sortOrder = null)
        {
            SortOrder = sortOrder;
        }

        /// <summary>
        /// The order in which results are listed.
        /// - `ASC` - Oldest to newest.
        /// - `DESC` - Newest to oldest (default).
        /// </summary>
        [JsonProperty("sort_order", NullValueHandling = NullValueHandling.Ignore)]
        public string SortOrder { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TerminalCheckoutQuerySort : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"SortOrder = {(SortOrder == null ? "null" : SortOrder == string.Empty ? "" : SortOrder)}");
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

            return obj is TerminalCheckoutQuerySort other &&
                ((SortOrder == null && other.SortOrder == null) || (SortOrder?.Equals(other.SortOrder) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -654235652;

            if (SortOrder != null)
            {
               hashCode += SortOrder.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .SortOrder(SortOrder);
            return builder;
        }

        public class Builder
        {
            private string sortOrder;



            public Builder SortOrder(string sortOrder)
            {
                this.sortOrder = sortOrder;
                return this;
            }

            public TerminalCheckoutQuerySort Build()
            {
                return new TerminalCheckoutQuerySort(sortOrder);
            }
        }
    }
}