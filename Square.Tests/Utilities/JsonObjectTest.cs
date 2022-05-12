using Newtonsoft.Json;
using NUnit.Framework;
using Square.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace Square.Tests.Utilities
{
    [TestFixture]
    public class JsonObjectTest
    {
        [Test]
        public void EmptyObjectTest()
        {
            JsonObject obj = JsonObject.FromJsonString("{}");
            Assert.AreEqual("{}", obj.ToString());
            Assert.AreEqual(new Dictionary<string, object>(), obj.GetStoredObject());
        }

        [Test]
        public void NonEmptyObjectTest()
        {
            JsonObject obj = JsonObject.FromJsonString("{\n"
                + "  \"stringProp\": \"test 1\",\n"
                + "  \"boolProp\": true,\n"
                + "  \"numProp\": 5.12,\n"
                + "  \"arrayProp\": [\"test 2\"],\n"
                + "  \"objProp\": {\n"
                + "    \"childProp\": true\n"
                + "  },\n"
                + "  \"nullProp\": null\n"
                + "}");

            Assert.AreEqual("{\"stringProp\":\"test 1\",\"boolProp\":true,\"numProp\":5.12,\"arrayProp\":[\"test 2\"],\"objProp\":{\"childProp\":true},\"nullProp\":null}", obj.ToString());

            var expected = new TestObject
            {
                stringProp = "test 1",
                boolProp = true,
                numProp = 5.12,
                arrayProp = new [] { "test 2" },
                objProp = new TestObject.TestChildObject
                {
                    childProp = true
                },
                nullProp = null
            };
            var deserialiedObj = obj.GetStoredObject().ToObject<TestObject>();
            Assert.AreEqual(expected, deserialiedObj);
        }

        private class TestObject
        {
            public string stringProp { get; set; }
            public bool boolProp { get; set; }
            public double numProp { get; set; }
            public string[] arrayProp { get; set; }
            public TestChildObject objProp { get; set; }
            public string nullProp { get; set; }

            public override bool Equals(object obj)
            {
                var other = obj as TestObject;
                if (other == null) return false;
                return stringProp.Equals(other.stringProp) &&
                    boolProp.Equals(other.boolProp) &&
                    numProp.Equals(other.numProp) &&
                    Enumerable.SequenceEqual(arrayProp, other.arrayProp) &&
                    objProp.Equals(other.objProp) &&
                    nullProp == other.nullProp;
            }

            public override int GetHashCode()
            {
                return stringProp.GetHashCode() ^
                    boolProp.GetHashCode() ^
                    numProp.GetHashCode() ^
                    arrayProp.GetHashCode() ^
                    objProp.GetHashCode() ^
                    nullProp?.GetHashCode() ?? 0;
            }

            public class TestChildObject
            {
                public bool childProp { get; set; }

                public override bool Equals(object obj)
                {
                    var other = obj as TestChildObject;
                    if (other == null) return false;
                    return childProp.Equals(other.childProp);
                }

                public override int GetHashCode()
                {
                    return childProp.GetHashCode();
                }
            }
        }

        [Test]
        public void NonObjectTest()
        {
            var ex = Assert.Throws<JsonReaderException>(() => JsonObject.FromJsonString("true"));
            Assert.AreEqual("Error reading JObject from JsonReader. Current JsonReader item is not an object: Boolean. Path '', line 1, position 4.", ex.Message);
            ex = Assert.Throws<JsonReaderException>(() => JsonObject.FromJsonString("\"hello world\""));
            Assert.AreEqual("Error reading JObject from JsonReader. Current JsonReader item is not an object: String. Path '', line 1, position 13.", ex.Message);
            ex = Assert.Throws<JsonReaderException>(() => JsonObject.FromJsonString("123"));
            Assert.AreEqual("Error reading JObject from JsonReader. Current JsonReader item is not an object: Integer. Path '', line 1, position 3.", ex.Message);
            ex = Assert.Throws<JsonReaderException>(() => JsonObject.FromJsonString("[]"));
            Assert.AreEqual("Error reading JObject from JsonReader. Current JsonReader item is not an object: StartArray. Path '', line 1, position 1.", ex.Message);
        }
    }
}
