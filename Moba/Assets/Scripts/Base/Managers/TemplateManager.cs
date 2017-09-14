using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public sealed class TemplateManager
{
    private readonly object _list;

    public TemplateManager(object list)
    {
        _list = list;
    }

    public void LoadXml(string path)
    {
        List<string> xmlNameList = _list.GetType().GetField("XMLList").GetValue(_list) as List<string>;
        List<Action<XmlNode>> funcList = _list.GetType().GetField("FunctionList").GetValue(_list) as List<Action<XmlNode>>;

        if (xmlNameList == null || funcList == null)
            return;

        if (Core.Editor)
        {
            for (int i = 0; i < xmlNameList.Count; i++)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(path + xmlNameList[i]);

                XmlNode xml = xmlDoc.LastChild.FirstChild.FirstChild;
                funcList[i](xml);
            }
            return;
        }

        var url = Path.Combine(GamePath.Release, path).TrimEnd("/".ToCharArray());
        var assetBundle = AssetBundle.LoadFromFile(url);
        if (assetBundle == null)
        {
            Debug.LogError("没有xml bundle");
            return;
        }

        for (int i = 0; i < xmlNameList.Count; i++)
        {
            var txt = assetBundle.LoadAsset<TextAsset>(xmlNameList[i]);
            if (txt == null)
            {
                Debug.LogWarning("没有" + xmlNameList[i]);
                continue;
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(txt.text);

            XmlNode xml = xmlDoc.LastChild.FirstChild.FirstChild;
            funcList[i](xml);
        }
    }
}