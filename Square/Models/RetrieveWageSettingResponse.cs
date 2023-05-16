namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// RetrieveWageSettingResponse.
    /// </summary>
    public class RetrieveWageSettingResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveWageSettingResponse"/> class.
        /// </summary>
        /// <param name="wageSetting">wage_setting.</param>
        /// <param name="errors">errors.</param>
        public RetrieveWageSettingResponse(
            Models.WageSetting wageSetting = null,
            IList<Models.Error> errors = null)
        {
            this.WageSetting = wageSetting;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// An object representing a team member's wage information.
        /// </summary>
        [JsonProperty("wage_setting", NullValueHandling = NullValueHandling.Ignore)]
        public Models.WageSetting WageSetting { get; }

        /// <summary>
        /// The errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RetrieveWageSettingResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is RetrieveWageSettingResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.WageSetting == null && other.WageSetting == null) || (this.WageSetting?.Equals(other.WageSetting) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -635387084;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.WageSetting, this.Errors);

            return hashCode;
        }
        internal RetrieveWageSettingResponse ContextSetter(HttpContext context)
        {
            this.Context = context;
            return this;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.WageSetting = {(this.WageSetting == null ? "null" : this.WageSetting.ToString())}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .WageSetting(this.WageSetting)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.WageSetting wageSetting;
            private IList<Models.Error> errors;

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
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> RetrieveWageSettingResponse. </returns>
            public RetrieveWageSettingResponse Build()
            {
                return new RetrieveWageSettingResponse(
                    this.wageSetting,
                    this.errors);
            }
        }
    }
}