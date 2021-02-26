
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
    public class CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection 
    {
        public CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection(string name,
            string uid = null)
        {
            Uid = uid;
            Name = name;
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Uid = {(Uid == null ? "null" : Uid == string.Empty ? "" : Uid)}");
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

            return obj is CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection other &&
                ((Uid == null && other.Uid == null) || (Uid?.Equals(other.Uid) == true)) &&
                ((Name == null && other.Name == null) || (Name?.Equals(other.Name) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 829627827;

            if (Uid != null)
            {
               hashCode += Uid.GetHashCode();
            }

            if (Name != null)
            {
               hashCode += Name.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(Name)
                .Uid(Uid);
            return builder;
        }

        public class Builder
        {
            private string name;
            private string uid;

            public Builder(string name)
            {
                this.name = name;
            }

            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder Uid(string uid)
            {
                this.uid = uid;
                return this;
            }

            public CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection Build()
            {
                return new CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection(name,
                    uid);
            }
        }
    }
}