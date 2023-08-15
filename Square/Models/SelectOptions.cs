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
    /// SelectOptions.
    /// </summary>
    public class SelectOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectOptions"/> class.
        /// </summary>
        /// <param name="title">title.</param>
        /// <param name="body">body.</param>
        /// <param name="options">options.</param>
        /// <param name="selectedOption">selected_option.</param>
        public SelectOptions(
            string title,
            string body,
            IList<Models.SelectOption> options,
            Models.SelectOption selectedOption = null)
        {
            this.Title = title;
            this.Body = body;
            this.Options = options;
            this.SelectedOption = selectedOption;
        }

        /// <summary>
        /// The title text to display in the select flow on the Terminal.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; }

        /// <summary>
        /// The body text to display in the select flow on the Terminal.
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; }

        /// <summary>
        /// Represents the buttons/options that should be displayed in the select flow on the Terminal.
        /// </summary>
        [JsonProperty("options")]
        public IList<Models.SelectOption> Options { get; }

        /// <summary>
        /// Gets or sets SelectedOption.
        /// </summary>
        [JsonProperty("selected_option", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SelectOption SelectedOption { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SelectOptions : ({string.Join(", ", toStringOutput)})";
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
            return obj is SelectOptions other &&                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.Body == null && other.Body == null) || (this.Body?.Equals(other.Body) == true)) &&
                ((this.Options == null && other.Options == null) || (this.Options?.Equals(other.Options) == true)) &&
                ((this.SelectedOption == null && other.SelectedOption == null) || (this.SelectedOption?.Equals(other.SelectedOption) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -488182536;
            hashCode = HashCode.Combine(this.Title, this.Body, this.Options, this.SelectedOption);

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
            toStringOutput.Add($"this.Options = {(this.Options == null ? "null" : $"[{string.Join(", ", this.Options)} ]")}");
            toStringOutput.Add($"this.SelectedOption = {(this.SelectedOption == null ? "null" : this.SelectedOption.ToString())}");
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
                this.Options)
                .SelectedOption(this.SelectedOption);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string title;
            private string body;
            private IList<Models.SelectOption> options;
            private Models.SelectOption selectedOption;

            public Builder(
                string title,
                string body,
                IList<Models.SelectOption> options)
            {
                this.title = title;
                this.body = body;
                this.options = options;
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
             /// Options.
             /// </summary>
             /// <param name="options"> options. </param>
             /// <returns> Builder. </returns>
            public Builder Options(IList<Models.SelectOption> options)
            {
                this.options = options;
                return this;
            }

             /// <summary>
             /// SelectedOption.
             /// </summary>
             /// <param name="selectedOption"> selectedOption. </param>
             /// <returns> Builder. </returns>
            public Builder SelectedOption(Models.SelectOption selectedOption)
            {
                this.selectedOption = selectedOption;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SelectOptions. </returns>
            public SelectOptions Build()
            {
                return new SelectOptions(
                    this.title,
                    this.body,
                    this.options,
                    this.selectedOption);
            }
        }
    }
}