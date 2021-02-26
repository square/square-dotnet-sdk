
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
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DeleteInvoiceRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Version = {(Version == null ? "null" : Version.ToString())}");
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

            return obj is DeleteInvoiceRequest other &&
                ((Version == null && other.Version == null) || (Version?.Equals(other.Version) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -231963317;

            if (Version != null)
            {
               hashCode += Version.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Version(Version);
            return builder;
        }

        public class Builder
        {
            private int? version;



            public Builder Version(int? version)
            {
                this.version = version;
                return this;
            }

            public DeleteInvoiceRequest Build()
            {
                return new DeleteInvoiceRequest(version);
            }
        }
    }
}