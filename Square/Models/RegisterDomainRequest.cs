namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities.Converters;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// RegisterDomainRequest.
    /// </summary>
    public class RegisterDomainRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterDomainRequest"/> class.
        /// </summary>
        /// <param name="domainName">domain_name.</param>
        public RegisterDomainRequest(
            string domainName)
        {
            this.DomainName = domainName;
        }

        /// <summary>
        /// A domain name as described in RFC-1034 that will be registered with ApplePay.
        /// </summary>
        [JsonProperty("domain_name")]
        public string DomainName { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RegisterDomainRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
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
            return obj is RegisterDomainRequest other &&                ((this.DomainName == null && other.DomainName == null) || (this.DomainName?.Equals(other.DomainName) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1345788057;
            hashCode = HashCode.Combine(this.DomainName);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.DomainName = {(this.DomainName == null ? "null" : this.DomainName)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.DomainName);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string domainName;

            /// <summary>
            /// Initialize Builder for RegisterDomainRequest.
            /// </summary>
            /// <param name="domainName"> domainName. </param>
            public Builder(
                string domainName)
            {
                this.domainName = domainName;
            }

             /// <summary>
             /// DomainName.
             /// </summary>
             /// <param name="domainName"> domainName. </param>
             /// <returns> Builder. </returns>
            public Builder DomainName(string domainName)
            {
                this.domainName = domainName;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> RegisterDomainRequest. </returns>
            public RegisterDomainRequest Build()
            {
                return new RegisterDomainRequest(
                    this.domainName);
            }
        }
    }
}