using NUnit.Framework;
using Square.Models;
using Square.Utilities;
using System.Collections.Generic;

namespace Square.Tests.Utilities
{
    [TestFixture]
    public class JsonValueTest
    {
        [Test]
        public void StringValueTest()
        {
            JsonValue value = JsonValue.FromString("hello world");
            Assert.AreEqual("\"hello world\"", value.ToString());
            value = JsonValue.FromString("null");
            Assert.AreEqual("\"null\"", value.ToString());
            value = JsonValue.FromString(null);
            Assert.AreEqual("null", value.ToString());
        }

        [Test]
        public void BooleanValueTest()
        {
            JsonValue value = JsonValue.FromBoolean(true);
            Assert.AreEqual("true", value.ToString());
            value = JsonValue.FromBoolean(null);
            Assert.AreEqual("null", value.ToString());
        }

        [Test]
        public void IntegerValueTest()
        {
            JsonValue value = JsonValue.FromInteger(123);
            Assert.AreEqual("123", value.ToString());
            value = JsonValue.FromInteger(null);
            Assert.AreEqual("null", value.ToString());
        }

        [Test]
        public void LongValueTest()
        {
            JsonValue value = JsonValue.FromLong(123L);
            Assert.AreEqual("123", value.ToString());
            value = JsonValue.FromLong(null);
            Assert.AreEqual("null", value.ToString());
        }

        [Test]
        public void DoubleValueTest()
        {
            JsonValue value = JsonValue.FromDouble(123D);
            Assert.AreEqual("123.0", value.ToString());
            value = JsonValue.FromDouble(null);
            Assert.AreEqual("null", value.ToString());
        }

        [Test]
        public void ObjectValueTest()
        {
            JsonValue value = JsonValue.FromObject(new BusinessHoursPeriod("Monday", "0800", "1700"));
            Assert.AreEqual("{\"day_of_week\":\"Monday\",\"start_local_time\":\"0800\",\"end_local_time\":\"1700\"}", value.ToString());
            value = JsonValue.FromObject(null);
            Assert.AreEqual("null", value.ToString());
        }

        [Test]
        public void ArrayValueTest()
        {
            JsonValue value = JsonValue.FromArray(new List<string> { "val1", "val2" });
            Assert.AreEqual("[\"val1\",\"val2\"]", value.ToString());
            value = JsonValue.FromArray<string>(null);
            Assert.AreEqual("null", value.ToString());
        }
    }
}
