using Common.Network;
using GameProtocol;

namespace Server.Manager
{
    public static class BattleManager
    {
        public static void Start()
        {
            NetMessage.AddListener(MessageType.RequestBattle, OnRequestBattle);
        }

        private static void OnRequestBattle(ProtocolMessage message, uint id)
        {
            EntityManager.AddClient(id);
        }
    }
}