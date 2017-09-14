using System;
using System.Collections.Generic;
using Assets.Scripts.Battle.Base.Model;
using Assets.Scripts.Battle.Player;
using GameProtocol;
using UnityEngine;

namespace Assets.Scripts.Battle.Base.Control
{
    public class CreateEntityProcess : BaseProcess
    {
        public CreateEntityProcess(BattleEventType evt) : base(evt)
        {
        }

        public override void Process()
        {
            List<object> list = GetParam() as List<object>;

            foreach (NotifyCreateEntity createEntity in list)
            {
                GameEntity entity = BattleModel.AddEntity(createEntity);
                entity.Entity = UnityEngine.Object.Instantiate(PlayerNet.Sphere);
                entity.Entity.transform.position = new Vector3(createEntity.X, 0, createEntity.Z);
                var objRenderer = entity.Entity.GetComponent<Renderer>();
                objRenderer.material.color = UnityEngine.Random.ColorHSV(0f, 1f);

                var textMesh = entity.Entity.GetComponentInChildren<TextMesh>();
                if (textMesh != null)
                {
                    textMesh.text = createEntity.Id.ToString();
                }
            }
        }
    }

    public class EntityMoveProcess : BaseProcess
    {
        public EntityMoveProcess() : base(0)
        {
        }

        public override bool IsProcess()
        {
            return true;
        }

        public override void Complete()
        {
        }

        public override void Process()
        {
            Dictionary<uint, EntityMove> moves = BattleModel.Moves;

            List<EntityMove> deleteMoves = new List<EntityMove>();
            foreach (KeyValuePair<uint, EntityMove> movePair in moves)
            {
                EntityMove move = movePair.Value;

                float speed = move.GameEntity.Speed;
                // 矢量最大速度
                float maxSpeed = Convert.ToSingle(Math.Sqrt(move.MoveX * move.MoveX + move.MoveZ * move.MoveZ));
                if (speed >= maxSpeed)
                {
                    move.SpeedX = move.MoveX;
                    move.SpeedZ = move.MoveZ;
                }
                else
                {
                    float rate = speed / maxSpeed;
                    move.SpeedX = move.MoveX * rate;
                    move.SpeedZ = move.MoveZ * rate;
                }

                move.MoveHandler(Time.deltaTime);

                if (move.IsEnd())
                {
                    deleteMoves.Add(move);
                }
            }

            foreach (EntityMove move in deleteMoves)
            {
                BattleModel.RemoveMove(move.GameEntity);
            }
        }
    }
}