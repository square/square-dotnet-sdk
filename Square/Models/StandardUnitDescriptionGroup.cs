
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"StandardUnitDescriptionGroup : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"StandardUnitDescriptions = {(StandardUnitDescriptions == null ? "null" : $"[{ string.Join(", ", StandardUnitDescriptions)} ]")}");
            toStringOutput.Add($"LanguageCode = {(LanguageCode == null ? "null" : LanguageCode == string.Empty ? "" : LanguageCode)}");
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

            return obj is StandardUnitDescriptionGroup other &&
                ((StandardUnitDescriptions == null && other.StandardUnitDescriptions == null) || (StandardUnitDescriptions?.Equals(other.StandardUnitDescriptions) == true)) &&
                ((LanguageCode == null && other.LanguageCode == null) || (LanguageCode?.Equals(other.LanguageCode) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1512557629;

            if (StandardUnitDescriptions != null)
            {
               hashCode += StandardUnitDescriptions.GetHashCode();
            }

            if (LanguageCode != null)
            {
               hashCode += LanguageCode.GetHashCode();
            }

            return hashCode;
        }

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