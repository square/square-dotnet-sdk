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
    /// CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection.
    /// </summary>
    public class CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="uid">uid.</param>
        public CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection(
            string name,
            string uid = null)
        {
            this.Uid = uid;
            this.Name = name;
        }

        /// <summary>
        /// Unique ID set by Square.
        /// </summary>
        [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
        public string Uid { get; }

        /// <summary>
        /// Selection name, unique within `allowed_selections`.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection other &&
                ((this.Uid == null && other.Uid == null) || (this.Uid?.Equals(other.Uid) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 829627827;
            hashCode = HashCode.Combine(this.Uid, this.Name);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Uid = {(this.Uid == null ? "null" : this.Uid == string.Empty ? "" : this.Uid)}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Name)
                .Uid(this.Uid);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string name;
            private string uid;

            public Builder(
                string name)
            {
                this.name = name;
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
             /// Uid.
             /// </summary>
             /// <param name="uid"> uid. </param>
             /// <returns> Builder. </returns>
            public Builder Uid(string uid)
            {
                this.uid = uid;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection. </returns>
            public CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection Build()
            {
                return new CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection(
                    this.name,
                    this.uid);
            }
        }
    }
}