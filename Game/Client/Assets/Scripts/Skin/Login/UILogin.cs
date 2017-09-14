/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
	public class UILogin : GComponent
	{
		public GButton BtnLogin;
		public GTextInput TxtAccount;
		public GTextInput TxtPassword;
		public GButton BtnRegister;

		public const string URL = "ui://4ujos3wpef430";

		public static UILogin CreateInstance()
		{
			return (UILogin)UIPackage.CreateObject("Login","Login");
		}

		public UILogin()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			BtnLogin = (GButton)this.GetChildAt(1);
			TxtAccount = (GTextInput)this.GetChildAt(2);
			TxtPassword = (GTextInput)this.GetChildAt(3);
			BtnRegister = (GButton)this.GetChildAt(6);
		}
	}
}