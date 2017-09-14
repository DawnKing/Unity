using System;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.Network;
using GameProtocol;
using Server.Manager;

namespace Server
{
    internal class Program
    {
        private static readonly CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();
        private static Task _task;

        private static void Main()
        {
            Log.Inst = new ServerLog();
            NetMessage.Init(true);

            Console.CancelKeyPress += OnCancelKeyPress;

            CancellationToken cancel = CancellationTokenSource.Token;

            _task = ClientManager.Start(cancel);
            EntityManager.Start();
//        PingManager.Start();
            AuthManager.Start();
            DatabaseManager.Start();
            BattleManager.Start();

            Console.ReadKey();
        }

        private static void OnCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Log.Write($"{DateTime.Now:HH:mm:ss} Exit server!", "Main");
            CancellationTokenSource.Cancel();
            _task.Wait();
            ClientManager.Stop();
            Log.Write($"{DateTime.Now:HH:mm:ss} Server has canceled!", "Main");
            Console.ReadKey();
        }
    }
}
