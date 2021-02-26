
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class LoyaltyAccount 
    {
        public LoyaltyAccount(IList<Models.LoyaltyAccountMapping> mappings,
            string programId,
            string id = null,
            int? balance = null,
            int? lifetimePoints = null,
            string customerId = null,
            string enrolledAt = null,
            string createdAt = null,
            string updatedAt = null)
        {
            Id = id;
            Mappings = mappings;
            ProgramId = programId;
            Balance = balance;
            LifetimePoints = lifetimePoints;
            CustomerId = customerId;
            EnrolledAt = enrolledAt;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// The Square-assigned ID of the loyalty account.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The list of mappings that the account is associated with. 
        /// Currently, a buyer can only be mapped to a loyalty account using 
        /// a phone number. Therefore, the list can only have one mapping.
        /// </summary>
        [JsonProperty("mappings")]
        public IList<Models.LoyaltyAccountMapping> Mappings { get; }

        /// <summary>
        /// The Square-assigned ID of the [loyalty program](#type-LoyaltyProgram) to which the account belongs.
        /// </summary>
        [JsonProperty("program_id")]
        public string ProgramId { get; }

        /// <summary>
        /// The available point balance in the loyalty account.  
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
        /// The Square-assigned ID of the [customer](#type-Customer) that is associated with the account.
        /// </summary>
        [JsonProperty("customer_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerId { get; }

        /// <summary>
        /// The timestamp when enrollment occurred, in RFC 3339 format.
        /// </summary>
        [JsonProperty("enrolled_at", NullValueHandling = NullValueHandling.Ignore)]
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyAccount : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"Mappings = {(Mappings == null ? "null" : $"[{ string.Join(", ", Mappings)} ]")}");
            toStringOutput.Add($"ProgramId = {(ProgramId == null ? "null" : ProgramId == string.Empty ? "" : ProgramId)}");
            toStringOutput.Add($"Balance = {(Balance == null ? "null" : Balance.ToString())}");
            toStringOutput.Add($"LifetimePoints = {(LifetimePoints == null ? "null" : LifetimePoints.ToString())}");
            toStringOutput.Add($"CustomerId = {(CustomerId == null ? "null" : CustomerId == string.Empty ? "" : CustomerId)}");
            toStringOutput.Add($"EnrolledAt = {(EnrolledAt == null ? "null" : EnrolledAt == string.Empty ? "" : EnrolledAt)}");
            toStringOutput.Add($"CreatedAt = {(CreatedAt == null ? "null" : CreatedAt == string.Empty ? "" : CreatedAt)}");
            toStringOutput.Add($"UpdatedAt = {(UpdatedAt == null ? "null" : UpdatedAt == string.Empty ? "" : UpdatedAt)}");
        }

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
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                ((Mappings == null && other.Mappings == null) || (Mappings?.Equals(other.Mappings) == true)) &&
                ((ProgramId == null && other.ProgramId == null) || (ProgramId?.Equals(other.ProgramId) == true)) &&
                ((Balance == null && other.Balance == null) || (Balance?.Equals(other.Balance) == true)) &&
                ((LifetimePoints == null && other.LifetimePoints == null) || (LifetimePoints?.Equals(other.LifetimePoints) == true)) &&
                ((CustomerId == null && other.CustomerId == null) || (CustomerId?.Equals(other.CustomerId) == true)) &&
                ((EnrolledAt == null && other.EnrolledAt == null) || (EnrolledAt?.Equals(other.EnrolledAt) == true)) &&
                ((CreatedAt == null && other.CreatedAt == null) || (CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((UpdatedAt == null && other.UpdatedAt == null) || (UpdatedAt?.Equals(other.UpdatedAt) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -823121408;

            if (Id != null)
            {
               hashCode += Id.GetHashCode();
            }

            if (Mappings != null)
            {
               hashCode += Mappings.GetHashCode();
            }

            if (ProgramId != null)
            {
               hashCode += ProgramId.GetHashCode();
            }

            if (Balance != null)
            {
               hashCode += Balance.GetHashCode();
            }

            if (LifetimePoints != null)
            {
               hashCode += LifetimePoints.GetHashCode();
            }

            if (CustomerId != null)
            {
               hashCode += CustomerId.GetHashCode();
            }

            if (EnrolledAt != null)
            {
               hashCode += EnrolledAt.GetHashCode();
            }

            if (CreatedAt != null)
            {
               hashCode += CreatedAt.GetHashCode();
            }

            if (UpdatedAt != null)
            {
               hashCode += UpdatedAt.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(Mappings,
                ProgramId)
                .Id(Id)
                .Balance(Balance)
                .LifetimePoints(LifetimePoints)
                .CustomerId(CustomerId)
                .EnrolledAt(EnrolledAt)
                .CreatedAt(CreatedAt)
                .UpdatedAt(UpdatedAt);
            return builder;
        }

        public class Builder
        {
            private IList<Models.LoyaltyAccountMapping> mappings;
            private string programId;
            private string id;
            private int? balance;
            private int? lifetimePoints;
            private string customerId;
            private string enrolledAt;
            private string createdAt;
            private string updatedAt;

            public Builder(IList<Models.LoyaltyAccountMapping> mappings,
                string programId)
            {
                this.mappings = mappings;
                this.programId = programId;
            }

            public Builder Mappings(IList<Models.LoyaltyAccountMapping> mappings)
            {
                this.mappings = mappings;
                return this;
            }

            public Builder ProgramId(string programId)
            {
                this.programId = programId;
                return this;
            }

            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder Balance(int? balance)
            {
                this.balance = balance;
                return this;
            }

            public Builder LifetimePoints(int? lifetimePoints)
            {
                this.lifetimePoints = lifetimePoints;
                return this;
            }

            public Builder CustomerId(string customerId)
            {
                this.customerId = customerId;
                return this;
            }

            public Builder EnrolledAt(string enrolledAt)
            {
                this.enrolledAt = enrolledAt;
                return this;
            }

            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

            public LoyaltyAccount Build()
            {
                return new LoyaltyAccount(mappings,
                    programId,
                    id,
                    balance,
                    lifetimePoints,
                    customerId,
                    enrolledAt,
                    createdAt,
                    updatedAt);
            }
        }
    }
}