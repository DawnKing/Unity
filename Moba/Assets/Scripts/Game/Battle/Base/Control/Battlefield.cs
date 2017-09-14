using System.Collections.Generic;

public class Battlefield
{
    protected readonly List<BaseProcess> Processes = new List<BaseProcess>();
    protected SelfSkillProcess SelfSkill;

    public virtual void Init()
    {
        Processes.Add(new UpdateHpProcess());

        Processes.Add(new DeletePlayerProcess());
        Processes.Add(new DeleteSkillProcess());

        Processes.Add(new CreatePlayerProcess());

        Processes.Add(new TargetProcess());
        Processes.Add(new InputMoveProcess());
        Processes.Add(new InputAttackProcess());
        Processes.Add(SelfSkill = new SelfSkillProcess());

        Processes.Add(new CameraMoveProcess());

        SelfSkill.SkillId = 1;
    }

    public void Process()
    {
        int length = Processes.Count;
        for (int i = 0; i < length; i++)
        {
            BaseProcess p = Processes[i];
            if (!p.IsProcess())
                continue;
            p.Process();
            p.Complete();
        }

        var entities = EntityModel.GetEntities();
        foreach (var pair in entities)
        {
            pair.Value.Update();
        }
    }
}