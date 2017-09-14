/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ZhanChang
{
	public partial class UIEntityInfo : GComponent
	{
		public GTextField txtName;
		public GProgressBar hpBar;

		public const string URL = "ui://rbw1tvvvzpcw1e";

		public static UIEntityInfo CreateInstance()
		{
			return (UIEntityInfo)UIPackage.CreateObject("战场","EntityInfo");
		}

		public UIEntityInfo()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			txtName = (GTextField)this.GetChildAt(0);
			hpBar = (GProgressBar)this.GetChildAt(1);
		}
	}
}