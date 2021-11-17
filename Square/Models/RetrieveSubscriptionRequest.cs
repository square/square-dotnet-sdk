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
    /// RetrieveSubscriptionRequest.
    /// </summary>
    public class RetrieveSubscriptionRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveSubscriptionRequest"/> class.
        /// </summary>
        /// <param name="include">include.</param>
        public RetrieveSubscriptionRequest(
            string include = null)
        {
            this.Include = include;
        }

        /// <summary>
        /// A query parameter to specify related information to be included in the response.
        /// The supported query parameter values are:
        /// - `actions`: to include scheduled actions on the targeted subscription.
        /// </summary>
        [JsonProperty("include", NullValueHandling = NullValueHandling.Ignore)]
        public string Include { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RetrieveSubscriptionRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is RetrieveSubscriptionRequest other &&
                ((this.Include == null && other.Include == null) || (this.Include?.Equals(other.Include) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 791482379;
            hashCode = HashCode.Combine(this.Include);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Include = {(this.Include == null ? "null" : this.Include == string.Empty ? "" : this.Include)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Include(this.Include);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string include;

             /// <summary>
             /// Include.
             /// </summary>
             /// <param name="include"> include. </param>
             /// <returns> Builder. </returns>
            public Builder Include(string include)
            {
                this.include = include;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> RetrieveSubscriptionRequest. </returns>
            public RetrieveSubscriptionRequest Build()
            {
                return new RetrieveSubscriptionRequest(
                    this.include);
            }
        }
    }
}