using Common;

namespace Assets.Scripts.Battle.Base.Model
{
    public sealed class EntityMove
    {
        public GameEntity GameEntity { get; private set; }
        // 移动方向
        public float Radian { get; private set; }
        // 移动结束位置
        public float EndX { get; private set; }
        public float EndZ { get; private set; }
        // 移动位移
        public float MoveX { get; private set; }
        public float MoveZ { get; private set; }
        // 每帧移动分量，NPC移动使用服务端发来的分量
        public float SpeedX;
        public float SpeedZ;

        public void SetData(GameEntity entity, float radian, float targetX, float targetZ)
        {
            if (entity == null)
                Log.Error("", this);

            GameEntity = entity;
            Radian = radian;
            EndX = targetX;
            EndZ = targetZ;
            MoveX = targetX - entity.Position.x;
            MoveZ = targetZ - entity.Position.z;
        }

        internal void MoveHandler(float time)
        {
            GameEntity.RotateTo(time, Radian);
            GameEntity.MoveTo(SpeedX, SpeedZ);
            MoveX -= SpeedX;
            MoveZ -= SpeedZ;
        }

        internal bool IsEnd()
        {
            return MoveX.Equals(0) && MoveZ.Equals(0);
        }

        public void Clear()
        {
            GameEntity = null;
            SpeedX = 0;
            SpeedZ = 0;
        }
    }
}