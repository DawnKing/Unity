/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace Battle
{
	public class BattleBinder
	{
		public static void BindAll()
		{
			UIObjectFactory.SetPackageItemExtension(UIJoystick.URL, typeof(UIJoystick));
			UIObjectFactory.SetPackageItemExtension(UIJoystickCircle.URL, typeof(UIJoystickCircle));
			UIObjectFactory.SetPackageItemExtension(UIBattle.URL, typeof(UIBattle));
			UIObjectFactory.SetPackageItemExtension(UIEntityInfo.URL, typeof(UIEntityInfo));
		}
	}
}