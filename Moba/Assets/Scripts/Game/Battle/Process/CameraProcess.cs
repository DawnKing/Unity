using UnityEngine;

public class CameraMoveProcess : BaseProcess
{
    public CameraMoveProcess() : base(0)
    {
    }

    public override bool IsProcess()
    {
        if (BattleModel.Self != null)
            return true;
        return false;
    }

    public override void Complete()
    {
    }

    public override void Process()
    {
        var data = BattleModel.Self.Data;
        Vector3 target = data.Position;
        BattleModel.CameraPosition.x = target.x;
        BattleModel.CameraPosition.z = target.z - 10;
        BattleModel.CameraEntity.transform.position = BattleModel.CameraPosition;
    }
}
