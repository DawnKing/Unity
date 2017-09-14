using System;
using UnityEngine;

public sealed class Capabilities
{
    public static RuntimePlatform Platform
    {
        get
        {
#if UNITY_ANDROID
                return RuntimePlatform.Android;
#elif UNITY_IOS
                return RuntimePlatform.IPhonePlayer;
#elif UNITY_STANDALONE_WIN
                return RuntimePlatform.WindowsPlayer;
#elif UNITY_STANDALONE_OSX
                return RuntimePlatform.OSXPlayer;
#else
            throw new Exception("Undefined Platform");
#endif
        }
    }

    public static string Os
    {
        get
        {
            switch (Platform)
            {
                case RuntimePlatform.LinuxPlayer: return "Linux";
                case RuntimePlatform.WindowsPlayer:
                case RuntimePlatform.WindowsEditor: return "Win";
                case RuntimePlatform.Android: return "Android";
                case RuntimePlatform.IPhonePlayer: return "IOS";
                case RuntimePlatform.OSXEditor:
                case RuntimePlatform.OSXPlayer: return "OSX";
                default: throw new InvalidOperationException("Undefined Platform");
            }
        }
    }
}