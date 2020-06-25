using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Square.Utilities
{
    public static class ApiHelper
    {
        //DateTime format to use for parsing and converting dates
        public static string DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";

        /// <summary>
        /// Creates a deep clone of an object by serializing it into a json string and then
        /// deserializing back into an object.
        /// </summary>
        /// <typeparam name="T">The type of the obj parameter as well as the return object</typeparam>
        /// <param name="obj">The object to clone</param>
        /// <returns></returns>
        internal static T DeepCloneObject<T>(T obj)
        {
            return JsonDeserialize<T>(JsonSerialize(obj));
        }

        /// <summary>
        /// JSON Serialization of a given object.
        /// </summary>
        /// <param name="obj">The object to serialize into JSON</param>
        /// <param name="converter">The converter to use for date time conversion</param>
        /// <returns>The serialized Json string representation of the given object</returns>
        public static string JsonSerialize(object obj, JsonConverter converter = null)
        {
            if (null == obj)
                return null;

            var settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;

            if (converter == null)
                settings.Converters.Add(new IsoDateTimeConverter());
            else
                settings.Converters.Add(converter);

            return JsonConvert.SerializeObject(obj, Formatting.None, settings);
        }

        /// <summary>
        /// JSON Deserialization of the given json string.
        /// </summary>
        /// <param name="json">The json string to deserialize</param>
        /// <param name="converter">The converter to use for date time conversion</param>
        /// <typeparam name="T">The type of the object to desialize into</typeparam>
        /// <returns>The deserialized object</returns>
        public static T JsonDeserialize<T>(string json, JsonConverter converter = null)
        {
            if (string.IsNullOrWhiteSpace(json))
                return default(T);
            if (converter == null)
                return JsonConvert.DeserializeObject<T>(json, new IsoDateTimeConverter());
            else
                return JsonConvert.DeserializeObject<T>(json, converter);
        }

        /// <summary>
        /// Replaces template parameters in the given url
        /// </summary>
        /// <param name="queryUrl">The query url string to replace the template parameters</param>
        /// <param name="parameters">The parameters to replace in the url</param>
        public static void AppendUrlWithTemplateParameters
            (StringBuilder queryBuilder, IEnumerable<KeyValuePair<string, object>> parameters)
        {
            //perform parameter validation
            if (null == queryBuilder)
                throw new ArgumentNullException("queryBuilder");

            if (null == parameters)
                return;

            //iterate and replace parameters
            foreach (KeyValuePair<string, object> pair in parameters)
            {
                string replaceValue = string.Empty;

                //load element value as string
                if (null == pair.Value)
                    replaceValue = "";
                else if (pair.Value is ICollection)
                    replaceValue = flattenCollection(pair.Value as ICollection, ArrayDeserialization.None, '/', false);
                else if (pair.Value is DateTime)
                    replaceValue = ((DateTime)pair.Value).ToString(DateTimeFormat);
                else if (pair.Value is DateTimeOffset)
                    replaceValue = ((DateTimeOffset)pair.Value).ToString(DateTimeFormat);
                else
                    replaceValue = pair.Value.ToString();

                replaceValue = Uri.EscapeUriString(replaceValue);

                //find the template parameter and replace it with its value
                queryBuilder.Replace(string.Format("{{{0}}}", pair.Key), replaceValue);
            }
        }

        /// <summary>
        /// Appends the given set of parameters to the given query string
        /// </summary>
        /// <param name="queryUrl">The query url string to append the parameters</param>
        /// <param name="parameters">The parameters to append</param>
        public static void AppendUrlWithQueryParameters
            (StringBuilder queryBuilder, IEnumerable<KeyValuePair<string, object>> parameters, ArrayDeserialization arrayDeserializationFormat = ArrayDeserialization.UnIndexed, char separator = '&')
        {
            //perform parameter validation
            if (null == queryBuilder)
                throw new ArgumentNullException("queryBuilder");

            if (null == parameters)
                return;

            //does the query string already has parameters
            bool hasParams = (indexOf(queryBuilder, "?") > 0);

            //iterate and append parameters
            foreach (KeyValuePair<string, object> pair in parameters)
            {
                //ignore null values
                if (pair.Value == null)
                    continue;

                //if already has parameters, use the &amp; to append new parameters
                queryBuilder.Append((hasParams) ? '&' : '?');

                //indicate that now the query has some params
                hasParams = true;

                string paramKeyValPair;

                //load element value as string
                if (pair.Value is ICollection)
                    paramKeyValPair = flattenCollection(pair.Value as ICollection, arrayDeserializationFormat, separator, true, pair.Key);
                else if (pair.Value is DateTime)
                    paramKeyValPair = string.Format("{0}={1}", Uri.EscapeDataString(pair.Key), ((DateTime)pair.Value).ToString(DateTimeFormat));
                else if (pair.Value is DateTimeOffset)
                    paramKeyValPair = string.Format("{0}={1}", Uri.EscapeDataString(pair.Key), ((DateTimeOffset)pair.Value).ToString(DateTimeFormat));
                else
                    paramKeyValPair = string.Format("{0}={1}", Uri.EscapeDataString(pair.Key), Uri.EscapeDataString(pair.Value.ToString()));

                //append keyval pair for current parameter
                queryBuilder.Append(paramKeyValPair);
            }
        }

        /// <summary>
        /// StringBuilder extension method to implement IndexOf functionality.
        /// This does a StringComparison.Ordinal kind of comparison.
        /// </summary>
        /// <param name="stringBuilder">The string builder to find the index in</param>
        /// <param name="strCheck">The string to locate in the string builder</param>
        /// <returns>The index of string inside the string builder</returns>
        private static int indexOf(StringBuilder stringBuilder, string strCheck)
        {
            if (stringBuilder == null)
                throw new ArgumentNullException("stringBuilder");

            if (strCheck == null)
                return 0;

            //iterate over the input
            for (int inputCounter = 0; inputCounter < stringBuilder.Length; inputCounter++)
            {
                int matchCounter;

                //attempt to locate a potential match
                for (matchCounter = 0;
                        (matchCounter < strCheck.Length)
                        && (inputCounter + matchCounter < stringBuilder.Length)
                        && (stringBuilder[inputCounter + matchCounter] == strCheck[matchCounter]);
                    matchCounter++) ;

                //verify the match
                if (matchCounter == strCheck.Length)
                    return inputCounter;
            }

            return -1;
        }

        /// <summary>
        /// Validates and processes the given query Url to clean empty slashes
        /// </summary>
        /// <param name="queryBuilder">The given query Url to process</param>
        /// <returns>Clean Url as string</returns>
        public static string CleanUrl(StringBuilder queryBuilder)
        {
            //convert to immutable string
            string url = queryBuilder.ToString();

            //ensure that the urls are absolute
            Match match = Regex.Match(url, "^https?://[^/]+");
            if (!match.Success)
                throw new ArgumentException("Invalid Url format.");

            //remove redundant forward slashes
            int index = url.IndexOf('?');
            string protocol = match.Value;
            string query = url.Substring(protocol.Length, (index == -1 ? url.Length : index) - protocol.Length);
            query = Regex.Replace(query, "//+", "/");
            string parameters = index == -1 ? "" : url.Substring(index);

            //return process url
            return string.Concat(protocol, query, parameters);
        }

        /// <summary>
        /// Used for flattening a collection of objects into a string 
        /// </summary>
        /// <param name="array">Array of elements to flatten</param>
        /// <param name="fmt">Format string to use for array flattening</param>
        /// <param name="separator">Separator to use for string concat</param>
        /// <returns>Representative string made up of array elements</returns>
        private static string flattenCollection(ICollection array, ArrayDeserialization fmt, char separator,
            bool urlEncode, string key = "")
        {
            StringBuilder builder = new StringBuilder();

            string format = string.Empty;
            if (fmt == ArrayDeserialization.UnIndexed)
                format = String.Format("{0}[]={{0}}{{1}}", key);
            else if (fmt == ArrayDeserialization.Indexed)
                format = String.Format("{0}[{{2}}]={{0}}{{1}}", key);
            else if (fmt == ArrayDeserialization.Plain)
                format = String.Format("{0}={{0}}{{1}}", key);
            else if (fmt == ArrayDeserialization.Csv || fmt == ArrayDeserialization.Psv ||
                     fmt == ArrayDeserialization.Tsv)
            {
                builder.Append(String.Format("{0}=", key));
                format = "{0}{1}";
            }
            else
                format = "{0}{1}";

            //append all elements in the array into a string
            int index = 0;
            foreach (object element in array)
                builder.AppendFormat(format, getElementValue(element, urlEncode), separator, index++);
            //remove the last separator, if appended
            if ((builder.Length > 1) && (builder[builder.Length - 1] == separator))
                builder.Length -= 1;

            return builder.ToString();
        }

        private static string getElementValue(object element, bool urlEncode)
        {
            string elemValue = null;

            //replace null values with empty string to maintain index order
            if (null == element)
                elemValue = string.Empty;
            else if (element is DateTime)
                elemValue = ((DateTime) element).ToString(DateTimeFormat);
            else if (element is DateTimeOffset)
                elemValue = ((DateTimeOffset) element).ToString(DateTimeFormat);
            else
                elemValue = element.ToString();

            if (urlEncode)
                elemValue = Uri.EscapeDataString(elemValue);
            return elemValue;
        }

        public static List<KeyValuePair<string, object>> PrepareFormFieldsFromObject(
            string name, object value, List<KeyValuePair<string, object>> keys = null, PropertyInfo propInfo = null, ArrayDeserialization arrayDeserializationFormat = ArrayDeserialization.UnIndexed)
        {
            keys = keys ?? new List<KeyValuePair<string, object>>();

            if (value == null)
            {
                return keys;
            }
            else if (value is Stream)
            {
                keys.Add(new KeyValuePair<string, object>(name,value));
                return keys;
            }
            else if (value is JObject)
            {
                var valueAccept = (value as JObject);
                foreach (var property in valueAccept.Properties())
                {
                    string pKey = property.Name;
                    object pValue = property.Value;
                    var fullSubName = name + '[' + pKey + ']';
                    PrepareFormFieldsFromObject(fullSubName, pValue, keys, propInfo,arrayDeserializationFormat);
                }
            }
            else if (value is IList)
            {
                var enumerator = ((IEnumerable) value).GetEnumerator();

                var hasNested = false;
                while (enumerator.MoveNext())
                {
                    var subValue = enumerator.Current;
                    if (subValue != null && (subValue is JObject || subValue is IList || subValue is IDictionary || !(subValue.GetType().Namespace.StartsWith("System"))))
                    {
                        hasNested = true;
                        break;
                    }
                }

                int i = 0;
                enumerator.Reset();
                while (enumerator.MoveNext())
                {
                    var fullSubName = name + '[' + i + ']';
                    if (!hasNested && arrayDeserializationFormat == ArrayDeserialization.UnIndexed)
                        fullSubName = name + "[]";
                    else if (!hasNested && arrayDeserializationFormat == ArrayDeserialization.Plain)
                        fullSubName = name;
                    
                    var subValue = enumerator.Current;
                    if (subValue == null) continue;
                    PrepareFormFieldsFromObject(fullSubName, subValue, keys, propInfo,arrayDeserializationFormat);
                    i++;
                }
            }
            else if (value is JToken)
            {
                keys.Add(new KeyValuePair<string, object>(name, value.ToString()));
            }
            else if (value is Enum)
            {
#if WINDOWS_UWP || NETSTANDARD1_3
                Assembly thisAssembly = typeof(ApiHelper).GetTypeInfo().Assembly;
#else
                Assembly thisAssembly = Assembly.GetExecutingAssembly();
#endif
                string enumTypeName = value.GetType().FullName;
                Type enumHelperType = thisAssembly.GetType(string.Format("{0}Helper", enumTypeName));
                object enumValue = (int) value;

                if (enumHelperType != null)
                {
                    //this enum has an associated helper, use that to load the value
#if NETSTANDARD1_3
                    MethodInfo enumHelperMethod = enumHelperType.GetRuntimeMethod("ToValue", new[] { value.GetType() });
#else
                    MethodInfo enumHelperMethod = enumHelperType.GetMethod("ToValue", new[] { value.GetType() });
#endif
                    if (enumHelperMethod != null)
                        enumValue = enumHelperMethod.Invoke(null, new object[] {value});
                }

                keys.Add(new KeyValuePair<string, object>(name, enumValue));
            }
            else if (value is IDictionary)
            {
                var obj = (IDictionary) value;
                foreach (var sName in obj.Keys)
                {
                    var subName = sName.ToString();
                    var subValue = obj[subName];
                    string fullSubName = string.IsNullOrWhiteSpace(name) ? subName : name + '[' + subName + ']';
                    PrepareFormFieldsFromObject(fullSubName, subValue, keys, propInfo,arrayDeserializationFormat);
                }
            }
            else if (!(value.GetType().Namespace.StartsWith("System")))
            {
                //Custom object Iterate through its properties
#if NETSTANDARD1_3
                var enumerator = value.GetType().GetRuntimeProperties().GetEnumerator();
#else
                var enumerator = value.GetType().GetProperties().GetEnumerator();;
#endif
                PropertyInfo pInfo = null;
                var t = new JsonPropertyAttribute().GetType();
                while (enumerator.MoveNext())
                {
                    pInfo = enumerator.Current as PropertyInfo;

                    var jsonProperty = (JsonPropertyAttribute) pInfo.GetCustomAttributes(t, true).FirstOrDefault();
                    var subName = (jsonProperty != null) ? jsonProperty.PropertyName : pInfo.Name;
                    string fullSubName = string.IsNullOrWhiteSpace(name) ? subName : name + '[' + subName + ']';
                    var subValue = pInfo.GetValue(value, null);
                    PrepareFormFieldsFromObject(fullSubName, subValue, keys, pInfo,arrayDeserializationFormat);
                }
            }
            else if (value is DateTime)
            {
                string convertedValue = null;
#if NETSTANDARD1_3
                IEnumerable<Attribute> pInfo = null;
#else
                object[] pInfo = null;
#endif
                if(propInfo!=null)
                    pInfo = propInfo.GetCustomAttributes(true);
                if (pInfo != null)
                {
                    foreach (object attr in pInfo)
                    {
                        JsonConverterAttribute converterAttr = attr as JsonConverterAttribute;
                        if (converterAttr != null)
                            convertedValue =
                                JsonSerialize(value,
                                    (JsonConverter)
                                        Activator.CreateInstance(converterAttr.ConverterType,
                                            converterAttr.ConverterParameters)).Replace("\"", "");
                    }
                }
                keys.Add(new KeyValuePair<string, object>(name, (convertedValue) ?? ((DateTime)value).ToString(DateTimeFormat)));
            }
            else
            {
                keys.Add(new KeyValuePair<string, object>(name,value));
            }
            return keys;
        }

        /// <summary>
        /// Add/update entries with the new dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="dictionary2"></param>
        public static void Add(this Dictionary<string, object> dictionary, Dictionary<string, object> dictionary2)
        {
            foreach (var kvp in dictionary2)
            {
                dictionary[kvp.Key] = kvp.Value;
            }
        }

        /// <summary>
        /// Runs asynchronous tasks synchronously and throws the first caught exception
        /// </summary>
        /// <param name="t">The task to be run synchronously</param>
        public static void RunTaskSynchronously(Task t)
        {
            try
            {
                t.Wait();
            }
            catch (AggregateException e)
            {
                if (e.InnerExceptions.Count > 0)
                    throw e.InnerExceptions[0];
                else
                    throw;
            }
        }
    }
}
