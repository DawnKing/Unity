using Assets.Scripts.Base.Network;
using Assets.Scripts.Battle.Base.Model;
using Common;
using Common.Network;
using GameProtocol;
using Google.Protobuf;
using UnityEngine;

namespace Assets.Scripts.Battle.Player
{
    internal class PlayerNet : BaseNet
    {
        public static GameObject Sphere;

        public PlayerNet()
        {
            AddMessage(MessageType.NotifySelfPlayer, typeof(NotifySelfPlayer), OnNotifySelfPlayer);
        }

        private void OnNotifySelfPlayer(IMessage message)
        {
            var notify = (NotifySelfPlayer)message;

            Log.Write(typeof(NotifySelfPlayer), this);

            Sphere = GameObject.Find("Sphere");
            var objRenderer = Sphere.GetComponent<Renderer>();
            objRenderer.material.color = Random.ColorHSV(0f, 1f);

            var textMesh = Sphere.GetComponentInChildren<TextMesh>();
            if (textMesh != null)
            {
                textMesh.text = notify.Id.ToString();
            }

            SelfPlayer selfPlayer = BattleModel.Inst.AddSelfPlayer(notify.Id, notify.X, notify.Z);
            selfPlayer.Entity = Sphere;

            Battle.Battlefield = new Battlefield();
            Battle.Battlefield.Init();
        }
    }
}