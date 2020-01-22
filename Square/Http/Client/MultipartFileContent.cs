using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Square.Utilities;

namespace Square.Http.Client
{
    internal class MultipartFileContent : MultipartContent
    {
        public FileStreamInfo File { get; }

        public MultipartFileContent(FileStreamInfo file)
        {
            File = file;
        }

        public MultipartFileContent(FileStreamInfo file, IReadOnlyDictionary<string, IReadOnlyCollection<string>> headers) : base(headers)
        {
            File = file;
        }

        public override HttpContent ToHttpContent(string contentDispositionName)
        {
            var streamContent = new StreamContent(File.FileStream);
            SetHeaders(contentDispositionName, streamContent.Headers);

            return streamContent;
        }

        protected override void SetHeaders(string contentDispositionName, HttpContentHeaders headers)
        {
            base.SetHeaders(contentDispositionName, headers);

            headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = contentDispositionName,
                FileName = string.IsNullOrWhiteSpace(File.FileName) ? "file" : File.FileName,
            };

            if (!string.IsNullOrEmpty(File.ContentType))
            {
                headers.ContentType = new MediaTypeHeaderValue(File.ContentType);
            }
            else if (!Headers.ContainsKey("content-type"))
            {
                headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            }
        }
    }
}
