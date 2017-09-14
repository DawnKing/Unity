using System;
using Common.Network;
using GameProtocol;
using UnityEngine;

namespace Assets.Scripts.Battle.Base.Control
{
    public class InputMoveProcess : BaseProcess
    {
        private readonly SelfPlayer _selfPlayer;

        public InputMoveProcess(BattleEventType evt, SelfPlayer selfPlayer) : base(evt)
        {
            _selfPlayer = selfPlayer;
        }

        public override void Process()
        {
            if (!_selfPlayer.IsMovable())
                return;
            float radian = Convert.ToSingle(GetParam());

            float targetX = Mathf.Sin(radian) + _selfPlayer.Entity.transform.position.x;
            float targetZ = Mathf.Cos(radian) + _selfPlayer.Entity.transform.position.z;

            BattleModel.AddMove(_selfPlayer, radian, targetX, targetZ);

            var move = new RequestEntityMove
            {
                X = targetX,
                Y = targetZ
            };
            NetMessage.Send(MessageType.RequestEntityMove, move, this);
        }
    }
}
