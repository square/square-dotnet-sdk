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
    public class CreateCustomerGroupRequest 
    {
        public CreateCustomerGroupRequest(Models.CustomerGroup mGroup,
            string idempotencyKey = null)
        {
            IdempotencyKey = idempotencyKey;
            MGroup = mGroup;
        }

        /// <summary>
        /// The idempotency key for the request. See the [Idempotency](https://developer.squareup.com/docs/basics/api101/idempotency)
        /// guide for more information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// Represents a group of customer profiles. 
        /// Customer groups can be created, modified, and have their membership defined either via 
        /// the Customers API or within Customer Directory in the Square Dashboard or Point of Sale.
        /// </summary>
        [JsonProperty("group")]
        public Models.CustomerGroup MGroup { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(MGroup)
                .IdempotencyKey(IdempotencyKey);
            return builder;
        }

        public class Builder
        {
            private Models.CustomerGroup mGroup;
            private string idempotencyKey;

            public Builder(Models.CustomerGroup mGroup)
            {
                this.mGroup = mGroup;
            }
            public Builder MGroup(Models.CustomerGroup value)
            {
                mGroup = value;
                return this;
            }

            public Builder IdempotencyKey(string value)
            {
                idempotencyKey = value;
                return this;
            }

            public CreateCustomerGroupRequest Build()
            {
                return new CreateCustomerGroupRequest(mGroup,
                    idempotencyKey);
            }
        }
    }
}