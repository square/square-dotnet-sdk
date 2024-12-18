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
    /// DisputeEvidenceFile.
    /// </summary>
    public class DisputeEvidenceFile
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="DisputeEvidenceFile"/> class.
        /// </summary>
        /// <param name="filename">filename.</param>
        /// <param name="filetype">filetype.</param>
        public DisputeEvidenceFile(
            string filename = null,
            string filetype = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "filename", false },
                { "filetype", false }
            };

            if (filename != null)
            {
                shouldSerialize["filename"] = true;
                this.Filename = filename;
            }

            if (filetype != null)
            {
                shouldSerialize["filetype"] = true;
                this.Filetype = filetype;
            }
        }

        internal DisputeEvidenceFile(
            Dictionary<string, bool> shouldSerialize,
            string filename = null,
            string filetype = null)
        {
            this.shouldSerialize = shouldSerialize;
            Filename = filename;
            Filetype = filetype;
        }

        /// <summary>
        /// The file name including the file extension. For example: "receipt.tiff".
        /// </summary>
        [JsonProperty("filename")]
        public string Filename { get; }

        /// <summary>
        /// Dispute evidence files must be application/pdf, image/heic, image/heif, image/jpeg, image/png, or image/tiff formats.
        /// </summary>
        [JsonProperty("filetype")]
        public string Filetype { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"DisputeEvidenceFile : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFilename()
        {
            return this.shouldSerialize["filename"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFiletype()
        {
            return this.shouldSerialize["filetype"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is DisputeEvidenceFile other &&
                (this.Filename == null && other.Filename == null ||
                 this.Filename?.Equals(other.Filename) == true) &&
                (this.Filetype == null && other.Filetype == null ||
                 this.Filetype?.Equals(other.Filetype) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 868250934;
            hashCode = HashCode.Combine(hashCode, this.Filename, this.Filetype);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Filename = {this.Filename ?? "null"}");
            toStringOutput.Add($"this.Filetype = {this.Filetype ?? "null"}");
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "filename", false },
                { "filetype", false },
            };

            private string filename;
            private string filetype;

             /// <summary>
             /// Filename.
             /// </summary>
             /// <param name="filename"> filename. </param>
             /// <returns> Builder. </returns>
            public Builder Filename(string filename)
            {
                shouldSerialize["filename"] = true;
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
                shouldSerialize["filetype"] = true;
                this.filetype = filetype;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetFilename()
            {
                this.shouldSerialize["filename"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetFiletype()
            {
                this.shouldSerialize["filetype"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DisputeEvidenceFile. </returns>
            public DisputeEvidenceFile Build()
            {
                return new DisputeEvidenceFile(
                    shouldSerialize,
                    this.filename,
                    this.filetype);
            }
        }
    }
}