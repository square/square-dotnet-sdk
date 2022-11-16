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
        /// <param name="employeeIds">employee_ids.</param>
        /// <param name="openingEmployeeId">opening_employee_id.</param>
        /// <param name="endingEmployeeId">ending_employee_id.</param>
        /// <param name="closingEmployeeId">closing_employee_id.</param>
        /// <param name="description">description.</param>
        /// <param name="openedCashMoney">opened_cash_money.</param>
        /// <param name="cashPaymentMoney">cash_payment_money.</param>
        /// <param name="cashRefundsMoney">cash_refunds_money.</param>
        /// <param name="cashPaidInMoney">cash_paid_in_money.</param>
        /// <param name="cashPaidOutMoney">cash_paid_out_money.</param>
        /// <param name="expectedCashMoney">expected_cash_money.</param>
        /// <param name="closedCashMoney">closed_cash_money.</param>
        /// <param name="device">device.</param>
        public CashDrawerShift(
            string id = null,
            string state = null,
            string openedAt = null,
            string endedAt = null,
            string closedAt = null,
            IList<string> employeeIds = null,
            string openingEmployeeId = null,
            string endingEmployeeId = null,
            string closingEmployeeId = null,
            string description = null,
            Models.Money openedCashMoney = null,
            Models.Money cashPaymentMoney = null,
            Models.Money cashRefundsMoney = null,
            Models.Money cashPaidInMoney = null,
            Models.Money cashPaidOutMoney = null,
            Models.Money expectedCashMoney = null,
            Models.Money closedCashMoney = null,
            Models.CashDrawerDevice device = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "opened_at", false },
                { "ended_at", false },
                { "closed_at", false },
                { "employee_ids", false },
                { "opening_employee_id", false },
                { "ending_employee_id", false },
                { "closing_employee_id", false },
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

            if (employeeIds != null)
            {
                shouldSerialize["employee_ids"] = true;
                this.EmployeeIds = employeeIds;
            }

            if (openingEmployeeId != null)
            {
                shouldSerialize["opening_employee_id"] = true;
                this.OpeningEmployeeId = openingEmployeeId;
            }

            if (endingEmployeeId != null)
            {
                shouldSerialize["ending_employee_id"] = true;
                this.EndingEmployeeId = endingEmployeeId;
            }

            if (closingEmployeeId != null)
            {
                shouldSerialize["closing_employee_id"] = true;
                this.ClosingEmployeeId = closingEmployeeId;
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
        }
        internal CashDrawerShift(Dictionary<string, bool> shouldSerialize,
            string id = null,
            string state = null,
            string openedAt = null,
            string endedAt = null,
            string closedAt = null,
            IList<string> employeeIds = null,
            string openingEmployeeId = null,
            string endingEmployeeId = null,
            string closingEmployeeId = null,
            string description = null,
            Models.Money openedCashMoney = null,
            Models.Money cashPaymentMoney = null,
            Models.Money cashRefundsMoney = null,
            Models.Money cashPaidInMoney = null,
            Models.Money cashPaidOutMoney = null,
            Models.Money expectedCashMoney = null,
            Models.Money closedCashMoney = null,
            Models.CashDrawerDevice device = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            State = state;
            OpenedAt = openedAt;
            EndedAt = endedAt;
            ClosedAt = closedAt;
            EmployeeIds = employeeIds;
            OpeningEmployeeId = openingEmployeeId;
            EndingEmployeeId = endingEmployeeId;
            ClosingEmployeeId = closingEmployeeId;
            Description = description;
            OpenedCashMoney = openedCashMoney;
            CashPaymentMoney = cashPaymentMoney;
            CashRefundsMoney = cashRefundsMoney;
            CashPaidInMoney = cashPaidInMoney;
            CashPaidOutMoney = cashPaidOutMoney;
            ExpectedCashMoney = expectedCashMoney;
            ClosedCashMoney = closedCashMoney;
            Device = device;
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
        /// The IDs of all employees that were logged into Square Point of Sale at any
        /// point while the cash drawer shift was open.
        /// </summary>
        [JsonProperty("employee_ids")]
        public IList<string> EmployeeIds { get; }

        /// <summary>
        /// The ID of the employee that started the cash drawer shift.
        /// </summary>
        [JsonProperty("opening_employee_id")]
        public string OpeningEmployeeId { get; }

        /// <summary>
        /// The ID of the employee that ended the cash drawer shift.
        /// </summary>
        [JsonProperty("ending_employee_id")]
        public string EndingEmployeeId { get; }

        /// <summary>
        /// The ID of the employee that closed the cash drawer shift by auditing
        /// the cash drawer contents.
        /// </summary>
        [JsonProperty("closing_employee_id")]
        public string ClosingEmployeeId { get; }

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
        public bool ShouldSerializeEmployeeIds()
        {
            return this.shouldSerialize["employee_ids"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOpeningEmployeeId()
        {
            return this.shouldSerialize["opening_employee_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEndingEmployeeId()
        {
            return this.shouldSerialize["ending_employee_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeClosingEmployeeId()
        {
            return this.shouldSerialize["closing_employee_id"];
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

            return obj is CashDrawerShift other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.State == null && other.State == null) || (this.State?.Equals(other.State) == true)) &&
                ((this.OpenedAt == null && other.OpenedAt == null) || (this.OpenedAt?.Equals(other.OpenedAt) == true)) &&
                ((this.EndedAt == null && other.EndedAt == null) || (this.EndedAt?.Equals(other.EndedAt) == true)) &&
                ((this.ClosedAt == null && other.ClosedAt == null) || (this.ClosedAt?.Equals(other.ClosedAt) == true)) &&
                ((this.EmployeeIds == null && other.EmployeeIds == null) || (this.EmployeeIds?.Equals(other.EmployeeIds) == true)) &&
                ((this.OpeningEmployeeId == null && other.OpeningEmployeeId == null) || (this.OpeningEmployeeId?.Equals(other.OpeningEmployeeId) == true)) &&
                ((this.EndingEmployeeId == null && other.EndingEmployeeId == null) || (this.EndingEmployeeId?.Equals(other.EndingEmployeeId) == true)) &&
                ((this.ClosingEmployeeId == null && other.ClosingEmployeeId == null) || (this.ClosingEmployeeId?.Equals(other.ClosingEmployeeId) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.OpenedCashMoney == null && other.OpenedCashMoney == null) || (this.OpenedCashMoney?.Equals(other.OpenedCashMoney) == true)) &&
                ((this.CashPaymentMoney == null && other.CashPaymentMoney == null) || (this.CashPaymentMoney?.Equals(other.CashPaymentMoney) == true)) &&
                ((this.CashRefundsMoney == null && other.CashRefundsMoney == null) || (this.CashRefundsMoney?.Equals(other.CashRefundsMoney) == true)) &&
                ((this.CashPaidInMoney == null && other.CashPaidInMoney == null) || (this.CashPaidInMoney?.Equals(other.CashPaidInMoney) == true)) &&
                ((this.CashPaidOutMoney == null && other.CashPaidOutMoney == null) || (this.CashPaidOutMoney?.Equals(other.CashPaidOutMoney) == true)) &&
                ((this.ExpectedCashMoney == null && other.ExpectedCashMoney == null) || (this.ExpectedCashMoney?.Equals(other.ExpectedCashMoney) == true)) &&
                ((this.ClosedCashMoney == null && other.ClosedCashMoney == null) || (this.ClosedCashMoney?.Equals(other.ClosedCashMoney) == true)) &&
                ((this.Device == null && other.Device == null) || (this.Device?.Equals(other.Device) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -498109440;
            hashCode = HashCode.Combine(this.Id, this.State, this.OpenedAt, this.EndedAt, this.ClosedAt, this.EmployeeIds, this.OpeningEmployeeId);

            hashCode = HashCode.Combine(hashCode, this.EndingEmployeeId, this.ClosingEmployeeId, this.Description, this.OpenedCashMoney, this.CashPaymentMoney, this.CashRefundsMoney, this.CashPaidInMoney);

            hashCode = HashCode.Combine(hashCode, this.CashPaidOutMoney, this.ExpectedCashMoney, this.ClosedCashMoney, this.Device);

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
            toStringOutput.Add($"this.EmployeeIds = {(this.EmployeeIds == null ? "null" : $"[{string.Join(", ", this.EmployeeIds)} ]")}");
            toStringOutput.Add($"this.OpeningEmployeeId = {(this.OpeningEmployeeId == null ? "null" : this.OpeningEmployeeId == string.Empty ? "" : this.OpeningEmployeeId)}");
            toStringOutput.Add($"this.EndingEmployeeId = {(this.EndingEmployeeId == null ? "null" : this.EndingEmployeeId == string.Empty ? "" : this.EndingEmployeeId)}");
            toStringOutput.Add($"this.ClosingEmployeeId = {(this.ClosingEmployeeId == null ? "null" : this.ClosingEmployeeId == string.Empty ? "" : this.ClosingEmployeeId)}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description == string.Empty ? "" : this.Description)}");
            toStringOutput.Add($"this.OpenedCashMoney = {(this.OpenedCashMoney == null ? "null" : this.OpenedCashMoney.ToString())}");
            toStringOutput.Add($"this.CashPaymentMoney = {(this.CashPaymentMoney == null ? "null" : this.CashPaymentMoney.ToString())}");
            toStringOutput.Add($"this.CashRefundsMoney = {(this.CashRefundsMoney == null ? "null" : this.CashRefundsMoney.ToString())}");
            toStringOutput.Add($"this.CashPaidInMoney = {(this.CashPaidInMoney == null ? "null" : this.CashPaidInMoney.ToString())}");
            toStringOutput.Add($"this.CashPaidOutMoney = {(this.CashPaidOutMoney == null ? "null" : this.CashPaidOutMoney.ToString())}");
            toStringOutput.Add($"this.ExpectedCashMoney = {(this.ExpectedCashMoney == null ? "null" : this.ExpectedCashMoney.ToString())}");
            toStringOutput.Add($"this.ClosedCashMoney = {(this.ClosedCashMoney == null ? "null" : this.ClosedCashMoney.ToString())}");
            toStringOutput.Add($"this.Device = {(this.Device == null ? "null" : this.Device.ToString())}");
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
                .EmployeeIds(this.EmployeeIds)
                .OpeningEmployeeId(this.OpeningEmployeeId)
                .EndingEmployeeId(this.EndingEmployeeId)
                .ClosingEmployeeId(this.ClosingEmployeeId)
                .Description(this.Description)
                .OpenedCashMoney(this.OpenedCashMoney)
                .CashPaymentMoney(this.CashPaymentMoney)
                .CashRefundsMoney(this.CashRefundsMoney)
                .CashPaidInMoney(this.CashPaidInMoney)
                .CashPaidOutMoney(this.CashPaidOutMoney)
                .ExpectedCashMoney(this.ExpectedCashMoney)
                .ClosedCashMoney(this.ClosedCashMoney)
                .Device(this.Device);
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
                { "employee_ids", false },
                { "opening_employee_id", false },
                { "ending_employee_id", false },
                { "closing_employee_id", false },
                { "description", false },
            };

            private string id;
            private string state;
            private string openedAt;
            private string endedAt;
            private string closedAt;
            private IList<string> employeeIds;
            private string openingEmployeeId;
            private string endingEmployeeId;
            private string closingEmployeeId;
            private string description;
            private Models.Money openedCashMoney;
            private Models.Money cashPaymentMoney;
            private Models.Money cashRefundsMoney;
            private Models.Money cashPaidInMoney;
            private Models.Money cashPaidOutMoney;
            private Models.Money expectedCashMoney;
            private Models.Money closedCashMoney;
            private Models.CashDrawerDevice device;

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
             /// EmployeeIds.
             /// </summary>
             /// <param name="employeeIds"> employeeIds. </param>
             /// <returns> Builder. </returns>
            public Builder EmployeeIds(IList<string> employeeIds)
            {
                shouldSerialize["employee_ids"] = true;
                this.employeeIds = employeeIds;
                return this;
            }

             /// <summary>
             /// OpeningEmployeeId.
             /// </summary>
             /// <param name="openingEmployeeId"> openingEmployeeId. </param>
             /// <returns> Builder. </returns>
            public Builder OpeningEmployeeId(string openingEmployeeId)
            {
                shouldSerialize["opening_employee_id"] = true;
                this.openingEmployeeId = openingEmployeeId;
                return this;
            }

             /// <summary>
             /// EndingEmployeeId.
             /// </summary>
             /// <param name="endingEmployeeId"> endingEmployeeId. </param>
             /// <returns> Builder. </returns>
            public Builder EndingEmployeeId(string endingEmployeeId)
            {
                shouldSerialize["ending_employee_id"] = true;
                this.endingEmployeeId = endingEmployeeId;
                return this;
            }

             /// <summary>
             /// ClosingEmployeeId.
             /// </summary>
             /// <param name="closingEmployeeId"> closingEmployeeId. </param>
             /// <returns> Builder. </returns>
            public Builder ClosingEmployeeId(string closingEmployeeId)
            {
                shouldSerialize["closing_employee_id"] = true;
                this.closingEmployeeId = closingEmployeeId;
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
            public void UnsetEmployeeIds()
            {
                this.shouldSerialize["employee_ids"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetOpeningEmployeeId()
            {
                this.shouldSerialize["opening_employee_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEndingEmployeeId()
            {
                this.shouldSerialize["ending_employee_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetClosingEmployeeId()
            {
                this.shouldSerialize["closing_employee_id"] = false;
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
                    this.employeeIds,
                    this.openingEmployeeId,
                    this.endingEmployeeId,
                    this.closingEmployeeId,
                    this.description,
                    this.openedCashMoney,
                    this.cashPaymentMoney,
                    this.cashRefundsMoney,
                    this.cashPaidInMoney,
                    this.cashPaidOutMoney,
                    this.expectedCashMoney,
                    this.closedCashMoney,
                    this.device);
            }
        }
    }
}