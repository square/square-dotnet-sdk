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
    /// SignatureOptions.
    /// </summary>
    public class SignatureOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignatureOptions"/> class.
        /// </summary>
        /// <param name="title">title.</param>
        /// <param name="body">body.</param>
        /// <param name="signature">signature.</param>
        public SignatureOptions(
            string title,
            string body,
            IList<Models.SignatureImage> signature = null)
        {
            this.Title = title;
            this.Body = body;
            this.Signature = signature;
        }

        /// <summary>
        /// The title text to display in the signature capture flow on the Terminal.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; }

        /// <summary>
        /// The body text to display in the signature capture flow on the Terminal.
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; }

        /// <summary>
        /// An image representation of the collected signature.
        /// </summary>
        [JsonProperty("signature", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.SignatureImage> Signature { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SignatureOptions : ({string.Join(", ", toStringOutput)})";
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
            return obj is SignatureOptions other &&                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.Body == null && other.Body == null) || (this.Body?.Equals(other.Body) == true)) &&
                ((this.Signature == null && other.Signature == null) || (this.Signature?.Equals(other.Signature) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 530007620;
            hashCode = HashCode.Combine(this.Title, this.Body, this.Signature);

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
            toStringOutput.Add($"this.Signature = {(this.Signature == null ? "null" : $"[{string.Join(", ", this.Signature)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Title,
                this.Body)
                .Signature(this.Signature);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string title;
            private string body;
            private IList<Models.SignatureImage> signature;

            /// <summary>
            /// Initialize Builder for SignatureOptions.
            /// </summary>
            /// <param name="title"> title. </param>
            /// <param name="body"> body. </param>
            public Builder(
                string title,
                string body)
            {
                this.title = title;
                this.body = body;
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
             /// Signature.
             /// </summary>
             /// <param name="signature"> signature. </param>
             /// <returns> Builder. </returns>
            public Builder Signature(IList<Models.SignatureImage> signature)
            {
                this.signature = signature;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SignatureOptions. </returns>
            public SignatureOptions Build()
            {
                return new SignatureOptions(
                    this.title,
                    this.body,
                    this.signature);
            }
        }
    }
}