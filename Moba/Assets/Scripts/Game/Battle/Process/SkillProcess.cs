using UnityEngine;

public class DeleteSkillProcess : BaseProcess
{
    public DeleteSkillProcess() : base(BattleEventType.DeleteSkill)
    {

    }

    public override void Process()
    {
        var list = GetIdList();
        Debug.Assert(list != null, "list != null");

        foreach (ulong id in list)
        {
            SkillFactory.RemoveSkill(id);
        }
    }
}