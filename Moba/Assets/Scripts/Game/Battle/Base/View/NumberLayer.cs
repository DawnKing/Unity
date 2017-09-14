using FairyGUI;
using System.Collections.Generic;
using UnityEngine;
using ZhanChang;
using Random = UnityEngine.Random;

public enum NumType
{
    Red, Green, Yellow, Purple, Big
}

public class NumberLayer : MonoBehaviour
{
    private static readonly List<FlyNumber> RedNumPool = new List<FlyNumber>();
    private static readonly List<FlyNumber> GreenNumPool = new List<FlyNumber>();
//    private static readonly List<FlyNumber> YellowNumPool = new List<FlyNumber>();
//    private static readonly List<FlyNumber> PurpleNumPool = new List<FlyNumber>();
    private static readonly List<FlyNumber> BigNumPool = new List<FlyNumber>();

    private static readonly List<FlyNumber> UpdateList = new List<FlyNumber>();
    public static NumberLayer Inst;

    public void Start()
    {
        Debug.Assert(Inst == null);
        Inst = this;

        // 数字图片资源在战场界面的包里，需要等加载完成
        if (WindowManager.Opened((int)WindowId.Battle))
            OnOpenComplete(null);
        else
            Message.AddListener(MsgType.OpenBattleWindow, OnOpenComplete);
    }

    public void FixedUpdate()
    {
        var list = UpdateList.ToArray();
        foreach (var number in list)
        {
            number.Update();
        }
    }

    public void OnDestroy()
    {
        Message.RemoveListener(MsgType.OpenBattleWindow, OnOpenComplete);
    }

    private void OnOpenComplete(object obj)
    {
        var num = UINumberLayer.CreateInstance();
        UITool.CreateUI(gameObject, num);

        const int count = 10;
        for (int i = 0; i < count; i++)
        {
            RedNumPool.Add(CreateFlyNum(num, NumType.Red, num.redNum));
            GreenNumPool.Add(CreateFlyNum(num, NumType.Green, num.greenNum));
            BigNumPool.Add(CreateFlyNum(num, NumType.Big, num.bigNum));
        }
    }

    private FlyNumber CreateFlyNum(UINumberLayer numLayer, NumType type, GTextField txt)
    {
        var packageItem = UIPackage.GetItemByURL(numLayer.resourceURL);

        GTextField child = null;

        DisplayListItem[] displayList = packageItem.displayList;
        int childCount = displayList.Length;
        for (int i = 0; i < childCount; i++)
        {
            DisplayListItem di = displayList[i];
            if (di.desc.GetAttribute("name") != txt.name)
                continue;
            child = UIObjectFactory.NewObject(di.type).asTextField;
            child.underConstruct = true;
            child.Setup_BeforeAdd(di.desc);
            numLayer.AddChild(child);

            child.scale = new Vector2(0.03f, 0.03f);
            child.position = new Vector3(0, -4, 40f);
            child.rotationX = 60;

            break;
        }

        return new FlyNumber(type, child);
    }

    public static void ShowNum(Vector3 position, NumType type, int value)
    {
        ShowNum(position.x, position.z, type, value);
    }

    public static void ShowNum(float x, float z, NumType type, int value)
    {
        List<FlyNumber> pool = GetPool(type);
        FlyNumber num = null;
        if (pool.Count > 0)
        {
            num = pool[0];
            pool.RemoveAt(0);
        }
        if (num == null)
            return;
        num.SetData(x, z, value);
        UpdateList.Add(num);
    }

    public static void Push(FlyNumber number)
    {
        List<FlyNumber> pool = GetPool(number.Type);
        pool.Add(number);
        if (!UpdateList.Remove(number))
            Debug.LogWarning("");

        number.TextField.visible = false;
    }

    private static List<FlyNumber> GetPool(NumType type)
    {
        List<FlyNumber> pool = null;
        switch (type)
        {
            case NumType.Red:
                pool = RedNumPool;
                break;
            case NumType.Green:
                pool = GreenNumPool;
                break;
            case NumType.Big:
                pool = BigNumPool;
                break;
        }
        return pool;
    }
}

public class FlyNumber
{
    private const float FlySpeedAccelration = 0.01f;   // 飞行时减速的加速度
    private const float FlySpeedOrigin = 0.2f;  // 飞行初始速度

    private float _flySpeedY;   // 纵向飞行速度

    public NumType Type { get; private set; }
    public GTextField TextField { get; private set; }

    public FlyNumber(NumType type, GTextField textField)
    {
        Type = type;
        TextField = textField;
    }

    public void SetData(float x, float z, int value)
    {
        TextField.visible = true;
        TextField.text = value > 0 ? "+" + value : value.ToString();

        x = x + Random.Range(-1f, 0f);
        z += 1;
        TextField.SetPosition(x, -3, z);

        _flySpeedY = FlySpeedOrigin;
    }

    public void Update()
    {
        if (_flySpeedY > 0)
        {
            TextField.z += _flySpeedY;
            _flySpeedY -= FlySpeedAccelration;
        }
        else
        {
            NumberLayer.Push(this);
        }
    }
}