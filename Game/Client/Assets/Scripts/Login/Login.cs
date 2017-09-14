using Assets.Scripts.Base.Core;
using Assets.Scripts.Base.Network;
using Assets.Scripts.Login.View;
using Common.Network;
using Login;
using UnityEngine;

namespace Assets.Scripts.Login
{
    public class Login : MonoBehaviour
    {
        private ServerConnection _net;

        public void Start()
        {
            if (Core.Inst.UseNet)
            {
                _net = new ServerConnection();
                _net.OnConnected = OnConnected;
                _net.Connect("127.0.0.1", 13000);
                NetMessage.Connection = _net;
            }

            WindowManager.Add((int)WindowId.Login, "Login", typeof(LoginWindow), typeof(LoginBinder), typeof(UILogin));
            WindowManager.Add((int)WindowId.Register, "Login", typeof(RegisterWindow), typeof(LoginBinder), typeof(UIRegister));

            WindowManager.Open((int)WindowId.Login);
        }

        private void OnConnected()
        {
            Debug.Log("连接服务器");
        }
    }
}