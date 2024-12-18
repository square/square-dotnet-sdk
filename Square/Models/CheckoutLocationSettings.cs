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

namespace Square.Models
{
    /// <summary>
    /// CheckoutLocationSettings.
    /// </summary>
    public class CheckoutLocationSettings
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutLocationSettings"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        /// <param name="customerNotesEnabled">customer_notes_enabled.</param>
        /// <param name="policies">policies.</param>
        /// <param name="branding">branding.</param>
        /// <param name="tipping">tipping.</param>
        /// <param name="coupons">coupons.</param>
        /// <param name="updatedAt">updated_at.</param>
        public CheckoutLocationSettings(
            string locationId = null,
            bool? customerNotesEnabled = null,
            IList<Models.CheckoutLocationSettingsPolicy> policies = null,
            Models.CheckoutLocationSettingsBranding branding = null,
            Models.CheckoutLocationSettingsTipping tipping = null,
            Models.CheckoutLocationSettingsCoupons coupons = null,
            string updatedAt = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "location_id", false },
                { "customer_notes_enabled", false },
                { "policies", false }
            };

            if (locationId != null)
            {
                shouldSerialize["location_id"] = true;
                this.LocationId = locationId;
            }

            if (customerNotesEnabled != null)
            {
                shouldSerialize["customer_notes_enabled"] = true;
                this.CustomerNotesEnabled = customerNotesEnabled;
            }

            if (policies != null)
            {
                shouldSerialize["policies"] = true;
                this.Policies = policies;
            }
            this.Branding = branding;
            this.Tipping = tipping;
            this.Coupons = coupons;
            this.UpdatedAt = updatedAt;
        }

        internal CheckoutLocationSettings(
            Dictionary<string, bool> shouldSerialize,
            string locationId = null,
            bool? customerNotesEnabled = null,
            IList<Models.CheckoutLocationSettingsPolicy> policies = null,
            Models.CheckoutLocationSettingsBranding branding = null,
            Models.CheckoutLocationSettingsTipping tipping = null,
            Models.CheckoutLocationSettingsCoupons coupons = null,
            string updatedAt = null)
        {
            this.shouldSerialize = shouldSerialize;
            LocationId = locationId;
            CustomerNotesEnabled = customerNotesEnabled;
            Policies = policies;
            Branding = branding;
            Tipping = tipping;
            Coupons = coupons;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// The ID of the location that these settings apply to.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// Indicates whether customers are allowed to leave notes at checkout.
        /// </summary>
        [JsonProperty("customer_notes_enabled")]
        public bool? CustomerNotesEnabled { get; }

        /// <summary>
        /// Policy information is displayed at the bottom of the checkout pages.
        /// You can set a maximum of two policies.
        /// </summary>
        [JsonProperty("policies")]
        public IList<Models.CheckoutLocationSettingsPolicy> Policies { get; }

        /// <summary>
        /// Gets or sets Branding.
        /// </summary>
        [JsonProperty("branding", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CheckoutLocationSettingsBranding Branding { get; }

        /// <summary>
        /// Gets or sets Tipping.
        /// </summary>
        [JsonProperty("tipping", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CheckoutLocationSettingsTipping Tipping { get; }

        /// <summary>
        /// Gets or sets Coupons.
        /// </summary>
        [JsonProperty("coupons", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CheckoutLocationSettingsCoupons Coupons { get; }

        /// <summary>
        /// The timestamp when the settings were last updated, in RFC 3339 format.
        /// Examples for January 25th, 2020 6:25:34pm Pacific Standard Time:
        /// UTC: 2020-01-26T02:25:34Z
        /// Pacific Standard Time with UTC offset: 2020-01-25T18:25:34-08:00
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CheckoutLocationSettings : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationId()
        {
            return this.shouldSerialize["location_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCustomerNotesEnabled()
        {
            return this.shouldSerialize["customer_notes_enabled"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePolicies()
        {
            return this.shouldSerialize["policies"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is CheckoutLocationSettings other &&
                (this.LocationId == null && other.LocationId == null ||
                 this.LocationId?.Equals(other.LocationId) == true) &&
                (this.CustomerNotesEnabled == null && other.CustomerNotesEnabled == null ||
                 this.CustomerNotesEnabled?.Equals(other.CustomerNotesEnabled) == true) &&
                (this.Policies == null && other.Policies == null ||
                 this.Policies?.Equals(other.Policies) == true) &&
                (this.Branding == null && other.Branding == null ||
                 this.Branding?.Equals(other.Branding) == true) &&
                (this.Tipping == null && other.Tipping == null ||
                 this.Tipping?.Equals(other.Tipping) == true) &&
                (this.Coupons == null && other.Coupons == null ||
                 this.Coupons?.Equals(other.Coupons) == true) &&
                (this.UpdatedAt == null && other.UpdatedAt == null ||
                 this.UpdatedAt?.Equals(other.UpdatedAt) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1080173946;
            hashCode = HashCode.Combine(hashCode, this.LocationId, this.CustomerNotesEnabled, this.Policies, this.Branding, this.Tipping, this.Coupons, this.UpdatedAt);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationId = {this.LocationId ?? "null"}");
            toStringOutput.Add($"this.CustomerNotesEnabled = {(this.CustomerNotesEnabled == null ? "null" : this.CustomerNotesEnabled.ToString())}");
            toStringOutput.Add($"this.Policies = {(this.Policies == null ? "null" : $"[{string.Join(", ", this.Policies)} ]")}");
            toStringOutput.Add($"this.Branding = {(this.Branding == null ? "null" : this.Branding.ToString())}");
            toStringOutput.Add($"this.Tipping = {(this.Tipping == null ? "null" : this.Tipping.ToString())}");
            toStringOutput.Add($"this.Coupons = {(this.Coupons == null ? "null" : this.Coupons.ToString())}");
            toStringOutput.Add($"this.UpdatedAt = {this.UpdatedAt ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .LocationId(this.LocationId)
                .CustomerNotesEnabled(this.CustomerNotesEnabled)
                .Policies(this.Policies)
                .Branding(this.Branding)
                .Tipping(this.Tipping)
                .Coupons(this.Coupons)
                .UpdatedAt(this.UpdatedAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "location_id", false },
                { "customer_notes_enabled", false },
                { "policies", false },
            };

            private string locationId;
            private bool? customerNotesEnabled;
            private IList<Models.CheckoutLocationSettingsPolicy> policies;
            private Models.CheckoutLocationSettingsBranding branding;
            private Models.CheckoutLocationSettingsTipping tipping;
            private Models.CheckoutLocationSettingsCoupons coupons;
            private string updatedAt;

             /// <summary>
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                shouldSerialize["location_id"] = true;
                this.locationId = locationId;
                return this;
            }

             /// <summary>
             /// CustomerNotesEnabled.
             /// </summary>
             /// <param name="customerNotesEnabled"> customerNotesEnabled. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerNotesEnabled(bool? customerNotesEnabled)
            {
                shouldSerialize["customer_notes_enabled"] = true;
                this.customerNotesEnabled = customerNotesEnabled;
                return this;
            }

             /// <summary>
             /// Policies.
             /// </summary>
             /// <param name="policies"> policies. </param>
             /// <returns> Builder. </returns>
            public Builder Policies(IList<Models.CheckoutLocationSettingsPolicy> policies)
            {
                shouldSerialize["policies"] = true;
                this.policies = policies;
                return this;
            }

             /// <summary>
             /// Branding.
             /// </summary>
             /// <param name="branding"> branding. </param>
             /// <returns> Builder. </returns>
            public Builder Branding(Models.CheckoutLocationSettingsBranding branding)
            {
                this.branding = branding;
                return this;
            }

             /// <summary>
             /// Tipping.
             /// </summary>
             /// <param name="tipping"> tipping. </param>
             /// <returns> Builder. </returns>
            public Builder Tipping(Models.CheckoutLocationSettingsTipping tipping)
            {
                this.tipping = tipping;
                return this;
            }

             /// <summary>
             /// Coupons.
             /// </summary>
             /// <param name="coupons"> coupons. </param>
             /// <returns> Builder. </returns>
            public Builder Coupons(Models.CheckoutLocationSettingsCoupons coupons)
            {
                this.coupons = coupons;
                return this;
            }

             /// <summary>
             /// UpdatedAt.
             /// </summary>
             /// <param name="updatedAt"> updatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetLocationId()
            {
                this.shouldSerialize["location_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetCustomerNotesEnabled()
            {
                this.shouldSerialize["customer_notes_enabled"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetPolicies()
            {
                this.shouldSerialize["policies"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CheckoutLocationSettings. </returns>
            public CheckoutLocationSettings Build()
            {
                return new CheckoutLocationSettings(
                    shouldSerialize,
                    this.locationId,
                    this.customerNotesEnabled,
                    this.policies,
                    this.branding,
                    this.tipping,
                    this.coupons,
                    this.updatedAt);
            }
        }
    }
}