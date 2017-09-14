using DengLu;
using FairyGUI;
using UnityEngine;

public class Login : MonoBehaviour
{
    // Use this for initialization
    public void Start()
    {
#if UNITY_EDITOR
        UIPackage.AddPackage(GamePath.UI + "common",
            (name, extension, type) => UnityEditor.AssetDatabase.LoadAssetAtPath(name + extension, type));

        OpenLoginWindow();
#else
        AssetManager.LoadAssetBundle(GamePath.UI + "common", ab =>
        {
            UIPackage.AddPackage(ab);

            OpenLoginWindow();
        });
#endif
    }

    private void OpenLoginWindow()
    {
        WindowManager.Add((int)WindowId.Login, "login", typeof(LoginWindow), typeof(DengLuBinder), typeof(UILogin));

        WindowManager.Open((int)WindowId.Login);
    }

    // Update is called once per frame
    public void Update()
    {
    }
}
