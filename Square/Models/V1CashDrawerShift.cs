using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class V1CashDrawerShift 
    {
        public V1CashDrawerShift(string id = null,
            string eventType = null,
            string openedAt = null,
            string endedAt = null,
            string closedAt = null,
            IList<string> employeeIds = null,
            string openingEmployeeId = null,
            string endingEmployeeId = null,
            string closingEmployeeId = null,
            string description = null,
            Models.V1Money startingCashMoney = null,
            Models.V1Money cashPaymentMoney = null,
            Models.V1Money cashRefundsMoney = null,
            Models.V1Money cashPaidInMoney = null,
            Models.V1Money cashPaidOutMoney = null,
            Models.V1Money expectedCashMoney = null,
            Models.V1Money closedCashMoney = null,
            Models.Device device = null,
            IList<Models.V1CashDrawerEvent> events = null)
        {
            Id = id;
            EventType = eventType;
            OpenedAt = openedAt;
            EndedAt = endedAt;
            ClosedAt = closedAt;
            EmployeeIds = employeeIds;
            OpeningEmployeeId = openingEmployeeId;
            EndingEmployeeId = endingEmployeeId;
            ClosingEmployeeId = closingEmployeeId;
            Description = description;
            StartingCashMoney = startingCashMoney;
            CashPaymentMoney = cashPaymentMoney;
            CashRefundsMoney = cashRefundsMoney;
            CashPaidInMoney = cashPaidInMoney;
            CashPaidOutMoney = cashPaidOutMoney;
            ExpectedCashMoney = expectedCashMoney;
            ClosedCashMoney = closedCashMoney;
            Device = device;
            Events = events;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The shift's unique ID.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// Getter for event_type
        /// </summary>
        [JsonProperty("event_type", NullValueHandling = NullValueHandling.Ignore)]
        public string EventType { get; }

        /// <summary>
        /// The time when the shift began, in ISO 8601 format.
        /// </summary>
        [JsonProperty("opened_at", NullValueHandling = NullValueHandling.Ignore)]
        public string OpenedAt { get; }

        /// <summary>
        /// The time when the shift ended, in ISO 8601 format.
        /// </summary>
        [JsonProperty("ended_at", NullValueHandling = NullValueHandling.Ignore)]
        public string EndedAt { get; }

        /// <summary>
        /// The time when the shift was closed, in ISO 8601 format.
        /// </summary>
        [JsonProperty("closed_at", NullValueHandling = NullValueHandling.Ignore)]
        public string ClosedAt { get; }

        /// <summary>
        /// The IDs of all employees that were logged into Square Register at some point during the cash drawer shift.
        /// </summary>
        [JsonProperty("employee_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> EmployeeIds { get; }

        /// <summary>
        /// The ID of the employee that started the cash drawer shift.
        /// </summary>
        [JsonProperty("opening_employee_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OpeningEmployeeId { get; }

        /// <summary>
        /// The ID of the employee that ended the cash drawer shift.
        /// </summary>
        [JsonProperty("ending_employee_id", NullValueHandling = NullValueHandling.Ignore)]
        public string EndingEmployeeId { get; }

        /// <summary>
        /// The ID of the employee that closed the cash drawer shift by auditing the cash drawer's contents.
        /// </summary>
        [JsonProperty("closing_employee_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ClosingEmployeeId { get; }

        /// <summary>
        /// A description of the cash drawer shift.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; }

        /// <summary>
        /// Getter for starting_cash_money
        /// </summary>
        [JsonProperty("starting_cash_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money StartingCashMoney { get; }

        /// <summary>
        /// Getter for cash_payment_money
        /// </summary>
        [JsonProperty("cash_payment_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money CashPaymentMoney { get; }

        /// <summary>
        /// Getter for cash_refunds_money
        /// </summary>
        [JsonProperty("cash_refunds_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money CashRefundsMoney { get; }

        /// <summary>
        /// Getter for cash_paid_in_money
        /// </summary>
        [JsonProperty("cash_paid_in_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money CashPaidInMoney { get; }

        /// <summary>
        /// Getter for cash_paid_out_money
        /// </summary>
        [JsonProperty("cash_paid_out_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money CashPaidOutMoney { get; }

        /// <summary>
        /// Getter for expected_cash_money
        /// </summary>
        [JsonProperty("expected_cash_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money ExpectedCashMoney { get; }

        /// <summary>
        /// Getter for closed_cash_money
        /// </summary>
        [JsonProperty("closed_cash_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money ClosedCashMoney { get; }

        /// <summary>
        /// Getter for device
        /// </summary>
        [JsonProperty("device", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Device Device { get; }

        /// <summary>
        /// All of the events (payments, refunds, and so on) that involved the cash drawer during the shift.
        /// </summary>
        [JsonProperty("events", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.V1CashDrawerEvent> Events { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .EventType(EventType)
                .OpenedAt(OpenedAt)
                .EndedAt(EndedAt)
                .ClosedAt(ClosedAt)
                .EmployeeIds(EmployeeIds)
                .OpeningEmployeeId(OpeningEmployeeId)
                .EndingEmployeeId(EndingEmployeeId)
                .ClosingEmployeeId(ClosingEmployeeId)
                .Description(Description)
                .StartingCashMoney(StartingCashMoney)
                .CashPaymentMoney(CashPaymentMoney)
                .CashRefundsMoney(CashRefundsMoney)
                .CashPaidInMoney(CashPaidInMoney)
                .CashPaidOutMoney(CashPaidOutMoney)
                .ExpectedCashMoney(ExpectedCashMoney)
                .ClosedCashMoney(ClosedCashMoney)
                .Device(Device)
                .Events(Events);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string eventType;
            private string openedAt;
            private string endedAt;
            private string closedAt;
            private IList<string> employeeIds;
            private string openingEmployeeId;
            private string endingEmployeeId;
            private string closingEmployeeId;
            private string description;
            private Models.V1Money startingCashMoney;
            private Models.V1Money cashPaymentMoney;
            private Models.V1Money cashRefundsMoney;
            private Models.V1Money cashPaidInMoney;
            private Models.V1Money cashPaidOutMoney;
            private Models.V1Money expectedCashMoney;
            private Models.V1Money closedCashMoney;
            private Models.Device device;
            private IList<Models.V1CashDrawerEvent> events;



            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder EventType(string eventType)
            {
                this.eventType = eventType;
                return this;
            }

            public Builder OpenedAt(string openedAt)
            {
                this.openedAt = openedAt;
                return this;
            }

            public Builder EndedAt(string endedAt)
            {
                this.endedAt = endedAt;
                return this;
            }

            public Builder ClosedAt(string closedAt)
            {
                this.closedAt = closedAt;
                return this;
            }

            public Builder EmployeeIds(IList<string> employeeIds)
            {
                this.employeeIds = employeeIds;
                return this;
            }

            public Builder OpeningEmployeeId(string openingEmployeeId)
            {
                this.openingEmployeeId = openingEmployeeId;
                return this;
            }

            public Builder EndingEmployeeId(string endingEmployeeId)
            {
                this.endingEmployeeId = endingEmployeeId;
                return this;
            }

            public Builder ClosingEmployeeId(string closingEmployeeId)
            {
                this.closingEmployeeId = closingEmployeeId;
                return this;
            }

            public Builder Description(string description)
            {
                this.description = description;
                return this;
            }

            public Builder StartingCashMoney(Models.V1Money startingCashMoney)
            {
                this.startingCashMoney = startingCashMoney;
                return this;
            }

            public Builder CashPaymentMoney(Models.V1Money cashPaymentMoney)
            {
                this.cashPaymentMoney = cashPaymentMoney;
                return this;
            }

            public Builder CashRefundsMoney(Models.V1Money cashRefundsMoney)
            {
                this.cashRefundsMoney = cashRefundsMoney;
                return this;
            }

            public Builder CashPaidInMoney(Models.V1Money cashPaidInMoney)
            {
                this.cashPaidInMoney = cashPaidInMoney;
                return this;
            }

            public Builder CashPaidOutMoney(Models.V1Money cashPaidOutMoney)
            {
                this.cashPaidOutMoney = cashPaidOutMoney;
                return this;
            }

            public Builder ExpectedCashMoney(Models.V1Money expectedCashMoney)
            {
                this.expectedCashMoney = expectedCashMoney;
                return this;
            }

            public Builder ClosedCashMoney(Models.V1Money closedCashMoney)
            {
                this.closedCashMoney = closedCashMoney;
                return this;
            }

            public Builder Device(Models.Device device)
            {
                this.device = device;
                return this;
            }

            public Builder Events(IList<Models.V1CashDrawerEvent> events)
            {
                this.events = events;
                return this;
            }

            public V1CashDrawerShift Build()
            {
                return new V1CashDrawerShift(id,
                    eventType,
                    openedAt,
                    endedAt,
                    closedAt,
                    employeeIds,
                    openingEmployeeId,
                    endingEmployeeId,
                    closingEmployeeId,
                    description,
                    startingCashMoney,
                    cashPaymentMoney,
                    cashRefundsMoney,
                    cashPaidInMoney,
                    cashPaidOutMoney,
                    expectedCashMoney,
                    closedCashMoney,
                    device,
                    events);
            }
        }
    }
}