
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CancelInvoiceRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Version = {Version}");
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

            return obj is CancelInvoiceRequest other &&
                Version.Equals(other.Version);
        }

        public override int GetHashCode()
        {
            int hashCode = 1350501489;
            hashCode += Version.GetHashCode();

            return hashCode;
        }

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

            public Builder Version(int version)
            {
                this.version = version;
                return this;
            }

            public CancelInvoiceRequest Build()
            {
                return new CancelInvoiceRequest(version);
            }
        }
    }
}