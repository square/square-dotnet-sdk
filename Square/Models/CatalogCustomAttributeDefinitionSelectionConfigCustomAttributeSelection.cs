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
    /// CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection.
    /// </summary>
    public class CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="uid">uid.</param>
        public CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection(
            string name,
            string uid = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false }
            };

            if (uid != null)
            {
                shouldSerialize["uid"] = true;
                this.Uid = uid;
            }

            this.Name = name;
        }
        internal CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection(Dictionary<string, bool> shouldSerialize,
            string name,
            string uid = null)
        {
            this.shouldSerialize = shouldSerialize;
            Uid = uid;
            Name = name;
        }

        /// <summary>
        /// Unique ID set by Square.
        /// </summary>
        [JsonProperty("uid")]
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

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUid()
        {
            return this.shouldSerialize["uid"];
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
            return obj is CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection other &&                ((this.Uid == null && other.Uid == null) || (this.Uid?.Equals(other.Uid) == true)) &&
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
            toStringOutput.Add($"this.Uid = {(this.Uid == null ? "null" : this.Uid)}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
            };

            private string name;
            private string uid;

            /// <summary>
            /// Initialize Builder for CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection.
            /// </summary>
            /// <param name="name"> name. </param>
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
                shouldSerialize["uid"] = true;
                this.uid = uid;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetUid()
            {
                this.shouldSerialize["uid"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection. </returns>
            public CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection Build()
            {
                return new CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection(shouldSerialize,
                    this.name,
                    this.uid);
            }
        }
    }
}