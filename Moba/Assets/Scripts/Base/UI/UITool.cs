using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

public static class UITool
{
    public static void CreateUI(GameObject parent, GComponent ui)
    {
        var container = new Container(parent);
        container.renderMode = RenderMode.WorldSpace;
        container.touchable = false;
        container.touchChildren = false;
//        container.fairyBatching = true;
        container.AddChild(ui.displayObject);
        Stage.inst.AddChild(container);
    }
}
