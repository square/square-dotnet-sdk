
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
    public class SourceApplication 
    {
        public SourceApplication(string product = null,
            string applicationId = null,
            string name = null)
        {
            Product = product;
            ApplicationId = applicationId;
            Name = name;
        }

        /// <summary>
        /// Indicates the Square product used to generate an inventory change.
        /// </summary>
        [JsonProperty("product", NullValueHandling = NullValueHandling.Ignore)]
        public string Product { get; }

        /// <summary>
        /// Read-only Square ID assigned to the application. Only used for
        /// [Product](#type-product) type `EXTERNAL_API`.
        /// </summary>
        [JsonProperty("application_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ApplicationId { get; }

        /// <summary>
        /// Read-only display name assigned to the application
        /// (e.g. `"Custom Application"`, `"Square POS 4.74 for Android"`).
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SourceApplication : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Product = {(Product == null ? "null" : Product.ToString())}");
            toStringOutput.Add($"ApplicationId = {(ApplicationId == null ? "null" : ApplicationId == string.Empty ? "" : ApplicationId)}");
            toStringOutput.Add($"Name = {(Name == null ? "null" : Name == string.Empty ? "" : Name)}");
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

            return obj is SourceApplication other &&
                ((Product == null && other.Product == null) || (Product?.Equals(other.Product) == true)) &&
                ((ApplicationId == null && other.ApplicationId == null) || (ApplicationId?.Equals(other.ApplicationId) == true)) &&
                ((Name == null && other.Name == null) || (Name?.Equals(other.Name) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -850254546;

            if (Product != null)
            {
               hashCode += Product.GetHashCode();
            }

            if (ApplicationId != null)
            {
               hashCode += ApplicationId.GetHashCode();
            }

            if (Name != null)
            {
               hashCode += Name.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Product(Product)
                .ApplicationId(ApplicationId)
                .Name(Name);
            return builder;
        }

        public class Builder
        {
            private string product;
            private string applicationId;
            private string name;



            public Builder Product(string product)
            {
                this.product = product;
                return this;
            }

            public Builder ApplicationId(string applicationId)
            {
                this.applicationId = applicationId;
                return this;
            }

            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public SourceApplication Build()
            {
                return new SourceApplication(product,
                    applicationId,
                    name);
            }
        }
    }
}