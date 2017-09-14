using UnityEngine;

public static class GamePath
{
    public static string Release { get; private set; }

    public static string EditorGameResources { get; private set; }
    public static string ReleaseGameResources { get; private set; }
    public static string StremingAssets { get; private set; }
    public static string Assets { get; private set; }

    public static string Prefabs { get; private set; }
    public static string XML { get; private set; }
    public static string UI { get; private set; }
    public static string Bundle { get; private set; }

    public static string Map { get; private set; }
    public static string Tanks { get; private set; }
    public static string Battle { get; private set; }

    public static void Init(bool editor)
    {
        Release = Application.streamingAssetsPath;

        EditorGameResources = "Assets/GameResources/";
        ReleaseGameResources = "assets/gameresources/";
        StremingAssets = "Assets/StreamingAssets";
        Assets = editor ? EditorGameResources : ReleaseGameResources;

        UI = Assets + "ui/";

        Prefabs = Assets + "prefabs/";
        Tanks = Prefabs + "tanks/";

        Bundle = Assets + "bundle/";
        Map = Bundle + "map/";
        XML = Bundle + "xml/";
    }

    #region path
    /*
    IOS:
    Application.dataPath :                Application/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/xxx.app/Data
    Application.streamingAssetsPath :     Application/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/xxx.app/Data/Raw
    Application.persistentDataPath :      Application/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/Documents
    Application.temporaryCachePath :      Application/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/Library/Caches

    Android:
    Application.dataPath :                /data/app/xxx.xxx.xxx.apk
    Application.streamingAssetsPath :     jar:file:///data/app/xxx.xxx.xxx.apk/!/assets
    Application.persistentDataPath :      /data/data/xxx.xxx.xxx/files
    Application.temporaryCachePath :      /data/data/xxx.xxx.xxx/cache

    Windows:
    Application.dataPath :                /Assets
    Application.streamingAssetsPath :     /Assets/StreamingAssets
    Application.persistentDataPath :      C:/Users/xxxx/AppData/LocalLow/CompanyName/ProductName
    Application.temporaryCachePath :      C:/Users/xxxx/AppData/Local/Temp/CompanyName/ProductName

    Mac:
    Application.dataPath :                /Assets
    Application.streamingAssetsPath :     /Assets/StreamingAssets
    Application.persistentDataPath :      /Users/xxxx/Library/Caches/CompanyName/Product Name
    Application.temporaryCachePath :      /var/folders/57/6b4_9w8113x2fsmzx_yhrhvh0000gn/T/CompanyName/Product Name

    Windows Web Player:
    Application.dataPath :                file:///D:/MyGame/WebPlayer (即导包后保存的文件夹，html文件所在文件夹)
    Application.streamingAssetsPath :
    Application.persistentDataPath :
    Application.temporaryCachePath :
    */
    #endregion
}