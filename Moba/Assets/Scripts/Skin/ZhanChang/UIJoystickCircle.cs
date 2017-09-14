/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ZhanChang
{
	public partial class UIJoystickCircle : GButton
	{
		public GImage thumb;

		public const string URL = "ui://rbw1tvvvq9do18";

		public static UIJoystickCircle CreateInstance()
		{
			return (UIJoystickCircle)UIPackage.CreateObject("战场","JoystickCircle");
		}

		public UIJoystickCircle()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			thumb = (GImage)this.GetChildAt(0);
		}
	}
}