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
        /// TThe ID of the applied modifier option, if available. Modifier options applied in older versions of Square Register might not have an ID.
        /// </summary>
        [JsonProperty("modifier_option_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ModifierOptionId { get; }

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