using Assets.Scripts.Base.Network;
using Assets.Scripts.Battle.Base.Model;
using Common;
using Common.Network;
using GameProtocol;
using Google.Protobuf;

namespace Assets.Scripts.Battle.Entity
{
    internal class EntityNet : BaseNet
    {
        public EntityNet()
        {
            AddMessage(MessageType.NotifyCreateEntity, typeof(NotifyCreateEntity), OnCreateEntity);
            AddMessage(MessageType.NotifyEntityMove, typeof(NotifyEntityMove), OnNotifyEntityMove);
        }

        private void OnCreateEntity(IMessage message)
        {
            var notify = (NotifyCreateEntity)message;
            Log.Write(string.Format("通知创建实体{0}, {1}, {2}", notify.Id, notify.X, notify.Z), this);

            BattleEvent.Inst.AddEvent(BattleEventType.CreateEntity, notify);
        }

        private void OnNotifyEntityMove(IMessage message)
        {
            var notify = (NotifyEntityMove)message;
            Log.Write(string.Format("{0} move ({1}, {2})", notify.Id, notify.X, notify.Y), this);
            if (notify.Id == BattleModel.Inst.SelfPlayer.Id)
                return;

            var entity = BattleModel.Inst.GetEntity(notify.Id);

            if (entity != null)
                BattleModel.Inst.AddMove(entity, 0, notify.X, notify.Y);
        }
    }
}