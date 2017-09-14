using System.Collections.Generic;

public sealed class MoveList
{
    internal static readonly ObjectPool<EntityMove> MovePool = new ObjectPool<EntityMove>(100);
    private readonly List<EntityMove> _moveList = new List<EntityMove>();

    public ulong Id;

    // 方向为弧度值
    public void AddMoveList(float fromX, float fromZ, float toX, float toZ, float direction, float speed)
    {
        var move = MovePool.Pop();
        move.SetData(fromX, fromZ, toX, toZ, direction, speed);
        _moveList.Add(move);

        if (_moveList.Count > 1)
        {
            // 后面的移动进行变速
            foreach (var entityMove in _moveList)
            {
                entityMove.Speed = _moveList.Count * speed;
            }
        }
    }

    public void AddMove(float fromX, float fromZ, float toX, float toZ, float direction, float speed)
    {
        if (_moveList.Count == 0)
        {
            var move = MovePool.Pop();
            _moveList.Add(move);
        }
        _moveList[0].SetData(fromX, fromZ, toX, toZ, direction, speed);
    }

    public EntityMove Get()
    {
        return _moveList[0];
    }

    public void MoveEnd()
    {
        _moveList[0].Clear();
        MovePool.Push(_moveList[0]);
        _moveList.RemoveAt(0);
    }

    public bool IsEnd()
    {
        return _moveList.Count == 0;
    }

    public void Clear()
    {
        foreach (var entityMove in _moveList)
        {
            entityMove.Clear();
            MovePool.Push(entityMove);
        }
        _moveList.Clear();
    }
}

public sealed class EntityMove
{
    public float TargetX { get; private set; }    // 移动位置
    public float TargetZ { get; private set; }
    public float Direction { get; private set; }    // 移动方向，弧度值
    public float Speed { get; internal set; }    // 移动速度

    public float MoveX { get; private set; }      // 移动位移
    public float MoveZ { get; private set; }
    
    public float SpeedX;    // 每帧移动分量
    public float SpeedZ;

    public void SetData(float fromX, float fromZ, float toX, float toZ, float direction, float speed)
    {
        TargetX = toX;
        TargetZ = toZ;
        Direction = direction;
        Speed = speed;

        MoveX = TargetX - fromX;
        MoveZ = TargetZ - fromZ;
    }

    public void Move()
    {
        MoveX -= SpeedX;
        MoveZ -= SpeedZ;
    }

    public bool IsEnd()
    {
        return MoveX.Equals(0) && MoveZ.Equals(0);
    }

    public void Clear()
    {
        SpeedX = 0;
        SpeedZ = 0;
    }
}