namespace Square.Models
{
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
    using Square;
    using Square.Utilities;

    /// <summary>
    /// LoyaltyProgramTerminology.
    /// </summary>
    public class LoyaltyProgramTerminology
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyProgramTerminology"/> class.
        /// </summary>
        /// <param name="one">one.</param>
        /// <param name="other">other.</param>
        public LoyaltyProgramTerminology(
            string one,
            string other)
        {
            this.One = one;
            this.Other = other;
        }

        /// <summary>
        /// A singular unit for a point (for example, 1 point is called 1 star).
        /// </summary>
        [JsonProperty("one")]
        public string One { get; }

        /// <summary>
        /// A plural unit for point (for example, 10 points is called 10 stars).
        /// </summary>
        [JsonProperty("other")]
        public string Other { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyProgramTerminology : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            return obj is LoyaltyProgramTerminology other &&                ((this.One == null && other.One == null) || (this.One?.Equals(other.One) == true)) &&
                ((this.Other == null && other.Other == null) || (this.Other?.Equals(other.Other) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 951751095;
            hashCode = HashCode.Combine(this.One, this.Other);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.One = {(this.One == null ? "null" : this.One)}");
            toStringOutput.Add($"this.Other = {(this.Other == null ? "null" : this.Other)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.One,
                this.Other);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string one;
            private string other;

            /// <summary>
            /// Initialize Builder for LoyaltyProgramTerminology.
            /// </summary>
            /// <param name="one"> one. </param>
            /// <param name="other"> other. </param>
            public Builder(
                string one,
                string other)
            {
                this.one = one;
                this.other = other;
            }

             /// <summary>
             /// One.
             /// </summary>
             /// <param name="one"> one. </param>
             /// <returns> Builder. </returns>
            public Builder One(string one)
            {
                this.one = one;
                return this;
            }

             /// <summary>
             /// Other.
             /// </summary>
             /// <param name="other"> other. </param>
             /// <returns> Builder. </returns>
            public Builder Other(string other)
            {
                this.other = other;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyProgramTerminology. </returns>
            public LoyaltyProgramTerminology Build()
            {
                return new LoyaltyProgramTerminology(
                    this.one,
                    this.other);
            }
        }
    }
}