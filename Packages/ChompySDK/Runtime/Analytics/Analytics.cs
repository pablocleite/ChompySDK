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
		    if (!nativeBridge.IsInitialized) { throw new AnalyticsException("Analytics is not initialized."); }
		    
        	Debug.Log($"[Analytics] Event Tracked: {analyticsEvent.Name}");
    	}
	}
}