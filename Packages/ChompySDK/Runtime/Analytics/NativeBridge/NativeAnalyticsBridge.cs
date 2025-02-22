using ChompySDK.Analytics.Events;

namespace ChompySDK.Analytics.NativeBridge
{
    public interface NativeAnalyticsBridge
    {
        bool IsInitialized { get; }
        
        void Init();
        
        void LogEvent(AnalyticsEvent analyticsEvent);
    }
}