using System;

namespace ChompySDK.Analytics.Events
{
    public class EventParam
    {
        public string Name { get; protected set; }
        public ParamType Type { get; protected set; }
        public object Value { get; protected set; }

        protected EventParam(string name, ParamType type, object value)
        {
            Name = name;
            Type = type;
            Value = value;
        }
    }
    
    public class EventParam<T>: EventParam
    {
        public new T Value { get; private set; }

        public EventParam(string name, T value): base(name, GetParamType(typeof(T)), value)
        {
            Value = value;
        }

        private static ParamType GetParamType(Type type)
        {
            if (type == typeof(int)) return ParamType.Integer;
            if (type == typeof(float) || type == typeof(double)) return ParamType.Float;
            if (type == typeof(string)) return ParamType.String;
            if (type == typeof(bool)) return ParamType.Boolean;
            if (type == typeof(DateTime)) return ParamType.Date;
            
            return ParamType.Object;
        }
    }
}