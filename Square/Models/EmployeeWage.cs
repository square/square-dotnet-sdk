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
    /// EmployeeWage.
    /// </summary>
    public class EmployeeWage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeWage"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="employeeId">employee_id.</param>
        /// <param name="title">title.</param>
        /// <param name="hourlyRate">hourly_rate.</param>
        public EmployeeWage(
            string id = null,
            string employeeId = null,
            string title = null,
            Models.Money hourlyRate = null)
        {
            this.Id = id;
            this.EmployeeId = employeeId;
            this.Title = title;
            this.HourlyRate = hourlyRate;
        }

        /// <summary>
        /// UUID for this object.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The `Employee` that this wage is assigned to.
        /// </summary>
        [JsonProperty("employee_id", NullValueHandling = NullValueHandling.Ignore)]
        public string EmployeeId { get; }

        /// <summary>
        /// The job title that this wage relates to.
        /// </summary>
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("hourly_rate", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money HourlyRate { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"EmployeeWage : ({string.Join(", ", toStringOutput)})";
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

            return obj is EmployeeWage other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.EmployeeId == null && other.EmployeeId == null) || (this.EmployeeId?.Equals(other.EmployeeId) == true)) &&
                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.HourlyRate == null && other.HourlyRate == null) || (this.HourlyRate?.Equals(other.HourlyRate) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -159635792;

            if (this.Id != null)
            {
               hashCode += this.Id.GetHashCode();
            }

            if (this.EmployeeId != null)
            {
               hashCode += this.EmployeeId.GetHashCode();
            }

            if (this.Title != null)
            {
               hashCode += this.Title.GetHashCode();
            }

            if (this.HourlyRate != null)
            {
               hashCode += this.HourlyRate.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.EmployeeId = {(this.EmployeeId == null ? "null" : this.EmployeeId == string.Empty ? "" : this.EmployeeId)}");
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title == string.Empty ? "" : this.Title)}");
            toStringOutput.Add($"this.HourlyRate = {(this.HourlyRate == null ? "null" : this.HourlyRate.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .EmployeeId(this.EmployeeId)
                .Title(this.Title)
                .HourlyRate(this.HourlyRate);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string id;
            private string employeeId;
            private string title;
            private Models.Money hourlyRate;

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
             /// EmployeeId.
             /// </summary>
             /// <param name="employeeId"> employeeId. </param>
             /// <returns> Builder. </returns>
            public Builder EmployeeId(string employeeId)
            {
                this.employeeId = employeeId;
                return this;
            }

             /// <summary>
             /// Title.
             /// </summary>
             /// <param name="title"> title. </param>
             /// <returns> Builder. </returns>
            public Builder Title(string title)
            {
                this.title = title;
                return this;
            }

             /// <summary>
             /// HourlyRate.
             /// </summary>
             /// <param name="hourlyRate"> hourlyRate. </param>
             /// <returns> Builder. </returns>
            public Builder HourlyRate(Models.Money hourlyRate)
            {
                this.hourlyRate = hourlyRate;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> EmployeeWage. </returns>
            public EmployeeWage Build()
            {
                return new EmployeeWage(
                    this.id,
                    this.employeeId,
                    this.title,
                    this.hourlyRate);
            }
        }
    }
}