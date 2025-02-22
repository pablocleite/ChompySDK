using UnityEngine;

namespace ChompySDK.Analytics.NativeBridge
{
    public class NativeAnalyticsBridgeFactory
    {
        public static NativeAnalyticsBridge Get()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                    return new IosNativeAnalyticsBridge();
                default:
                    return new MockAnalyticsBridge();
            }
        }
    }
}