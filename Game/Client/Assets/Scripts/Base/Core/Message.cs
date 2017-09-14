using System;
using System.Collections.Generic;

namespace GameCore
{
    public static class Message
    {
        private static Dictionary<string, Action<object>> _list = new Dictionary<string, Action<object>>();

        public static void Send(string type, object param = null)
        {
            if (!_list.ContainsKey(type))
                return;
            var callback = _list[type];
            callback(param);
        }

        public static void AddListener(string type, Action<object> listener)
        {
            if (_list.ContainsKey(type))
            {
                _list[type] += listener;
            }
            else
            {
                _list[type] = listener;
            }
        }

        public static void RemoveListener(string type, Action<object> listener)
        {
            if (!_list.ContainsKey(type))
                return;
            _list[type] -= listener;

            if (_list[type] == null)
                _list.Remove(type);
        }
    }
}