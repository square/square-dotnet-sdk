using System;
using System.IO;
using APIMatic.Core.Types.Sdk;

namespace Square.Legacy.Http.Client
{
    /// <summary>
    /// An DTO class to capture information for file uploads.
    /// </summary>
    public class FileStreamInfo : CoreFileStreamInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileStreamInfo"/> class.
        /// </summary>
        /// <param name="stream">The stream object with read access to the file data.</param>
        /// <param name="fileName">Optional file name associated with the stream.</param>
        /// <param name="contentType">Optional file content type associated with the stream.</param>
        public FileStreamInfo(Stream stream, string fileName = null, string contentType = null)
            : base(stream, fileName, contentType) { }
    }
}
