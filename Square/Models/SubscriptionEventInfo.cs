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
    /// SubscriptionEventInfo.
    /// </summary>
    public class SubscriptionEventInfo
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionEventInfo"/> class.
        /// </summary>
        /// <param name="detail">detail.</param>
        /// <param name="code">code.</param>
        public SubscriptionEventInfo(
            string detail = null,
            string code = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "detail", false }
            };

            if (detail != null)
            {
                shouldSerialize["detail"] = true;
                this.Detail = detail;
            }

            this.Code = code;
        }
        internal SubscriptionEventInfo(Dictionary<string, bool> shouldSerialize,
            string detail = null,
            string code = null)
        {
            this.shouldSerialize = shouldSerialize;
            Detail = detail;
            Code = code;
        }

        /// <summary>
        /// A human-readable explanation for the event.
        /// </summary>
        [JsonProperty("detail")]
        public string Detail { get; }

        /// <summary>
        /// Supported info codes of a subscription event.
        /// </summary>
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SubscriptionEventInfo : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDetail()
        {
            return this.shouldSerialize["detail"];
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
            return obj is SubscriptionEventInfo other &&                ((this.Detail == null && other.Detail == null) || (this.Detail?.Equals(other.Detail) == true)) &&
                ((this.Code == null && other.Code == null) || (this.Code?.Equals(other.Code) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -150881047;
            hashCode = HashCode.Combine(this.Detail, this.Code);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Detail = {(this.Detail == null ? "null" : this.Detail)}");
            toStringOutput.Add($"this.Code = {(this.Code == null ? "null" : this.Code.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Detail(this.Detail)
                .Code(this.Code);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "detail", false },
            };

            private string detail;
            private string code;

             /// <summary>
             /// Detail.
             /// </summary>
             /// <param name="detail"> detail. </param>
             /// <returns> Builder. </returns>
            public Builder Detail(string detail)
            {
                shouldSerialize["detail"] = true;
                this.detail = detail;
                return this;
            }

             /// <summary>
             /// Code.
             /// </summary>
             /// <param name="code"> code. </param>
             /// <returns> Builder. </returns>
            public Builder Code(string code)
            {
                this.code = code;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDetail()
            {
                this.shouldSerialize["detail"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SubscriptionEventInfo. </returns>
            public SubscriptionEventInfo Build()
            {
                return new SubscriptionEventInfo(shouldSerialize,
                    this.detail,
                    this.code);
            }
        }
    }
}