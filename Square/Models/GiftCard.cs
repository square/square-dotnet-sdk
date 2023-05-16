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
    /// GiftCard.
    /// </summary>
    public class GiftCard
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCard"/> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="id">id.</param>
        /// <param name="ganSource">gan_source.</param>
        /// <param name="state">state.</param>
        /// <param name="balanceMoney">balance_money.</param>
        /// <param name="gan">gan.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="customerIds">customer_ids.</param>
        public GiftCard(
            string type,
            string id = null,
            string ganSource = null,
            string state = null,
            Models.Money balanceMoney = null,
            string gan = null,
            string createdAt = null,
            IList<string> customerIds = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "gan", false }
            };

            this.Id = id;
            this.Type = type;
            this.GanSource = ganSource;
            this.State = state;
            this.BalanceMoney = balanceMoney;
            if (gan != null)
            {
                shouldSerialize["gan"] = true;
                this.Gan = gan;
            }

            this.CreatedAt = createdAt;
            this.CustomerIds = customerIds;
        }
        internal GiftCard(Dictionary<string, bool> shouldSerialize,
            string type,
            string id = null,
            string ganSource = null,
            string state = null,
            Models.Money balanceMoney = null,
            string gan = null,
            string createdAt = null,
            IList<string> customerIds = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            Type = type;
            GanSource = ganSource;
            State = state;
            BalanceMoney = balanceMoney;
            Gan = gan;
            CreatedAt = createdAt;
            CustomerIds = customerIds;
        }

        /// <summary>
        /// The Square-assigned ID of the gift card.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// Indicates the gift card type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// Indicates the source that generated the gift card
        /// account number (GAN).
        /// </summary>
        [JsonProperty("gan_source", NullValueHandling = NullValueHandling.Ignore)]
        public string GanSource { get; }

        /// <summary>
        /// Indicates the gift card state.
        /// </summary>
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("balance_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money BalanceMoney { get; }

        /// <summary>
        /// The gift card account number (GAN). Buyers can use the GAN to make purchases or check
        /// the gift card balance.
        /// </summary>
        [JsonProperty("gan")]
        public string Gan { get; }

        /// <summary>
        /// The timestamp when the gift card was created, in RFC 3339 format.
        /// In the case of a digital gift card, it is the time when you create a card
        /// (using the Square Point of Sale application, Seller Dashboard, or Gift Cards API).
        /// In the case of a plastic gift card, it is the time when Square associates the card with the
        /// seller at the time of activation.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The IDs of the [customer profiles](entity:Customer) to whom this gift card is linked.
        /// </summary>
        [JsonProperty("customer_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> CustomerIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"GiftCard : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeGan()
        {
            return this.shouldSerialize["gan"];
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
            return obj is GiftCard other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.GanSource == null && other.GanSource == null) || (this.GanSource?.Equals(other.GanSource) == true)) &&
                ((this.State == null && other.State == null) || (this.State?.Equals(other.State) == true)) &&
                ((this.BalanceMoney == null && other.BalanceMoney == null) || (this.BalanceMoney?.Equals(other.BalanceMoney) == true)) &&
                ((this.Gan == null && other.Gan == null) || (this.Gan?.Equals(other.Gan) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.CustomerIds == null && other.CustomerIds == null) || (this.CustomerIds?.Equals(other.CustomerIds) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -2027493314;
            hashCode = HashCode.Combine(this.Id, this.Type, this.GanSource, this.State, this.BalanceMoney, this.Gan, this.CreatedAt);

            hashCode = HashCode.Combine(hashCode, this.CustomerIds);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.GanSource = {(this.GanSource == null ? "null" : this.GanSource.ToString())}");
            toStringOutput.Add($"this.State = {(this.State == null ? "null" : this.State.ToString())}");
            toStringOutput.Add($"this.BalanceMoney = {(this.BalanceMoney == null ? "null" : this.BalanceMoney.ToString())}");
            toStringOutput.Add($"this.Gan = {(this.Gan == null ? "null" : this.Gan == string.Empty ? "" : this.Gan)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.CustomerIds = {(this.CustomerIds == null ? "null" : $"[{string.Join(", ", this.CustomerIds)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Type)
                .Id(this.Id)
                .GanSource(this.GanSource)
                .State(this.State)
                .BalanceMoney(this.BalanceMoney)
                .Gan(this.Gan)
                .CreatedAt(this.CreatedAt)
                .CustomerIds(this.CustomerIds);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "gan", false },
            };

            private string type;
            private string id;
            private string ganSource;
            private string state;
            private Models.Money balanceMoney;
            private string gan;
            private string createdAt;
            private IList<string> customerIds;

            public Builder(
                string type)
            {
                this.type = type;
            }

             /// <summary>
             /// Type.
             /// </summary>
             /// <param name="type"> type. </param>
             /// <returns> Builder. </returns>
            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

             /// <summary>
             /// Id.
             /// </summary>
             /// <param name="id"> id. </param>
             /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

             /// <summary>
             /// GanSource.
             /// </summary>
             /// <param name="ganSource"> ganSource. </param>
             /// <returns> Builder. </returns>
            public Builder GanSource(string ganSource)
            {
                this.ganSource = ganSource;
                return this;
            }

             /// <summary>
             /// State.
             /// </summary>
             /// <param name="state"> state. </param>
             /// <returns> Builder. </returns>
            public Builder State(string state)
            {
                this.state = state;
                return this;
            }

             /// <summary>
             /// BalanceMoney.
             /// </summary>
             /// <param name="balanceMoney"> balanceMoney. </param>
             /// <returns> Builder. </returns>
            public Builder BalanceMoney(Models.Money balanceMoney)
            {
                this.balanceMoney = balanceMoney;
                return this;
            }

             /// <summary>
             /// Gan.
             /// </summary>
             /// <param name="gan"> gan. </param>
             /// <returns> Builder. </returns>
            public Builder Gan(string gan)
            {
                shouldSerialize["gan"] = true;
                this.gan = gan;
                return this;
            }

             /// <summary>
             /// CreatedAt.
             /// </summary>
             /// <param name="createdAt"> createdAt. </param>
             /// <returns> Builder. </returns>
            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

             /// <summary>
             /// CustomerIds.
             /// </summary>
             /// <param name="customerIds"> customerIds. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerIds(IList<string> customerIds)
            {
                this.customerIds = customerIds;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetGan()
            {
                this.shouldSerialize["gan"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> GiftCard. </returns>
            public GiftCard Build()
            {
                return new GiftCard(shouldSerialize,
                    this.type,
                    this.id,
                    this.ganSource,
                    this.state,
                    this.balanceMoney,
                    this.gan,
                    this.createdAt,
                    this.customerIds);
            }
        }
    }
}