using ChompySDK.Analytics.Events;
using UnityEngine;

namespace ChompySDK.Analytics
{
    public class Analytics
    {
	    public bool IsInitialized { get; private set; } = false;
	    
	    public void Init()
	    {
		    IsInitialized = true;    
	    }
	    
    	public void LogEvent(AnalyticsEvent analyticsEvent)
    	{
		    if (!IsInitialized) { throw new AnalyticsException("Analytics is not initialized."); }
		    
        	Debug.Log($"[Analytics] Event Tracked: {analyticsEvent.Name}");
    	}
	}
}