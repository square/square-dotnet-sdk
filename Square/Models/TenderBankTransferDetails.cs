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
    public class TenderBankTransferDetails 
    {
        public TenderBankTransferDetails(string status = null)
        {
            Status = status;
        }

        /// <summary>
        /// Indicates the bank transfer's current status.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Status(Status);
            return builder;
        }

        public class Builder
        {
            private string status;

            public Builder() { }
            public Builder Status(string value)
            {
                status = value;
                return this;
            }

            public TenderBankTransferDetails Build()
            {
                return new TenderBankTransferDetails(status);
            }
        }
    }
}