using System.Collections;
using System.IO;
using FairyGUI;
using GameProtocol.SystemMessage;
using GameProtocol.TeamMessage;
using UnityEngine;

public class Core : MonoBehaviour
{
    public static Core Inst { get; private set; }

    public static bool IsDebug = true;
    public static bool Editor;
    public bool UseNet = true;

    private static int _mainThreadID;

    public void Awake()
    {
        if (Inst != null)
            Debug.LogError("重复创建");

        Inst = this;
        _mainThreadID = System.Threading.Thread.CurrentThread.ManagedThreadId;

        DontDestroyOnLoad(gameObject);

        Application.targetFrameRate = 60;
#if UNITY_WEBPLAYER || UNITY_WEBGL || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR
        CopyPastePatch.Apply();
#endif
        UIConfig.defaultFont = "Microsoft YaHei";

#if UNITY_EDITOR
        Editor = true;
#endif

        GamePath.Init(Editor);
        AssetManager.Init(Editor);
        TemplateManager templateMgr = new TemplateManager(new TemplateList());
        templateMgr.LoadXml(GamePath.XML);

        CoreDebug();
    }

    public void Update()
    {
        NetMessage.Update();
    }

    public void OnDestroy()
    {
        if (NetMessage.NetConnection != null)
            GmCommand.Send("endbattle 1", PlayerModel.Inst.PlayerName, this);
    }

    public static bool IsMainThread
    {
        get
        {
            return _mainThreadID == System.Threading.Thread.CurrentThread.ManagedThreadId;
        }
    }

    #region Debug
    public void OnGUI()
    {
#if !UNITY_EDITOR
        GUILayout.Label(_logInfo);
#endif
    }

    private string _logInfo;
    private readonly Queue _logQueue = new Queue(50);
    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        if (_logQueue.Count > 20)
            _logQueue.Dequeue();
        _logInfo = logString;
        string newString = "\n [" + type + "] : " + _logInfo;
        _logQueue.Enqueue(newString);
        if (type == LogType.Exception)
        {
            newString = "\n" + stackTrace;
            _logQueue.Enqueue(newString);
        }
        _logInfo = string.Empty;
        foreach (string mylog in _logQueue)
        {
            _logInfo += mylog;
        }
    }

    void CoreDebug()
    {
        Application.logMessageReceived += HandleLog;

        if (Debug.isDebugBuild)
        {
            Debug.Log("====================================================================================");
            Debug.Log(string.Format("Application.platform = {0}", Application.platform));
            Debug.Log(string.Format("Application.dataPath = {0} , WritePermission: {1}",
                Application.dataPath, HasWriteAccessToFolder(Application.dataPath)));
            Debug.Log(string.Format("Application.streamingAssetsPath = {0} , WritePermission: {1}",
                Application.streamingAssetsPath, HasWriteAccessToFolder(Application.streamingAssetsPath)));
            Debug.Log(string.Format("Application.persistentDataPath = {0} , WritePermission: {1}",
                Application.persistentDataPath, HasWriteAccessToFolder(Application.persistentDataPath)));
            Debug.Log(string.Format("Application.temporaryCachePath = {0} , WritePermission: {1}",
                Application.temporaryCachePath, HasWriteAccessToFolder(Application.temporaryCachePath)));
            Debug.Log(string.Format("SystemInfo.deviceModel = {0}", SystemInfo.deviceModel));
            Debug.Log(string.Format("SystemInfo.graphicsDeviceVersion = {0}", SystemInfo.graphicsDeviceVersion));
            Debug.Log("====================================================================================");
        }
    }

    // 测试有无写权限
    static bool HasWriteAccessToFolder(string folderPath)
    {
        try
        {
            string tmpFilePath = Path.Combine(folderPath, Path.GetRandomFileName());
            using (
                FileStream fs = new FileStream(tmpFilePath, FileMode.CreateNew, FileAccess.ReadWrite,
                    FileShare.ReadWrite))
            {
                StreamWriter writer = new StreamWriter(fs);
                writer.Write("1");
            }
            File.Delete(tmpFilePath);
            return true;
        }
        catch
        {
            return false;
        }
    }
    #endregion
}
