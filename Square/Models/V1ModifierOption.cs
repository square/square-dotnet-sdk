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
    public class V1ModifierOption 
    {
        public V1ModifierOption(string id = null,
            string name = null,
            Models.V1Money priceMoney = null,
            bool? onByDefault = null,
            int? ordinal = null,
            string modifierListId = null,
            string v2Id = null)
        {
            Id = id;
            Name = name;
            PriceMoney = priceMoney;
            OnByDefault = onByDefault;
            Ordinal = ordinal;
            ModifierListId = modifierListId;
            V2Id = v2Id;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The modifier option's unique ID.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The modifier option's name.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// Getter for price_money
        /// </summary>
        [JsonProperty("price_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money PriceMoney { get; }

        /// <summary>
        /// If true, the modifier option is the default option in a modifier list for which selection_type is SINGLE.
        /// </summary>
        [JsonProperty("on_by_default", NullValueHandling = NullValueHandling.Ignore)]
        public bool? OnByDefault { get; }

        /// <summary>
        /// Indicates the modifier option's list position when displayed in Square Point of Sale and the merchant dashboard. If more than one modifier option in the same modifier list has the same ordinal value, those options are displayed in alphabetical order.
        /// </summary>
        [JsonProperty("ordinal", NullValueHandling = NullValueHandling.Ignore)]
        public int? Ordinal { get; }

        /// <summary>
        /// The ID of the modifier list the option belongs to.
        /// </summary>
        [JsonProperty("modifier_list_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ModifierListId { get; }

        /// <summary>
        /// The ID of the CatalogObject in the Connect v2 API. Objects that are shared across multiple locations share the same v2 ID.
        /// </summary>
        [JsonProperty("v2_id", NullValueHandling = NullValueHandling.Ignore)]
        public string V2Id { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .Name(Name)
                .PriceMoney(PriceMoney)
                .OnByDefault(OnByDefault)
                .Ordinal(Ordinal)
                .ModifierListId(ModifierListId)
                .V2Id(V2Id);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string name;
            private Models.V1Money priceMoney;
            private bool? onByDefault;
            private int? ordinal;
            private string modifierListId;
            private string v2Id;



            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder PriceMoney(Models.V1Money priceMoney)
            {
                this.priceMoney = priceMoney;
                return this;
            }

            public Builder OnByDefault(bool? onByDefault)
            {
                this.onByDefault = onByDefault;
                return this;
            }

            public Builder Ordinal(int? ordinal)
            {
                this.ordinal = ordinal;
                return this;
            }

            public Builder ModifierListId(string modifierListId)
            {
                this.modifierListId = modifierListId;
                return this;
            }

            public Builder V2Id(string v2Id)
            {
                this.v2Id = v2Id;
                return this;
            }

            public V1ModifierOption Build()
            {
                return new V1ModifierOption(id,
                    name,
                    priceMoney,
                    onByDefault,
                    ordinal,
                    modifierListId,
                    v2Id);
            }
        }
    }
}