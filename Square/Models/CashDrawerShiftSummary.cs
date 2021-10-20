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
    /// CashDrawerShiftSummary.
    /// </summary>
    public class CashDrawerShiftSummary
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CashDrawerShiftSummary"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="state">state.</param>
        /// <param name="openedAt">opened_at.</param>
        /// <param name="endedAt">ended_at.</param>
        /// <param name="closedAt">closed_at.</param>
        /// <param name="description">description.</param>
        /// <param name="openedCashMoney">opened_cash_money.</param>
        /// <param name="expectedCashMoney">expected_cash_money.</param>
        /// <param name="closedCashMoney">closed_cash_money.</param>
        public CashDrawerShiftSummary(
            string id = null,
            string state = null,
            string openedAt = null,
            string endedAt = null,
            string closedAt = null,
            string description = null,
            Models.Money openedCashMoney = null,
            Models.Money expectedCashMoney = null,
            Models.Money closedCashMoney = null)
        {
            this.Id = id;
            this.State = state;
            this.OpenedAt = openedAt;
            this.EndedAt = endedAt;
            this.ClosedAt = closedAt;
            this.Description = description;
            this.OpenedCashMoney = openedCashMoney;
            this.ExpectedCashMoney = expectedCashMoney;
            this.ClosedCashMoney = closedCashMoney;
        }

        /// <summary>
        /// The shift unique ID.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The current state of a cash drawer shift.
        /// </summary>
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; }

        /// <summary>
        /// The shift start time in ISO 8601 format.
        /// </summary>
        [JsonProperty("opened_at", NullValueHandling = NullValueHandling.Ignore)]
        public string OpenedAt { get; }

        /// <summary>
        /// The shift end time in ISO 8601 format.
        /// </summary>
        [JsonProperty("ended_at", NullValueHandling = NullValueHandling.Ignore)]
        public string EndedAt { get; }

        /// <summary>
        /// The shift close time in ISO 8601 format.
        /// </summary>
        [JsonProperty("closed_at", NullValueHandling = NullValueHandling.Ignore)]
        public string ClosedAt { get; }

        /// <summary>
        /// An employee free-text description of a cash drawer shift.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("opened_cash_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money OpenedCashMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("expected_cash_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money ExpectedCashMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("closed_cash_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money ClosedCashMoney { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CashDrawerShiftSummary : ({string.Join(", ", toStringOutput)})";
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

            return obj is CashDrawerShiftSummary other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.State == null && other.State == null) || (this.State?.Equals(other.State) == true)) &&
                ((this.OpenedAt == null && other.OpenedAt == null) || (this.OpenedAt?.Equals(other.OpenedAt) == true)) &&
                ((this.EndedAt == null && other.EndedAt == null) || (this.EndedAt?.Equals(other.EndedAt) == true)) &&
                ((this.ClosedAt == null && other.ClosedAt == null) || (this.ClosedAt?.Equals(other.ClosedAt) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.OpenedCashMoney == null && other.OpenedCashMoney == null) || (this.OpenedCashMoney?.Equals(other.OpenedCashMoney) == true)) &&
                ((this.ExpectedCashMoney == null && other.ExpectedCashMoney == null) || (this.ExpectedCashMoney?.Equals(other.ExpectedCashMoney) == true)) &&
                ((this.ClosedCashMoney == null && other.ClosedCashMoney == null) || (this.ClosedCashMoney?.Equals(other.ClosedCashMoney) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -323366853;
            hashCode = HashCode.Combine(this.Id, this.State, this.OpenedAt, this.EndedAt, this.ClosedAt, this.Description, this.OpenedCashMoney);

            hashCode = HashCode.Combine(hashCode, this.ExpectedCashMoney, this.ClosedCashMoney);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.State = {(this.State == null ? "null" : this.State.ToString())}");
            toStringOutput.Add($"this.OpenedAt = {(this.OpenedAt == null ? "null" : this.OpenedAt == string.Empty ? "" : this.OpenedAt)}");
            toStringOutput.Add($"this.EndedAt = {(this.EndedAt == null ? "null" : this.EndedAt == string.Empty ? "" : this.EndedAt)}");
            toStringOutput.Add($"this.ClosedAt = {(this.ClosedAt == null ? "null" : this.ClosedAt == string.Empty ? "" : this.ClosedAt)}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description == string.Empty ? "" : this.Description)}");
            toStringOutput.Add($"this.OpenedCashMoney = {(this.OpenedCashMoney == null ? "null" : this.OpenedCashMoney.ToString())}");
            toStringOutput.Add($"this.ExpectedCashMoney = {(this.ExpectedCashMoney == null ? "null" : this.ExpectedCashMoney.ToString())}");
            toStringOutput.Add($"this.ClosedCashMoney = {(this.ClosedCashMoney == null ? "null" : this.ClosedCashMoney.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .State(this.State)
                .OpenedAt(this.OpenedAt)
                .EndedAt(this.EndedAt)
                .ClosedAt(this.ClosedAt)
                .Description(this.Description)
                .OpenedCashMoney(this.OpenedCashMoney)
                .ExpectedCashMoney(this.ExpectedCashMoney)
                .ClosedCashMoney(this.ClosedCashMoney);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string id;
            private string state;
            private string openedAt;
            private string endedAt;
            private string closedAt;
            private string description;
            private Models.Money openedCashMoney;
            private Models.Money expectedCashMoney;
            private Models.Money closedCashMoney;

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
             /// OpenedAt.
             /// </summary>
             /// <param name="openedAt"> openedAt. </param>
             /// <returns> Builder. </returns>
            public Builder OpenedAt(string openedAt)
            {
                this.openedAt = openedAt;
                return this;
            }

             /// <summary>
             /// EndedAt.
             /// </summary>
             /// <param name="endedAt"> endedAt. </param>
             /// <returns> Builder. </returns>
            public Builder EndedAt(string endedAt)
            {
                this.endedAt = endedAt;
                return this;
            }

             /// <summary>
             /// ClosedAt.
             /// </summary>
             /// <param name="closedAt"> closedAt. </param>
             /// <returns> Builder. </returns>
            public Builder ClosedAt(string closedAt)
            {
                this.closedAt = closedAt;
                return this;
            }

             /// <summary>
             /// Description.
             /// </summary>
             /// <param name="description"> description. </param>
             /// <returns> Builder. </returns>
            public Builder Description(string description)
            {
                this.description = description;
                return this;
            }

             /// <summary>
             /// OpenedCashMoney.
             /// </summary>
             /// <param name="openedCashMoney"> openedCashMoney. </param>
             /// <returns> Builder. </returns>
            public Builder OpenedCashMoney(Models.Money openedCashMoney)
            {
                this.openedCashMoney = openedCashMoney;
                return this;
            }

             /// <summary>
             /// ExpectedCashMoney.
             /// </summary>
             /// <param name="expectedCashMoney"> expectedCashMoney. </param>
             /// <returns> Builder. </returns>
            public Builder ExpectedCashMoney(Models.Money expectedCashMoney)
            {
                this.expectedCashMoney = expectedCashMoney;
                return this;
            }

             /// <summary>
             /// ClosedCashMoney.
             /// </summary>
             /// <param name="closedCashMoney"> closedCashMoney. </param>
             /// <returns> Builder. </returns>
            public Builder ClosedCashMoney(Models.Money closedCashMoney)
            {
                this.closedCashMoney = closedCashMoney;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CashDrawerShiftSummary. </returns>
            public CashDrawerShiftSummary Build()
            {
                return new CashDrawerShiftSummary(
                    this.id,
                    this.state,
                    this.openedAt,
                    this.endedAt,
                    this.closedAt,
                    this.description,
                    this.openedCashMoney,
                    this.expectedCashMoney,
                    this.closedCashMoney);
            }
        }
    }
}