/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
	public class UIRegister : GComponent
	{
		public GTextInput TxtAccount;
		public GTextInput TxtPassword;
		public GButton BtnRegister;

		public const string URL = "ui://4ujos3wpef432";

		public static UIRegister CreateInstance()
		{
			return (UIRegister)UIPackage.CreateObject("Login","Register");
		}

		public UIRegister()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			TxtAccount = (GTextInput)this.GetChildAt(1);
			TxtPassword = (GTextInput)this.GetChildAt(2);
			BtnRegister = (GButton)this.GetChildAt(5);
		}
	}
}