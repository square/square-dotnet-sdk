using System;
using System.IO;

namespace Square.Http.Client
{
    /// <summary>
    /// An DTO class to capture information for file uploads
    /// </summary>
    public class FileStreamInfo
    {
        /// <summary>
        /// The stream object with read access to the file data
        /// </summary>
        public Stream FileStream { get; }

        /// <summary>
        /// Name of the file associated with the stream
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// Content type of the file associated with the stream
        /// </summary>
        public string ContentType { get; }

        /// <summary>
        /// Constructor to initialize the object with optional file name
        /// </summary>
        /// <param name="stream">The stream object with read access to the file data</param>
        /// <param name="fileName">Optional file name associated with the stream</param>
        /// <param name="contentType">Optional file content type associated with the stream</param>
        public FileStreamInfo(Stream stream, string fileName = null, string contentType = null)
        {
            FileStream = stream;
            FileName = fileName;
            ContentType = contentType;
        }
    }
}
