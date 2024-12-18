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
    /// SignatureImage.
    /// </summary>
    public class SignatureImage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignatureImage"/> class.
        /// </summary>
        /// <param name="imageType">image_type.</param>
        /// <param name="data">data.</param>
        public SignatureImage(
            string imageType = null,
            string data = null)
        {
            this.ImageType = imageType;
            this.Data = data;
        }

        /// <summary>
        /// The mime/type of the image data.
        /// Use `image/png;base64` for png.
        /// </summary>
        [JsonProperty("image_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageType { get; }

        /// <summary>
        /// The base64 representation of the image.
        /// </summary>
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public string Data { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"SignatureImage : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is SignatureImage other &&
                (this.ImageType == null && other.ImageType == null ||
                 this.ImageType?.Equals(other.ImageType) == true) &&
                (this.Data == null && other.Data == null ||
                 this.Data?.Equals(other.Data) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 144332077;
            hashCode = HashCode.Combine(hashCode, this.ImageType, this.Data);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ImageType = {this.ImageType ?? "null"}");
            toStringOutput.Add($"this.Data = {this.Data ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ImageType(this.ImageType)
                .Data(this.Data);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string imageType;
            private string data;

             /// <summary>
             /// ImageType.
             /// </summary>
             /// <param name="imageType"> imageType. </param>
             /// <returns> Builder. </returns>
            public Builder ImageType(string imageType)
            {
                this.imageType = imageType;
                return this;
            }

             /// <summary>
             /// Data.
             /// </summary>
             /// <param name="data"> data. </param>
             /// <returns> Builder. </returns>
            public Builder Data(string data)
            {
                this.data = data;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SignatureImage. </returns>
            public SignatureImage Build()
            {
                return new SignatureImage(
                    this.imageType,
                    this.data);
            }
        }
    }
}