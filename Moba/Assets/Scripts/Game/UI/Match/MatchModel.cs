
public sealed class MatchModel
{
    #region Inst
    private static readonly MatchModel Instant = new MatchModel();
    static MatchModel() { }
    private MatchModel() { }
    public static MatchModel Inst { get { return Instant; } }
    #endregion

    public static bool IsMatch = false;
    public uint SceneId;
}
