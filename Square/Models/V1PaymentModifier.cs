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
    /// V1PaymentModifier.
    /// </summary>
    public class V1PaymentModifier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1PaymentModifier"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="appliedMoney">applied_money.</param>
        /// <param name="modifierOptionId">modifier_option_id.</param>
        public V1PaymentModifier(
            string name = null,
            Models.V1Money appliedMoney = null,
            string modifierOptionId = null)
        {
            this.Name = name;
            this.AppliedMoney = appliedMoney;
            this.ModifierOptionId = modifierOptionId;
        }

        /// <summary>
        /// The modifier option's name.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// Gets or sets AppliedMoney.
        /// </summary>
        [JsonProperty("applied_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money AppliedMoney { get; }

        /// <summary>
        /// The ID of the applied modifier option, if available. Modifier options applied in older versions of Square Register might not have an ID.
        /// </summary>
        [JsonProperty("modifier_option_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ModifierOptionId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1PaymentModifier : ({string.Join(", ", toStringOutput)})";
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

            return obj is V1PaymentModifier other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.AppliedMoney == null && other.AppliedMoney == null) || (this.AppliedMoney?.Equals(other.AppliedMoney) == true)) &&
                ((this.ModifierOptionId == null && other.ModifierOptionId == null) || (this.ModifierOptionId?.Equals(other.ModifierOptionId) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 255545397;

            if (this.Name != null)
            {
               hashCode += this.Name.GetHashCode();
            }

            if (this.AppliedMoney != null)
            {
               hashCode += this.AppliedMoney.GetHashCode();
            }

            if (this.ModifierOptionId != null)
            {
               hashCode += this.ModifierOptionId.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.AppliedMoney = {(this.AppliedMoney == null ? "null" : this.AppliedMoney.ToString())}");
            toStringOutput.Add($"this.ModifierOptionId = {(this.ModifierOptionId == null ? "null" : this.ModifierOptionId == string.Empty ? "" : this.ModifierOptionId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(this.Name)
                .AppliedMoney(this.AppliedMoney)
                .ModifierOptionId(this.ModifierOptionId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string name;
            private Models.V1Money appliedMoney;
            private string modifierOptionId;

             /// <summary>
             /// Name.
             /// </summary>
             /// <param name="name"> name. </param>
             /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

             /// <summary>
             /// AppliedMoney.
             /// </summary>
             /// <param name="appliedMoney"> appliedMoney. </param>
             /// <returns> Builder. </returns>
            public Builder AppliedMoney(Models.V1Money appliedMoney)
            {
                this.appliedMoney = appliedMoney;
                return this;
            }

             /// <summary>
             /// ModifierOptionId.
             /// </summary>
             /// <param name="modifierOptionId"> modifierOptionId. </param>
             /// <returns> Builder. </returns>
            public Builder ModifierOptionId(string modifierOptionId)
            {
                this.modifierOptionId = modifierOptionId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1PaymentModifier. </returns>
            public V1PaymentModifier Build()
            {
                return new V1PaymentModifier(
                    this.name,
                    this.appliedMoney,
                    this.modifierOptionId);
            }
        }
    }
}