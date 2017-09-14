using DG.Tweening;
using FairyGUI;
using UnityEngine;

public class JoystickModule : EventDispatcher
{
    private readonly float _initX;
    private readonly float _initY;
    private float _startStageX;
    private float _startStageY;
    private float _lastStageX;
    private float _lastStageY;

    private readonly GButton _button;
    private readonly GObject _mainView;
    private readonly GObject _thumb;
    private readonly GObject _center;

    private int _touchId;
    private Tweener _tweener;

    public EventListener OnMove { get; private set; }
    public EventListener OnEnd { get; private set; }

    public int Radius { get; set; }

    public JoystickModule(GComponent mainView)
    {
        OnMove = new EventListener(this, "onMove");
        OnEnd = new EventListener(this, "onEnd");

        _mainView = mainView;
        _button = mainView.GetChild("joystick").asButton;
        _button.changeStateOnClick = false;
        _thumb = _button.GetChild("thumb");
        _center = mainView.GetChild("joystick_center");

        _initX = _center.x + _center.width / 2;
        _initY = _center.y + _center.height / 2;
        _touchId = -1;
        Radius = 150;

        _mainView.onTouchBegin.Add(OnTouchDown);
    }

    private void OnTouchDown(EventContext context)
    {
        if (_touchId == -1)//First touch
        {
            InputEvent evt = (InputEvent)context.data;
            _touchId = evt.touchId;

            if (_tweener != null)
            {
                _tweener.Kill();
                _tweener = null;
            }

            Vector2 pt = GRoot.inst.GlobalToLocal(new Vector2(evt.x, evt.y));
            float bx = pt.x - _mainView.x;
            float by = pt.y - _mainView.y;
            _button.selected = true;

            if (bx < 0)
                bx = 0;
            else if (bx > _mainView.width)
                bx = _mainView.width;

            if (by < 0)
                by = 0;
            else if (by > _mainView.height)
                by = _mainView.height;

            _lastStageX = bx;
            _lastStageY = by;
            _startStageX = bx;
            _startStageY = by;

            _center.visible = true;
            _center.x = bx - _center.width / 2;
            _center.y = by - _center.height / 2;
            _button.x = bx - _button.width / 2;
            _button.y = by - _button.height / 2;

            float deltaX = bx - _initX;
            float deltaY = by - _initY;
            float degrees = Mathf.Atan2(deltaY, deltaX) * 180 / Mathf.PI;
            _thumb.rotation = degrees + 90;

            Stage.inst.onTouchMove.Add(OnTouchMove);
            Stage.inst.onTouchEnd.Add(OnTouchUp);
        }
    }

    private void OnTouchUp(EventContext context)
    {
        InputEvent inputEvt = (InputEvent)context.data;
        if (_touchId != -1 && inputEvt.touchId == _touchId)
        {
            _touchId = -1;
            _thumb.rotation = _thumb.rotation + 180;
            _center.visible = false;
            _tweener = _button.TweenMove(new Vector2(_initX - _button.width / 2, _initY - _button.height / 2), 0.3f).OnComplete(() =>
            {
                _tweener = null;
                _button.selected = false;
                _thumb.rotation = 0;
                _center.visible = true;
                _center.x = _initX - _center.width / 2;
                _center.y = _initY - _center.height / 2;
            }
            );

            Stage.inst.onTouchMove.Remove(OnTouchMove);
            Stage.inst.onTouchEnd.Remove(OnTouchUp);

            OnEnd.Call();
        }
    }

    private void OnTouchMove(EventContext context)
    {
        InputEvent evt = (InputEvent)context.data;
        if (_touchId != -1 && evt.touchId == _touchId)
        {
            Vector2 pt = GRoot.inst.GlobalToLocal(new Vector2(evt.x, evt.y));
            float bx = pt.x - _mainView.x;
            float by = pt.y - _mainView.y;
            float moveX = bx - _lastStageX;
            float moveY = by - _lastStageY;
            _lastStageX = bx;
            _lastStageY = by;
            float buttonX = _button.x + moveX;
            float buttonY = _button.y + moveY;

            float offsetX = buttonX + _button.width / 2 - _startStageX;
            float offsetY = buttonY + _button.height / 2 - _startStageY;

            float rad = Mathf.Atan2(offsetY, offsetX);
            float degree = rad * 180 / Mathf.PI;
            _thumb.rotation = degree + 90;

            float maxX = Radius * Mathf.Cos(rad);
            float maxY = Radius * Mathf.Sin(rad);
            if (Mathf.Abs(offsetX) > Mathf.Abs(maxX))
                offsetX = maxX;
            if (Mathf.Abs(offsetY) > Mathf.Abs(maxY))
                offsetY = maxY;

            buttonX = _startStageX + offsetX;
            buttonY = _startStageY + offsetY;

            if (buttonX < 0)
                buttonX = 0;
            if (buttonY > _mainView.height)
                buttonY = _mainView.height;

            _button.x = buttonX - _button.width / 2;
            _button.y = buttonY - _button.height / 2;

            OnMove.Call(degree + 90);
        }
    }
}