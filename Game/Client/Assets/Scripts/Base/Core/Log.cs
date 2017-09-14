using Common;
using UnityEngine;

namespace Assets.Scripts.Base.Core
{
    internal class ClientLog : Log
    {
        protected override void WriteHandler(object message, object className)
        {
            if (className != null)
                Debug.Log(message + string.Format(" @ {0}", className));
            else
                Debug.Log(message);
        }

        protected override void WarningHandler(object message, object className)
        {
            if (className != null)
                Debug.LogWarning(message + string.Format(" @ {0}", className));
            else
                Debug.LogWarning(message);
        }

        protected override void ErrorHandler(object message, object className)
        {
            if (className != null)
                Debug.LogError(message + string.Format(" @ {0}", className));
            else
                Debug.LogError(message);
        }
    }
}
