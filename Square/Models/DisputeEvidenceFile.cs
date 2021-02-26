
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class DisputeEvidenceFile 
    {
        public DisputeEvidenceFile(string filename = null,
            string filetype = null)
        {
            Filename = filename;
            Filetype = filetype;
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DisputeEvidenceFile : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Filename = {(Filename == null ? "null" : Filename == string.Empty ? "" : Filename)}");
            toStringOutput.Add($"Filetype = {(Filetype == null ? "null" : Filetype == string.Empty ? "" : Filetype)}");
        }

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
                ((Filename == null && other.Filename == null) || (Filename?.Equals(other.Filename) == true)) &&
                ((Filetype == null && other.Filetype == null) || (Filetype?.Equals(other.Filetype) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 868250934;

            if (Filename != null)
            {
               hashCode += Filename.GetHashCode();
            }

            if (Filetype != null)
            {
               hashCode += Filetype.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Filename(Filename)
                .Filetype(Filetype);
            return builder;
        }

        public class Builder
        {
            private string filename;
            private string filetype;



            public Builder Filename(string filename)
            {
                this.filename = filename;
                return this;
            }

            public Builder Filetype(string filetype)
            {
                this.filetype = filetype;
                return this;
            }

            public DisputeEvidenceFile Build()
            {
                return new DisputeEvidenceFile(filename,
                    filetype);
            }
        }
    }
}