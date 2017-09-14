using Battle;
using GameCore;

public class BattleWindow : WindowExtend
{
    public UIBattle Frame { get { return contentPane as UIBattle; } }

    protected override void OnShown()
    {
    }
}
