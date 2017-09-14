using FairyGUI;
using System;
using System.Collections.Generic;

namespace GameCore
{
    public enum InitWindow
    {
        Center,
        FullScreen
    }

    public class WindowExtend : Window
    {
        public Type BindType { get; internal set; }
        public Type SkinType { get; internal set; }

        protected Dictionary<string, Action<object>> Msg = new Dictionary<string, Action<object>>();
        protected InitWindow InitType = InitWindow.Center;

        protected override void OnInit()
        {
            base.OnInit();
            AddMessage();

            BindType.GetMethod("BindAll").Invoke(null, null);
            if (SkinType != null)
                contentPane = SkinType.GetMethod("CreateInstance").Invoke(null, null) as GComponent;

            switch (InitType)
            {
                case InitWindow.Center:
                    Center();
                    break;
                case InitWindow.FullScreen:
                    MakeFullScreen();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
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
