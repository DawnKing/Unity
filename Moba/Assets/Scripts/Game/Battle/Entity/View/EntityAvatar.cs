using FairyGUI;
using UnityEngine;
using ZhanChang;

public class EntityAvatar
{
    public static int RotateSpeed = 10; // 旋转速度

    public ulong Id { get; private set; }
    public string AssetName { get; protected set; }

    public readonly GameObject Container;
    public GameObject Model { get; protected set; }
    public UIEntityInfo EntityInfo { get; protected set; }

    public EntityAvatar()
    {
        Container = new GameObject("EntityAvatar");
    }

    public virtual void Clear()
    {
        Model = null;
    }

    public void Set(ulong id, string objName)
    {
        Id = id;
        Container.name = objName;
    }

    public bool Loaded
    {
        get { return Model != null; }
    }

    public virtual void Load(string assetName)
    {
        AssetName = assetName;
    }

    protected virtual void OnLoadComplete(GameObject obj)
    {
        Model = obj;
        Model.transform.SetParent(Container.transform, false);

        var entity = EntityModel.GetEntity(Id);
        if (entity == null)
            return;
        UpdateAvatar(entity.Data.Position, entity.Data.Rotation);
    }

    public void UpdateAvatar(float time, Vector3 position, Quaternion rotate)
    {
        SetPosition(position);
        Rotate(time, rotate);
    }

    public void UpdateAvatar(Vector3 position, Quaternion rotate)
    {
        UpdateAvatar(1, position, rotate);
    }

    public void SetPosition(Vector3 position)
    {
        Container.transform.position = position;
    }

    public virtual void Rotate(float time, Quaternion target)
    {
        Model.transform.rotation = time >= 1 ? target : Quaternion.Slerp(Model.transform.rotation, target, time * RotateSpeed);
    }
}

public class MovableAvatar : EntityAvatar
{
    public virtual void BeginMove()
    {
    }

    public virtual void EndMove()
    {
    }
}

public class FighterAvatar : MovableAvatar
{
    public Transform FirePosition { get; protected set; }

    public virtual void SetSkill(string skillType, float radian)
    {
    }

    public void UpdateHp(int hp, int maxHp)
    {
        if (EntityInfo == null)
            return;

        var percent = (double)hp / maxHp * 100;
        EntityInfo.hpBar.asProgress.value = percent;
    }
}

public class PlayerAvatar : FighterAvatar
{
    public static GameObject PlayerContainer = new GameObject("PlayerAvatar");

    private GameObject _head;
    private GameObject _body;

    private Animator _headAnimator;
    private Animator _bodyAnimator;

    public PlayerAvatar()
    {
        Container.transform.SetParent(PlayerContainer.transform, false);
    }

    public override void Clear()
    {
        if (Model == null)
        {
            Debug.LogError("模型还加载完就Clear，需要停止资源加载");
        }
        else
        {
            BattleResource.PushTank(AssetName, Model);
        }
        if (EntityInfo != null)
            EntityInfo.visible = false;

        base.Clear();
    }

    public override void Load(string assetName)
    {
        base.Load(assetName);

        BattleResource.GetTank(assetName, OnLoadComplete);
    }

    public override void BeginMove()
    {
        if (_headAnimator)
            _headAnimator.SetBool(AnimationType.Move, true);

        if (_bodyAnimator)
            _bodyAnimator.SetBool(AnimationType.Move, true);

        Timers.inst.Remove(OnStopMove);
    }

    public override void EndMove()
    {
        // 避免一直停止移动开始移动
        Timers.inst.Add(0.2f, 1, OnStopMove);
    }

    private void OnStopMove(object param)
    {
        if (_headAnimator)
            _headAnimator.SetBool(AnimationType.Move, false);

        if (_bodyAnimator)
            _bodyAnimator.SetBool(AnimationType.Move, false);
    }

    private void RotateUpper(float radian)
    {
        _head.transform.rotation = Quaternion.Euler(0, radian * Mathf.Rad2Deg, 0);
    }

    public override void Rotate(float time, Quaternion target)
    {
        _body.transform.rotation = Quaternion.Slerp(_body.transform.rotation, target, time * RotateSpeed);
    }

    public override void SetSkill(string skillType, float radian)
    {
        if (_headAnimator)
            _headAnimator.SetTrigger(skillType);

        if (_bodyAnimator)
            _bodyAnimator.SetTrigger(skillType);

        RotateUpper(radian);
    }

    protected override void OnLoadComplete(GameObject obj)
    {
        if (obj == null)
            return;
        _head = EntityTool.GetChildGameObject(obj, "head_layer");
        _body = EntityTool.GetChildGameObject(obj, "body_layer");

        _headAnimator = _head.GetComponent<Animator>();
        _bodyAnimator = _body.GetComponent<Animator>();

        FirePosition = EntityTool.GetBoneTransform(ModelBone.FireBone, obj.transform);

        base.OnLoadComplete(obj);

        SetGameObjectTag();

        if (EntityInfo != null)
        {
            EntityInfo.visible = true;
            SetInfo();
            return;
        }

        EntityInfo = UIEntityInfo.CreateInstance();
        EntityInfo.scale = new Vector2(0.03f, 0.03f);
        EntityInfo.rotationX = 60;
        EntityInfo.position = new Vector3(0, -1, -2.5f);
        UITool.CreateUI(Container, EntityInfo);

        SetInfo();
    }

    protected virtual void SetGameObjectTag()
    {
        Container.tag = BattleTool.IsSelfCamp(Id) ? EntityTag.TeamPlayer : EntityTag.EnemyPlayer;
    }

    private void SetInfo()
    {
        var tankInfo = BattleModel.GetPlayerInfo(Id);
        Debug.Assert(tankInfo != null);

        EntityInfo.txtName.text = tankInfo.name;
        EntityInfo.txtName.asTextField.color = BattleTool.IsSelfCamp(Id) ? Color.blue : Color.red;

        UpdateHp(tankInfo.hp, tankInfo.maxHp);
    }
}

public sealed class SelfAvatar : PlayerAvatar
{
    protected override void SetGameObjectTag()
    {
        Container.tag = EntityTag.SelfPlayer;
    }
}