using GameProtocol.BulkDataEnum;
using GameProtocol.SceneMessage;
using GameProtocol.TankMessage;
using System;
using GameProtocol;
using UnityEngine;
using Random = UnityEngine.Random;

public class BattleDebug : MonoBehaviour
{
    public int EntityPool;
    public int SkillEntityPool;
    public int MoveListPool;
    public int MovePool;

    public void Start()
	{
	    if (!Core.Inst.UseNet)
	    {
	        // 名字血条信息在战场界面的包里，需要等加载完成
	        if (WindowManager.Opened((int)WindowId.Battle))
	            OnOpenComplete(null);
	        else
	            Message.AddListener(MsgType.OpenBattleWindow, OnOpenComplete);
        }
    }

    public void Update()
    {
        EntityPool = EntityModel.EntityPoolCount;
        SkillEntityPool = EntityModel.SkillEntityPoolCount;
        MoveListPool = EntityModel.MoveListPoolCount;
	    MovePool = MoveList.MovePool.Count;
	}

    public void FixedUpdate()
    {
        PCHandler();
        SceneData();
    }

    public static void PCHandler()
    {
        if (BattleEvent.Inst.HasEvent(BattleEventType.MoveJoystick))
            return;
        float xDelta = Input.GetAxis("Horizontal");
        float yDelta = Input.GetAxis("Vertical");
        if (!xDelta.Equals(0) || !yDelta.Equals(0))
        {
            float radian = Mathf.Atan2(xDelta, yDelta);
            BattleEvent.Inst.AddEvent(BattleEventType.MoveJoystick, radian);
        }

        if (BattleEvent.Inst.HasEvent(BattleEventType.AttachJoystick))
            return;

        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(ray.origin, hit.point);
                float xAttackDelta = hit.point.x - BattleModel.Self.Data.X;
                float zAttackDelta = hit.point.z - BattleModel.Self.Data.Z;
                float attackRadian = Mathf.Atan2(xAttackDelta, zAttackDelta);
                BattleEvent.Inst.AddEvent(BattleEventType.AttachJoystick, attackRadian);
            }
        }
    }

    private int _count;
    private void SceneData()
    {
        if (!Input.GetMouseButton(1))
            return;
        _count++;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out hit))
            return;

        ulong selectId = 0;

        var entity = EntityModel.GetEntity(selectId);
        var entityData = entity.Data;

        Debug.DrawLine(ray.origin, hit.point);
        float xDelta = hit.point.x - entityData.X;
        float zDelta = hit.point.z - entityData.Z;
        float radian = Mathf.Atan2(xDelta, zDelta);

        var sceneData = new SyncSceneData();

        sceneData.moveVec = new MoveInfo[1];
        sceneData.moveVec[0] = new MoveInfo();
        sceneData.moveVec[0].objId = 0;
        sceneData.moveVec[0].x = CMath.MeterToInchX(hit.point.x);
        sceneData.moveVec[0].y = CMath.MeterToInchZ(hit.point.z);
        sceneData.moveVec[0].speed = 140;
        sceneData.moveVec[0].direction = CMath.AngleToDirection(radian * Mathf.Rad2Deg);
        sceneData.moveVec[0].moveType = MOVE_TYPE.MOVE_NORMAL;

        sceneData.fireVec = new NotifyFire[1];
        sceneData.fireVec[0] = new NotifyFire();
        sceneData.fireVec[0].bullteId = 1 << 52;
        sceneData.fireVec[0].objId = selectId;
        sceneData.fireVec[0].startX = CMath.MeterToInchX(entityData.X);
        sceneData.fireVec[0].startY = CMath.MeterToInchZ(entityData.Z);
        sceneData.fireVec[0].destX = CMath.MeterToInchX(hit.point.x);
        sceneData.fireVec[0].destY = CMath.MeterToInchZ(hit.point.z);
        sceneData.fireVec[0].Speed = 1;

        sceneData.skillVec = new NotifyUseSkill[0];

        sceneData.hpVec = new ObjectHp[1];
        sceneData.hpVec[0] = new ObjectHp();
        sceneData.hpVec[0].objId = 2;
        sceneData.hpVec[0].objHp = _count % 100;
        sceneData.hpVec[0].Fury = 0;

        sceneData.deadVec = new AINpcDead[0];
        sceneData.mpVec = new ObjectMp[0];
        sceneData.blowUpVec = new ulong[0];

        sceneData.delVec = new ulong[1];
        sceneData.delVec[0] = 1;

        sceneData.overVec = new ulong[0];

        NetMessage.DispatchMessage(sceneData.BuildPacket());
    }

    private void OnOpenComplete(object obj)
    {
        AddPlayer();
    }

    private void AddPlayer()
    {
        // 玩家自己
        var selfData = new NotifySelfData();
        selfData.speed = 140;
        selfData.selfData = new TankInfo();
        selfData.selfData.acctOid = 1000;
        selfData.selfData.name = "SelfPlayer";
        selfData.selfData.hp = 100;
        selfData.selfData.maxHp = 100;

        NetMessage.DispatchMessage(selfData.BuildPacket());

        // 其他玩家
        var count = 9;
        for (uint i = 0; i < count; i++)
        {
            var addTank = new NotifyAddTank();
            addTank.selfData = new TankInfo();
            addTank.selfData.acctOid = i;
            addTank.selfData.x = (short)Random.Range(0, 1000);
            addTank.selfData.y = (short)Random.Range(0, 1000);
            addTank.selfData.name = "OtherPlayer" + i;
            addTank.selfData.hp = 100;
            addTank.selfData.maxHp = 100;
            if (i > 3)
                addTank.selfData.Camp = 1;
            NetMessage.DispatchMessage(addTank.BuildPacket());
        }
    }
}

public static class DirectionType
{
    // ReSharper disable once InconsistentNaming
    public const byte UP_LEFT = 0;
    // ReSharper disable once InconsistentNaming
    public const byte UP = 1;
    // ReSharper disable once InconsistentNaming
    public const byte UP_RIGHT = 2;
    // ReSharper disable once InconsistentNaming
    public const byte RIGHT = 3;
    // ReSharper disable once InconsistentNaming
    public const byte DOWN_RIGHT = 4;
    // ReSharper disable once InconsistentNaming
    public const byte DOWN = 5;
    // ReSharper disable once InconsistentNaming
    public const byte DOWN_LEFT = 6;
    // ReSharper disable once InconsistentNaming
    public const byte LEFT = 7;
    // ReSharper disable once InconsistentNaming
    public const byte NONE = 8;
}

public class CMath
{
    public static float DirectionToAngle(byte direction)
    {
        float angle = 0;
        switch (direction)
        {
            case DirectionType.UP:
                angle = 0;
                break;
            case DirectionType.UP_RIGHT:
                angle = 45;
                break;
            case DirectionType.RIGHT:
                angle = 90;
                break;
            case DirectionType.DOWN_RIGHT:
                angle = 135;
                break;
            case DirectionType.DOWN:
                angle = 180;
                break;
            case DirectionType.DOWN_LEFT:
                angle = 225;
                break;
            case DirectionType.LEFT:
                angle = 270;
                break;
            case DirectionType.UP_LEFT:
                angle = 315;
                break;
        }
        return angle;
    }

    public static byte AngleToDirection(float angle)
    {
        while (angle < 0)
            angle += 360;
        return (byte)((Math.Floor(angle / 45) + 1) % 8);
    }

    public static short MeterToInchX(float meter)
    {
        return Convert.ToInt16(meter * UnityMeter);
    }

    public static short MeterToInchZ(float meter)
    {
        return Convert.ToInt16(MapHeight - meter * UnityMeter);
    }

    public static float InchToMeter(float inch)
    {
        return inch / UnityMeter;
    }

    public static float InchToMeterX(float inch)
    {
        return inch / UnityMeter;
    }

    const int MapHeight = 1700;
    public static float InchToMeterZ(float inch)
    {
        return MapHeight / UnityMeter - inch / UnityMeter;
    }

    public const float UnityMeter = 39.37f; // unity使用米为单位，游戏使用英寸，1米 = 39.37英寸
    public const float Grid = 24 / UnityMeter;

    public static float GetRotationRadian(float x1, float y1, float x2, float y2)
    {
        return GetRotation(x1, y1, x2, y2) * Mathf.Deg2Rad;     // Unity中上0，右90，下180，左270
    }

    public static float GetRotation(float x1, float y1, float x2, float y2)
    {
        float deltaX = x2 - x1;
        float deltaY = y1 - y2; // 坦克地图原点在左上角，Unity在左下角
        if (deltaX.Equals(0))
        {
            return deltaY < 0 ? 0 : 180;
        }

        float rotation = Mathf.Atan2(deltaY, deltaX) * Mathf.Rad2Deg;// 右为0度，左为180度，上为-90度，下为90度
        return rotation + 90;     // Unity中上0，右90，下180，左270
    }
}