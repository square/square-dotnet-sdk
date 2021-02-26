
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
    public class RegisterDomainRequest 
    {
        public RegisterDomainRequest(string domainName)
        {
            DomainName = domainName;
        }

        /// <summary>
        /// A domain name as described in RFC-1034 that will be registered with ApplePay
        /// </summary>
        [JsonProperty("domain_name")]
        public string DomainName { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RegisterDomainRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"DomainName = {(DomainName == null ? "null" : DomainName == string.Empty ? "" : DomainName)}");
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

            return obj is RegisterDomainRequest other &&
                ((DomainName == null && other.DomainName == null) || (DomainName?.Equals(other.DomainName) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1345788057;

            if (DomainName != null)
            {
               hashCode += DomainName.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(DomainName);
            return builder;
        }

        public class Builder
        {
            private string domainName;

            public Builder(string domainName)
            {
                this.domainName = domainName;
            }

            public Builder DomainName(string domainName)
            {
                this.domainName = domainName;
                return this;
            }

            public RegisterDomainRequest Build()
            {
                return new RegisterDomainRequest(domainName);
            }
        }
    }
}