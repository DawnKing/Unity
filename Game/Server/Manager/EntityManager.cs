using System.Collections.Concurrent;
using System.Collections.Generic;
using Common;
using Common.Network;
using GameProtocol;
using Server.Entity;

namespace Server.Manager
{
    public static class EntityManager
    {
        private static readonly ConcurrentDictionary<uint, GameEntity> EntityList = new ConcurrentDictionary<uint, GameEntity>();

        public static void Start()
        {
            ClientManager.OnRemoveClient += OnRemoveClient;

            NetMessage.AddListener(MessageType.RequestEntityMove, OnRequestEntityMove);
        }

        public static void AddClient(uint id)
        {
            float x = 0;
            float z = 0;
            var entity = new GameEntity(id);
            entity.SetPosition(x, 0, z);
            EntityList.TryAdd(id, entity);

            var notifySelf = new NotifySelfPlayer
            {
                Id = id,
                X = x,
                Z = z
            };
            ClientManager.Send(id, MessageType.NotifySelfPlayer, notifySelf, typeof(EntityManager));

            SyncNearbyEntity(id);
        }

        private static void OnRemoveClient(uint id)
        {
            GameEntity entity;
            if (!EntityList.TryRemove(id, out entity))
                Log.Error("移除失败", typeof(EntityManager));
        }

        private static void SyncNearbyEntity(uint selfId)
        {
            var selfEntity = GetGameEntity(selfId);
            var list = GetNearbyEntity(selfEntity);
            foreach (var otherEntity in list)
            {
                Log.Write($"通知{selfId}附近创建玩家{otherEntity.Id}, {otherEntity.X}, {otherEntity.Z}", typeof(EntityManager));

                var notifySelfCreateOther = new NotifyCreateEntity
                {
                    Id = otherEntity.Id,
                    X = otherEntity.X,
                    Z = otherEntity.Z
                };
                ClientManager.Send(selfId, MessageType.NotifyCreateEntity, notifySelfCreateOther, typeof(EntityManager));


                Log.Write($"通知{otherEntity.Id}附近创建玩家{selfId}, {selfEntity.X}, {selfEntity.Z}", typeof(EntityManager));

                var notifyOtherCreateSelf = new NotifyCreateEntity
                {
                    Id = selfId,
                    X = selfEntity.X,
                    Z = selfEntity.Z
                };
                ClientManager.Send(otherEntity.Id, MessageType.NotifyCreateEntity, notifyOtherCreateSelf, typeof(EntityManager));
            }
        }

        private static void OnRequestEntityMove(ProtocolMessage message, uint id)
        {
            var moveTo = RequestEntityMove.Parser.ParseFrom(message.Data);
            var self = GetGameEntity(id);
            self.X = moveTo.X;
            self.Z = moveTo.Y;

            Log.Write($"{id} move ({moveTo.X}, {moveTo.Y})", typeof(EntityManager));

//        var notify = new NotifyEntityMove
//        {
//            Id = id,
//            X = self.X,
//            Y = self.Z
//        };
//        ClientManager.Inst.Send(id, MessageType.NotifyEntityMove, notify, this);

            SyncNearbyEntityMove(self);
        }

        private static void SyncNearbyEntityMove(GameEntity self)
        {
            List<GameEntity> list = GetNearbyEntity(self);
            foreach (var otherEntity in list)
            {
                Log.Write($"通知移动{self.Id} to 附近玩家{otherEntity.Id}", typeof(EntityManager));

                var notify = new NotifyEntityMove
                {
                    Id = self.Id,
                    X = self.X,
                    Y = self.Z
                };
                ClientManager.Send(otherEntity.Id, MessageType.NotifyEntityMove, notify, typeof(EntityManager));
            }
        }

        private static List<GameEntity> GetNearbyEntity(GameEntity self)
        {
            var list = new List<GameEntity>();
            foreach (KeyValuePair<uint, GameEntity> entityPair in EntityList)
            {
                var entity = entityPair.Value;
                if (self.Id == entity.Id)
                    continue;
                list.Add(entity);
            }
            return list;
        }

        private static GameEntity GetGameEntity(uint? id)
        {
            GameEntity entity;
            EntityList.TryGetValue((uint)id, out entity);
            return entity;
        }
    }
}
