/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ZhanChang
{
	public partial class UINumberLayer : GComponent
	{
		public GTextField redNum;
		public GTextField greenNum;
		public GTextField yellowNum;
		public GTextField purpleNum;
		public GTextField bigNum;

		public const string URL = "ui://rbw1tvvvdg3e5e";

		public static UINumberLayer CreateInstance()
		{
			return (UINumberLayer)UIPackage.CreateObject("战场","NumberLayer");
		}

		public UINumberLayer()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			redNum = (GTextField)this.GetChildAt(0);
			greenNum = (GTextField)this.GetChildAt(1);
			yellowNum = (GTextField)this.GetChildAt(2);
			purpleNum = (GTextField)this.GetChildAt(3);
			bigNum = (GTextField)this.GetChildAt(4);
		}
	}
}