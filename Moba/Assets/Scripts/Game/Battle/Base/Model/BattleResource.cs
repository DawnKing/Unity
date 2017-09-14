using System;
using System.Collections.Generic;
using UnityEngine;

public static class BattleResource
{
    private static readonly Dictionary<string, PrefabPool> Caches = new Dictionary<string, PrefabPool>();

    public static void GetMap(string name, Action<GameObject> callback, bool usePool)
    {
        var abPath = String.Format(GamePath.Map + "{0}", name); // "assets/gameresources/bundle/map/map001"
        LoadHandler(abPath, name, callback, usePool);
    }

    public static void GetTank(string tankName, Action<GameObject> callback)
    {
        var abPath = GetTankAssetBundlePath(tankName);
        LoadHandler(abPath, tankName, callback);
    }

    public static void PushTank(string tankName, GameObject gameObject)
    {
        var url = GetTankUrl(tankName);
        PushHandler(url, gameObject);
    }

    public static void GetSkill(string tankName, string skillName, Action<GameObject> callback)
    {
        var abPath = GetSkillAssetBundlePath(tankName, skillName);
        LoadHandler(abPath, skillName, callback);
    }

    public static void PushSkill(string tankName, string skillName, GameObject gameObject)
    {
        var url = GetSkillUrl(tankName, skillName);
        PushHandler(url, gameObject);
    }

    private static void LoadHandler(string abPath, string fileName, Action<GameObject> callback, bool usePool = true)
    {
        var prefabName = fileName + ".prefab";
        var url = abPath + "/" + prefabName;
        // 已有缓存，取出未使用的
        if (Caches.ContainsKey(url))
        {
            PrefabPool pool = Caches[url];
            GameObject skill = pool.ObtainPrefabInstance();
            callback(skill);
            return;
        }

        AssetManager.LoadPrefab(prefabName, abPath, url, gameObject =>
        {
            if (gameObject != null)
            {
                // 缓存对象
                if (usePool)
                {
                    PrefabPool pool = new PrefabPool(null, gameObject);
                    Caches[url] = pool;
                    gameObject = pool.ObtainPrefabInstance();
                }
            
                callback(gameObject);
            }
            else
            {
                callback(null);
            }
        });
    }

    public static void PushSkillCache(string tankName, string skillName, GameObject gameObject)
    {
        var url = GetSkillAssetBundlePath(tankName, skillName);
        PrefabPool pool = new PrefabPool(null, gameObject);
        Caches[url] = pool;
    }

    private static void PushHandler(string url, GameObject gameObject)
    {
        if (!Caches.ContainsKey(url))
        {
            Debug.LogError("不存在缓存" + url);
            return;
        }
        Caches[url].RecyclePrefabInstance(gameObject);
    }

    private static string GetTankPath(string tankName)
    {
        return string.Format(GamePath.Tanks + "{0}", tankName);
    }

    private static string GetTankAssetBundlePath(string tankName)
    {
        // "assets/gameresources/prefabs/tanks/feiyi/feiyi.prefab"
        var prefabName = tankName + ".prefab";
        string tankPath = GetTankPath(tankName);
        if (Core.Editor)
            return tankPath;
        var abPath = tankPath + "/" + prefabName;
        return abPath;
    }

    private static string GetTankUrl(string tankName)
    {
        // "assets/gameresources/prefabs/tanks/feiyi/feiyi.prefab/feiyi.prefab"
        var abPath = GetTankAssetBundlePath(tankName);
        var url = abPath + "/" + tankName + ".prefab";
        return url;
    }

    private static string GetSkillAssetBundlePath(string tankName, string skillName)
    {
        // "assets/gameresources/prefabs/tanks/feiyi/attack.prefab"
        var prefabName = skillName + ".prefab";
        string tankPath = GetTankPath(tankName);
        if (Core.Editor)
            return tankPath;
        var abPath = tankPath + "/" + prefabName;
        return abPath;
    }

    private static string GetSkillUrl(string tankName, string skillName)
    {
        // "assets/gameresources/prefabs/tanks/feiyi/attack.prefab/attack.prefab"
        var abPath = GetSkillAssetBundlePath(tankName, skillName);
        var url = abPath + "/" + skillName + ".prefab";
        return url;
    }
}