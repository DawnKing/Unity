public class SkillEntity : MovableEntity
{
    public SkillData SkillData { get { return Data as SkillData; } }
    public SkillAvatar SkillAvatar { get { return Avatar as SkillAvatar; } }

    private static uint _totalUuid = 1 << 56;

    public SkillEntity()
    {
        Data = new SkillData();
        Avatar = new SkillAvatar();
    }

    public void Set()
    {
        Set(_totalUuid++);
        SkillAvatar.Set(Id, GetType().Name);
    }

    public virtual void Play(SkillDisplay skillDisplay)
    {
        Init();
    }
}