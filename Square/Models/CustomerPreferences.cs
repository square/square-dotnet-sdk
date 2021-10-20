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
    /// CustomerPreferences.
    /// </summary>
    public class CustomerPreferences
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerPreferences"/> class.
        /// </summary>
        /// <param name="emailUnsubscribed">email_unsubscribed.</param>
        public CustomerPreferences(
            bool? emailUnsubscribed = null)
        {
            this.EmailUnsubscribed = emailUnsubscribed;
        }

        /// <summary>
        /// Indicates whether the customer has unsubscribed from marketing campaign emails. A value of `true` means that the customer chose to opt out of email marketing from the current Square seller or from all Square sellers. This value is read-only from the Customers API.
        /// </summary>
        [JsonProperty("email_unsubscribed", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EmailUnsubscribed { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CustomerPreferences : ({string.Join(", ", toStringOutput)})";
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

            return obj is CustomerPreferences other &&
                ((this.EmailUnsubscribed == null && other.EmailUnsubscribed == null) || (this.EmailUnsubscribed?.Equals(other.EmailUnsubscribed) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1448015667;
            hashCode = HashCode.Combine(this.EmailUnsubscribed);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.EmailUnsubscribed = {(this.EmailUnsubscribed == null ? "null" : this.EmailUnsubscribed.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .EmailUnsubscribed(this.EmailUnsubscribed);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private bool? emailUnsubscribed;

             /// <summary>
             /// EmailUnsubscribed.
             /// </summary>
             /// <param name="emailUnsubscribed"> emailUnsubscribed. </param>
             /// <returns> Builder. </returns>
            public Builder EmailUnsubscribed(bool? emailUnsubscribed)
            {
                this.emailUnsubscribed = emailUnsubscribed;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CustomerPreferences. </returns>
            public CustomerPreferences Build()
            {
                return new CustomerPreferences(
                    this.emailUnsubscribed);
            }
        }
    }
}