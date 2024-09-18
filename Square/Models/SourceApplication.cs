using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    /// <summary>
    /// SourceApplication.
    /// </summary>
    public class SourceApplication
    {
        private readonly Dictionary<string, bool> shouldSerialize;
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
            shouldSerialize = new Dictionary<string, bool>
            {
                { "application_id", false },
                { "name", false }
            };

            this.Product = product;
            if (applicationId != null)
            {
                shouldSerialize["application_id"] = true;
                this.ApplicationId = applicationId;
            }

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }

        }
        internal SourceApplication(Dictionary<string, bool> shouldSerialize,
            string product = null,
            string applicationId = null,
            string name = null)
        {
            this.shouldSerialize = shouldSerialize;
            Product = product;
            ApplicationId = applicationId;
            Name = name;
        }

        /// <summary>
        /// Indicates the Square product used to generate a change.
        /// </summary>
        [JsonProperty("product", NullValueHandling = NullValueHandling.Ignore)]
        public string Product { get; }

        /// <summary>
        /// __Read only__ The Square-assigned ID of the application. This field is used only if the
        /// [product](entity:Product) type is `EXTERNAL_API`.
        /// </summary>
        [JsonProperty("application_id")]
        public string ApplicationId { get; }

        /// <summary>
        /// __Read only__ The display name of the application
        /// (for example, `"Custom Application"` or `"Square POS 4.74 for Android"`).
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SourceApplication : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeApplicationId()
        {
            return this.shouldSerialize["application_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeName()
        {
            return this.shouldSerialize["name"];
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
            return obj is SourceApplication other &&                ((this.Product == null && other.Product == null) || (this.Product?.Equals(other.Product) == true)) &&
                ((this.ApplicationId == null && other.ApplicationId == null) || (this.ApplicationId?.Equals(other.ApplicationId) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -850254546;
            hashCode = HashCode.Combine(this.Product, this.ApplicationId, this.Name);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Product = {(this.Product == null ? "null" : this.Product.ToString())}");
            toStringOutput.Add($"this.ApplicationId = {(this.ApplicationId == null ? "null" : this.ApplicationId)}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "application_id", false },
                { "name", false },
            };

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
                shouldSerialize["application_id"] = true;
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
                shouldSerialize["name"] = true;
                this.name = name;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetApplicationId()
            {
                this.shouldSerialize["application_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetName()
            {
                this.shouldSerialize["name"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SourceApplication. </returns>
            public SourceApplication Build()
            {
                return new SourceApplication(shouldSerialize,
                    this.product,
                    this.applicationId,
                    this.name);
            }
        }
    }
}