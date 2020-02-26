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
    public class MethodErrorCodes 
    {
        public MethodErrorCodes(IList<string> mValue = null)
        {
            MValue = mValue;
        }

        /// <summary>
        /// See [ErrorCode](#type-errorcode) for possible values
        /// </summary>
        [JsonProperty("value")]
        public IList<string> MValue { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .MValue(MValue);
            return builder;
        }

        public class Builder
        {
            private IList<string> mValue = new List<string>();

            public Builder() { }
            public Builder MValue(IList<string> value)
            {
                mValue = value;
                return this;
            }

            public MethodErrorCodes Build()
            {
                return new MethodErrorCodes(mValue);
            }
        }
    }
}