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
            public Builder MGroup(Models.CustomerGroup value)
            {
                mGroup = value;
                return this;
            }

            public UpdateCustomerGroupRequest Build()
            {
                return new UpdateCustomerGroupRequest(mGroup);
            }
        }
    }
}