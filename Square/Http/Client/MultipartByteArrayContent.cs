using System.Collections.Generic;
using System.Net.Http;

namespace Square.Http.Client
{
    internal class MultipartByteArrayContent : MultipartContent
    {
        public byte[] ByteArray { get; }

        public MultipartByteArrayContent(byte[] byteArray)
        {
            ByteArray = byteArray;
        }

        public MultipartByteArrayContent(byte[] byteArray, IReadOnlyDictionary<string, IReadOnlyCollection<string>> headers) : base(headers)
        {
            ByteArray = byteArray;
        }

        public override HttpContent ToHttpContent(string contentDispositionName)
        {
            var byteArrayContent = new ByteArrayContent(ByteArray);
            SetHeaders(contentDispositionName, byteArrayContent.Headers);

            return byteArrayContent;
        }
    }
}
