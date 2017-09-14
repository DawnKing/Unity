using FairyGUI;
using System;
using System.Collections.Generic;
using GameCore;
using UnityEngine;

public static class WindowManager
{
    public static string Path = "UI/";

    private static readonly Dictionary<int, WindowData> Datas = new Dictionary<int, WindowData>();
    private static readonly Dictionary<int, Window> OpenedList = new Dictionary<int, Window>();
    private static readonly List<int> OpeningList = new List<int>();

    public static void Add(int id, string assetName, Type windowType, Type bindType, Type skinType, bool canClose = true)
    {
        if (Datas.ContainsKey(id))
        {
            Debug.LogWarning("已经注册" + id);
            return;
        }

        var data = new WindowData
        {
            Id = id,
            AssetName = assetName,
            WindowType = windowType,
            BindType = bindType,
            SkinType = skinType,
            CanClose = canClose
        };

        Datas.Add(id, data);
    }

    public static void Remove(int id)
    {
        if (Opened(id))
            Close(id);

        Datas.Remove(id);
    }

    public static bool Opened(int id)
    {
        return OpenedList.ContainsKey(id);
    }

    public static Window Get(int id)
    {
        return OpenedList[id];
    }

    public static void Open(int id, Action onComplete = null)
    {
        if (Opened(id))
            return;

        if (!Datas.ContainsKey(id))
        {
            Debug.LogWarning("窗口未注册" + id);
            return;
        }

        OpeningList.Add(id);
        var data = Datas[id];

        UIPackage.AddPackage(Path + data.AssetName);
        var window = (WindowExtend)Activator.CreateInstance(data.WindowType);
        window.BindType = data.BindType;
        window.SkinType = data.SkinType;
        window.Show();
        OpenedList[id] = window;
        OpeningList.Remove(id);
        if (onComplete != null)
            onComplete();
    }

    public static bool Opening(int id)
    {
        return OpeningList.Contains(id);
    }

    public static void Close(int id, bool dispose = true)
    {
        if (Opening(id))
        {
            Debug.LogWarning("正在打开的窗口不能关闭，需要停止加载");
            return;
        }
        if (!Opened(id))
            return;

        var window = OpenedList[id];
        GRoot.inst.HideWindowImmediately(window, dispose);

        OpenedList.Remove(id);
    }

    public static void CloseAllWindow()
    {
        var closeList = new List<int>();
        foreach (var pair in OpenedList)
        {
            var data = Datas[pair.Key];
            if (!data.CanClose)
                continue;
            closeList.Add(pair.Key);
        }
        foreach (var id in closeList)
        {
            Close(id);
        }
    }
}

class WindowData
{
    public int Id;
    public string AssetName;
    public Type WindowType;
    public Type BindType;
    public Type SkinType;
    public bool CanClose;   // 当切换场景的时候（如主界面进入战场会关闭所有窗口），是否允许关闭此窗口
}