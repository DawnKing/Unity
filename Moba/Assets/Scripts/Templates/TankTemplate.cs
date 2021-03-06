// Generated by template.py. DO NOT EDIT!
using System.Collections.Generic;
using System.Xml;

public sealed class TankTemplate
{
	public uint Id;	//id
	public string Res;	//资源路径
}


public sealed class TankTemplateData
{
	public static Dictionary<uint, TankTemplate> Data = new Dictionary<uint, TankTemplate>();

	public static void Init(XmlNode xml)
	{
		foreach (XmlElement element in xml.ChildNodes)
		{
			TankTemplate template = new TankTemplate();
			template.Id = element["Id"] != null ? uint.Parse(element["Id"].InnerText) : 0;	//id
			template.Res = element["Res"] != null ? element["Res"].InnerText : "";	//资源路径

			Data.Add(template.Id, template);
		}
	}

	public static TankTemplate GetData(uint Id, object className)
	{
		if (!Data.ContainsKey(Id) && className != null)
		{
			UnityEngine.Debug.LogError(string.Format("TankTemplate is null, Id = {0} @ {1}", "Id="+Id, className));
			return null;
		}
		TankTemplate template = Data[Id];
		return template;
	}
}