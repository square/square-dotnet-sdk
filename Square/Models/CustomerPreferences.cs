
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
    public class CustomerPreferences 
    {
        public CustomerPreferences(bool? emailUnsubscribed = null)
        {
            EmailUnsubscribed = emailUnsubscribed;
        }

        /// <summary>
        /// The customer has unsubscribed from receiving marketing campaign emails.
        /// </summary>
        [JsonProperty("email_unsubscribed", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EmailUnsubscribed { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CustomerPreferences : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"EmailUnsubscribed = {(EmailUnsubscribed == null ? "null" : EmailUnsubscribed.ToString())}");
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

            return obj is CustomerPreferences other &&
                ((EmailUnsubscribed == null && other.EmailUnsubscribed == null) || (EmailUnsubscribed?.Equals(other.EmailUnsubscribed) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1448015667;

            if (EmailUnsubscribed != null)
            {
               hashCode += EmailUnsubscribed.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .EmailUnsubscribed(EmailUnsubscribed);
            return builder;
        }

        public class Builder
        {
            private bool? emailUnsubscribed;



            public Builder EmailUnsubscribed(bool? emailUnsubscribed)
            {
                this.emailUnsubscribed = emailUnsubscribed;
                return this;
            }

            public CustomerPreferences Build()
            {
                return new CustomerPreferences(emailUnsubscribed);
            }
        }
    }
}