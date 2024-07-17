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
    /// CashDrawerShift.
    /// </summary>
    public class CashDrawerShift
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CashDrawerShift"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="state">state.</param>
        /// <param name="openedAt">opened_at.</param>
        /// <param name="endedAt">ended_at.</param>
        /// <param name="closedAt">closed_at.</param>
        /// <param name="description">description.</param>
        /// <param name="openedCashMoney">opened_cash_money.</param>
        /// <param name="cashPaymentMoney">cash_payment_money.</param>
        /// <param name="cashRefundsMoney">cash_refunds_money.</param>
        /// <param name="cashPaidInMoney">cash_paid_in_money.</param>
        /// <param name="cashPaidOutMoney">cash_paid_out_money.</param>
        /// <param name="expectedCashMoney">expected_cash_money.</param>
        /// <param name="closedCashMoney">closed_cash_money.</param>
        /// <param name="device">device.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="teamMemberIds">team_member_ids.</param>
        /// <param name="openingTeamMemberId">opening_team_member_id.</param>
        /// <param name="endingTeamMemberId">ending_team_member_id.</param>
        /// <param name="closingTeamMemberId">closing_team_member_id.</param>
        public CashDrawerShift(
            string id = null,
            string state = null,
            string openedAt = null,
            string endedAt = null,
            string closedAt = null,
            string description = null,
            Models.Money openedCashMoney = null,
            Models.Money cashPaymentMoney = null,
            Models.Money cashRefundsMoney = null,
            Models.Money cashPaidInMoney = null,
            Models.Money cashPaidOutMoney = null,
            Models.Money expectedCashMoney = null,
            Models.Money closedCashMoney = null,
            Models.CashDrawerDevice device = null,
            string createdAt = null,
            string updatedAt = null,
            string locationId = null,
            IList<string> teamMemberIds = null,
            string openingTeamMemberId = null,
            string endingTeamMemberId = null,
            string closingTeamMemberId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "opened_at", false },
                { "ended_at", false },
                { "closed_at", false },
                { "description", false }
            };

            this.Id = id;
            this.State = state;
            if (openedAt != null)
            {
                shouldSerialize["opened_at"] = true;
                this.OpenedAt = openedAt;
            }

            if (endedAt != null)
            {
                shouldSerialize["ended_at"] = true;
                this.EndedAt = endedAt;
            }

            if (closedAt != null)
            {
                shouldSerialize["closed_at"] = true;
                this.ClosedAt = closedAt;
            }

            if (description != null)
            {
                shouldSerialize["description"] = true;
                this.Description = description;
            }

            this.OpenedCashMoney = openedCashMoney;
            this.CashPaymentMoney = cashPaymentMoney;
            this.CashRefundsMoney = cashRefundsMoney;
            this.CashPaidInMoney = cashPaidInMoney;
            this.CashPaidOutMoney = cashPaidOutMoney;
            this.ExpectedCashMoney = expectedCashMoney;
            this.ClosedCashMoney = closedCashMoney;
            this.Device = device;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.LocationId = locationId;
            this.TeamMemberIds = teamMemberIds;
            this.OpeningTeamMemberId = openingTeamMemberId;
            this.EndingTeamMemberId = endingTeamMemberId;
            this.ClosingTeamMemberId = closingTeamMemberId;
        }
        internal CashDrawerShift(Dictionary<string, bool> shouldSerialize,
            string id = null,
            string state = null,
            string openedAt = null,
            string endedAt = null,
            string closedAt = null,
            string description = null,
            Models.Money openedCashMoney = null,
            Models.Money cashPaymentMoney = null,
            Models.Money cashRefundsMoney = null,
            Models.Money cashPaidInMoney = null,
            Models.Money cashPaidOutMoney = null,
            Models.Money expectedCashMoney = null,
            Models.Money closedCashMoney = null,
            Models.CashDrawerDevice device = null,
            string createdAt = null,
            string updatedAt = null,
            string locationId = null,
            IList<string> teamMemberIds = null,
            string openingTeamMemberId = null,
            string endingTeamMemberId = null,
            string closingTeamMemberId = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            State = state;
            OpenedAt = openedAt;
            EndedAt = endedAt;
            ClosedAt = closedAt;
            Description = description;
            OpenedCashMoney = openedCashMoney;
            CashPaymentMoney = cashPaymentMoney;
            CashRefundsMoney = cashRefundsMoney;
            CashPaidInMoney = cashPaidInMoney;
            CashPaidOutMoney = cashPaidOutMoney;
            ExpectedCashMoney = expectedCashMoney;
            ClosedCashMoney = closedCashMoney;
            Device = device;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            LocationId = locationId;
            TeamMemberIds = teamMemberIds;
            OpeningTeamMemberId = openingTeamMemberId;
            EndingTeamMemberId = endingTeamMemberId;
            ClosingTeamMemberId = closingTeamMemberId;
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
        /// The time when the shift began, in ISO 8601 format.
        /// </summary>
        [JsonProperty("opened_at")]
        public string OpenedAt { get; }

        /// <summary>
        /// The time when the shift ended, in ISO 8601 format.
        /// </summary>
        [JsonProperty("ended_at")]
        public string EndedAt { get; }

        /// <summary>
        /// The time when the shift was closed, in ISO 8601 format.
        /// </summary>
        [JsonProperty("closed_at")]
        public string ClosedAt { get; }

        /// <summary>
        /// The free-form text description of a cash drawer by an employee.
        /// </summary>
        [JsonProperty("description")]
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
        [JsonProperty("cash_payment_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money CashPaymentMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("cash_refunds_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money CashRefundsMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("cash_paid_in_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money CashPaidInMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("cash_paid_out_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money CashPaidOutMoney { get; }

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

        /// <summary>
        /// Gets or sets Device.
        /// </summary>
        [JsonProperty("device", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CashDrawerDevice Device { get; }

        /// <summary>
        /// The shift start time in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The shift updated at time in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// The ID of the location the cash drawer shift belongs to.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// The IDs of all team members that were logged into Square Point of Sale at any
        /// point while the cash drawer shift was open.
        /// </summary>
        [JsonProperty("team_member_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> TeamMemberIds { get; }

        /// <summary>
        /// The ID of the team member that started the cash drawer shift.
        /// </summary>
        [JsonProperty("opening_team_member_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OpeningTeamMemberId { get; }

        /// <summary>
        /// The ID of the team member that ended the cash drawer shift.
        /// </summary>
        [JsonProperty("ending_team_member_id", NullValueHandling = NullValueHandling.Ignore)]
        public string EndingTeamMemberId { get; }

        /// <summary>
        /// The ID of the team member that closed the cash drawer shift by auditing
        /// the cash drawer contents.
        /// </summary>
        [JsonProperty("closing_team_member_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ClosingTeamMemberId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CashDrawerShift : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOpenedAt()
        {
            return this.shouldSerialize["opened_at"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEndedAt()
        {
            return this.shouldSerialize["ended_at"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeClosedAt()
        {
            return this.shouldSerialize["closed_at"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDescription()
        {
            return this.shouldSerialize["description"];
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
            return obj is CashDrawerShift other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.State == null && other.State == null) || (this.State?.Equals(other.State) == true)) &&
                ((this.OpenedAt == null && other.OpenedAt == null) || (this.OpenedAt?.Equals(other.OpenedAt) == true)) &&
                ((this.EndedAt == null && other.EndedAt == null) || (this.EndedAt?.Equals(other.EndedAt) == true)) &&
                ((this.ClosedAt == null && other.ClosedAt == null) || (this.ClosedAt?.Equals(other.ClosedAt) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.OpenedCashMoney == null && other.OpenedCashMoney == null) || (this.OpenedCashMoney?.Equals(other.OpenedCashMoney) == true)) &&
                ((this.CashPaymentMoney == null && other.CashPaymentMoney == null) || (this.CashPaymentMoney?.Equals(other.CashPaymentMoney) == true)) &&
                ((this.CashRefundsMoney == null && other.CashRefundsMoney == null) || (this.CashRefundsMoney?.Equals(other.CashRefundsMoney) == true)) &&
                ((this.CashPaidInMoney == null && other.CashPaidInMoney == null) || (this.CashPaidInMoney?.Equals(other.CashPaidInMoney) == true)) &&
                ((this.CashPaidOutMoney == null && other.CashPaidOutMoney == null) || (this.CashPaidOutMoney?.Equals(other.CashPaidOutMoney) == true)) &&
                ((this.ExpectedCashMoney == null && other.ExpectedCashMoney == null) || (this.ExpectedCashMoney?.Equals(other.ExpectedCashMoney) == true)) &&
                ((this.ClosedCashMoney == null && other.ClosedCashMoney == null) || (this.ClosedCashMoney?.Equals(other.ClosedCashMoney) == true)) &&
                ((this.Device == null && other.Device == null) || (this.Device?.Equals(other.Device) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.TeamMemberIds == null && other.TeamMemberIds == null) || (this.TeamMemberIds?.Equals(other.TeamMemberIds) == true)) &&
                ((this.OpeningTeamMemberId == null && other.OpeningTeamMemberId == null) || (this.OpeningTeamMemberId?.Equals(other.OpeningTeamMemberId) == true)) &&
                ((this.EndingTeamMemberId == null && other.EndingTeamMemberId == null) || (this.EndingTeamMemberId?.Equals(other.EndingTeamMemberId) == true)) &&
                ((this.ClosingTeamMemberId == null && other.ClosingTeamMemberId == null) || (this.ClosingTeamMemberId?.Equals(other.ClosingTeamMemberId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1388764759;
            hashCode = HashCode.Combine(this.Id, this.State, this.OpenedAt, this.EndedAt, this.ClosedAt, this.Description, this.OpenedCashMoney);

            hashCode = HashCode.Combine(hashCode, this.CashPaymentMoney, this.CashRefundsMoney, this.CashPaidInMoney, this.CashPaidOutMoney, this.ExpectedCashMoney, this.ClosedCashMoney, this.Device);

            hashCode = HashCode.Combine(hashCode, this.CreatedAt, this.UpdatedAt, this.LocationId, this.TeamMemberIds, this.OpeningTeamMemberId, this.EndingTeamMemberId, this.ClosingTeamMemberId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.State = {(this.State == null ? "null" : this.State.ToString())}");
            toStringOutput.Add($"this.OpenedAt = {(this.OpenedAt == null ? "null" : this.OpenedAt)}");
            toStringOutput.Add($"this.EndedAt = {(this.EndedAt == null ? "null" : this.EndedAt)}");
            toStringOutput.Add($"this.ClosedAt = {(this.ClosedAt == null ? "null" : this.ClosedAt)}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description)}");
            toStringOutput.Add($"this.OpenedCashMoney = {(this.OpenedCashMoney == null ? "null" : this.OpenedCashMoney.ToString())}");
            toStringOutput.Add($"this.CashPaymentMoney = {(this.CashPaymentMoney == null ? "null" : this.CashPaymentMoney.ToString())}");
            toStringOutput.Add($"this.CashRefundsMoney = {(this.CashRefundsMoney == null ? "null" : this.CashRefundsMoney.ToString())}");
            toStringOutput.Add($"this.CashPaidInMoney = {(this.CashPaidInMoney == null ? "null" : this.CashPaidInMoney.ToString())}");
            toStringOutput.Add($"this.CashPaidOutMoney = {(this.CashPaidOutMoney == null ? "null" : this.CashPaidOutMoney.ToString())}");
            toStringOutput.Add($"this.ExpectedCashMoney = {(this.ExpectedCashMoney == null ? "null" : this.ExpectedCashMoney.ToString())}");
            toStringOutput.Add($"this.ClosedCashMoney = {(this.ClosedCashMoney == null ? "null" : this.ClosedCashMoney.ToString())}");
            toStringOutput.Add($"this.Device = {(this.Device == null ? "null" : this.Device.ToString())}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.TeamMemberIds = {(this.TeamMemberIds == null ? "null" : $"[{string.Join(", ", this.TeamMemberIds)} ]")}");
            toStringOutput.Add($"this.OpeningTeamMemberId = {(this.OpeningTeamMemberId == null ? "null" : this.OpeningTeamMemberId)}");
            toStringOutput.Add($"this.EndingTeamMemberId = {(this.EndingTeamMemberId == null ? "null" : this.EndingTeamMemberId)}");
            toStringOutput.Add($"this.ClosingTeamMemberId = {(this.ClosingTeamMemberId == null ? "null" : this.ClosingTeamMemberId)}");
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
                .CashPaymentMoney(this.CashPaymentMoney)
                .CashRefundsMoney(this.CashRefundsMoney)
                .CashPaidInMoney(this.CashPaidInMoney)
                .CashPaidOutMoney(this.CashPaidOutMoney)
                .ExpectedCashMoney(this.ExpectedCashMoney)
                .ClosedCashMoney(this.ClosedCashMoney)
                .Device(this.Device)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt)
                .LocationId(this.LocationId)
                .TeamMemberIds(this.TeamMemberIds)
                .OpeningTeamMemberId(this.OpeningTeamMemberId)
                .EndingTeamMemberId(this.EndingTeamMemberId)
                .ClosingTeamMemberId(this.ClosingTeamMemberId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "opened_at", false },
                { "ended_at", false },
                { "closed_at", false },
                { "description", false },
            };

            private string id;
            private string state;
            private string openedAt;
            private string endedAt;
            private string closedAt;
            private string description;
            private Models.Money openedCashMoney;
            private Models.Money cashPaymentMoney;
            private Models.Money cashRefundsMoney;
            private Models.Money cashPaidInMoney;
            private Models.Money cashPaidOutMoney;
            private Models.Money expectedCashMoney;
            private Models.Money closedCashMoney;
            private Models.CashDrawerDevice device;
            private string createdAt;
            private string updatedAt;
            private string locationId;
            private IList<string> teamMemberIds;
            private string openingTeamMemberId;
            private string endingTeamMemberId;
            private string closingTeamMemberId;

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
                shouldSerialize["opened_at"] = true;
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
                shouldSerialize["ended_at"] = true;
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
                shouldSerialize["closed_at"] = true;
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
                shouldSerialize["description"] = true;
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
             /// CashPaymentMoney.
             /// </summary>
             /// <param name="cashPaymentMoney"> cashPaymentMoney. </param>
             /// <returns> Builder. </returns>
            public Builder CashPaymentMoney(Models.Money cashPaymentMoney)
            {
                this.cashPaymentMoney = cashPaymentMoney;
                return this;
            }

             /// <summary>
             /// CashRefundsMoney.
             /// </summary>
             /// <param name="cashRefundsMoney"> cashRefundsMoney. </param>
             /// <returns> Builder. </returns>
            public Builder CashRefundsMoney(Models.Money cashRefundsMoney)
            {
                this.cashRefundsMoney = cashRefundsMoney;
                return this;
            }

             /// <summary>
             /// CashPaidInMoney.
             /// </summary>
             /// <param name="cashPaidInMoney"> cashPaidInMoney. </param>
             /// <returns> Builder. </returns>
            public Builder CashPaidInMoney(Models.Money cashPaidInMoney)
            {
                this.cashPaidInMoney = cashPaidInMoney;
                return this;
            }

             /// <summary>
             /// CashPaidOutMoney.
             /// </summary>
             /// <param name="cashPaidOutMoney"> cashPaidOutMoney. </param>
             /// <returns> Builder. </returns>
            public Builder CashPaidOutMoney(Models.Money cashPaidOutMoney)
            {
                this.cashPaidOutMoney = cashPaidOutMoney;
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
             /// Device.
             /// </summary>
             /// <param name="device"> device. </param>
             /// <returns> Builder. </returns>
            public Builder Device(Models.CashDrawerDevice device)
            {
                this.device = device;
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
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

             /// <summary>
             /// TeamMemberIds.
             /// </summary>
             /// <param name="teamMemberIds"> teamMemberIds. </param>
             /// <returns> Builder. </returns>
            public Builder TeamMemberIds(IList<string> teamMemberIds)
            {
                this.teamMemberIds = teamMemberIds;
                return this;
            }

             /// <summary>
             /// OpeningTeamMemberId.
             /// </summary>
             /// <param name="openingTeamMemberId"> openingTeamMemberId. </param>
             /// <returns> Builder. </returns>
            public Builder OpeningTeamMemberId(string openingTeamMemberId)
            {
                this.openingTeamMemberId = openingTeamMemberId;
                return this;
            }

             /// <summary>
             /// EndingTeamMemberId.
             /// </summary>
             /// <param name="endingTeamMemberId"> endingTeamMemberId. </param>
             /// <returns> Builder. </returns>
            public Builder EndingTeamMemberId(string endingTeamMemberId)
            {
                this.endingTeamMemberId = endingTeamMemberId;
                return this;
            }

             /// <summary>
             /// ClosingTeamMemberId.
             /// </summary>
             /// <param name="closingTeamMemberId"> closingTeamMemberId. </param>
             /// <returns> Builder. </returns>
            public Builder ClosingTeamMemberId(string closingTeamMemberId)
            {
                this.closingTeamMemberId = closingTeamMemberId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetOpenedAt()
            {
                this.shouldSerialize["opened_at"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEndedAt()
            {
                this.shouldSerialize["ended_at"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetClosedAt()
            {
                this.shouldSerialize["closed_at"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDescription()
            {
                this.shouldSerialize["description"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CashDrawerShift. </returns>
            public CashDrawerShift Build()
            {
                return new CashDrawerShift(shouldSerialize,
                    this.id,
                    this.state,
                    this.openedAt,
                    this.endedAt,
                    this.closedAt,
                    this.description,
                    this.openedCashMoney,
                    this.cashPaymentMoney,
                    this.cashRefundsMoney,
                    this.cashPaidInMoney,
                    this.cashPaidOutMoney,
                    this.expectedCashMoney,
                    this.closedCashMoney,
                    this.device,
                    this.createdAt,
                    this.updatedAt,
                    this.locationId,
                    this.teamMemberIds,
                    this.openingTeamMemberId,
                    this.endingTeamMemberId,
                    this.closingTeamMemberId);
            }
        }
    }
}