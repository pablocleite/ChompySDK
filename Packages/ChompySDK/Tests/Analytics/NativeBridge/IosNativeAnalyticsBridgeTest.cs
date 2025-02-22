using ChompySDK.Analytics.Events;
using ChompySDK.Analytics.NativeBridge;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace ChompySDK.Tests.Analytics.NativeBridge
{
    [TestFixture]
    [TestOf(typeof(IosNativeAnalyticsBridge))]
    public class IosNativeAnalyticsBridgeTest
    {

        [Test]
        public void IosNativeAnalyticsBridge_ShouldInit()
        {
            var testBridge = new IosNativeAnalyticsBridge();
            
            testBridge.Init();
            Assert.IsTrue(testBridge.IsInitialized);
            LogAssert.Expect("[Mock] Initializing iOS Analytics Bridge");
        }
        
        [Test]
        public void IosNativeAnalyticsBridge_ShouldLogEventWithNoParams()
        {
            var testBridge = new IosNativeAnalyticsBridge();
            var testEvent = new AnalyticsEvent("testEvent");
            
            testBridge.LogEvent(testEvent);
            LogAssert.Expect("[Mock] Logging event: testEvent, with parameter count: 0; ");
        }
    }
}