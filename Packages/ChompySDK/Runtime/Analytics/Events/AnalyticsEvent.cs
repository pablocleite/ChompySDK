using System.Collections.Generic;

namespace ChompySDK.Analytics.Events
{
    public class AnalyticsEvent : IAnalyticsEvent
    {
        public string Name { get; protected set; }
        public List<EventParam> Params { get; protected set; }

        public AnalyticsEvent(string name, List<EventParam> eventParams = null)
        {
            Name = name;
            Params = eventParams ?? new List<EventParam>();
        }

        public AnalyticsEvent AddParam<T>(string name, T value)
        {
            Params.Add(new EventParam<T>(name, value));
            
            return this;
        }
    }
}