using FairyGUI;
using GameCore;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using ZhanChang;

public sealed class BattleWindow : WindowExtend
{
    public UIBattle Frame { get { return contentPane as UIBattle; } }

    JoystickModule _moveJoystick;
    JoystickModule _attackJoystick;
    private float _moveDegree;
    private float _attackDegree;
    private bool _moving;
    private bool _attacking;

    public BattleWindow()
    {
        InitType = InitWindow.FullScreen;
    }

    protected override void OnHide()
    {
        Timers.inst.Remove(Update);
        base.OnHide();
    }

    public override void Dispose()
    {
        Timers.inst.Remove(Update);
        base.Dispose();
    }

    protected override void OnShown()
    {
        MakeFullScreen();
        _moveJoystick = new JoystickModule(Frame.MoveJoystick);
        _moveJoystick.OnMove.Add(OnJoystickMove);
        _moveJoystick.OnEnd.Add(OnJoystickEnd);

        _attackJoystick = new JoystickModule(Frame.AttackJoystick);
        _attackJoystick.OnMove.Add(OnAttackMove);
        _attackJoystick.OnEnd.Add(OnAttackEnd);

        Frame.BtnSkill1.onClick.Add(OnSkill1);

        Frame.btnT1.onClick.Add(T1);
        //                Frame.btnT2.onClick.Add(T2);

        Timers.inst.AddUpdate(Update);
    }

    private void OnSkill1(EventContext context)
    {
        BattleEvent.Inst.AddEvent(BattleEventType.SelectTarget);
        BattleEvent.Inst.AddEvent(BattleEventType.Skill1);
    }

    void T1()
    {
        HotfixManager.HotfixMethod();
//        Core.Inst.StartCoroutine(GetText("http://120.31.130.198/event_bug.txt"));
    }

    void T2()
    {
        Core.Inst.StartCoroutine(GetText("http://120.31.130.198/fix_event_bug.txt"));
    }

    IEnumerator GetText(string url)
    {
        UnityWebRequest loader = UnityWebRequest.Get(url);
        Debug.Log("hotfix   " + url);

        yield return loader.Send();

        if (loader.isError)
        {
            Debug.Log(loader.error);
        }
        else
        {
            // Show results as text
            Debug.Log(loader.downloadHandler.text);

            HotfixManager.LuaRuntime.DoString(loader.downloadHandler.text);
        }
    }

    void OnJoystickMove(EventContext context)
    {
        _moving = true;
        _moveDegree = Convert.ToSingle(context.data);
        Frame.MoveJoystick.txtDegree.text = "" + _moveDegree;
    }

    void OnJoystickEnd()
    {
        _moving = false;
        Frame.MoveJoystick.txtDegree.text = "";
    }

    void OnAttackMove(EventContext context)
    {
        _attacking = true;
        _attackDegree = Convert.ToSingle(context.data);
        Frame.AttackJoystick.txtDegree.text = "" + _attackDegree;
    }

    void OnAttackEnd()
    {
        _attacking = false;
        Frame.AttackJoystick.txtDegree.text = "";
    }

    private void Update(object param)
    {
        if (_moving)
        {
            if (!BattleEvent.Inst.HasEvent(BattleEventType.MoveJoystick))
                BattleEvent.Inst.AddEvent(BattleEventType.MoveJoystick, _moveDegree * Mathf.Deg2Rad);
        }

        if (_attacking)
        {
            if (!BattleEvent.Inst.HasEvent(BattleEventType.AttachJoystick))
                BattleEvent.Inst.AddEvent(BattleEventType.AttachJoystick, _attackDegree * Mathf.Deg2Rad);
        }
    }

    public bool Attacking
    {
        get { return _attacking; }
    }
}
