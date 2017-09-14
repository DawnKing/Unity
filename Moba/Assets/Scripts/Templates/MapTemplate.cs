// Generated by template.py. DO NOT EDIT!
using System.Collections.Generic;
using System.Xml;

public sealed class MapTemplate
{
	public uint Id;	//id
	public string Res;	//资源路径
}


public sealed class MapTemplateData
{
	public static Dictionary<uint, MapTemplate> Data = new Dictionary<uint, MapTemplate>();

	public static void Init(XmlNode xml)
	{
		foreach (XmlElement element in xml.ChildNodes)
		{
			MapTemplate template = new MapTemplate();
			template.Id = element["Id"] != null ? uint.Parse(element["Id"].InnerText) : 0;	//id
			template.Res = element["Res"] != null ? element["Res"].InnerText : "";	//资源路径

			Data.Add(template.Id, template);
		}
	}

	public static MapTemplate GetData(uint Id, object className)
	{
		if (!Data.ContainsKey(Id) && className != null)
		{
			UnityEngine.Debug.LogError(string.Format("MapTemplate is null, Id = {0} @ {1}", "Id="+Id, className));
			return null;
		}
		MapTemplate template = Data[Id];
		return template;
	}
}