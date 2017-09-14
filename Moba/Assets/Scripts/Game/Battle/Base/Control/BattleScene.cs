using GameProtocol.BulkDataEnum;
using GameProtocol.SceneMessage;
using GameProtocol.ShareTypes;
using GameProtocol.TankMessage;
using UnityEngine;

public static class BattleScene 
{
    public static void SceneHandler(SyncSceneData notify)
    {
        MoveHandler(notify.moveVec);
        FireHandler(notify.fireVec);
//        SkillHandler(notify.skillVec);
        HpHandler(notify.hpVec);
//        DeadHandler(notify.deadVec);
//        MpHandler(notify.mpVec);
//        BlowUpHandler(notify.blowUpVec);
        DeleteHandler(notify.delVec);
//        OverHandler(notify.overVec);
    }

    private static void MoveHandler(MoveInfo[] moveList)
    {
        foreach (MoveInfo moveInfo in moveList)
        {
            int objectType = GetObjectType(moveInfo.objId);
            switch (objectType)
            {
                case GAME_OBJECT_TYPE.ZUOBJ_TANK:
                    PlayerMoveHandler(moveInfo);
                    break;
                case GAME_OBJECT_TYPE.ZUOBJ_AINPC:
//                    Debug.LogWarning("ZUOBJ_AINPC id " + moveInfo.objId);
                    break;
                default:
//                    Debug.LogWarning("未处理的对象类型" + objectType);
                    break;
            }
        }
    }

    private static void PlayerMoveHandler(MoveInfo moveInfo)
    {
        // 如果是自己坦克且不是击退的移动信息则不处理
        if (moveInfo.objId == BattleModel.Self.Id && !IsSeverControlMove(moveInfo.moveType))
            return;

        BattleTool.AddMoveList(moveInfo);
    }

    private static bool IsSeverControlMove(byte type)
    {
        return type == MOVE_TYPE.MOVE_BEAT_BACK ||
               type == MOVE_TYPE.MOVE_THROW ||
               type == MOVE_TYPE.MOVE_DASH ||
               type == MOVE_TYPE.MOVE_SERVER;
    }

    private static int GetObjectType(ulong objId)
    {
        int type = (int)(objId >> 56);
        return type;
    }

    private static void FireHandler(NotifyFire[] fireVec)
    {
        foreach (NotifyFire notifyFire in fireVec)
        {
            var entity = EntityModel.GetFighter(notifyFire.objId);
            if (entity == null)
                continue;

            var fromX = CMath.InchToMeterX(notifyFire.startX);
            var fromZ = CMath.InchToMeterZ(notifyFire.startY);
            var toX = CMath.InchToMeterX(notifyFire.destX);
            var toZ = CMath.InchToMeterZ(notifyFire.destY);
            var speed = CMath.InchToMeter(notifyFire.Speed);
            float radian = CMath.GetRotationRadian(fromX, fromZ, toX, toZ);

            SkillTool.AddSkill(entity.Id, 1, AnimationType.Attack, 
                fromX, fromZ, toX, toZ, 
                radian, speed, entity.FighterAvatar.FirePosition);
        }
    }

    private static void SkillHandler(NotifyUseSkill[] skillVec)
    {
        foreach (var notifyUseSkill in skillVec)
        {
            var skillTplt = SkillTemplateData.GetData(notifyUseSkill.SkillId, typeof(BattleScene));
            if (skillTplt == null)
                continue;

//            if (notifyUseSkill.isReady == 1) // 如果是技能蓄力阶段
//            {
//                if (skillTplt.ChargeEffectId != 0) // 如果有蓄力动画
//                    SkillTool.AddChargeSkill(skillTplt.ChargeEffectId, notifyUseSkill);
//            }
//            else if (skillTplt.SkillEffectId != 0) // 如果有技能动画
//            {
//                SkillTool.AddSkillEffect(skillTplt.SkillEffectId, notifyUseSkill);
//            }
        }
    }

    private static void HpHandler(ObjectHp[] hpVec)
    {
        foreach (ObjectHp objectHp in hpVec)
        {
            int objectType = GetObjectType(objectHp.objId);
            switch (objectType)
            {
                case GAME_OBJECT_TYPE.ZUOBJ_TANK:
                    BattleEvent.Inst.AddEvent(BattleEventType.UpdateHp, objectHp);

                    if (objectHp.objHp == 0)
                    {
                        BattleEvent.Inst.AddEvent(BattleEventType.DeletePlayer, objectHp.objId);
                    }
                    break;
                case GAME_OBJECT_TYPE.ZUOBJ_PROPS:
                    break;
                case GAME_OBJECT_TYPE.ZUOBJ_AINPC:
                    break;
                default:
//                    Debug.LogWarning("未处理的对象类型" + objectType);
                    break;
            }
        }
    }

    private static void DeadHandler(AINpcDead[] deadVec)
    {
        foreach (var aiNpcDead in deadVec)
        {
            
        }
    }

    private static void MpHandler(ObjectMp[] mpVec)
    {
        foreach (var objectMp in mpVec)
        {
            
        }
    }

    private static void BlowUpHandler(ulong[] blowUpVec)
    {
        foreach (var id in blowUpVec)
        {
            
        }
    }

    private static void DeleteHandler(ulong[] delVec)
    {
        foreach (ulong objId in delVec)
        {
            int objectType = GetObjectType(objId);
            switch (objectType)
            {
                case GAME_OBJECT_TYPE.ZUOBJ_TANK:
                    Debug.Log("[DeleteHandler]删除" + objId);
                    BattleEvent.Inst.AddEvent(BattleEventType.DeletePlayer, objId);
                    break;
                case GAME_OBJECT_TYPE.ZUOBJ_PROPS:
                    break;
                case GAME_OBJECT_TYPE.ZUOBJ_AINPC:
//                    Debug.LogWarning("未处理的对象类型" + objectType);
                    break;
                default:
//                    Debug.LogWarning("未处理的对象类型" + objectType);
                    break;
            }
        }
    }

    private static void OverHandler(ulong[] overVec)
    {
        foreach (var id in overVec)
        {
            
        }
    }
}
