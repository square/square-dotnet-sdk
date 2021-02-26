
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
    public class CatalogCustomAttributeDefinitionSelectionConfig 
    {
        public CatalogCustomAttributeDefinitionSelectionConfig(int? maxAllowedSelections = null,
            IList<Models.CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection> allowedSelections = null)
        {
            MaxAllowedSelections = maxAllowedSelections;
            AllowedSelections = allowedSelections;
        }

        /// <summary>
        /// The maximum number of selections that can be set. The maximum value for this
        /// attribute is 100. The default value is 1. The value can be modified, but changing the value will not
        /// affect existing custom attribute values on objects. Clients need to
        /// handle custom attributes with more selected values than allowed by this limit.
        /// </summary>
        [JsonProperty("max_allowed_selections", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxAllowedSelections { get; }

        /// <summary>
        /// The set of valid `CatalogCustomAttributeSelections`. Up to a maximum of 100
        /// selections can be defined. Can be modified.
        /// </summary>
        [JsonProperty("allowed_selections", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection> AllowedSelections { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogCustomAttributeDefinitionSelectionConfig : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"MaxAllowedSelections = {(MaxAllowedSelections == null ? "null" : MaxAllowedSelections.ToString())}");
            toStringOutput.Add($"AllowedSelections = {(AllowedSelections == null ? "null" : $"[{ string.Join(", ", AllowedSelections)} ]")}");
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

            return obj is CatalogCustomAttributeDefinitionSelectionConfig other &&
                ((MaxAllowedSelections == null && other.MaxAllowedSelections == null) || (MaxAllowedSelections?.Equals(other.MaxAllowedSelections) == true)) &&
                ((AllowedSelections == null && other.AllowedSelections == null) || (AllowedSelections?.Equals(other.AllowedSelections) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 960165059;

            if (MaxAllowedSelections != null)
            {
               hashCode += MaxAllowedSelections.GetHashCode();
            }

            if (AllowedSelections != null)
            {
               hashCode += AllowedSelections.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .MaxAllowedSelections(MaxAllowedSelections)
                .AllowedSelections(AllowedSelections);
            return builder;
        }

        public class Builder
        {
            private int? maxAllowedSelections;
            private IList<Models.CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection> allowedSelections;



            public Builder MaxAllowedSelections(int? maxAllowedSelections)
            {
                this.maxAllowedSelections = maxAllowedSelections;
                return this;
            }

            public Builder AllowedSelections(IList<Models.CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection> allowedSelections)
            {
                this.allowedSelections = allowedSelections;
                return this;
            }

            public CatalogCustomAttributeDefinitionSelectionConfig Build()
            {
                return new CatalogCustomAttributeDefinitionSelectionConfig(maxAllowedSelections,
                    allowedSelections);
            }
        }
    }
}