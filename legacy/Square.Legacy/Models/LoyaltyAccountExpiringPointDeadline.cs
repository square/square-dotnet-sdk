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
    /// LoyaltyAccountExpiringPointDeadline.
    /// </summary>
    public class LoyaltyAccountExpiringPointDeadline
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyAccountExpiringPointDeadline"/> class.
        /// </summary>
        /// <param name="points">points.</param>
        /// <param name="expiresAt">expires_at.</param>
        public LoyaltyAccountExpiringPointDeadline(int points, string expiresAt)
        {
            this.Points = points;
            this.ExpiresAt = expiresAt;
        }

        /// <summary>
        /// The number of points scheduled to expire at the `expires_at` timestamp.
        /// </summary>
        [JsonProperty("points")]
        public int Points { get; }

        /// <summary>
        /// The timestamp of when the points are scheduled to expire, in RFC 3339 format.
        /// </summary>
        [JsonProperty("expires_at")]
        public string ExpiresAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"LoyaltyAccountExpiringPointDeadline : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is LoyaltyAccountExpiringPointDeadline other
                && (this.Points.Equals(other.Points))
                && (
                    this.ExpiresAt == null && other.ExpiresAt == null
                    || this.ExpiresAt?.Equals(other.ExpiresAt) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1494271948;
            hashCode = HashCode.Combine(hashCode, this.Points, this.ExpiresAt);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Points = {this.Points}");
            toStringOutput.Add($"this.ExpiresAt = {this.ExpiresAt ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.Points, this.ExpiresAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private int points;
            private string expiresAt;

            /// <summary>
            /// Initialize Builder for LoyaltyAccountExpiringPointDeadline.
            /// </summary>
            /// <param name="points"> points. </param>
            /// <param name="expiresAt"> expiresAt. </param>
            public Builder(int points, string expiresAt)
            {
                this.points = points;
                this.expiresAt = expiresAt;
            }

            /// <summary>
            /// Points.
            /// </summary>
            /// <param name="points"> points. </param>
            /// <returns> Builder. </returns>
            public Builder Points(int points)
            {
                this.points = points;
                return this;
            }

            /// <summary>
            /// ExpiresAt.
            /// </summary>
            /// <param name="expiresAt"> expiresAt. </param>
            /// <returns> Builder. </returns>
            public Builder ExpiresAt(string expiresAt)
            {
                this.expiresAt = expiresAt;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyAccountExpiringPointDeadline. </returns>
            public LoyaltyAccountExpiringPointDeadline Build()
            {
                return new LoyaltyAccountExpiringPointDeadline(this.points, this.expiresAt);
            }
        }
    }
}
