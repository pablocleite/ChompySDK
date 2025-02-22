using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ChompySDK.Analytics.Events;
using UnityEngine;

namespace ChompySDK.Analytics.NativeBridge
{
    public class IosNativeAnalyticsBridge: NativeAnalyticsBridge
    {
        [DllImport("__Internal")]
        private static extern void _init();
        
        //Best to avoid strings and serialization, taking advantage of ObjC Extern C functions performance
        [DllImport("__Internal")]
        private static extern void _logEvent(
            string eventName,
            string[] paramKeys,
            string[] paramValues,
            string[] paramTypes,
            int paramCount
        );
        
        public bool IsInitialized { get; private set; }
        
        public void Init()
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                _init();
            }
            else
            {
                Debug.Log("[Mock] Initializing iOS Analytics Bridge");
                IsInitialized = true;
            }
        }

        public void LogEvent(AnalyticsEvent analyticsEvent)
        {
            string eventName = analyticsEvent.Name;
            int paramCount = analyticsEvent.Params.Count;
            
            string[] paramKeys = new string[paramCount];
            string[] paramValues = new string[paramCount];
            string[] paramTypes = new string[paramCount];
            
            //Using for as foreach requires an enumerator allocation which can put pressure on GC
            //it also boxes var unnecessarily due to enumerator.
            for (var i = 0; i < analyticsEvent.Params.Count; i++)
            {
                paramKeys[i] = analyticsEvent.Params[i].Name;
                paramValues[i] = analyticsEvent.Params[i].Value.ToString();
                paramTypes[i] = analyticsEvent.Params[i].Type.ToString();
            }
            
            LogEvent(eventName, paramKeys, paramValues, paramTypes, paramCount);
        }

        private static void LogEvent(string analyticsEvent, string[] paramKeys, string[] paramValues, string[] paramTypes, int paramCount)
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                _logEvent(analyticsEvent, paramKeys, paramValues, paramTypes, paramCount);
            }
            else
            {
                MockNativeLogEvent(analyticsEvent, paramKeys, paramValues, paramTypes, paramCount);
            }
        }

        private static void MockNativeLogEvent(string analyticsEvent, string[] paramKeys, string[] paramValues, string[] paramTypes, int paramCount)
        {
            var paramsString = new string[paramCount];
            for (var i = 0; i < paramCount; i++)
            {
                var paramKey = paramKeys[i];
                var paramValue = paramValues[i];
                var paramType = paramTypes[i];
                    
                paramsString[i] = $"{paramKey}={paramValue} [{paramType}]";
            }
            
            var paramsList = paramCount > 0 ? $"params:\n${string.Join(Environment.NewLine, paramsString)}" : "";
            
            Debug.Log($"[Mock] Logging event: {analyticsEvent}, with parameter count: {paramCount}; {paramsList}");
        }
    }
}