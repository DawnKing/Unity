using System.Collections.Generic;
using Assets.Scripts.Base.Managers;
using Common;
using GameProtocol;
using UnityEngine;

namespace Assets.Scripts.Battle.Base.Model
{
    public sealed class BattleModel
    {
        #region Inst
        static BattleModel() { }
        private BattleModel() { }
        public static BattleModel Inst { get { return Instant; } }
        private static readonly BattleModel Instant = new BattleModel();
        #endregion

        // 缓存
        private readonly ObjectPool<EntityMove> _movePool = new ObjectPool<EntityMove>(100);
        // 游戏数据
        private readonly Dictionary<uint, EntityMove> _moves = new Dictionary<uint, EntityMove>();
        // 游戏实体
        private readonly Dictionary<uint, GameEntity> _entities = new Dictionary<uint, GameEntity>();

        public GameObject CameraEntity;
        public Vector3 CameraPosition = new Vector3(0, 20, 0);

        public Dictionary<uint, EntityMove> Moves { get { return _moves; } }

        public SelfPlayer SelfPlayer { get; private set; }
        public GameObject Target { get; set; }

        internal void AddMove(GameEntity entity, float radian, float targetX, float targetZ)
        {
            entity.StartMove();

            EntityMove move;
            if (IsMoving(entity))
            {
                move = GetMove(entity);
                if (entity != move.GameEntity)
                    Log.Error("错误的实体", this);
            }
            else
            {
                move = _movePool.Pop();
                _moves[entity.Id] = move;
            }

            move.SetData(entity, radian, targetX, targetZ);
        }

        public void RemoveMove(GameEntity entity)
        {
            entity.EndMove();

            var move = GetMove(entity);
            if (move == null)
                return;

            move.Clear();
            _movePool.Push(move);
            _moves.Remove(entity.Id);
        }

        private EntityMove GetMove(GameEntity gameEntity)
        {
            return _moves[gameEntity.Id];
        }

        private bool IsMoving(GameEntity gameEntity)
        {
            return _moves.ContainsKey(gameEntity.Id);
        }

        public GameEntity AddEntity(NotifyCreateEntity createEntity)
        {
            if (_entities.ContainsKey(createEntity.Id))
            {
                Log.Warning("已经包含实体" + createEntity.Id, this);
                return _entities[createEntity.Id];
            }

            var position = new Vector3(createEntity.X, 0, createEntity.Z);
            var entity = new GameEntity(createEntity.Id, position);

            _entities.Add(entity.Id, entity);

            Log.Write("创建一个实体" + createEntity.Id, this);
            return entity;
        }

        public SelfPlayer AddSelfPlayer(uint id, float x, float z)
        {
            SelfPlayer = new SelfPlayer(id, new Vector3(x, 0, z));

            _entities.Add(SelfPlayer.Id, SelfPlayer);
            return SelfPlayer;
        }

        public GameEntity GetEntity(uint id)
        {
            GameEntity entity;
            _entities.TryGetValue(id, out entity);
            return entity;
        }
    }
}