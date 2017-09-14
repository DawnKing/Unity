using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneTool
{
    public const string Login = "Login";
    public const string MainUI = "MainUI";
    public const string Battle = "Battle";

    public static void ChangeScene(string sceneName)
    {
        Debug.Log("Change scene to " + sceneName);
        WindowManager.CloseAllWindow();
        SceneManager.LoadScene(sceneName);
    }
}
