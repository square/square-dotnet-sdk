namespace Square.Http.Client
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Square.Utilities;

    /// <summary>
    /// MultipartFileContent.
    /// </summary>
    internal class MultipartFileContent : MultipartContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultipartFileContent"/> class.
        /// </summary>
        /// <param name="file">file.</param>
        public MultipartFileContent(FileStreamInfo file)
        {
            this.File = file;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipartFileContent"/> class.
        /// </summary>
        /// <param name="file">file.</param>
        /// <param name="headers">headers.</param>
        public MultipartFileContent(
            FileStreamInfo file,
            IReadOnlyDictionary<string,
            IReadOnlyCollection<string>> headers)
            : base(headers)
        {
            this.File = file;
        }

        /// <summary>
        /// Gets file.
        /// </summary>
        public FileStreamInfo File { get; }

        /// <summary>
        /// Rewind the stream.
        /// </summary>
        public override void Rewind()
        {
            this.File.FileStream.Position = 0;
        }

        /// <summary>
        /// ToHttpContent.
        /// </summary>
        /// <param name="contentDispositionName">contentDispositionName.</param>
        /// <returns>HttpContent.</returns>
        public override HttpContent ToHttpContent(string contentDispositionName)
        {
            var streamContent = new StreamContent(this.File.FileStream);
            this.SetHeaders(contentDispositionName, streamContent.Headers);

            return streamContent;
        }

        /// <summary>
        /// SetHeaders.
        /// </summary>
        /// <param name="contentDispositionName">contentDispositionName.</param>
        /// <param name="headers">headers.</param>
        protected override void SetHeaders(
            string contentDispositionName,
            HttpContentHeaders headers)
        {
            base.SetHeaders(contentDispositionName, headers);

            headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = contentDispositionName,
                FileName = string.IsNullOrWhiteSpace(this.File.FileName) ? "file" : this.File.FileName,
            };

            if (!string.IsNullOrEmpty(this.File.ContentType))
            {
                headers.ContentType = new MediaTypeHeaderValue(this.File.ContentType);
            }
            else if (!this.Headers.ContainsKey("content-type"))
            {
                headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            }
        }
    }
}
