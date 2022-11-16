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
    /// LoyaltyAccount.
    /// </summary>
    public class LoyaltyAccount
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyAccount"/> class.
        /// </summary>
        /// <param name="programId">program_id.</param>
        /// <param name="id">id.</param>
        /// <param name="balance">balance.</param>
        /// <param name="lifetimePoints">lifetime_points.</param>
        /// <param name="customerId">customer_id.</param>
        /// <param name="enrolledAt">enrolled_at.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="mapping">mapping.</param>
        /// <param name="expiringPointDeadlines">expiring_point_deadlines.</param>
        public LoyaltyAccount(
            string programId,
            string id = null,
            int? balance = null,
            int? lifetimePoints = null,
            string customerId = null,
            string enrolledAt = null,
            string createdAt = null,
            string updatedAt = null,
            Models.LoyaltyAccountMapping mapping = null,
            IList<Models.LoyaltyAccountExpiringPointDeadline> expiringPointDeadlines = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "customer_id", false },
                { "enrolled_at", false },
                { "expiring_point_deadlines", false }
            };

            this.Id = id;
            this.ProgramId = programId;
            this.Balance = balance;
            this.LifetimePoints = lifetimePoints;
            if (customerId != null)
            {
                shouldSerialize["customer_id"] = true;
                this.CustomerId = customerId;
            }

            if (enrolledAt != null)
            {
                shouldSerialize["enrolled_at"] = true;
                this.EnrolledAt = enrolledAt;
            }

            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.Mapping = mapping;
            if (expiringPointDeadlines != null)
            {
                shouldSerialize["expiring_point_deadlines"] = true;
                this.ExpiringPointDeadlines = expiringPointDeadlines;
            }

        }
        internal LoyaltyAccount(Dictionary<string, bool> shouldSerialize,
            string programId,
            string id = null,
            int? balance = null,
            int? lifetimePoints = null,
            string customerId = null,
            string enrolledAt = null,
            string createdAt = null,
            string updatedAt = null,
            Models.LoyaltyAccountMapping mapping = null,
            IList<Models.LoyaltyAccountExpiringPointDeadline> expiringPointDeadlines = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            ProgramId = programId;
            Balance = balance;
            LifetimePoints = lifetimePoints;
            CustomerId = customerId;
            EnrolledAt = enrolledAt;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Mapping = mapping;
            ExpiringPointDeadlines = expiringPointDeadlines;
        }

        /// <summary>
        /// The Square-assigned ID of the loyalty account.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The Square-assigned ID of the [loyalty program]($m/LoyaltyProgram) to which the account belongs.
        /// </summary>
        [JsonProperty("program_id")]
        public string ProgramId { get; }

        /// <summary>
        /// The available point balance in the loyalty account. If points are scheduled to expire, they are listed in the `expiring_point_deadlines` field.
        /// Your application should be able to handle loyalty accounts that have a negative point balance (`balance` is less than 0). This might occur if a seller makes a manual adjustment or as a result of a refund or exchange.
        /// </summary>
        [JsonProperty("balance", NullValueHandling = NullValueHandling.Ignore)]
        public int? Balance { get; }

        /// <summary>
        /// The total points accrued during the lifetime of the account.
        /// </summary>
        [JsonProperty("lifetime_points", NullValueHandling = NullValueHandling.Ignore)]
        public int? LifetimePoints { get; }

        /// <summary>
        /// The Square-assigned ID of the [customer]($m/Customer) that is associated with the account.
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; }

        /// <summary>
        /// The timestamp when the buyer joined the loyalty program, in RFC 3339 format. This field is used to display the **Enrolled On** or **Member Since** date in first-party Square products.
        /// If this field is not set in a `CreateLoyaltyAccount` request, Square populates it after the buyer's first action on their account
        /// (when `AccumulateLoyaltyPoints` or `CreateLoyaltyReward` is called). In first-party flows, Square populates the field when the buyer agrees to the terms of service in Square Point of Sale.
        /// This field is typically specified in a `CreateLoyaltyAccount` request when creating a loyalty account for a buyer who already interacted with their account.
        /// For example, you would set this field when migrating accounts from an external system. The timestamp in the request can represent a current or previous date and time, but it cannot be set for the future.
        /// </summary>
        [JsonProperty("enrolled_at")]
        public string EnrolledAt { get; }

        /// <summary>
        /// The timestamp when the loyalty account was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp when the loyalty account was last updated, in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// Represents the mapping that associates a loyalty account with a buyer.
        /// Currently, a loyalty account can only be mapped to a buyer by phone number. For more information, see
        /// [Loyalty Overview](https://developer.squareup.com/docs/loyalty/overview).
        /// </summary>
        [JsonProperty("mapping", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyAccountMapping Mapping { get; }

        /// <summary>
        /// The schedule for when points expire in the loyalty account balance. This field is present only if the account has points that are scheduled to expire.
        /// The total number of points in this field equals the number of points in the `balance` field.
        /// </summary>
        [JsonProperty("expiring_point_deadlines")]
        public IList<Models.LoyaltyAccountExpiringPointDeadline> ExpiringPointDeadlines { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyAccount : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCustomerId()
        {
            return this.shouldSerialize["customer_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEnrolledAt()
        {
            return this.shouldSerialize["enrolled_at"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeExpiringPointDeadlines()
        {
            return this.shouldSerialize["expiring_point_deadlines"];
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

            return obj is LoyaltyAccount other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.ProgramId == null && other.ProgramId == null) || (this.ProgramId?.Equals(other.ProgramId) == true)) &&
                ((this.Balance == null && other.Balance == null) || (this.Balance?.Equals(other.Balance) == true)) &&
                ((this.LifetimePoints == null && other.LifetimePoints == null) || (this.LifetimePoints?.Equals(other.LifetimePoints) == true)) &&
                ((this.CustomerId == null && other.CustomerId == null) || (this.CustomerId?.Equals(other.CustomerId) == true)) &&
                ((this.EnrolledAt == null && other.EnrolledAt == null) || (this.EnrolledAt?.Equals(other.EnrolledAt) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((this.Mapping == null && other.Mapping == null) || (this.Mapping?.Equals(other.Mapping) == true)) &&
                ((this.ExpiringPointDeadlines == null && other.ExpiringPointDeadlines == null) || (this.ExpiringPointDeadlines?.Equals(other.ExpiringPointDeadlines) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 302731941;
            hashCode = HashCode.Combine(this.Id, this.ProgramId, this.Balance, this.LifetimePoints, this.CustomerId, this.EnrolledAt, this.CreatedAt);

            hashCode = HashCode.Combine(hashCode, this.UpdatedAt, this.Mapping, this.ExpiringPointDeadlines);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.ProgramId = {(this.ProgramId == null ? "null" : this.ProgramId == string.Empty ? "" : this.ProgramId)}");
            toStringOutput.Add($"this.Balance = {(this.Balance == null ? "null" : this.Balance.ToString())}");
            toStringOutput.Add($"this.LifetimePoints = {(this.LifetimePoints == null ? "null" : this.LifetimePoints.ToString())}");
            toStringOutput.Add($"this.CustomerId = {(this.CustomerId == null ? "null" : this.CustomerId == string.Empty ? "" : this.CustomerId)}");
            toStringOutput.Add($"this.EnrolledAt = {(this.EnrolledAt == null ? "null" : this.EnrolledAt == string.Empty ? "" : this.EnrolledAt)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt == string.Empty ? "" : this.UpdatedAt)}");
            toStringOutput.Add($"this.Mapping = {(this.Mapping == null ? "null" : this.Mapping.ToString())}");
            toStringOutput.Add($"this.ExpiringPointDeadlines = {(this.ExpiringPointDeadlines == null ? "null" : $"[{string.Join(", ", this.ExpiringPointDeadlines)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.ProgramId)
                .Id(this.Id)
                .Balance(this.Balance)
                .LifetimePoints(this.LifetimePoints)
                .CustomerId(this.CustomerId)
                .EnrolledAt(this.EnrolledAt)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt)
                .Mapping(this.Mapping)
                .ExpiringPointDeadlines(this.ExpiringPointDeadlines);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "customer_id", false },
                { "enrolled_at", false },
                { "expiring_point_deadlines", false },
            };

            private string programId;
            private string id;
            private int? balance;
            private int? lifetimePoints;
            private string customerId;
            private string enrolledAt;
            private string createdAt;
            private string updatedAt;
            private Models.LoyaltyAccountMapping mapping;
            private IList<Models.LoyaltyAccountExpiringPointDeadline> expiringPointDeadlines;

            public Builder(
                string programId)
            {
                this.programId = programId;
            }

             /// <summary>
             /// ProgramId.
             /// </summary>
             /// <param name="programId"> programId. </param>
             /// <returns> Builder. </returns>
            public Builder ProgramId(string programId)
            {
                this.programId = programId;
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
             /// Balance.
             /// </summary>
             /// <param name="balance"> balance. </param>
             /// <returns> Builder. </returns>
            public Builder Balance(int? balance)
            {
                this.balance = balance;
                return this;
            }

             /// <summary>
             /// LifetimePoints.
             /// </summary>
             /// <param name="lifetimePoints"> lifetimePoints. </param>
             /// <returns> Builder. </returns>
            public Builder LifetimePoints(int? lifetimePoints)
            {
                this.lifetimePoints = lifetimePoints;
                return this;
            }

             /// <summary>
             /// CustomerId.
             /// </summary>
             /// <param name="customerId"> customerId. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerId(string customerId)
            {
                shouldSerialize["customer_id"] = true;
                this.customerId = customerId;
                return this;
            }

             /// <summary>
             /// EnrolledAt.
             /// </summary>
             /// <param name="enrolledAt"> enrolledAt. </param>
             /// <returns> Builder. </returns>
            public Builder EnrolledAt(string enrolledAt)
            {
                shouldSerialize["enrolled_at"] = true;
                this.enrolledAt = enrolledAt;
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
             /// Mapping.
             /// </summary>
             /// <param name="mapping"> mapping. </param>
             /// <returns> Builder. </returns>
            public Builder Mapping(Models.LoyaltyAccountMapping mapping)
            {
                this.mapping = mapping;
                return this;
            }

             /// <summary>
             /// ExpiringPointDeadlines.
             /// </summary>
             /// <param name="expiringPointDeadlines"> expiringPointDeadlines. </param>
             /// <returns> Builder. </returns>
            public Builder ExpiringPointDeadlines(IList<Models.LoyaltyAccountExpiringPointDeadline> expiringPointDeadlines)
            {
                shouldSerialize["expiring_point_deadlines"] = true;
                this.expiringPointDeadlines = expiringPointDeadlines;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCustomerId()
            {
                this.shouldSerialize["customer_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEnrolledAt()
            {
                this.shouldSerialize["enrolled_at"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetExpiringPointDeadlines()
            {
                this.shouldSerialize["expiring_point_deadlines"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyAccount. </returns>
            public LoyaltyAccount Build()
            {
                return new LoyaltyAccount(shouldSerialize,
                    this.programId,
                    this.id,
                    this.balance,
                    this.lifetimePoints,
                    this.customerId,
                    this.enrolledAt,
                    this.createdAt,
                    this.updatedAt,
                    this.mapping,
                    this.expiringPointDeadlines);
            }
        }
    }
}