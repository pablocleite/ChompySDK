using System;
using ChompySDK.Analytics.Events;
using NUnit.Framework;

namespace ChompySDK.Tests.Analytics.Events
{
    [TestFixture]
    [TestOf(typeof(AnalyticsEvent))]
    public class AnalyticsEventTest
    {
        [Test]
        public void AnalyticsEvent_ShouldInitWithName()
        {
            var testEvent = new AnalyticsEvent("TestEvent");
            
            Assert.AreEqual("TestEvent", testEvent.Name);
            Assert.NotNull(testEvent.Params);
            Assert.AreEqual(0, testEvent.Params.Count);
        }
        
        [Test]
        public void AnalyticsEvent_ShouldAddParamReturnThis()
        {
            var testEvent = new AnalyticsEvent("TestEvent");
            var addParamReturn = testEvent.AddParam("TestParam", "TestValue");
            
            Assert.AreSame(testEvent, addParamReturn);
        }
        
        [Test]
        public void AnalyticsEvent_ShouldAddStringParam()
        {
            var testEvent = new AnalyticsEvent("TestEvent");
            testEvent.AddParam("TestParam", "StringValue");
            
            Assert.AreEqual(1, testEvent.Params.Count);
            Assert.AreEqual("TestParam", testEvent.Params[0].Name);
            Assert.AreEqual("StringValue", testEvent.Params[0].Value);
            Assert.AreEqual(ParamType.String, testEvent.Params[0].Type);
        }
        
        [Test]
        public void AnalyticsEvent_ShouldAddIntParam()
        {
            var testEvent = new AnalyticsEvent("TestEvent");
            testEvent.AddParam("TestParam", 42);
            
            Assert.AreEqual(1, testEvent.Params.Count);
            Assert.AreEqual("TestParam", testEvent.Params[0].Name);
            Assert.AreEqual(42, testEvent.Params[0].Value);
            Assert.AreEqual(ParamType.Integer, testEvent.Params[0].Type);
        }
        
        [Test]
        public void AnalyticsEvent_ShouldAddFloatParam()
        {
            var testEvent = new AnalyticsEvent("TestEvent");
            testEvent.AddParam("TestParam", 42.0f);
            
            Assert.AreEqual(1, testEvent.Params.Count);
            Assert.AreEqual("TestParam", testEvent.Params[0].Name);
            Assert.AreEqual(42.0f, testEvent.Params[0].Value);
            Assert.AreEqual(ParamType.Float, testEvent.Params[0].Type);
        }
        
        [Test]
        public void AnalyticsEvent_ShouldAddBooleanParam()
        {
            var testEvent = new AnalyticsEvent("TestEvent");
            testEvent.AddParam("TestParam", true);
            
            Assert.AreEqual(1, testEvent.Params.Count);
            Assert.AreEqual("TestParam", testEvent.Params[0].Name);
            Assert.AreEqual(true, testEvent.Params[0].Value);
            Assert.AreEqual(ParamType.Boolean, testEvent.Params[0].Type);
        }
        
        [Test]
        public void AnalyticsEvent_ShouldAddDateParam()
        {
            var testEvent = new AnalyticsEvent("TestEvent");
            testEvent.AddParam("TestParam", new DateTime(2042, 1, 1));
            
            Assert.AreEqual(1, testEvent.Params.Count);
            Assert.AreEqual("TestParam", testEvent.Params[0].Name);
            Assert.AreEqual(new DateTime(2042, 1, 1), testEvent.Params[0].Value);
            Assert.AreEqual(ParamType.Date, testEvent.Params[0].Type);
        }
        
        [Test]
        public void AnalyticsEvent_ShouldAddMultipleParams()
        {
            var testEvent = new AnalyticsEvent("TestEvent");
            testEvent
                .AddParam("StringParam", "StringValue")
                .AddParam("IntValue", 42)
                .AddParam("FloatValue", 42.0f)
                .AddParam("DoubleValue", 42.0d)
                .AddParam("DateValue", new DateTime(2042, 1, 1))
                .AddParam("BoolValue", true);
            
            Assert.AreEqual(6, testEvent.Params.Count);
        }
    }
}