/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ZhanChang
{
	public partial class UIBattle : GComponent
	{
		public UIJoystick MoveJoystick;
		public UIJoystick AttackJoystick;
		public GButton btnT1;
		public GButton BtnSkill1;

		public const string URL = "ui://rbw1tvvvg6oc1c";

		public static UIBattle CreateInstance()
		{
			return (UIBattle)UIPackage.CreateObject("战场","Battle");
		}

		public UIBattle()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			MoveJoystick = (UIJoystick)this.GetChildAt(0);
			AttackJoystick = (UIJoystick)this.GetChildAt(1);
			btnT1 = (GButton)this.GetChildAt(2);
			BtnSkill1 = (GButton)this.GetChildAt(3);
		}
	}
}