namespace Square.Models
{
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

    /// <summary>
    /// SelectOption.
    /// </summary>
    public class SelectOption
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectOption"/> class.
        /// </summary>
        /// <param name="referenceId">reference_id.</param>
        /// <param name="title">title.</param>
        public SelectOption(
            string referenceId,
            string title)
        {
            this.ReferenceId = referenceId;
            this.Title = title;
        }

        /// <summary>
        /// The reference id for the option.
        /// </summary>
        [JsonProperty("reference_id")]
        public string ReferenceId { get; }

        /// <summary>
        /// The title text that displays in the select option button.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SelectOption : ({string.Join(", ", toStringOutput)})";
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
            return obj is SelectOption other &&                ((this.ReferenceId == null && other.ReferenceId == null) || (this.ReferenceId?.Equals(other.ReferenceId) == true)) &&
                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -2076684246;
            hashCode = HashCode.Combine(this.ReferenceId, this.Title);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ReferenceId = {(this.ReferenceId == null ? "null" : this.ReferenceId)}");
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.ReferenceId,
                this.Title);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string referenceId;
            private string title;

            /// <summary>
            /// Initialize Builder for SelectOption.
            /// </summary>
            /// <param name="referenceId"> referenceId. </param>
            /// <param name="title"> title. </param>
            public Builder(
                string referenceId,
                string title)
            {
                this.referenceId = referenceId;
                this.title = title;
            }

             /// <summary>
             /// ReferenceId.
             /// </summary>
             /// <param name="referenceId"> referenceId. </param>
             /// <returns> Builder. </returns>
            public Builder ReferenceId(string referenceId)
            {
                this.referenceId = referenceId;
                return this;
            }

             /// <summary>
             /// Title.
             /// </summary>
             /// <param name="title"> title. </param>
             /// <returns> Builder. </returns>
            public Builder Title(string title)
            {
                this.title = title;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SelectOption. </returns>
            public SelectOption Build()
            {
                return new SelectOption(
                    this.referenceId,
                    this.title);
            }
        }
    }
}