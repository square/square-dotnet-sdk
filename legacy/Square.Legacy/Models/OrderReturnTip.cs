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
    /// OrderReturnTip.
    /// </summary>
    public class OrderReturnTip
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderReturnTip"/> class.
        /// </summary>
        /// <param name="uid">uid.</param>
        /// <param name="appliedMoney">applied_money.</param>
        /// <param name="sourceTenderUid">source_tender_uid.</param>
        /// <param name="sourceTenderId">source_tender_id.</param>
        public OrderReturnTip(
            string uid = null,
            Models.Money appliedMoney = null,
            string sourceTenderUid = null,
            string sourceTenderId = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
                { "source_tender_uid", false },
                { "source_tender_id", false },
            };

            if (uid != null)
            {
                shouldSerialize["uid"] = true;
                this.Uid = uid;
            }
            this.AppliedMoney = appliedMoney;

            if (sourceTenderUid != null)
            {
                shouldSerialize["source_tender_uid"] = true;
                this.SourceTenderUid = sourceTenderUid;
            }

            if (sourceTenderId != null)
            {
                shouldSerialize["source_tender_id"] = true;
                this.SourceTenderId = sourceTenderId;
            }
        }

        internal OrderReturnTip(
            Dictionary<string, bool> shouldSerialize,
            string uid = null,
            Models.Money appliedMoney = null,
            string sourceTenderUid = null,
            string sourceTenderId = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            Uid = uid;
            AppliedMoney = appliedMoney;
            SourceTenderUid = sourceTenderUid;
            SourceTenderId = sourceTenderId;
        }

        /// <summary>
        /// A unique ID that identifies the tip only within this order.
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("applied_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money AppliedMoney { get; }

        /// <summary>
        /// The tender `uid` from the order that contains the original application of this tip.
        /// </summary>
        [JsonProperty("source_tender_uid")]
        public string SourceTenderUid { get; }

        /// <summary>
        /// The tender `id` from the order that contains the original application of this tip.
        /// </summary>
        [JsonProperty("source_tender_id")]
        public string SourceTenderId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"OrderReturnTip : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUid()
        {
            return this.shouldSerialize["uid"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSourceTenderUid()
        {
            return this.shouldSerialize["source_tender_uid"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSourceTenderId()
        {
            return this.shouldSerialize["source_tender_id"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is OrderReturnTip other
                && (this.Uid == null && other.Uid == null || this.Uid?.Equals(other.Uid) == true)
                && (
                    this.AppliedMoney == null && other.AppliedMoney == null
                    || this.AppliedMoney?.Equals(other.AppliedMoney) == true
                )
                && (
                    this.SourceTenderUid == null && other.SourceTenderUid == null
                    || this.SourceTenderUid?.Equals(other.SourceTenderUid) == true
                )
                && (
                    this.SourceTenderId == null && other.SourceTenderId == null
                    || this.SourceTenderId?.Equals(other.SourceTenderId) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1771795951;
            hashCode = HashCode.Combine(
                hashCode,
                this.Uid,
                this.AppliedMoney,
                this.SourceTenderUid,
                this.SourceTenderId
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Uid = {this.Uid ?? "null"}");
            toStringOutput.Add(
                $"this.AppliedMoney = {(this.AppliedMoney == null ? "null" : this.AppliedMoney.ToString())}"
            );
            toStringOutput.Add($"this.SourceTenderUid = {this.SourceTenderUid ?? "null"}");
            toStringOutput.Add($"this.SourceTenderId = {this.SourceTenderId ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Uid(this.Uid)
                .AppliedMoney(this.AppliedMoney)
                .SourceTenderUid(this.SourceTenderUid)
                .SourceTenderId(this.SourceTenderId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
                { "source_tender_uid", false },
                { "source_tender_id", false },
            };

            private string uid;
            private Models.Money appliedMoney;
            private string sourceTenderUid;
            private string sourceTenderId;

            /// <summary>
            /// Uid.
            /// </summary>
            /// <param name="uid"> uid. </param>
            /// <returns> Builder. </returns>
            public Builder Uid(string uid)
            {
                shouldSerialize["uid"] = true;
                this.uid = uid;
                return this;
            }

            /// <summary>
            /// AppliedMoney.
            /// </summary>
            /// <param name="appliedMoney"> appliedMoney. </param>
            /// <returns> Builder. </returns>
            public Builder AppliedMoney(Models.Money appliedMoney)
            {
                this.appliedMoney = appliedMoney;
                return this;
            }

            /// <summary>
            /// SourceTenderUid.
            /// </summary>
            /// <param name="sourceTenderUid"> sourceTenderUid. </param>
            /// <returns> Builder. </returns>
            public Builder SourceTenderUid(string sourceTenderUid)
            {
                shouldSerialize["source_tender_uid"] = true;
                this.sourceTenderUid = sourceTenderUid;
                return this;
            }

            /// <summary>
            /// SourceTenderId.
            /// </summary>
            /// <param name="sourceTenderId"> sourceTenderId. </param>
            /// <returns> Builder. </returns>
            public Builder SourceTenderId(string sourceTenderId)
            {
                shouldSerialize["source_tender_id"] = true;
                this.sourceTenderId = sourceTenderId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetUid()
            {
                this.shouldSerialize["uid"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetSourceTenderUid()
            {
                this.shouldSerialize["source_tender_uid"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetSourceTenderId()
            {
                this.shouldSerialize["source_tender_id"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderReturnTip. </returns>
            public OrderReturnTip Build()
            {
                return new OrderReturnTip(
                    shouldSerialize,
                    this.uid,
                    this.appliedMoney,
                    this.sourceTenderUid,
                    this.sourceTenderId
                );
            }
        }
    }
}
