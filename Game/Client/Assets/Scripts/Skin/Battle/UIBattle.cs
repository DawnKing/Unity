/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Battle
{
	public class UIBattle : GComponent
	{
		public UIJoystick MoveJoystick;
		public UIJoystick AttackJoystick;

		public const string URL = "ui://tmnh7azcv38d8";

		public static UIBattle CreateInstance()
		{
			return (UIBattle)UIPackage.CreateObject("Battle","Battle");
		}

		public UIBattle()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			MoveJoystick = (UIJoystick)this.GetChildAt(0);
			AttackJoystick = (UIJoystick)this.GetChildAt(1);
		}
	}
}