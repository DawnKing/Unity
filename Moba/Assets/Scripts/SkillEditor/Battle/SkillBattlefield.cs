public class SkillBattlefield : Battlefield
{
    public override void Init()
    {
        Processes.Add(new DeleteSkillProcess());

        Processes.Add(new CreatePlayerProcess());

        Processes.Add(new TargetProcess());
        Processes.Add(new InputMoveProcess());
        Processes.Add(new EditorSkillProcess());

        Processes.Add(new CameraMoveProcess());
    }
}
