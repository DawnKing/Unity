using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T _instance = null;

    public static T Inst()
    {
        if (_instance != null)
            return _instance;

        _instance = FindObjectOfType<T>();

        if (FindObjectsOfType<T>().Length > 1)
        {
            Debug.LogError("More than 1!");
            return _instance;
        }

        if (_instance == null)
        {
            string instanceName = typeof(T).Name;
            Debug.Log("Instance Name: " + instanceName);
            GameObject instanceGO = GameObject.Find(instanceName);
            if (instanceGO == null)
                instanceGO = new GameObject(instanceName);
            _instance = instanceGO.AddComponent<T>();
            DontDestroyOnLoad(instanceGO);
            Debug.Log("Add New Singleton " + _instance.name + " in Game!");
        }
        else
        {
            Debug.Log("Already exist: " + _instance.name);
        }

        return _instance;
    }

    protected virtual void OnDestroy()
    {
        if (_instance == this)
            _instance = null;
    }
}
