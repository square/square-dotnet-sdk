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
    /// StandardUnitDescriptionGroup.
    /// </summary>
    public class StandardUnitDescriptionGroup
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="StandardUnitDescriptionGroup"/> class.
        /// </summary>
        /// <param name="standardUnitDescriptions">standard_unit_descriptions.</param>
        /// <param name="languageCode">language_code.</param>
        public StandardUnitDescriptionGroup(
            IList<Models.StandardUnitDescription> standardUnitDescriptions = null,
            string languageCode = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "standard_unit_descriptions", false },
                { "language_code", false }
            };

            if (standardUnitDescriptions != null)
            {
                shouldSerialize["standard_unit_descriptions"] = true;
                this.StandardUnitDescriptions = standardUnitDescriptions;
            }

            if (languageCode != null)
            {
                shouldSerialize["language_code"] = true;
                this.LanguageCode = languageCode;
            }

        }
        internal StandardUnitDescriptionGroup(Dictionary<string, bool> shouldSerialize,
            IList<Models.StandardUnitDescription> standardUnitDescriptions = null,
            string languageCode = null)
        {
            this.shouldSerialize = shouldSerialize;
            StandardUnitDescriptions = standardUnitDescriptions;
            LanguageCode = languageCode;
        }

        /// <summary>
        /// List of standard (non-custom) measurement units in this description group.
        /// </summary>
        [JsonProperty("standard_unit_descriptions")]
        public IList<Models.StandardUnitDescription> StandardUnitDescriptions { get; }

        /// <summary>
        /// IETF language tag.
        /// </summary>
        [JsonProperty("language_code")]
        public string LanguageCode { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"StandardUnitDescriptionGroup : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStandardUnitDescriptions()
        {
            return this.shouldSerialize["standard_unit_descriptions"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLanguageCode()
        {
            return this.shouldSerialize["language_code"];
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
            return obj is StandardUnitDescriptionGroup other &&                ((this.StandardUnitDescriptions == null && other.StandardUnitDescriptions == null) || (this.StandardUnitDescriptions?.Equals(other.StandardUnitDescriptions) == true)) &&
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
            toStringOutput.Add($"this.LanguageCode = {(this.LanguageCode == null ? "null" : this.LanguageCode)}");
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "standard_unit_descriptions", false },
                { "language_code", false },
            };

            private IList<Models.StandardUnitDescription> standardUnitDescriptions;
            private string languageCode;

             /// <summary>
             /// StandardUnitDescriptions.
             /// </summary>
             /// <param name="standardUnitDescriptions"> standardUnitDescriptions. </param>
             /// <returns> Builder. </returns>
            public Builder StandardUnitDescriptions(IList<Models.StandardUnitDescription> standardUnitDescriptions)
            {
                shouldSerialize["standard_unit_descriptions"] = true;
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
                shouldSerialize["language_code"] = true;
                this.languageCode = languageCode;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetStandardUnitDescriptions()
            {
                this.shouldSerialize["standard_unit_descriptions"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLanguageCode()
            {
                this.shouldSerialize["language_code"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> StandardUnitDescriptionGroup. </returns>
            public StandardUnitDescriptionGroup Build()
            {
                return new StandardUnitDescriptionGroup(shouldSerialize,
                    this.standardUnitDescriptions,
                    this.languageCode);
            }
        }
    }
}