using Assets.Scripts.Battle.Base.Control;
using UnityEngine;

public class CameraMoveProcess : BaseProcess
{
    public CameraMoveProcess() : base(0)
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
        Vector3 target = BattleModel.SelfPlayer.Entity.transform.position;
        BattleModel.CameraPosition.x = target.x;
        BattleModel.CameraPosition.z = target.z - 10;
        BattleModel.CameraEntity.transform.position = BattleModel.CameraPosition;
    }
}
