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
    public class CancelInvoiceRequest 
    {
        public CancelInvoiceRequest(int version)
        {
            Version = version;
        }

        /// <summary>
        /// The version of the [invoice](#type-invoice) to cancel.
        /// If you do not know the version, you can call 
        /// [GetInvoice](#endpoint-Invoices-GetInvoice) or [ListInvoices](#endpoint-Invoices-ListInvoices).
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Version);
            return builder;
        }

        public class Builder
        {
            private int version;

            public Builder(int version)
            {
                this.version = version;
            }
            public Builder Version(int value)
            {
                version = value;
                return this;
            }

            public CancelInvoiceRequest Build()
            {
                return new CancelInvoiceRequest(version);
            }
        }
    }
}