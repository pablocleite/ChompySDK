
using System.Collections.Generic;

namespace ChompySDK.Analytics.Events
{
    public interface IAnalyticsEvent
    {
        string Name { get; }
        List<EventParam> Params { get; }
    }
}