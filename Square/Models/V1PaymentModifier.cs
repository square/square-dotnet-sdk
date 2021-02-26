
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
    public class V1PaymentModifier 
    {
        public V1PaymentModifier(string name = null,
            Models.V1Money appliedMoney = null,
            string modifierOptionId = null)
        {
            Name = name;
            AppliedMoney = appliedMoney;
            ModifierOptionId = modifierOptionId;
        }

        /// <summary>
        /// The modifier option's name.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// Getter for applied_money
        /// </summary>
        [JsonProperty("applied_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money AppliedMoney { get; }

        /// <summary>
        /// The ID of the applied modifier option, if available. Modifier options applied in older versions of Square Register might not have an ID.
        /// </summary>
        [JsonProperty("modifier_option_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ModifierOptionId { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1PaymentModifier : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Name = {(Name == null ? "null" : Name == string.Empty ? "" : Name)}");
            toStringOutput.Add($"AppliedMoney = {(AppliedMoney == null ? "null" : AppliedMoney.ToString())}");
            toStringOutput.Add($"ModifierOptionId = {(ModifierOptionId == null ? "null" : ModifierOptionId == string.Empty ? "" : ModifierOptionId)}");
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

            return obj is V1PaymentModifier other &&
                ((Name == null && other.Name == null) || (Name?.Equals(other.Name) == true)) &&
                ((AppliedMoney == null && other.AppliedMoney == null) || (AppliedMoney?.Equals(other.AppliedMoney) == true)) &&
                ((ModifierOptionId == null && other.ModifierOptionId == null) || (ModifierOptionId?.Equals(other.ModifierOptionId) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 255545397;

            if (Name != null)
            {
               hashCode += Name.GetHashCode();
            }

            if (AppliedMoney != null)
            {
               hashCode += AppliedMoney.GetHashCode();
            }

            if (ModifierOptionId != null)
            {
               hashCode += ModifierOptionId.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(Name)
                .AppliedMoney(AppliedMoney)
                .ModifierOptionId(ModifierOptionId);
            return builder;
        }

        public class Builder
        {
            private string name;
            private Models.V1Money appliedMoney;
            private string modifierOptionId;



            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder AppliedMoney(Models.V1Money appliedMoney)
            {
                this.appliedMoney = appliedMoney;
                return this;
            }

            public Builder ModifierOptionId(string modifierOptionId)
            {
                this.modifierOptionId = modifierOptionId;
                return this;
            }

            public V1PaymentModifier Build()
            {
                return new V1PaymentModifier(name,
                    appliedMoney,
                    modifierOptionId);
            }
        }
    }
}