using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public static class AssetBuilder
{
    [MenuItem("Game/AssetBundle/BuildAll")]
    public static void BuildAll()
    {
        GamePath.Init(true);

        // 发布目录
        DirectoryInfo dir = new DirectoryInfo(GamePath.StremingAssets);
        if (dir.Exists)
            dir.Delete(true);

        EditorUtility.DisplayProgressBar("Build all assets", "BuildPrefabs", .1f);
        BuildPrefabs();
        EditorUtility.DisplayProgressBar("Build all assets", "BuildUI", .2f);
        BuildUI();
        EditorUtility.DisplayProgressBar("Build all assets", "BuildBundle", .3f);
        BuildBundle();
        EditorUtility.ClearProgressBar();
    }

    // 根据prefab文件，寻找所有依赖的资源打成一个包，如果依赖的资源有被共享，则单独打成一个包
    [MenuItem("Game/AssetBundle/BuildPrefabs")]
    public static void BuildPrefabs()
    {
        GamePath.Init(true);

        if (!Directory.Exists(GamePath.Prefabs))
        {
            Debug.LogError(GamePath.Prefabs + "目录不存在");
            return;
        }
        // 遍历所有prefab的依赖关系
        var assetDic = new Dictionary<string, Dependency>();
        var bundles = new Dictionary<string, string[]>();
        var assets = AssetDatabase.FindAssets("t:prefab", new[] { GamePath.Prefabs.TrimEnd("/".ToCharArray()) });
        foreach (var guid in assets)
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            var dependencies = AssetDatabase.GetDependencies(path, true);
            // 不用打包cs脚本
            dependencies = dependencies.Where(denpendency => !denpendency.EndsWith(".cs")).ToArray();
            // 需要打包的列表
            bundles.Add(path, dependencies);

            // 所有资源列表，计算依赖次数
            foreach (var dependency in dependencies)
            {
                if (assetDic.ContainsKey(dependency))
                {
                    assetDic[dependency].Add(path);
                }
                else
                {
                    assetDic.Add(dependency, new Dependency(path));
                }
            }
        }
        // 编译Prefabs目录下的所有prefab
        var assetBundleBuilds = new List<AssetBundleBuild>();
        foreach (var bundle in bundles)
        {
            // 编译独享资源
            var build = new AssetBundleBuild
            {
                assetBundleName = bundle.Key,
                assetNames = bundle.Value.Where(dependency => assetDic[dependency].Count == 1).ToArray()
            };
            assetBundleBuilds.Add(build);
        }
        // 编译共享资源
        foreach (var asset in assetDic)
        {
            if (asset.Value.Count == 1)
                continue;
            var build = new AssetBundleBuild
            {
                assetBundleName = asset.Key,
                assetNames = new[] { asset.Key }
            };
            assetBundleBuilds.Add(build);
        }

        Release(assetBundleBuilds.ToArray());
    }

    private static void Release(AssetBundleBuild[] assetBundleBuilds)
    {
        // 发布目录
        DirectoryInfo dir = new DirectoryInfo(GamePath.StremingAssets);
        if (!dir.Exists)
            dir.Create();

        if (assetBundleBuilds != null)
            BuildPipeline.BuildAssetBundles(GamePath.StremingAssets, assetBundleBuilds, BuildAssetBundleOptions.None, PlatformToBuildTarget());
        else
            BuildPipeline.BuildAssetBundles(GamePath.StremingAssets, BuildAssetBundleOptions.None, PlatformToBuildTarget());
        AssetDatabase.Refresh();
    }

    // 将平台转为编译目标
    private static BuildTarget PlatformToBuildTarget()
    {
        switch (Capabilities.Platform)
        {
            case RuntimePlatform.LinuxPlayer: return BuildTarget.StandaloneLinux64;
            case RuntimePlatform.WindowsPlayer:
            case RuntimePlatform.WindowsEditor: return BuildTarget.StandaloneWindows64;
            case RuntimePlatform.Android: return BuildTarget.Android;
            case RuntimePlatform.IPhonePlayer: return BuildTarget.iOS;
            case RuntimePlatform.OSXEditor:
            case RuntimePlatform.OSXPlayer: return BuildTarget.StandaloneOSXIntel64;
            default: throw new Exception("Undefined Platform");
        }
    }

    // 根据ui资源名，打成一个包
    [MenuItem("Game/AssetBundle/BuildUI")]
    public static void BuildUI()
    {
        GamePath.Init(true);

        // 清空AssetBundle标记
        string[] assetBundleNames = AssetDatabase.GetAllAssetBundleNames();
        foreach (string name in assetBundleNames)
        {
            AssetDatabase.RemoveAssetBundleName(name, true);
        }

        // 定义文件和资源各打包为一个bundle(desc_bundle+res_bundle)
        var assets = AssetDatabase.FindAssets("", new[] { GamePath.UI.TrimEnd("/".ToCharArray()) });
        foreach (var guid in assets)
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            AssetImporter assetImporter = AssetImporter.GetAtPath(path);
            if (path.Contains("@"))
            {
                assetImporter.assetBundleName = path.Substring(0, path.LastIndexOf("@", StringComparison.Ordinal));
            }
            else
            {
                assetImporter.assetBundleName = path.Substring(0, path.LastIndexOf(".", StringComparison.Ordinal));
            }
        }

        Release(null);
    }

    // 以文件夹名为单位，如果文件夹下有资源存在，则把所有资源打成一个包，此时文件夹下不允许存在子文件夹
    [MenuItem("Game/AssetBundle/BuildBundle")]
    public static void BuildBundle()
    {
        GamePath.Init(true);

        // 清空AssetBundle标记
        string[] assetBundleNames = AssetDatabase.GetAllAssetBundleNames();
        foreach (string name in assetBundleNames)
        {
            AssetDatabase.RemoveAssetBundleName(name, true);
        }

        // 编译AssetBundle标记的名字
        Walk(GamePath.Bundle, file =>
        {
            if (!file.Name.EndsWith(".meta"))
            {
                BuildFileBundleName(file, GamePath.Bundle);
            }
        });

        Release(null);
    }

    public static void Walk(string path, Action<FileInfo> callBack)
    {
        DirectoryInfo folder = new DirectoryInfo(path);
        FileSystemInfo[] files = folder.GetFileSystemInfos();
        int length = files.Length;
        for (int i = 0; i < length; i++)
        {
            if (files[i] is DirectoryInfo)
            {
                Walk(files[i].FullName, callBack);
            }
            else
            {
                callBack(new FileInfo(files[i].FullName));
            }
        }
    }

    // 编译文件AssetBundle名字
    private static void BuildFileBundleName(FileSystemInfo file, string basePath)
    {
        // file : "E:\\Game\\Assets\\GameResources\\map\\map001\\map001_01.FBX"
        // basePath : "Assets/GameResources/map/"
        string fullName = file.FullName.Replace("\\", "/"); // "E:/MobaGame/Moba/Assets/GameResources/map/map001/map001.prefab"
        string fileName = file.Name;    // "map001_01.FBX"
        string extension = file.Extension;  // ".FBX"
        string baseFileName = fileName.Substring(0, fileName.Length - extension.Length);    // "map001_01"
        var a = fullName.IndexOf(basePath, StringComparison.Ordinal);
        var b = fullName.IndexOf(fileName, StringComparison.Ordinal);
        string assetDirectory = fullName.Substring(a, b - a);   // "Assets/GameResources/map/map001/"

        if (baseFileName + extension == ".DS_Store")
            return;

        int variantIndex = baseFileName.LastIndexOf(".", StringComparison.Ordinal);
        string variantName = string.Empty;

        if (variantIndex > 0)
        {
            variantName = baseFileName.Substring(variantIndex + 1);
        }

        var assetFile = assetDirectory + fileName;
        AssetImporter assetImporter = AssetImporter.GetAtPath(assetFile);
        if (assetImporter == null)
        {
            Debug.LogError(assetFile);
            return;
        }
        assetImporter.assetBundleName = assetDirectory.TrimEnd("/".ToCharArray());
        if (variantName != string.Empty)
        {
            assetImporter.assetBundleVariant = variantName;
        }
    }
}


internal class Dependency
{
    private readonly List<string> _prefabList = new List<string>();

    public Dependency(string path)
    {
        Add(path);
    }

    public void Add(string path)
    {
        Count++;
        _prefabList.Add(path);
    }

    public int Count { get; private set; }

    public List<string> PrefabList
    {
        get { return _prefabList; }
    }
}