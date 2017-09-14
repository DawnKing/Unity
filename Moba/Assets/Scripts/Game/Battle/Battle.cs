using GameProtocol.SceneMessage;
using UnityEngine;
using ZhanChang;

public class Battle : MonoBehaviour
{
    private Battlefield _battlefield;

    // Use this for initialization
    public void Start()
    {
        WindowManager.Add((int)WindowId.Battle, "battle", typeof(BattleWindow), typeof(ZhanChangBinder), typeof(UIBattle));

        WindowManager.Open((int)WindowId.Battle, OnOpenBattleComplete);

        MapTemplate mapTplt = MapTemplateData.GetData(1, this);
        if (mapTplt != null)
            BattleResource.GetMap(mapTplt.Res, OnLoadMapComplete, false);

        BattleModel.CameraEntity = GameObject.Find("Main Camera");
        Debug.Assert(BattleModel.CameraEntity);
    }

    private void OnOpenBattleComplete()
    {
        _battlefield = new Battlefield();
        _battlefield.Init();

        // 552请求进入战场
        if (NetMessage.NetConnection != null)
            RequestBattleEnter.Send(BattleModel.SceneId, this);
        Message.Send(MsgType.OpenBattleWindow);
    }

    private void OnLoadMapComplete(GameObject obj)
    {
        if (obj == null)
            return;
        obj.transform.position = new Vector3(26.5f, 0, 19.3f);
    }

    public void FixedUpdate()
    {
        if (_battlefield != null)
            _battlefield.Process();
    }
}