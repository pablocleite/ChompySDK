using ChompySDK.Analytics.Events;
using ChompySDK.Analytics.NativeBridge;
using UnityEngine;

namespace ChompySDK.Analytics
{
    public class Analytics
    {
	    public bool IsInitialized { get; private set; } = false;
	    private NativeAnalyticsBridge nativeBridge = NativeAnalyticsBridgeFactory.Get();
	    
	    public void Init()
	    {
		    nativeBridge.Init();
	    }
	    
    	public void LogEvent(AnalyticsEvent analyticsEvent)
    	{
		    //TODO: Implement the getter from native side
		    // if (!nativeBridge.IsInitialized) { throw new AnalyticsException("Analytics is not initialized."); }
		    
		    nativeBridge.LogEvent(analyticsEvent);
		    
        	Debug.Log($"[Analytics] Event Tracked: {analyticsEvent.Name}");
    	}
	}
}