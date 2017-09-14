using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;

public static class AssetManager
{
    private static bool _editor;

    private static AssetBundleManifest _assetBundleManifest;

    private static readonly Dictionary<string, List<Delegate>> Loading = new Dictionary<string, List<Delegate>>();
    private static readonly List<string> LoadError = new List<string>();

    private static readonly Dictionary<string, LoadedBundle> LoadedBundles = new Dictionary<string, LoadedBundle>();
    private static readonly Dictionary<string, LoadedObject> LoadedObjects = new Dictionary<string, LoadedObject>();

    public static void Init(bool editor)
    {
        _editor = editor;
        Debug.Log("---------" + _editor + "     " + Path.Combine(GamePath.Release, "StreamingAssets"));
        if (_editor)
            return;
        if (_assetBundleManifest != null)
        {
            Debug.LogError("Repeated loading");
            return;
        }

        var assetBundle = AssetBundle.LoadFromFile(Path.Combine(GamePath.Release, "StreamingAssets"));
        _assetBundleManifest = assetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
    }

    public static bool LoadedDependency(string path, Action<AssetBundle> callback, string refPath)
    {
        return Loaded(path, callback, refPath);
    }

    public static bool Loaded(string path, Delegate callback, string refPath = null)
    {
        // 已经加载失败
        if (LoadError.Contains(path))
        {
            callback.DynamicInvoke(null);
            return true;
        }

        // 正在加载
        if (Loading.ContainsKey(path))
        {
            Loading[path].Add(callback);
            return true;
        }

        // 已经缓存
        if (LoadedBundles.ContainsKey(path))
        {
            if (refPath != null)
                LoadedBundles[path].AddRef(refPath);
            callback.DynamicInvoke(LoadedBundles[path].Bundle);
            return true;
        }

        if (LoadedObjects.ContainsKey(path))
        {
            LoadedObjects[path].AddRef();
            callback.DynamicInvoke(LoadedObjects[path].Obj);
            return true;
        }

        return false;
    }

    public static void LoadAssetBundle(string path, Action<AssetBundle> callback, string refPath = null)
    {
        if (Loaded(path, callback))
            return;

        var dependencies = GetBundleDenpendencies(path);
        if (dependencies == null)
        {
            callback(null);
            return;
        }

        var totalCount = dependencies.Count + 1;
        var loadedCount = 0;
        AssetBundle bundle = null;
        // 先加载所有依赖包
        foreach (var dependency in dependencies)
        {
            // 是否已经加载过了
            if (LoadedDependency(dependency, ab =>
            {
                loadedCount++;
                if (loadedCount == totalCount)
                    callback(bundle);
            }, path))
            {
                continue;
            }
            // 新加载
            Core.Inst.StartCoroutine(LoadAssetBundleHandler(dependency, ab =>
            {
                loadedCount++;
                if (loadedCount == totalCount)
                    callback(bundle);
            }, path));
        }
        // 加载目标包
        Core.Inst.StartCoroutine(LoadAssetBundleHandler(path, ab =>
        {
            loadedCount++;
            bundle = ab;
            if (loadedCount == totalCount)
                callback(bundle);
        }, refPath));
    }

    private static List<string> GetBundleDenpendencies(string path)
    {
        var result = new List<string>();
        if (_assetBundleManifest == null)
        {
            Debug.LogError("Not has dependencies file");
            return null;
        }
        var dependencies = _assetBundleManifest.GetAllDependencies(path);
        result.AddRange(dependencies);
        foreach (var dependency in dependencies)
        {
            result.AddRange(GetBundleDenpendencies(dependency));
        }
        return result;
    }

    private static IEnumerator LoadAssetBundleHandler(string path, Action<AssetBundle> callback, string refPath = null)
    {
        var url = GamePath.Release + "/" + path;

        Debug.Log(string.Format("load LoadAssetBundle: url = {0}", url));

        // 开始加载
        Loading[path] = new List<Delegate> { callback };

        AssetBundleCreateRequest bundleLoadRequest = AssetBundle.LoadFromFileAsync(url);
        yield return bundleLoadRequest;

        AssetBundle assetBundle = bundleLoadRequest.assetBundle;
        // 加载失败
        if (assetBundle == null)
        {
            Debug.LogWarning("Failed to load AssetBundle   " + url);
            LoadError.Add(path);
            // 加载失败回调
            CallbackList(path);
            yield break;
        }

        LoadedBundles.Add(path, new LoadedBundle(assetBundle));
        if (refPath != null)
            LoadedBundles[path].AddRef(refPath);
        // 加载成功回调
        CallbackList(path, assetBundle);
    }

    private static void CallbackList(string path)
    {
        foreach (Delegate func in Loading[path])
        {
            func.DynamicInvoke(null);
        }
        Loading.Remove(path);
    }

    private static void CallbackList(string path, AssetBundle obj)
    {
        foreach (Delegate func in Loading[path])
        {
            func.DynamicInvoke(obj);
        }
        Loading.Remove(path);
    }

    private static void CallbackList(string path, GameObject obj)
    {
        foreach (Delegate func in Loading[path])
        {
            func.DynamicInvoke(Object.Instantiate(obj));
        }
        Loading.Remove(path);
    }

    // 资源目录 + prefab文件名
    public static void LoadPrefab(string resDir, string file, Action<GameObject> callback)
    {
        var prefabName = file + ".prefab";
        var abPath = resDir + prefabName;
        var url = abPath + "/" + prefabName;
        LoadPrefab(prefabName, abPath, url, callback);
    }

    public static void LoadPrefab(string prefabName, string abPath, string url, Action<GameObject> callback)
    {
        Debug.Log(string.Format("load prefab: {0}", url));

        if (_editor)
        {
#if UNITY_EDITOR
            GameObject obj = UnityEditor.AssetDatabase.LoadAssetAtPath(url, typeof(Object)) as GameObject;
            if (obj == null)
            {
                Debug.LogError("load error" + url);
                callback(null);
                return;
            }
            callback(Object.Instantiate(obj));
#endif
        }
        else
        {
            if (Loaded(url, callback))
                return;
            LoadAssetBundle(abPath, ab =>
            {
                if (ab == null)
                {
                    callback(null);
                    return;
                }

                if (Loaded(url, callback))
                    return;
                Core.Inst.StartCoroutine(LoadPrefabHandler(url, prefabName, ab, callback));
            }, url);
        }
    }

    private static IEnumerator LoadPrefabHandler(string url, string file, AssetBundle assetBundle, Action<GameObject> callback)
    {
        Loading[url] = new List<Delegate> { callback };

        // 从AssetBundle中加载Prefab
        AssetBundleRequest assetLoadRequest = assetBundle.LoadAssetAsync<GameObject>(file);
        yield return assetLoadRequest;

        // 加载Prefab失败
        if (assetLoadRequest.asset == null)
        {
            Debug.LogError("load error" + url);
            // 加载失败回调
            CallbackList(url);
            yield break;
        }
        if (LoadedObjects.ContainsKey(url))
        {
            Debug.LogWarning("Repeated loading" + url);
        }
        else
        {
            LoadedObjects.Add(url, new LoadedObject(assetLoadRequest.asset));
        }
        LoadedObjects[url].AddRef();
        // 加载成功回调
        CallbackList(url, assetLoadRequest.asset as GameObject);
    }
}

internal sealed class LoadedBundle
{
    public int RefCount { get; private set; }
    public AssetBundle Bundle { get; private set; }
    private readonly List<string> _refList = new List<string>();

    public LoadedBundle(AssetBundle assetBundle)
    {
        Bundle = assetBundle;
        RefCount = 0;
    }

    public void AddRef(string path)
    {
        RefCount++;
        _refList.Add(path);
    }

    public void RemoveRef(string path)
    {
        RefCount--;
        _refList.Remove(path);
    }

    public List<string> RefList
    {
        get { return _refList; }
    }
}

internal sealed class LoadedObject
{
    public int RefCount { get; private set; }
    public Object Obj { get; private set; }

    public LoadedObject(Object obj)
    {
        Obj = obj;
        RefCount = 0;
    }

    public void AddRef()
    {
        RefCount++;
    }

    public void RemoveRef()
    {
        RefCount--;
    }
}