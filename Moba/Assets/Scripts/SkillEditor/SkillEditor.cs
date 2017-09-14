using FairyGUI;
using GameProtocol.TankMessage;
using UnityEngine;
using ZhanChang;

public class SkillEditor : MonoBehaviour
{
    public static SkillEditor Inst;
    public float SkillTime = 1.0f;   // 技能间隔1秒

    private Battlefield _battlefield;

    // Use this for initialization
    public void Start()
    {
        Inst = this;
        MapTemplate mapTplt = MapTemplateData.GetData(1, this);
        if (mapTplt != null)
            BattleResource.GetMap(mapTplt.Res, OnLoadMapComplete, false);

        ZhanChangBinder.BindAll();
        AssetManager.LoadAssetBundle(GamePath.UI + "battle", OnComplete);

        BattleModel.CameraEntity = GameObject.Find("Main Camera");
        Debug.Assert(BattleModel.CameraEntity);
    }

    private void OnLoadMapComplete(GameObject obj)
    {
        if (obj == null)
            return;
        obj.transform.position = new Vector3(26.5f, 0, 19.3f);
    }

    public void Update()
    {
        BattleDebug.PCHandler();

        if (_battlefield != null)
            _battlefield.Process();
    }

    private void OnComplete(AssetBundle obj)
    {
        if (obj == null)
            return;
        UIPackage.AddPackage(obj, obj);
        var window = new BattleWindow();
        window.Show();

        _battlefield = new SkillBattlefield();
        _battlefield.Init();

        AddPlayer();
    }

    private void AddPlayer()
    {
        // 玩家自己
        BattleModel.SelfData = new NotifySelfData();
        BattleModel.SelfData.speed = 140;

        var info = new TankInfo();
        info.acctOid = 1000;
        info.name = "SelfPlayer";
        info.hp = 100;
        info.maxHp = 100;

        EntityFactory.AddSelfPlayer(info);

        // 其他玩家
        var count = 1;
        for (uint i = 0; i < count; i++)
        {
            info = new TankInfo();
            info.acctOid = i;
            info.x = (short)Random.Range(0, 1000);
            info.y = (short)Random.Range(0, 1000);
            info.name = "OtherPlayer" + i;
            info.hp = 100;
            info.maxHp = 100;
            if (i > 3)
                info.Camp = 1;
            BattleEvent.Inst.AddEvent(BattleEventType.CreatePlayer, info);
        }
    }
}