using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Square;
using Square.Utilities;
using Square.Http.Client;
using Square.Http.Request;
using Square.Http.Response;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;

namespace Square.Helpers
{
    static class TestHelper
    {
        /// <summary>
        /// Convert an InputStream to a string (utility function)
        /// </summary>
        /// <param name="inStream">The input stream to read</param>
        /// <returns>string read from the stream</returns>
        internal static string ConvertStreamToString(Stream inStream)
        {
            using (StreamReader reader = new StreamReader(inStream))
            {
                var str = reader.ReadToEnd();
                return str;
            }
        }

        /// <summary>
        /// Recursively check whether the leftTree is a proper subset of the right tree
        /// </summary>
        /// <param name="lefrTree">Left tree</param>
        /// <param name="rightTree">Right tree</param>
        /// <param name="checkValues">Check primitive values for equality?</param>
        /// <param name="allowExtra">Are extra elements allowed in right array?</param>
        /// <param name="isOrdered">Should elements in right be compared in order to left?</param>
        /// <returns></returns>
        private static bool IsProperSubsetOf(
            JObject leftTree,
            JObject rightTree,
            bool checkValues, bool allowExtra, bool isOrdered)
        {
            foreach (var property in leftTree.Properties())
            {
                // Check if key exists
                if (rightTree.Property(property.Name) == null)
                    return false;

                object leftVal = property.Value;
                object rightVal = rightTree.Property(property.Name).Value;

                if (leftVal is JObject)
                {
                    // If left value is tree, right value should be be tree too
                    if (rightVal is JObject)
                    {
                        if (!IsProperSubsetOf(
                                (JObject)leftVal,
                                (JObject)rightVal,
                                checkValues, allowExtra, isOrdered))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    // Value comparison if checkValues 
                    if (checkValues)
                    {
                        // If left value is a primitive, check if it equals right value
                        if (leftVal == null)
                        {
                            if (rightVal != null)
                            {
                                return false;
                            }
                        }
                        else if (leftVal is JArray)
                        {
                            if (!(rightVal is JArray))
                                return false;

                            //is array of objects
                            if (((JArray)leftVal).First is JObject)
                            {
                                if (!IsArrayOfJsonObjectsProperSubsetOf(
                                        (JArray)leftVal,
                                        (JArray)rightVal,
                                        checkValues, allowExtra, isOrdered))
                                    return false;
                            }
                            else
                            {
                                if (!IsListProperSubsetOf(
                                        (JArray)leftVal,
                                        (JArray)rightVal,
                                        allowExtra, isOrdered))
                                    return false;
                            }
                        }
                        else if (!leftVal.Equals(rightVal))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Check if left array of objects is a subset of right array
        /// </summary>
        /// <param name="leftObject">Left array as a JSON string</param>
        /// <param name="rightObject">Right array as a JSON string</param>
        /// <param name="checkValues">Check primitive values for equality?</param>
        /// <param name="allowExtra">Are extra elements allowed in right array?</param>
        /// <param name="isOrdered">Should elements in right be compared in order to left?</param>
        /// <returns>True if it is a subset</returns>
        public static bool IsArrayOfJsonObjectsProperSubsetOf(
            string leftObject, string rightObject,
            bool checkValues, bool allowExtra, bool isOrdered)
        {
            // Deserialize left and right objects from their respective strings
            JArray left = ApiHelper.JsonDeserialize<dynamic>(leftObject);
            JArray right = ApiHelper.JsonDeserialize<dynamic>(rightObject);

            return IsArrayOfJsonObjectsProperSubsetOf(left, right, checkValues, allowExtra, isOrdered);
        }

        /// <summary>
        /// Check if left array of objects is a subset of right array
        /// </summary>
        /// <param name="leftList">Left array</param>
        /// <param name="rightList">Right array</param>
        /// <param name="checkValues">Check primitive values for equality?</param>
        /// <param name="allowExtra">Are extra elements allowed in right array?</param>
        /// <param name="isOrdered">Should elements in right be compared in order to left?</param>
        /// <returns>True if it is a subset</returns>
        public static bool IsArrayOfJsonObjectsProperSubsetOf(
                JArray leftList,
                JArray rightList,
                bool checkValues, bool allowExtra, bool isOrdered)
        {
            // Return false if size different and checking was strict
            if ((!allowExtra) && (rightList.Count != leftList.Count))
                return false;

            // Create list iterators
            var leftIter = leftList.GetEnumerator();
            var rightIter = rightList.GetEnumerator();

            // Iterate left list and check if each value is present in the right list
            while (leftIter.MoveNext())
            {
                var leftTree = leftIter.Current;
                bool found = false;

                //restart right iterator if ordered comparision is not required
                if (!isOrdered)
                    rightIter = rightList.GetEnumerator();

                while (rightIter.MoveNext())
                {
                    if (IsProperSubsetOf((JObject)leftTree, (JObject)rightIter.Current, checkValues, allowExtra, isOrdered))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Check whether the a list (as JSON string) is a subset of another list (as JSON string)
        /// </summary>
        /// <param name="leftList">Expected List</param>
        /// <param name="rightList">List to check</param>
        /// <param name="allowExtra">Are extras allowed in the list to check?</param>
        /// <param name="isOrdered">Should checking be in order?</param>
        /// <returns></returns>
        public static bool IsListProperSubsetOf(string leftListJson, string rightListJson,
                bool allowExtra, bool isOrdered)
        {
            // Deserialize left and right lists from their respective strings
            JArray left = ApiHelper.JsonDeserialize<dynamic>(leftListJson);
            JArray right = ApiHelper.JsonDeserialize<dynamic>(rightListJson);

            return IsListProperSubsetOf(left, right, allowExtra, isOrdered);
        }

        /// <summary>
        /// Check whether the a list is a subset of another list
        /// </summary>
        /// <param name="leftList">Expected List</param>
        /// <param name="rightList">List to check</param>
        /// <param name="allowExtra">Are extras allowed in the list to check?</param>
        /// <param name="isOrdered">Should checking be in order?</param>
        /// <returns></returns>
        public static bool IsListProperSubsetOf(JArray leftList, JArray rightList,
                bool allowExtra, bool isOrdered)
        {
            if (isOrdered)
            {
                if ((!allowExtra) && (rightList.Count != leftList.Count))
                    return false;

                else if (rightList.Count < leftList.Count)
                    return false;

                int rIndex = 0, lIndex = 0;
                while (rIndex < rightList.Count)
                {
                    if(rightList[rIndex].ToString() == leftList[lIndex].ToString())
                    {
                        lIndex++;
                    }
                    rIndex++;
                }

                return (lIndex == leftList.Count);
            }
            else
            {
                if ((!allowExtra) && (rightList.Count != leftList.Count))
                    return false;

                HashSet<object> rHashSet = new HashSet<object>(rightList);
                return rHashSet.IsSupersetOf(leftList);
            }
        }

        /// <summary>
        /// Recursively check whether the left JSON object is a proper subset of the right JSON object
        /// </summary>
        /// <param name="leftObject">Left JSON object as string</param>
        /// <param name="rightObject">rightObject Right JSON object as string</param>
        /// <param name="checkValues">Check primitive values for equality?</param>
        /// <param name="allowExtra">Are extra elements allowed in right array?</param>
        /// <param name="isOrdered">Should elements in right be compared in order to left?</param>
        /// <returns>True, if the given object is a proper subset of other other</returns>
        internal static bool IsJsonObjectProperSubsetOf(string leftObject, string rightObject,
                bool checkValues, bool allowExtra, bool isOrdered)
        {
            return IsProperSubsetOf(
                ApiHelper.JsonDeserialize<dynamic>(leftObject),
                ApiHelper.JsonDeserialize<dynamic>(rightObject),
                checkValues, allowExtra, isOrdered);
        }

        /// <summary>
        /// Recursively check whether the left headers map is a proper subset of the right headers map
        /// </summary>
        /// <param name="leftDict">Left headers map</param>
        /// <param name="rightDict">Right headers map</param>
        /// <returns></returns>
        public static bool AreHeadersProperSubsetOf(
            Dictionary<string, string> leftDict, Dictionary<string, string> rightDict)
        {
            Dictionary<string, string> leftDictInv = new Dictionary<string, string>(leftDict, StringComparer.CurrentCultureIgnoreCase);
            Dictionary<string, string> rightDictInv = new Dictionary<string, string>(rightDict, StringComparer.CurrentCultureIgnoreCase);
            foreach (var leftKey in leftDictInv.Keys)
            {
                if (!leftDictInv.ContainsKey(leftKey))
                    return false;

                if (null == leftDictInv[leftKey])
                    continue;

                if (!leftDictInv[leftKey].Equals(rightDictInv[leftKey]))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Compare the input stream to file byte-by-byte
        /// </summary>
        /// <param name="file">First input</param>
        /// <param name="input">Second input</param>
        /// <returns>True if stream contains the same content as the file</returns>
        public static bool IsSameAsFile(string file, Stream input)
        {
            return IsSameInputStream(GetFile(file).FileStream, input);
        }

        /// <summary>
        /// Compare two input streams
        /// </summary>
        /// <param name="input1">First stream</param>
        /// <param name="input2">Second stream</param>
        /// <returns>True if streams contain the same content</returns>
        public static bool IsSameInputStream(Stream input1, Stream input2)
        {
            if (input1 == input2)
            {
                return true;
            }

            int ch = input1.ReadByte();
            while (ch != -1)
            {
                int ch2 = input2.ReadByte();
                if (ch != ch2)
                {
                    return false;
                }
                ch = input1.ReadByte();
            }

            //should reach end of stream
            bool input2Finished = (input2.ReadByte() == -1);

            try { input1.Dispose(); } catch { }
            try { input2.Dispose(); } catch { }

            return input2Finished;
        }

        /// <summary>
        /// Downloads a given url and return a path to its local version.
        /// Files are cached.Second call for the same URL will return cached version.
        /// </summary>
        /// <param name="url">URL to download</param>
        /// <returns>Absolute path to the local downloaded version of file</returns>
        public static FileStreamInfo GetFile(string url)
        {
            string originalFileName = Path.GetFileName(url);
            string filename = "sdk_tests" + toSHA1(url) + ".tmp";
            string tmpPath = Path.GetTempPath();
            string filePath = Path.Combine(tmpPath, filename);
            FileInfo fileInfo = new FileInfo(filePath);
            FileStream fileStream = null;

            // if file does not exist locally, download it
            if (!fileInfo.Exists)
            {
                IHttpClient client = new HttpClientWrapper();
                HttpRequest req = client.Get(url);
                
                HttpResponse resp = client.ExecuteAsBinary(req);
                fileStream = System.IO.File.Create(filePath);
                byte[] buffer = new byte[2048];
                int len = resp.RawBody.Read(buffer, 0, 2048);

                while (len > 0)
                {
                    fileStream.Write(buffer, 0, len);
                    len = resp.RawBody.Read(buffer, 0, 2048);
                }
                fileStream.Position = 0;
            }
            else
            {
                fileStream = System.IO.File.OpenRead(filePath);
            }

            return new FileStreamInfo(fileStream, originalFileName);
        }

        /// <summary>
        /// Get SHA1 hash of a string
        /// </summary>
        /// <param name="convertme">The string to convert</param>
        /// <returns>SHA1 hash</returns>
        public static string toSHA1(string convertme)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(convertme);
            using (var sha1 = SHA1.Create())
            {
                byte[] hashBytes = sha1.ComputeHash(bytes);
                return ByteArrayToHexString(hashBytes);
            }
        }

        /// <summary>
        /// Convert byte array to the hexadecimal representation in string
        /// </summary>
        /// <param name="bytes">Byte array to convert</param>
        /// <returns>Hex representation in string</returns>
        public static string ByteArrayToHexString(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Checks if the left items set is the superset of right items set
        /// </summary>
        /// <typeparam name="T">Type of items</typeparam>
        /// <param name="left">Left items set</param>
        /// <param name="right">Right items set</param>
        /// <returns>True if the left has all items of right</returns>
        public static bool IsSuperSetOf<T>(this IEnumerable<T> left, IEnumerable<T> right)
        {
            HashSet<T> lHashSet = new HashSet<T>(left);
            return lHashSet.IsSupersetOf(right);
        }

        /// <summary>
        /// Checks if the left items ordered set is the ordered superset of right items ordered set
        /// </summary>
        /// <typeparam name="T">Type of items</typeparam>
        /// <param name="left">Left items set</param>
        /// <param name="right">Right items set</param>
        /// <param name="checkSize">Should the size of left and right be equal as well</param>
        /// <returns>True if the left has all items of right in the same order</returns>
        public static bool IsOrderedSupersetOf<T>(this IEnumerable<T> left, IEnumerable<T> right, bool checkSize = false)
        {
            var lItr = left.GetEnumerator();
            var rItr = right.GetEnumerator();

            while(lItr.MoveNext())
            {
                T lCurrent = lItr.Current;

                //right list ended prematurely
                if (!rItr.MoveNext())
                    return false;

                T rCurrent = rItr.Current;

                if (!lCurrent.Equals(rCurrent))
                    return false;
            }

            //left and right should also of the same size
            if(checkSize)
            {
                //right items should have been exhaustively read?
                if (rItr.MoveNext())
                    return false;
            }

            return true;
        }
    }
}