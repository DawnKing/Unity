using System;
using System.Reflection;

public abstract class Singleton<T> where T : Singleton<T>
{
    private static T _instance = null;

    protected Singleton()
    {
    }

    public static T Inst()
    {
        if (_instance == null)
        {
            ConstructorInfo[] ctors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            ConstructorInfo ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);
            if (ctor == null)
                throw new Exception("Non-public ctor() not found!");
            _instance = ctor.Invoke(null) as T;
        }

        return _instance;
    }
}
