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
            public Builder DomainName(string value)
            {
                domainName = value;
                return this;
            }

            public RegisterDomainRequest Build()
            {
                return new RegisterDomainRequest(domainName);
            }
        }
    }
}