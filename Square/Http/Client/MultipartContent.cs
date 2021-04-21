namespace Square.Http.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Square.Utilities;

    /// <summary>
    /// MultipartContent.
    /// </summary>
    internal abstract class MultipartContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultipartContent"/> class.
        /// </summary>
        public MultipartContent()
        {
            this.Headers = new Dictionary<string, IReadOnlyCollection<string>>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipartContent"/> class.
        /// </summary>
        /// <param name="headers">headers.</param>
        public MultipartContent(
            IReadOnlyDictionary<string,
            IReadOnlyCollection<string>> headers)
        {
            this.Headers = headers;
        }

        /// <summary>
        /// Gets headers.
        /// </summary>
        public IReadOnlyDictionary<string, IReadOnlyCollection<string>> Headers { get; }

        /// <summary>
        /// Rewind the stream.
        /// </summary>
        public abstract void Rewind();

        /// <summary>
        /// ToHttpContent.
        /// </summary>
        /// <param name="contentDispositionName">contentDispositionName.</param>
        /// <returns>HttpContent.</returns>
        public abstract HttpContent ToHttpContent(string contentDispositionName);

        /// <summary>
        /// SetHeaders.
        /// </summary>
        /// <param name="contentDispositionName">contentDispositionName.</param>
        /// <param name="headers">headers.</param>
        protected virtual void SetHeaders(
            string contentDispositionName,
            HttpContentHeaders headers)
        {
            if (this.Headers.ContainsKey("content-type"))
            {
                bool isContentTypeValid = MediaTypeHeaderValue.TryParse(this.Headers["content-type"].FirstOrDefault(), out var parsedContentType);

                if (isContentTypeValid)
                {
                    headers.ContentType = parsedContentType;
                }
            }

            headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = contentDispositionName,
            };

            var headersList = this.Headers.Where(kv => !this.IsReservedHeader(kv.Key));

            foreach (var header in headersList)
            {
                headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        /// <summary>
        /// IsReservedHeader.
        /// </summary>
        /// <param name="key">key.</param>
        /// <returns>boolean.</returns>
        protected bool IsReservedHeader(string key)
        {
            return key.Equals("content-type", StringComparison.OrdinalIgnoreCase) ||
                key.Equals("content-disposition", StringComparison.OrdinalIgnoreCase);
        }
    }
}
