using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// TenderSquareAccountDetails.
    /// </summary>
    public class TenderSquareAccountDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TenderSquareAccountDetails"/> class.
        /// </summary>
        /// <param name="status">status.</param>
        public TenderSquareAccountDetails(string status = null)
        {
            this.Status = status;
        }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"TenderSquareAccountDetails : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is TenderSquareAccountDetails other
                && (
                    this.Status == null && other.Status == null
                    || this.Status?.Equals(other.Status) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1722337095;
            hashCode = HashCode.Combine(hashCode, this.Status);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Status(this.Status);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string status;

            /// <summary>
            /// Status.
            /// </summary>
            /// <param name="status"> status. </param>
            /// <returns> Builder. </returns>
            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> TenderSquareAccountDetails. </returns>
            public TenderSquareAccountDetails Build()
            {
                return new TenderSquareAccountDetails(this.status);
            }
        }
    }
}
