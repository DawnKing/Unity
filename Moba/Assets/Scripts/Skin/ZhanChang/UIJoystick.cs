/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ZhanChang
{
	public partial class UIJoystick : GComponent
	{
		public GImage joystick_center;
		public UIJoystickCircle joystick;
		public GTextField txtDegree;

		public const string URL = "ui://rbw1tvvviitt1";

		public static UIJoystick CreateInstance()
		{
			return (UIJoystick)UIPackage.CreateObject("战场","Joystick");
		}

		public UIJoystick()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			joystick_center = (GImage)this.GetChildAt(0);
			joystick = (UIJoystickCircle)this.GetChildAt(1);
			txtDegree = (GTextField)this.GetChildAt(2);
		}
	}
}