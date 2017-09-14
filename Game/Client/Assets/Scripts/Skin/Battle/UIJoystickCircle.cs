/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Battle
{
	public class UIJoystickCircle : GButton
	{
		public GImage thumb;

		public const string URL = "ui://tmnh7azcv38d6";

		public static UIJoystickCircle CreateInstance()
		{
			return (UIJoystickCircle)UIPackage.CreateObject("Battle","JoystickCircle");
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