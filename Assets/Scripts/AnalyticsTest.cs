using UnityEngine;
using ChompySDK.Analytics;
using ChompySDK.Analytics.Events;

public class AnalyticsTest : MonoBehaviour
{
    private Analytics analytics = new Analytics();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        analytics.Init();

        var analyticsEvent = new AnalyticsEvent("TestEvent");
        analytics.LogEvent(analyticsEvent);
    }

    public void OnLogEventBtnClicked()
    {
        var analyticsEvent = new AnalyticsEvent("TestEvent");
        analytics.LogEvent(analyticsEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
