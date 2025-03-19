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
    /// InvoiceAttachment.
    /// </summary>
    public class InvoiceAttachment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceAttachment"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="filename">filename.</param>
        /// <param name="description">description.</param>
        /// <param name="filesize">filesize.</param>
        /// <param name="hash">hash.</param>
        /// <param name="mimeType">mime_type.</param>
        /// <param name="uploadedAt">uploaded_at.</param>
        public InvoiceAttachment(
            string id = null,
            string filename = null,
            string description = null,
            int? filesize = null,
            string hash = null,
            string mimeType = null,
            string uploadedAt = null
        )
        {
            this.Id = id;
            this.Filename = filename;
            this.Description = description;
            this.Filesize = filesize;
            this.Hash = hash;
            this.MimeType = mimeType;
            this.UploadedAt = uploadedAt;
        }

        /// <summary>
        /// The Square-assigned ID of the attachment.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The file name of the attachment, which is displayed on the invoice.
        /// </summary>
        [JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
        public string Filename { get; }

        /// <summary>
        /// The description of the attachment, which is displayed on the invoice.
        /// This field maps to the seller-defined **Message** field.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; }

        /// <summary>
        /// The file size of the attachment in bytes.
        /// </summary>
        [JsonProperty("filesize", NullValueHandling = NullValueHandling.Ignore)]
        public int? Filesize { get; }

        /// <summary>
        /// The MD5 hash that was generated from the file contents.
        /// </summary>
        [JsonProperty("hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; }

        /// <summary>
        /// The mime type of the attachment.
        /// The following mime types are supported:
        /// image/gif, image/jpeg, image/png, image/tiff, image/bmp, application/pdf.
        /// </summary>
        [JsonProperty("mime_type", NullValueHandling = NullValueHandling.Ignore)]
        public string MimeType { get; }

        /// <summary>
        /// The timestamp when the attachment was uploaded, in RFC 3339 format.
        /// </summary>
        [JsonProperty("uploaded_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UploadedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"InvoiceAttachment : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is InvoiceAttachment other
                && (this.Id == null && other.Id == null || this.Id?.Equals(other.Id) == true)
                && (
                    this.Filename == null && other.Filename == null
                    || this.Filename?.Equals(other.Filename) == true
                )
                && (
                    this.Description == null && other.Description == null
                    || this.Description?.Equals(other.Description) == true
                )
                && (
                    this.Filesize == null && other.Filesize == null
                    || this.Filesize?.Equals(other.Filesize) == true
                )
                && (
                    this.Hash == null && other.Hash == null || this.Hash?.Equals(other.Hash) == true
                )
                && (
                    this.MimeType == null && other.MimeType == null
                    || this.MimeType?.Equals(other.MimeType) == true
                )
                && (
                    this.UploadedAt == null && other.UploadedAt == null
                    || this.UploadedAt?.Equals(other.UploadedAt) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -700483952;
            hashCode = HashCode.Combine(
                hashCode,
                this.Id,
                this.Filename,
                this.Description,
                this.Filesize,
                this.Hash,
                this.MimeType,
                this.UploadedAt
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {this.Id ?? "null"}");
            toStringOutput.Add($"this.Filename = {this.Filename ?? "null"}");
            toStringOutput.Add($"this.Description = {this.Description ?? "null"}");
            toStringOutput.Add(
                $"this.Filesize = {(this.Filesize == null ? "null" : this.Filesize.ToString())}"
            );
            toStringOutput.Add($"this.Hash = {this.Hash ?? "null"}");
            toStringOutput.Add($"this.MimeType = {this.MimeType ?? "null"}");
            toStringOutput.Add($"this.UploadedAt = {this.UploadedAt ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .Filename(this.Filename)
                .Description(this.Description)
                .Filesize(this.Filesize)
                .Hash(this.Hash)
                .MimeType(this.MimeType)
                .UploadedAt(this.UploadedAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string id;
            private string filename;
            private string description;
            private int? filesize;
            private string hash;
            private string mimeType;
            private string uploadedAt;

            /// <summary>
            /// Id.
            /// </summary>
            /// <param name="id"> id. </param>
            /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

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
            /// Description.
            /// </summary>
            /// <param name="description"> description. </param>
            /// <returns> Builder. </returns>
            public Builder Description(string description)
            {
                this.description = description;
                return this;
            }

            /// <summary>
            /// Filesize.
            /// </summary>
            /// <param name="filesize"> filesize. </param>
            /// <returns> Builder. </returns>
            public Builder Filesize(int? filesize)
            {
                this.filesize = filesize;
                return this;
            }

            /// <summary>
            /// Hash.
            /// </summary>
            /// <param name="hash"> hash. </param>
            /// <returns> Builder. </returns>
            public Builder Hash(string hash)
            {
                this.hash = hash;
                return this;
            }

            /// <summary>
            /// MimeType.
            /// </summary>
            /// <param name="mimeType"> mimeType. </param>
            /// <returns> Builder. </returns>
            public Builder MimeType(string mimeType)
            {
                this.mimeType = mimeType;
                return this;
            }

            /// <summary>
            /// UploadedAt.
            /// </summary>
            /// <param name="uploadedAt"> uploadedAt. </param>
            /// <returns> Builder. </returns>
            public Builder UploadedAt(string uploadedAt)
            {
                this.uploadedAt = uploadedAt;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> InvoiceAttachment. </returns>
            public InvoiceAttachment Build()
            {
                return new InvoiceAttachment(
                    this.id,
                    this.filename,
                    this.description,
                    this.filesize,
                    this.hash,
                    this.mimeType,
                    this.uploadedAt
                );
            }
        }
    }
}
