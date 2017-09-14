/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace PiPei
{
	public partial class UIMatch : GComponent
	{
		public Controller c1;
		public GButton BtnMatch;

		public const string URL = "ui://u293sllssylr1";

		public static UIMatch CreateInstance()
		{
			return (UIMatch)UIPackage.CreateObject("匹配","Match");
		}

		public UIMatch()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			c1 = this.GetControllerAt(0);
			BtnMatch = (GButton)this.GetChildAt(1);
		}
	}
}