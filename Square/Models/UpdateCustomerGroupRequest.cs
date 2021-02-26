
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
    public class UpdateCustomerGroupRequest 
    {
        public UpdateCustomerGroupRequest(Models.CustomerGroup mGroup)
        {
            MGroup = mGroup;
        }

        /// <summary>
        /// Represents a group of customer profiles. 
        /// Customer groups can be created, modified, and have their membership defined either via 
        /// the Customers API or within Customer Directory in the Square Dashboard or Point of Sale.
        /// </summary>
        [JsonProperty("group")]
        public Models.CustomerGroup MGroup { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateCustomerGroupRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"MGroup = {(MGroup == null ? "null" : MGroup.ToString())}");
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

            return obj is UpdateCustomerGroupRequest other &&
                ((MGroup == null && other.MGroup == null) || (MGroup?.Equals(other.MGroup) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1040897599;

            if (MGroup != null)
            {
               hashCode += MGroup.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(MGroup);
            return builder;
        }

        public class Builder
        {
            private Models.CustomerGroup mGroup;

            public Builder(Models.CustomerGroup mGroup)
            {
                this.mGroup = mGroup;
            }

            public Builder MGroup(Models.CustomerGroup mGroup)
            {
                this.mGroup = mGroup;
                return this;
            }

            public UpdateCustomerGroupRequest Build()
            {
                return new UpdateCustomerGroupRequest(mGroup);
            }
        }
    }
}