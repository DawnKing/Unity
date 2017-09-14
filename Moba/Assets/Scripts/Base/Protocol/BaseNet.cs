using System;
using System.Collections.Generic;

public class BaseNet
{
    protected Dictionary<Type, Action<IProtocol>> Msg = new Dictionary<Type, Action<IProtocol>>();

    public virtual void Dispose()
    {
        RemoveMessage();
    }

    public virtual void AddMessage()
    {
        foreach (var keyValuePair in Msg)
        {
            NetMessage.AddListener(keyValuePair.Key, keyValuePair.Value);
        }
    }

    public void RemoveMessage()
    {
        foreach (var keyValuePair in Msg)
        {
            NetMessage.RemoveListener(keyValuePair.Key);
        }
    }
}
