/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Battle
{
	public class UIJoystick : GComponent
	{
		public GImage joystick_center;
		public UIJoystickCircle joystick;
		public GTextField txtDegree;

		public const string URL = "ui://tmnh7azcv38d5";

		public static UIJoystick CreateInstance()
		{
			return (UIJoystick)UIPackage.CreateObject("Battle","Joystick");
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