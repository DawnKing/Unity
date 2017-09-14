/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Battle
{
	public class UIEntityInfo : GComponent
	{
		public GTextField txtName;

		public const string URL = "ui://tmnh7azcv38d9";

		public static UIEntityInfo CreateInstance()
		{
			return (UIEntityInfo)UIPackage.CreateObject("Battle","EntityInfo");
		}

		public UIEntityInfo()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			txtName = (GTextField)this.GetChildAt(0);
		}
	}
}