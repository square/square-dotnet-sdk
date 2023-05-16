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
    using Square.Utilities;

    /// <summary>
    /// BusinessHours.
    /// </summary>
    public class BusinessHours
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessHours"/> class.
        /// </summary>
        /// <param name="periods">periods.</param>
        public BusinessHours(
            IList<Models.BusinessHoursPeriod> periods = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "periods", false }
            };

            if (periods != null)
            {
                shouldSerialize["periods"] = true;
                this.Periods = periods;
            }

        }
        internal BusinessHours(Dictionary<string, bool> shouldSerialize,
            IList<Models.BusinessHoursPeriod> periods = null)
        {
            this.shouldSerialize = shouldSerialize;
            Periods = periods;
        }

        /// <summary>
        /// The list of time periods during which the business is open. There can be at most 10 periods per day.
        /// </summary>
        [JsonProperty("periods")]
        public IList<Models.BusinessHoursPeriod> Periods { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BusinessHours : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePeriods()
        {
            return this.shouldSerialize["periods"];
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
            return obj is BusinessHours other &&                ((this.Periods == null && other.Periods == null) || (this.Periods?.Equals(other.Periods) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1271827402;
            hashCode = HashCode.Combine(this.Periods);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Periods = {(this.Periods == null ? "null" : $"[{string.Join(", ", this.Periods)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Periods(this.Periods);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "periods", false },
            };

            private IList<Models.BusinessHoursPeriod> periods;

             /// <summary>
             /// Periods.
             /// </summary>
             /// <param name="periods"> periods. </param>
             /// <returns> Builder. </returns>
            public Builder Periods(IList<Models.BusinessHoursPeriod> periods)
            {
                shouldSerialize["periods"] = true;
                this.periods = periods;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPeriods()
            {
                this.shouldSerialize["periods"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BusinessHours. </returns>
            public BusinessHours Build()
            {
                return new BusinessHours(shouldSerialize,
                    this.periods);
            }
        }
    }
}