using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Square.Utilities;

namespace Square.Http.Client
{
    internal abstract class MultipartContent
    {
        public IReadOnlyDictionary<string, IReadOnlyCollection<string>> Headers { get; }

        public MultipartContent()
        {
            Headers = new Dictionary<string, IReadOnlyCollection<string>>();
        }

        public MultipartContent(IReadOnlyDictionary<string, IReadOnlyCollection<string>> headers)
        {
            Headers = headers;
        }

        public abstract HttpContent ToHttpContent(string contentDispositionName);

        protected virtual void SetHeaders(string contentDispositionName, HttpContentHeaders headers)
        {
            if (Headers.ContainsKey("content-type"))
            {
                bool isContentTypeValid = MediaTypeHeaderValue.TryParse(Headers["content-type"].FirstOrDefault(), out var parsedContentType);

                if (isContentTypeValid)
                {
                    headers.ContentType = parsedContentType;
                }
            }

            headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = contentDispositionName,
            };

            var headersList = Headers.Where(kv => !IsReservedHeader(kv.Key));

            foreach (var header in headersList)
            {
                headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        protected bool IsReservedHeader(string key)
        {
            return key.Equals("content-type", StringComparison.OrdinalIgnoreCase) ||
                key.Equals("content-disposition", StringComparison.OrdinalIgnoreCase);
        }
    }
}
