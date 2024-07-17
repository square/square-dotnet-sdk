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
    /// UpdateWageSettingRequest.
    /// </summary>
    public class UpdateWageSettingRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWageSettingRequest"/> class.
        /// </summary>
        /// <param name="wageSetting">wage_setting.</param>
        public UpdateWageSettingRequest(
            Models.WageSetting wageSetting)
        {
            this.WageSetting = wageSetting;
        }

        /// <summary>
        /// An object representing a team member's wage information.
        /// </summary>
        [JsonProperty("wage_setting")]
        public Models.WageSetting WageSetting { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateWageSettingRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is UpdateWageSettingRequest other &&                ((this.WageSetting == null && other.WageSetting == null) || (this.WageSetting?.Equals(other.WageSetting) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 316748925;
            hashCode = HashCode.Combine(this.WageSetting);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.WageSetting = {(this.WageSetting == null ? "null" : this.WageSetting.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.WageSetting);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.WageSetting wageSetting;

            /// <summary>
            /// Initialize Builder for UpdateWageSettingRequest.
            /// </summary>
            /// <param name="wageSetting"> wageSetting. </param>
            public Builder(
                Models.WageSetting wageSetting)
            {
                this.wageSetting = wageSetting;
            }

             /// <summary>
             /// WageSetting.
             /// </summary>
             /// <param name="wageSetting"> wageSetting. </param>
             /// <returns> Builder. </returns>
            public Builder WageSetting(Models.WageSetting wageSetting)
            {
                this.wageSetting = wageSetting;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> UpdateWageSettingRequest. </returns>
            public UpdateWageSettingRequest Build()
            {
                return new UpdateWageSettingRequest(
                    this.wageSetting);
            }
        }
    }
}