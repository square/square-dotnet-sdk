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
    /// ConfirmationOptions.
    /// </summary>
    public class ConfirmationOptions
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmationOptions"/> class.
        /// </summary>
        /// <param name="title">title.</param>
        /// <param name="body">body.</param>
        /// <param name="agreeButtonText">agree_button_text.</param>
        /// <param name="disagreeButtonText">disagree_button_text.</param>
        /// <param name="decision">decision.</param>
        public ConfirmationOptions(
            string title,
            string body,
            string agreeButtonText,
            string disagreeButtonText = null,
            Models.ConfirmationDecision decision = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "disagree_button_text", false }
            };

            this.Title = title;
            this.Body = body;
            this.AgreeButtonText = agreeButtonText;
            if (disagreeButtonText != null)
            {
                shouldSerialize["disagree_button_text"] = true;
                this.DisagreeButtonText = disagreeButtonText;
            }

            this.Decision = decision;
        }
        internal ConfirmationOptions(Dictionary<string, bool> shouldSerialize,
            string title,
            string body,
            string agreeButtonText,
            string disagreeButtonText = null,
            Models.ConfirmationDecision decision = null)
        {
            this.shouldSerialize = shouldSerialize;
            Title = title;
            Body = body;
            AgreeButtonText = agreeButtonText;
            DisagreeButtonText = disagreeButtonText;
            Decision = decision;
        }

        /// <summary>
        /// The title text to display in the confirmation screen flow on the Terminal.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; }

        /// <summary>
        /// The agreement details to display in the confirmation flow on the Terminal.
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; }

        /// <summary>
        /// The button text to display indicating the customer agrees to the displayed terms.
        /// </summary>
        [JsonProperty("agree_button_text")]
        public string AgreeButtonText { get; }

        /// <summary>
        /// The button text to display indicating the customer does not agree to the displayed terms.
        /// </summary>
        [JsonProperty("disagree_button_text")]
        public string DisagreeButtonText { get; }

        /// <summary>
        /// Gets or sets Decision.
        /// </summary>
        [JsonProperty("decision", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ConfirmationDecision Decision { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ConfirmationOptions : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDisagreeButtonText()
        {
            return this.shouldSerialize["disagree_button_text"];
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
            return obj is ConfirmationOptions other &&                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.Body == null && other.Body == null) || (this.Body?.Equals(other.Body) == true)) &&
                ((this.AgreeButtonText == null && other.AgreeButtonText == null) || (this.AgreeButtonText?.Equals(other.AgreeButtonText) == true)) &&
                ((this.DisagreeButtonText == null && other.DisagreeButtonText == null) || (this.DisagreeButtonText?.Equals(other.DisagreeButtonText) == true)) &&
                ((this.Decision == null && other.Decision == null) || (this.Decision?.Equals(other.Decision) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -300469146;
            hashCode = HashCode.Combine(this.Title, this.Body, this.AgreeButtonText, this.DisagreeButtonText, this.Decision);

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
            toStringOutput.Add($"this.AgreeButtonText = {(this.AgreeButtonText == null ? "null" : this.AgreeButtonText)}");
            toStringOutput.Add($"this.DisagreeButtonText = {(this.DisagreeButtonText == null ? "null" : this.DisagreeButtonText)}");
            toStringOutput.Add($"this.Decision = {(this.Decision == null ? "null" : this.Decision.ToString())}");
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
                this.AgreeButtonText)
                .DisagreeButtonText(this.DisagreeButtonText)
                .Decision(this.Decision);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "disagree_button_text", false },
            };

            private string title;
            private string body;
            private string agreeButtonText;
            private string disagreeButtonText;
            private Models.ConfirmationDecision decision;

            /// <summary>
            /// Initialize Builder for ConfirmationOptions.
            /// </summary>
            /// <param name="title"> title. </param>
            /// <param name="body"> body. </param>
            /// <param name="agreeButtonText"> agreeButtonText. </param>
            public Builder(
                string title,
                string body,
                string agreeButtonText)
            {
                this.title = title;
                this.body = body;
                this.agreeButtonText = agreeButtonText;
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
             /// AgreeButtonText.
             /// </summary>
             /// <param name="agreeButtonText"> agreeButtonText. </param>
             /// <returns> Builder. </returns>
            public Builder AgreeButtonText(string agreeButtonText)
            {
                this.agreeButtonText = agreeButtonText;
                return this;
            }

             /// <summary>
             /// DisagreeButtonText.
             /// </summary>
             /// <param name="disagreeButtonText"> disagreeButtonText. </param>
             /// <returns> Builder. </returns>
            public Builder DisagreeButtonText(string disagreeButtonText)
            {
                shouldSerialize["disagree_button_text"] = true;
                this.disagreeButtonText = disagreeButtonText;
                return this;
            }

             /// <summary>
             /// Decision.
             /// </summary>
             /// <param name="decision"> decision. </param>
             /// <returns> Builder. </returns>
            public Builder Decision(Models.ConfirmationDecision decision)
            {
                this.decision = decision;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDisagreeButtonText()
            {
                this.shouldSerialize["disagree_button_text"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ConfirmationOptions. </returns>
            public ConfirmationOptions Build()
            {
                return new ConfirmationOptions(shouldSerialize,
                    this.title,
                    this.body,
                    this.agreeButtonText,
                    this.disagreeButtonText,
                    this.decision);
            }
        }
    }
}