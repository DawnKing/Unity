using GameProtocol.CharMessage;

public sealed class PlayerModel
{
    #region Inst
    private static readonly PlayerModel Instant = new PlayerModel();
    static PlayerModel() { }
    private PlayerModel() { }
    public static PlayerModel Inst { get { return Instant; } }
    #endregion

    public string CharUuid { get; set; }

    private NotifyCharData _playerData;

    internal void InitData(NotifyCharData data)
    {
        _playerData = data;
    }

    public string PlayerName
    {
        get
        {
            return _playerData == null ? "" : _playerData.charData.name;
        }
    }
}
