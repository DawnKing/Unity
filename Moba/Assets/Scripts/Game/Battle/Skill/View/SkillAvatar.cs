using UnityEngine;

public class SkillAvatar : MovableAvatar
{
    public static GameObject SkillContainer = new GameObject("SkillAvatar");
    public string TankName { get; private set; }

    public SkillAvatar()
    {
        Container.transform.SetParent(SkillContainer.transform, false);
    }

    public void Load(string tankName, string skillName)
    {
        TankName = tankName;
        AssetName = skillName;

        BattleResource.GetSkill(tankName, skillName, OnLoadComplete);
    }

    protected override void OnLoadComplete(GameObject obj)
    {
        Model = obj;
        Model.transform.SetParent(Container.transform, false);
    }

    public void SetModel(GameObject obj, string tankName, string skillName)
    {
        Model = obj;
        Model.transform.SetParent(Container.transform, false);
        TankName = tankName;
        AssetName = skillName;
    }

    public void MoveEnd()
    {
        BattleResource.PushSkill(TankName, AssetName, Model);
    }
}
