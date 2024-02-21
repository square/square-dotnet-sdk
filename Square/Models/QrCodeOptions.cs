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
    /// QrCodeOptions.
    /// </summary>
    public class QrCodeOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QrCodeOptions"/> class.
        /// </summary>
        /// <param name="title">title.</param>
        /// <param name="body">body.</param>
        /// <param name="barcodeContents">barcode_contents.</param>
        public QrCodeOptions(
            string title,
            string body,
            string barcodeContents)
        {
            this.Title = title;
            this.Body = body;
            this.BarcodeContents = barcodeContents;
        }

        /// <summary>
        /// The title text to display in the QR code flow on the Terminal.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; }

        /// <summary>
        /// The body text to display in the QR code flow on the Terminal.
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; }

        /// <summary>
        /// The text representation of the data to show in the QR code
        /// as UTF8-encoded data.
        /// </summary>
        [JsonProperty("barcode_contents")]
        public string BarcodeContents { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"QrCodeOptions : ({string.Join(", ", toStringOutput)})";
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
            return obj is QrCodeOptions other &&                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.Body == null && other.Body == null) || (this.Body?.Equals(other.Body) == true)) &&
                ((this.BarcodeContents == null && other.BarcodeContents == null) || (this.BarcodeContents?.Equals(other.BarcodeContents) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 674934960;
            hashCode = HashCode.Combine(this.Title, this.Body, this.BarcodeContents);

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
            toStringOutput.Add($"this.BarcodeContents = {(this.BarcodeContents == null ? "null" : this.BarcodeContents)}");
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
                this.BarcodeContents);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string title;
            private string body;
            private string barcodeContents;

            /// <summary>
            /// Initialize Builder for QrCodeOptions.
            /// </summary>
            /// <param name="title"> title. </param>
            /// <param name="body"> body. </param>
            /// <param name="barcodeContents"> barcodeContents. </param>
            public Builder(
                string title,
                string body,
                string barcodeContents)
            {
                this.title = title;
                this.body = body;
                this.barcodeContents = barcodeContents;
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
             /// BarcodeContents.
             /// </summary>
             /// <param name="barcodeContents"> barcodeContents. </param>
             /// <returns> Builder. </returns>
            public Builder BarcodeContents(string barcodeContents)
            {
                this.barcodeContents = barcodeContents;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> QrCodeOptions. </returns>
            public QrCodeOptions Build()
            {
                return new QrCodeOptions(
                    this.title,
                    this.body,
                    this.barcodeContents);
            }
        }
    }
}