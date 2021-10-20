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
    /// DisputeEvidenceFile.
    /// </summary>
    public class DisputeEvidenceFile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisputeEvidenceFile"/> class.
        /// </summary>
        /// <param name="filename">filename.</param>
        /// <param name="filetype">filetype.</param>
        public DisputeEvidenceFile(
            string filename = null,
            string filetype = null)
        {
            this.Filename = filename;
            this.Filetype = filetype;
        }

        /// <summary>
        /// The file name including the file extension. For example: "receipt.tiff".
        /// </summary>
        [JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
        public string Filename { get; }

        /// <summary>
        /// Dispute evidence files must be application/pdf, image/heic, image/heif, image/jpeg, image/png, or image/tiff formats.
        /// </summary>
        [JsonProperty("filetype", NullValueHandling = NullValueHandling.Ignore)]
        public string Filetype { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DisputeEvidenceFile : ({string.Join(", ", toStringOutput)})";
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

            return obj is DisputeEvidenceFile other &&
                ((this.Filename == null && other.Filename == null) || (this.Filename?.Equals(other.Filename) == true)) &&
                ((this.Filetype == null && other.Filetype == null) || (this.Filetype?.Equals(other.Filetype) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 868250934;
            hashCode = HashCode.Combine(this.Filename, this.Filetype);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Filename = {(this.Filename == null ? "null" : this.Filename == string.Empty ? "" : this.Filename)}");
            toStringOutput.Add($"this.Filetype = {(this.Filetype == null ? "null" : this.Filetype == string.Empty ? "" : this.Filetype)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Filename(this.Filename)
                .Filetype(this.Filetype);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string filename;
            private string filetype;

             /// <summary>
             /// Filename.
             /// </summary>
             /// <param name="filename"> filename. </param>
             /// <returns> Builder. </returns>
            public Builder Filename(string filename)
            {
                this.filename = filename;
                return this;
            }

             /// <summary>
             /// Filetype.
             /// </summary>
             /// <param name="filetype"> filetype. </param>
             /// <returns> Builder. </returns>
            public Builder Filetype(string filetype)
            {
                this.filetype = filetype;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DisputeEvidenceFile. </returns>
            public DisputeEvidenceFile Build()
            {
                return new DisputeEvidenceFile(
                    this.filename,
                    this.filetype);
            }
        }
    }
}