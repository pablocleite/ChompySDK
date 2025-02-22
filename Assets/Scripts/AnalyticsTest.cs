using UnityEngine;
using ChompySDK.Analytics;

public class AnalyticsTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var analytics = new Analytics();
        analytics.Init();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
