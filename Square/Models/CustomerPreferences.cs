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
        [JsonProperty("email_unsubscribed")]
        public bool? EmailUnsubscribed { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .EmailUnsubscribed(EmailUnsubscribed);
            return builder;
        }

        public class Builder
        {
            private bool? emailUnsubscribed;

            public Builder() { }
            public Builder EmailUnsubscribed(bool? value)
            {
                emailUnsubscribed = value;
                return this;
            }

            public CustomerPreferences Build()
            {
                return new CustomerPreferences(emailUnsubscribed);
            }
        }
    }
}