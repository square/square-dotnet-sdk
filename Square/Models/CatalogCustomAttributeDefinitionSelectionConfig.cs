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
        [JsonProperty("max_allowed_selections")]
        public int? MaxAllowedSelections { get; }

        /// <summary>
        /// The set of valid `CatalogCustomAttributeSelections`. Up to a maximum of 100
        /// selections can be defined. Can be modified.
        /// </summary>
        [JsonProperty("allowed_selections")]
        public IList<Models.CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection> AllowedSelections { get; }

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
            private IList<Models.CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection> allowedSelections = new List<Models.CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection>();

            public Builder() { }
            public Builder MaxAllowedSelections(int? value)
            {
                maxAllowedSelections = value;
                return this;
            }

            public Builder AllowedSelections(IList<Models.CatalogCustomAttributeDefinitionSelectionConfigCustomAttributeSelection> value)
            {
                allowedSelections = value;
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