
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
    public class CreateCustomerGroupResponse 
    {
        public CreateCustomerGroupResponse(IList<Models.Error> errors = null,
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateCustomerGroupResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Errors = {(Errors == null ? "null" : $"[{ string.Join(", ", Errors)} ]")}");
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

            return obj is CreateCustomerGroupResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((Errors == null && other.Errors == null) || (Errors?.Equals(other.Errors) == true)) &&
                ((MGroup == null && other.MGroup == null) || (MGroup?.Equals(other.MGroup) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1932456736;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (Errors != null)
            {
               hashCode += Errors.GetHashCode();
            }

            if (MGroup != null)
            {
               hashCode += MGroup.GetHashCode();
            }

            return hashCode;
        }

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

            public CreateCustomerGroupResponse Build()
            {
                return new CreateCustomerGroupResponse(errors,
                    mGroup);
            }
        }
    }
}