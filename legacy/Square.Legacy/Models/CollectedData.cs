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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// CollectedData.
    /// </summary>
    public class CollectedData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectedData"/> class.
        /// </summary>
        /// <param name="inputText">input_text.</param>
        public CollectedData(string inputText = null)
        {
            this.InputText = inputText;
        }

        /// <summary>
        /// The buyer's input text.
        /// </summary>
        [JsonProperty("input_text", NullValueHandling = NullValueHandling.Ignore)]
        public string InputText { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CollectedData : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is CollectedData other
                && (
                    this.InputText == null && other.InputText == null
                    || this.InputText?.Equals(other.InputText) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1600633646;
            hashCode = HashCode.Combine(hashCode, this.InputText);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.InputText = {this.InputText ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().InputText(this.InputText);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string inputText;

            /// <summary>
            /// InputText.
            /// </summary>
            /// <param name="inputText"> inputText. </param>
            /// <returns> Builder. </returns>
            public Builder InputText(string inputText)
            {
                this.inputText = inputText;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CollectedData. </returns>
            public CollectedData Build()
            {
                return new CollectedData(this.inputText);
            }
        }
    }
}
