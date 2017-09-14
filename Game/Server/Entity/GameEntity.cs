namespace Server.Entity
{
    public class GameEntity
    {
        public uint Id;
        public float X;
        public float Y;
        public float Z;

        public GameEntity(uint id)
        {
            Id = id;
        }

        public void SetPosition(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
