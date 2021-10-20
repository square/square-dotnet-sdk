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
    /// StandardUnitDescriptionGroup.
    /// </summary>
    public class StandardUnitDescriptionGroup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StandardUnitDescriptionGroup"/> class.
        /// </summary>
        /// <param name="standardUnitDescriptions">standard_unit_descriptions.</param>
        /// <param name="languageCode">language_code.</param>
        public StandardUnitDescriptionGroup(
            IList<Models.StandardUnitDescription> standardUnitDescriptions = null,
            string languageCode = null)
        {
            this.StandardUnitDescriptions = standardUnitDescriptions;
            this.LanguageCode = languageCode;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"StandardUnitDescriptionGroup : ({string.Join(", ", toStringOutput)})";
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

            return obj is StandardUnitDescriptionGroup other &&
                ((this.StandardUnitDescriptions == null && other.StandardUnitDescriptions == null) || (this.StandardUnitDescriptions?.Equals(other.StandardUnitDescriptions) == true)) &&
                ((this.LanguageCode == null && other.LanguageCode == null) || (this.LanguageCode?.Equals(other.LanguageCode) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1512557629;
            hashCode = HashCode.Combine(this.StandardUnitDescriptions, this.LanguageCode);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.StandardUnitDescriptions = {(this.StandardUnitDescriptions == null ? "null" : $"[{string.Join(", ", this.StandardUnitDescriptions)} ]")}");
            toStringOutput.Add($"this.LanguageCode = {(this.LanguageCode == null ? "null" : this.LanguageCode == string.Empty ? "" : this.LanguageCode)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .StandardUnitDescriptions(this.StandardUnitDescriptions)
                .LanguageCode(this.LanguageCode);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.StandardUnitDescription> standardUnitDescriptions;
            private string languageCode;

             /// <summary>
             /// StandardUnitDescriptions.
             /// </summary>
             /// <param name="standardUnitDescriptions"> standardUnitDescriptions. </param>
             /// <returns> Builder. </returns>
            public Builder StandardUnitDescriptions(IList<Models.StandardUnitDescription> standardUnitDescriptions)
            {
                this.standardUnitDescriptions = standardUnitDescriptions;
                return this;
            }

             /// <summary>
             /// LanguageCode.
             /// </summary>
             /// <param name="languageCode"> languageCode. </param>
             /// <returns> Builder. </returns>
            public Builder LanguageCode(string languageCode)
            {
                this.languageCode = languageCode;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> StandardUnitDescriptionGroup. </returns>
            public StandardUnitDescriptionGroup Build()
            {
                return new StandardUnitDescriptionGroup(
                    this.standardUnitDescriptions,
                    this.languageCode);
            }
        }
    }
}