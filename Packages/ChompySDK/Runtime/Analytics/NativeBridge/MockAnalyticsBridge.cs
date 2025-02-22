using ChompySDK.Analytics.Events;
using UnityEngine;

namespace ChompySDK.Analytics.NativeBridge
{
    public class MockAnalyticsBridge : NativeAnalyticsBridge
    {
        public bool IsInitialized { get; private set; }
        
        public void Init()
        {
            Debug.Log($"[MockAnalyticsBridge] Initializing...");
            
            IsInitialized = true;
        }

        public void LogEvent(AnalyticsEvent analyticsEvent)
        {
            Debug.Log($"[MockAnalyticsBridge] Logging event ${analyticsEvent.Name}");
        }
    }
}