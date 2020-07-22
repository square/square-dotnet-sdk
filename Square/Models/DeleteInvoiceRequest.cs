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
    public class DeleteInvoiceRequest 
    {
        public DeleteInvoiceRequest(int? version = null)
        {
            Version = version;
        }

        /// <summary>
        /// The version of the [invoice](#type-invoice) to delete.
        /// If you do not know the version, you can call [GetInvoice](#endpoint-Invoices-GetInvoice) or 
        /// [ListInvoices](#endpoint-Invoices-ListInvoices).
        /// </summary>
        [JsonProperty("version")]
        public int? Version { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Version(Version);
            return builder;
        }

        public class Builder
        {
            private int? version;

            public Builder() { }
            public Builder Version(int? value)
            {
                version = value;
                return this;
            }

            public DeleteInvoiceRequest Build()
            {
                return new DeleteInvoiceRequest(version);
            }
        }
    }
}