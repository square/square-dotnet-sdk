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
    public class UpdateCustomerGroupResponse 
    {
        public UpdateCustomerGroupResponse(IList<Models.Error> errors = null,
            Models.CustomerGroup mGroup = null)
        {
            Errors = errors;
            MGroup = mGroup;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a group of customer profiles. 
        /// Customer groups can be created, modified, and have their membership defined either via 
        /// the Customers API or within Customer Directory in the Square Dashboard or Point of Sale.
        /// </summary>
        [JsonProperty("group", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomerGroup MGroup { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .MGroup(MGroup);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.CustomerGroup mGroup;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder MGroup(Models.CustomerGroup mGroup)
            {
                this.mGroup = mGroup;
                return this;
            }

            public UpdateCustomerGroupResponse Build()
            {
                return new UpdateCustomerGroupResponse(errors,
                    mGroup);
            }
        }
    }
}