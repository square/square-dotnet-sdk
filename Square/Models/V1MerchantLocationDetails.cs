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
    public class V1MerchantLocationDetails 
    {
        public V1MerchantLocationDetails(string nickname = null)
        {
            Nickname = nickname;
        }

        /// <summary>
        /// The nickname assigned to the single-location account by the parent business. This value appears in the parent business's multi-location dashboard.
        /// </summary>
        [JsonProperty("nickname", NullValueHandling = NullValueHandling.Ignore)]
        public string Nickname { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Nickname(Nickname);
            return builder;
        }

        public class Builder
        {
            private string nickname;



            public Builder Nickname(string nickname)
            {
                this.nickname = nickname;
                return this;
            }

            public V1MerchantLocationDetails Build()
            {
                return new V1MerchantLocationDetails(nickname);
            }
        }
    }
}