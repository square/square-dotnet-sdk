namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// RenewTokenRequest.
    /// </summary>
    public class RenewTokenRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RenewTokenRequest"/> class.
        /// </summary>
        /// <param name="accessToken">access_token.</param>
        public RenewTokenRequest(
            string accessToken = null)
        {
            this.AccessToken = accessToken;
        }

        /// <summary>
        /// The token you want to renew.
        /// </summary>
        [JsonProperty("access_token", NullValueHandling = NullValueHandling.Ignore)]
        public string AccessToken { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RenewTokenRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is RenewTokenRequest other &&
                ((this.AccessToken == null && other.AccessToken == null) || (this.AccessToken?.Equals(other.AccessToken) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -475718546;
            hashCode = HashCode.Combine(this.AccessToken);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AccessToken = {(this.AccessToken == null ? "null" : this.AccessToken == string.Empty ? "" : this.AccessToken)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .AccessToken(this.AccessToken);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string accessToken;

             /// <summary>
             /// AccessToken.
             /// </summary>
             /// <param name="accessToken"> accessToken. </param>
             /// <returns> Builder. </returns>
            public Builder AccessToken(string accessToken)
            {
                this.accessToken = accessToken;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> RenewTokenRequest. </returns>
            public RenewTokenRequest Build()
            {
                return new RenewTokenRequest(
                    this.accessToken);
            }
        }
    }
}