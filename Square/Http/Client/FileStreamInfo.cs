namespace Square.Http.Client
{
    using System;
    using System.IO;

    /// <summary>
    /// An DTO class to capture information for file uploads.
    /// </summary>
    public class FileStreamInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileStreamInfo"/> class.
        /// </summary>
        /// <param name="stream">The stream object with read access to the file data.</param>
        /// <param name="fileName">Optional file name associated with the stream.</param>
        /// <param name="contentType">Optional file content type associated with the stream.</param>
        public FileStreamInfo(Stream stream, string fileName = null, string contentType = null)
        {
            this.FileStream = stream;
            this.FileName = fileName;
            this.ContentType = contentType;
        }

        /// <summary>
        /// Gets the stream object with read access to the file data.
        /// </summary>
        public Stream FileStream { get; }

        /// <summary>
        /// Gets name of the file associated with the stream.
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// Gets content type of the file associated with the stream.
        /// </summary>
        public string ContentType { get; }
    }
}
