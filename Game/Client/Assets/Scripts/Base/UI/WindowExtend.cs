using FairyGUI;
using System;
using System.Collections.Generic;

namespace GameCore
{
    public class WindowExtend : Window
    {
        public Type BindType { get; internal set; }
        public Type SkinType { get; internal set; }

        protected Dictionary<string, Action<object>> Msg = new Dictionary<string, Action<object>>();

        protected override void OnInit()
        {
            base.OnInit();
            AddMessage();

            BindType.GetMethod("BindAll").Invoke(null, null);
            contentPane = SkinType.GetMethod("CreateInstance").Invoke(null, null) as GComponent;
            Center();
        }

        public override void Dispose()
        {
            RemoveMessage();
            base.Dispose();
        }

        public virtual void AddMessage()
        {
            foreach (var keyValuePair in Msg)
            {
                Message.AddListener(keyValuePair.Key, keyValuePair.Value);
            }
        }

        public void RemoveMessage()
        {
            foreach (var keyValuePair in Msg)
            {
                Message.RemoveListener(keyValuePair.Key, keyValuePair.Value);
            }
        }
    }
}
