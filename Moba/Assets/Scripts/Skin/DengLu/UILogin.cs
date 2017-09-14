/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace DengLu
{
	public partial class UILogin : GComponent
	{
		public GButton BtnLogin;
		public GButton BtnRegister;
		public GLoader ml1;
		public GButton BtnRemeber;

		public const string URL = "ui://zwnpjpbppbx09";

		public static UILogin CreateInstance()
		{
			return (UILogin)UIPackage.CreateObject("登录","Login");
		}

		public UILogin()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			BtnLogin = (GButton)this.GetChildAt(6);
			BtnRegister = (GButton)this.GetChildAt(7);
			ml1 = (GLoader)this.GetChildAt(14);
			BtnRemeber = (GButton)this.GetChildAt(15);
		}
	}
}