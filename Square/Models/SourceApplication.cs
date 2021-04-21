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
    /// SourceApplication.
    /// </summary>
    public class SourceApplication
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SourceApplication"/> class.
        /// </summary>
        /// <param name="product">product.</param>
        /// <param name="applicationId">application_id.</param>
        /// <param name="name">name.</param>
        public SourceApplication(
            string product = null,
            string applicationId = null,
            string name = null)
        {
            this.Product = product;
            this.ApplicationId = applicationId;
            this.Name = name;
        }

        /// <summary>
        /// Indicates the Square product used to generate an inventory change.
        /// </summary>
        [JsonProperty("product", NullValueHandling = NullValueHandling.Ignore)]
        public string Product { get; }

        /// <summary>
        /// Read-only Square ID assigned to the application. Only used for
        /// [Product]($m/Product) type `EXTERNAL_API`.
        /// </summary>
        [JsonProperty("application_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ApplicationId { get; }

        /// <summary>
        /// Read-only display name assigned to the application
        /// (e.g. `"Custom Application"`, `"Square POS 4.74 for Android"`).
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SourceApplication : ({string.Join(", ", toStringOutput)})";
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

            return obj is SourceApplication other &&
                ((this.Product == null && other.Product == null) || (this.Product?.Equals(other.Product) == true)) &&
                ((this.ApplicationId == null && other.ApplicationId == null) || (this.ApplicationId?.Equals(other.ApplicationId) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -850254546;

            if (this.Product != null)
            {
               hashCode += this.Product.GetHashCode();
            }

            if (this.ApplicationId != null)
            {
               hashCode += this.ApplicationId.GetHashCode();
            }

            if (this.Name != null)
            {
               hashCode += this.Name.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Product = {(this.Product == null ? "null" : this.Product.ToString())}");
            toStringOutput.Add($"this.ApplicationId = {(this.ApplicationId == null ? "null" : this.ApplicationId == string.Empty ? "" : this.ApplicationId)}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Product(this.Product)
                .ApplicationId(this.ApplicationId)
                .Name(this.Name);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string product;
            private string applicationId;
            private string name;

             /// <summary>
             /// Product.
             /// </summary>
             /// <param name="product"> product. </param>
             /// <returns> Builder. </returns>
            public Builder Product(string product)
            {
                this.product = product;
                return this;
            }

             /// <summary>
             /// ApplicationId.
             /// </summary>
             /// <param name="applicationId"> applicationId. </param>
             /// <returns> Builder. </returns>
            public Builder ApplicationId(string applicationId)
            {
                this.applicationId = applicationId;
                return this;
            }

             /// <summary>
             /// Name.
             /// </summary>
             /// <param name="name"> name. </param>
             /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SourceApplication. </returns>
            public SourceApplication Build()
            {
                return new SourceApplication(
                    this.product,
                    this.applicationId,
                    this.name);
            }
        }
    }
}