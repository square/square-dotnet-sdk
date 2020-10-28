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
    public class StandardUnitDescriptionGroup 
    {
        public StandardUnitDescriptionGroup(IList<Models.StandardUnitDescription> standardUnitDescriptions = null,
            string languageCode = null)
        {
            StandardUnitDescriptions = standardUnitDescriptions;
            LanguageCode = languageCode;
        }

        /// <summary>
        /// List of standard (non-custom) measurement units in this description group.
        /// </summary>
        [JsonProperty("standard_unit_descriptions", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.StandardUnitDescription> StandardUnitDescriptions { get; }

        /// <summary>
        /// IETF language tag.
        /// </summary>
        [JsonProperty("language_code", NullValueHandling = NullValueHandling.Ignore)]
        public string LanguageCode { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .StandardUnitDescriptions(StandardUnitDescriptions)
                .LanguageCode(LanguageCode);
            return builder;
        }

        public class Builder
        {
            private IList<Models.StandardUnitDescription> standardUnitDescriptions;
            private string languageCode;



            public Builder StandardUnitDescriptions(IList<Models.StandardUnitDescription> standardUnitDescriptions)
            {
                this.standardUnitDescriptions = standardUnitDescriptions;
                return this;
            }

            public Builder LanguageCode(string languageCode)
            {
                this.languageCode = languageCode;
                return this;
            }

            public StandardUnitDescriptionGroup Build()
            {
                return new StandardUnitDescriptionGroup(standardUnitDescriptions,
                    languageCode);
            }
        }
    }
}