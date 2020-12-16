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