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
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// Getter for event_type
        /// </summary>
        [JsonProperty("event_type")]
        public string EventType { get; }

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
        /// The IDs of all employees that were logged into Square Register at some point during the cash drawer shift.
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
        /// The ID of the employee that closed the cash drawer shift by auditing the cash drawer's contents.
        /// </summary>
        [JsonProperty("closing_employee_id")]
        public string ClosingEmployeeId { get; }

        /// <summary>
        /// A description of the cash drawer shift.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; }

        /// <summary>
        /// Getter for starting_cash_money
        /// </summary>
        [JsonProperty("starting_cash_money")]
        public Models.V1Money StartingCashMoney { get; }

        /// <summary>
        /// Getter for cash_payment_money
        /// </summary>
        [JsonProperty("cash_payment_money")]
        public Models.V1Money CashPaymentMoney { get; }

        /// <summary>
        /// Getter for cash_refunds_money
        /// </summary>
        [JsonProperty("cash_refunds_money")]
        public Models.V1Money CashRefundsMoney { get; }

        /// <summary>
        /// Getter for cash_paid_in_money
        /// </summary>
        [JsonProperty("cash_paid_in_money")]
        public Models.V1Money CashPaidInMoney { get; }

        /// <summary>
        /// Getter for cash_paid_out_money
        /// </summary>
        [JsonProperty("cash_paid_out_money")]
        public Models.V1Money CashPaidOutMoney { get; }

        /// <summary>
        /// Getter for expected_cash_money
        /// </summary>
        [JsonProperty("expected_cash_money")]
        public Models.V1Money ExpectedCashMoney { get; }

        /// <summary>
        /// Getter for closed_cash_money
        /// </summary>
        [JsonProperty("closed_cash_money")]
        public Models.V1Money ClosedCashMoney { get; }

        /// <summary>
        /// Getter for device
        /// </summary>
        [JsonProperty("device")]
        public Models.Device Device { get; }

        /// <summary>
        /// All of the events (payments, refunds, and so on) that involved the cash drawer during the shift.
        /// </summary>
        [JsonProperty("events")]
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
            private IList<string> employeeIds = new List<string>();
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
            private IList<Models.V1CashDrawerEvent> events = new List<Models.V1CashDrawerEvent>();

            public Builder() { }
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder EventType(string value)
            {
                eventType = value;
                return this;
            }

            public Builder OpenedAt(string value)
            {
                openedAt = value;
                return this;
            }

            public Builder EndedAt(string value)
            {
                endedAt = value;
                return this;
            }

            public Builder ClosedAt(string value)
            {
                closedAt = value;
                return this;
            }

            public Builder EmployeeIds(IList<string> value)
            {
                employeeIds = value;
                return this;
            }

            public Builder OpeningEmployeeId(string value)
            {
                openingEmployeeId = value;
                return this;
            }

            public Builder EndingEmployeeId(string value)
            {
                endingEmployeeId = value;
                return this;
            }

            public Builder ClosingEmployeeId(string value)
            {
                closingEmployeeId = value;
                return this;
            }

            public Builder Description(string value)
            {
                description = value;
                return this;
            }

            public Builder StartingCashMoney(Models.V1Money value)
            {
                startingCashMoney = value;
                return this;
            }

            public Builder CashPaymentMoney(Models.V1Money value)
            {
                cashPaymentMoney = value;
                return this;
            }

            public Builder CashRefundsMoney(Models.V1Money value)
            {
                cashRefundsMoney = value;
                return this;
            }

            public Builder CashPaidInMoney(Models.V1Money value)
            {
                cashPaidInMoney = value;
                return this;
            }

            public Builder CashPaidOutMoney(Models.V1Money value)
            {
                cashPaidOutMoney = value;
                return this;
            }

            public Builder ExpectedCashMoney(Models.V1Money value)
            {
                expectedCashMoney = value;
                return this;
            }

            public Builder ClosedCashMoney(Models.V1Money value)
            {
                closedCashMoney = value;
                return this;
            }

            public Builder Device(Models.Device value)
            {
                device = value;
                return this;
            }

            public Builder Events(IList<Models.V1CashDrawerEvent> value)
            {
                events = value;
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