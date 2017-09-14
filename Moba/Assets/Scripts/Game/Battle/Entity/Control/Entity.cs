using System;
using GameProtocol.SceneMessage;
using UnityEngine;

public class Entity
{
    public ulong Id { get; private set; }
    public EntityData Data { get; protected set; }
    public EntityAvatar Avatar { get; protected set; }

    public virtual void Dispose()
    {

    }

    public virtual void Clear()
    {
        Data.Clear();
        Avatar.Clear();
    }

    public void Set(ulong id)
    {
        Id = id;
    }

    public virtual void Init()
    {
    }

    public virtual void Update()
    {
    }
}

public class MovableEntity : Entity
{
    public MovableData MovableData { get { return Data as MovableData; } }
    public MovableAvatar MovableAvatar { get { return Avatar as MovableAvatar; } }

    protected MovableEntity()
    {
    }

    public override void Init()
    {
        base.Init();
        UpdateAvatar(1);
    }

    public override void Update()
    {
        var time = Time.deltaTime;
        bool isMove;
        bool moveEnd;
        UpdateMove(time, out isMove, out moveEnd);
        if (isMove)
            UpdateAvatar(time);
    }

    public virtual void UpdateMove(float time, out bool isMove, out bool moveEnd)
    {
        isMove = false;
        moveEnd = false;
        // 移动列表，包括多个移动节点
        MoveList moveList = EntityModel.GetMove(Id);
        if (moveList == null)
            return;
        isMove = true;

        // 计算当前移动节点
        EntityMove move = moveList.Get();
        float speed = move.Speed * time;
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
        // 处理移动数据
        move.Move();
        // 移动实体数据
        Data.X += move.SpeedX;
        Data.Z += move.SpeedZ;
        Data.SetRotation(Quaternion.Euler(0, move.Direction * Mathf.Rad2Deg, 0));

        // 单个移动节点结束
        if (move.IsEnd())
        {
            moveList.MoveEnd();
            // 移动列表结束
            if (moveList.IsEnd())
            {
                BattleTool.RemoveMove(Id);

                moveEnd = true;
            }
        }
    }

    private void UpdateAvatar(float time)
    {
        if (!Avatar.Loaded)
            return;
        Avatar.UpdateAvatar(time, Data.Position, Data.Rotation);
    }
}

public class Fighter : MovableEntity
{
    public FighterData FighterData { get { return Data as FighterData; } }
    public FighterAvatar FighterAvatar { get { return Avatar as FighterAvatar; } }

    protected Fighter()
    {
    }

    public void Init(int hp, int maxHp)
    {
        base.Init();
        FighterAvatar.UpdateHp(hp, maxHp);
    }

    public virtual int UpdateHp(ObjectHp objectHp)
    {
        throw new NotImplementedException();
    }
}

public class Player : Fighter
{
    public PlayerData PlayerData { get { return Data as PlayerData; } }
    public PlayerAvatar PlayerAvatar { get { return Avatar as PlayerAvatar; } }

    public Player()
    {
        // ReSharper disable once VirtualMemberCallInConstructor
        Create();
    }

    protected virtual void Create()
    {
        Data = new PlayerData();
        Avatar = new PlayerAvatar();
    }

    public bool IsMovable()
    {
        return true;
    }

    public bool IsAttack()
    {
        return true;
    }

    public override int UpdateHp(ObjectHp objectHp)
    {
        var info = BattleModel.GetPlayerInfo(objectHp.objId);
        if (info == null)
        {
            Debug.LogError("获取失败" + objectHp.objId);
            return 0;
        }

        var changed = objectHp.objHp - info.hp;
        info.hp = objectHp.objHp;

        FighterAvatar.UpdateHp(info.hp, info.maxHp);

        return changed;
    }
}

public sealed class SelfPlayer : Player
{
    public SelfData SelfData { get { return Data as SelfData; } }

    protected override void Create()
    {
        Data = new SelfData();
        Avatar = new SelfAvatar();
    }
}