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
    /// DataCollectionOptions.
    /// </summary>
    public class DataCollectionOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataCollectionOptions"/> class.
        /// </summary>
        /// <param name="title">title.</param>
        /// <param name="body">body.</param>
        /// <param name="inputType">input_type.</param>
        /// <param name="collectedData">collected_data.</param>
        public DataCollectionOptions(
            string title,
            string body,
            string inputType,
            Models.CollectedData collectedData = null)
        {
            this.Title = title;
            this.Body = body;
            this.InputType = inputType;
            this.CollectedData = collectedData;
        }

        /// <summary>
        /// The title text to display in the data collection flow on the Terminal.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; }

        /// <summary>
        /// The body text to display under the title in the data collection screen flow on the
        /// Terminal.
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; }

        /// <summary>
        /// Describes the input type of the data.
        /// </summary>
        [JsonProperty("input_type")]
        public string InputType { get; }

        /// <summary>
        /// Gets or sets CollectedData.
        /// </summary>
        [JsonProperty("collected_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CollectedData CollectedData { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DataCollectionOptions : ({string.Join(", ", toStringOutput)})";
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
            return obj is DataCollectionOptions other &&                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.Body == null && other.Body == null) || (this.Body?.Equals(other.Body) == true)) &&
                ((this.InputType == null && other.InputType == null) || (this.InputType?.Equals(other.InputType) == true)) &&
                ((this.CollectedData == null && other.CollectedData == null) || (this.CollectedData?.Equals(other.CollectedData) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 913429537;
            hashCode = HashCode.Combine(this.Title, this.Body, this.InputType, this.CollectedData);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title)}");
            toStringOutput.Add($"this.Body = {(this.Body == null ? "null" : this.Body)}");
            toStringOutput.Add($"this.InputType = {(this.InputType == null ? "null" : this.InputType.ToString())}");
            toStringOutput.Add($"this.CollectedData = {(this.CollectedData == null ? "null" : this.CollectedData.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Title,
                this.Body,
                this.InputType)
                .CollectedData(this.CollectedData);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string title;
            private string body;
            private string inputType;
            private Models.CollectedData collectedData;

            /// <summary>
            /// Initialize Builder for DataCollectionOptions.
            /// </summary>
            /// <param name="title"> title. </param>
            /// <param name="body"> body. </param>
            /// <param name="inputType"> inputType. </param>
            public Builder(
                string title,
                string body,
                string inputType)
            {
                this.title = title;
                this.body = body;
                this.inputType = inputType;
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
             /// Body.
             /// </summary>
             /// <param name="body"> body. </param>
             /// <returns> Builder. </returns>
            public Builder Body(string body)
            {
                this.body = body;
                return this;
            }

             /// <summary>
             /// InputType.
             /// </summary>
             /// <param name="inputType"> inputType. </param>
             /// <returns> Builder. </returns>
            public Builder InputType(string inputType)
            {
                this.inputType = inputType;
                return this;
            }

             /// <summary>
             /// CollectedData.
             /// </summary>
             /// <param name="collectedData"> collectedData. </param>
             /// <returns> Builder. </returns>
            public Builder CollectedData(Models.CollectedData collectedData)
            {
                this.collectedData = collectedData;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DataCollectionOptions. </returns>
            public DataCollectionOptions Build()
            {
                return new DataCollectionOptions(
                    this.title,
                    this.body,
                    this.inputType,
                    this.collectedData);
            }
        }
    }
}